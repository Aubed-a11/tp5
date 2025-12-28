import pandas as pd 
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.preprocessing import LabelEncoder, StandardScaler
from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score, confusion_matrix, recall_score
from sklearn.metrics import roc_curve, auc

#Regression Linéaire

df=pd.read_csv('insurance.csv')   
df.head() #Affiche les 05 premières lignes
print(df.shape) #dimension du dataset
print(df.dtypes) #types de données du dataset 

plt.figure(figsize=(6,7))
plt.scatter(df['age'],df['charges'])
plt.xlabel("Age")
plt.ylabel("Charges")
plt.title("Graphiques")
plt.show()

#Coefficient de correlation de pearson
correlation= df['age'].corr(df['age'])
print(correlation)
#Partie b

def calcul_coefficients(x, y):
    x_mean=np.mean(x)
    y_mean=np.mean(y)
    
    num=np.sum((x-x_mean) * (y-y_mean))
    den=np.sum((x-x_mean) ** 2)

    beta_1= num/den
    beta_0= y_mean - beta_1 * x_mean

    return beta_0,beta_1

#calcul des coefficients réesl
beta_0,beta_1= calcul_coefficients(df['age'].values,df['charges'].values)
print(beta_0,beta_1)

#calcul des prédictions
y_pred=beta_0+beta_1 * df['age'].values
y_pred[:10]

#Partie C:Evaluation du modéle
 
def mse(y_pred,y):
    return np.mean((y-y_pred)**2)
def determination(y_pred,y):
    ss=np.sum((y-y_pred) ** 2)
    ss_totaux=np.sum((y-np.mean(y-y_pred))**2)
    return 1-(ss/ss_totaux)

MSE=mse(df['age'],df['charges'])
R_au_carre=determination(df['age'],df['charges'])

print(MSE,R_au_carre)


#partie 2

le = LabelEncoder()
df['smoker_encoded'] = le.fit_transform(df['smoker'])  

df = pd.get_dummies(df, columns=['region'], drop_first=True)


plt.figure(figsize=(10,6))
sns.heatmap(df.corr(), annot=True, cmap='coolwarm')
plt.title("Heatmap de corrélation")
plt.show()


features = ['age', 'bmi', 'children', 'smoker_encoded']
X = df[features]
y = df['charges']

scaler = StandardScaler()
X_scaled = scaler.fit_transform(X)


X_with_intercept = np.c_[np.ones(X_scaled.shape[0]), X_scaled]

beta_hat = np.linalg.inv(X_with_intercept.T @ X_with_intercept) @ (X_with_intercept.T @ y)
print("Coefficients OLS (matrice) :", beta_hat)


model = LinearRegression()
model.fit(X_scaled, y)

print("Intercept Scikit-Learn :", model.intercept_)
print("Coefficients Scikit-Learn :", model.coef_)



X_train, X_test, y_train, y_test = train_test_split(
    X_scaled, y, test_size=0.2, random_state=42
)

model = LinearRegression()
model.fit(X_train, y_train)

print("Coefficients par feature :")
for f, c in zip(features, model.coef_):
    print(f"{f} = {c}")

print("Impact du statut fumeur :", model.coef_[features.index('smoker_encoded')])



y_pred = model.predict(X_test)
residuals = y_test - y_pred

plt.scatter(y_pred, residuals)
plt.axhline(0, color='red')
plt.xlabel("Prédictions")
plt.ylabel("Résidus")
plt.title("Graphique des résidus")
plt.show()



df_heart = pd.read_csv("heart.csv")

print("Répartition des classes :")
print(df_heart['target'].value_counts())

features = ['cp', 'thalach', 'exang', 'oldpeak', 'age']
X = df_heart[features]
y = df_heart['target']



X_train, X_test, y_train, y_test = train_test_split(
    X, y, test_size=0.20, stratify=y, random_state=42
)

model_log = LogisticRegression(max_iter=1000)
model_log.fit(X_train, y_train)

probs = model_log.predict_proba(X_test)[:, 1]
preds = model_log.predict(X_test)



acc = accuracy_score(y_test, preds)
rec = recall_score(y_test, preds)
mat = confusion_matrix(y_test, preds)

print("Accuracy :", acc)
print("Recall :", rec)
print("Matrice de confusion :\n", mat)

#  Courbe
fpr, tpr, _ = roc_curve(y_test, probs)
roc_auc = auc(fpr, tpr)

plt.plot(fpr, tpr)
plt.xlabel("Taux Faux Positifs (FPR)")
plt.ylabel("Taux Vrais Positifs (TPR)")
plt.title(f"Courbe  — AUC = {roc_auc:.3f}")
plt.show()
plt.close()

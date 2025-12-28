import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.preprocessing import StandardScaler
from sklearn.model_selection import train_test_split
from sklearn.neighbors import KNeighborsClassifier
from sklearn.metrics import confusion_matrix, ConfusionMatrixDisplay
from sklearn.preprocessing import LabelEncoder
from sklearn.tree import DecisionTreeClassifier,plot_tree



df = pd.read_csv("train.csv")  #chargement du fichier 

# afficher les lignes 
print(df.head())
print(df.info())

X = df.drop(columns=['price_range'])
y = df['price_range'] #prédiction de la variable price_range(reste toujours en Y)

scaler = StandardScaler()  #standardisation avant division en train_set pour éviter les fuites de données
X_scaled = scaler.fit_transform(X)

# Division en train/test
X_train, X_test, y_train, y_test = train_test_split(
    X_scaled, y, test_size=0.2, random_state=42
)


scores = []
k_range = range(1, 21)  # on teste K de 1 à 20 pour voir quelle valeur maximise la production(autrement la meilleure mise à échelle des données)
for k in k_range:
    knn = KNeighborsClassifier(n_neighbors=k)
    knn.fit(X_train, y_train) 
    score = knn.score(X_test, y_test)
    scores.append(score)

plt.figure(figsize=(8,5))
plt.plot(k_range, scores, marker='o', color='red') #ce qu'on veut visualiser
plt.xlabel('Valeur de K')
plt.ylabel('Accuracy')
plt.title('Recherche du meilleur K')
plt.grid(True)
plt.show()

best_k = k_range[np.argmax(scores)]
print("Meilleur K =",best_k, "Accuracy = {max(scores):.4f}")

knn_final = KNeighborsClassifier(n_neighbors=best_k)
knn_final.fit(X_train, y_train)
y_pred = knn_final.predict(X_test)

cm = confusion_matrix(y_test, y_pred)
disp = ConfusionMatrixDisplay(confusion_matrix=cm,
                              display_labels=knn_final.classes_)
disp.plot(cmap=plt.cm.Reds)
plt.title("Matrice de Confusion KNN")
plt.show()

errors = cm.copy()
np.fill_diagonal(errors, 0)
print("Erreurs hors diagonale (confusions) :")
print(errors)

print("Conclusion :")
print("Si la plupart des confusions sont entre classes voisines (0-1, 1-2, 2-3), ce sont des erreurs acceptables.")
print("Si on voit des confusions entre 0 et 3, ce sont des erreurs graves.")


df = pd.read_csv("WA_Fn-UseC_-Telco-Customer-Churn.csv")
le = LabelEncoder()
df["gender"] = le.fit_transform(df["gender"])

print(df.head())
df['TotalCharges'] = pd.to_numeric(df['TotalCharges'], errors='coerce')
df['TotalCharges'] = df['TotalCharges'].fillna(0)
le = LabelEncoder()
df['Churn'] = le.fit_transform(df['Churn'])  
df.drop('customerID', axis=1, inplace=True)
df_encoded = pd.get_dummies(df, drop_first=True)
X = df_encoded.drop('Churn', axis=1)
y = df_encoded['Churn']
X_train, X_test, y_train, y_test = train_test_split(
    X, y, test_size=0.2, random_state=42
)
modele_arbre = DecisionTreeClassifier(
    max_depth=3,
    criterion='gini',
    random_state=42
)

modele_arbre.fit(X_train, y_train)
plt.figure(figsize=(20,10))
plot_tree(
    modele_arbre,
    feature_names=X.columns,
    class_names=['Stay', 'Churn'],
    filled=True,
    rounded=True,
    fontsize=10
)
plt.show()

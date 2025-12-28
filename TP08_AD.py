import numpy as np
import pandas as pd
import matplotlib.pyplot as plt


N = np.array([
    [20, 15, 25],
    [10, 30, 10],
    [15, 5, 20]
])

df = pd.DataFrame(N, index=["L1", "L2", "L3"], columns=["C1", "C2", "C3"])

n = N.sum()
P = N / n

r = P.sum(axis=1)
c = P.sum(axis=0)

Dr_inv_sqrt = np.diag(1 / np.sqrt(r))
Dc_inv_sqrt = np.diag(1 / np.sqrt(c))

print("Matrice P:\n", P)
print("\nMasses lignes r:\n", r)
print("\nMasses colonnes c:\n", c)

rc = np.outer(r, c)

Z = Dr_inv_sqrt @ (P - rc) @ Dc_inv_sqrt

print("\nMatrice standardisée Z:\n", Z)
U, sigma, VT = np.linalg.svd(Z, full_matrices=False)

print("\nValeurs singulières σ_k:\n", sigma)
print("\nValeurs propres λ_k = σ_k²:\n", sigma**2)
F = Dr_inv_sqrt @ U @ np.diag(sigma)

F_df = pd.DataFrame(F, index=df.index,
                    columns=[f"Axe {k+1}" for k in range(F.shape[1])])

print("\nCoordonnées factorielles des lignes:\n", F_df)
for k in range(len(sigma)):
    inertia_k = np.sum(r * F[:, k]**2)
    print(f"Inertie axe {k+1} : {inertia_k:.6f} (σ² = {sigma[k]**2:.6f})")
plt.figure(figsize=(7, 6))
plt.scatter(F[:, 0], F[:, 1])

for i, txt in enumerate(df.index):
    plt.text(F[i, 0], F[i, 1], txt)

plt.axhline(0)
plt.axvline(0)
plt.xlabel("Axe 1 (σ₁)")
plt.ylabel("Axe 2 (σ₂)")
plt.title("Nuage des lignes – Étirement contrôlé par σ")
plt.grid()
plt.show()
print("Rapport des étirements σ1 / σ2 :", sigma[0] / sigma[1])

P_indep = rc.copy()
Z_zero = Dr_inv_sqrt @ (P_indep - rc) @ Dc_inv_sqrt

U0, sigma0, V0 = np.linalg.svd(Z_zero, full_matrices=False)

print("\nValeurs singulières (indépendance):\n", sigma0)

X = np.random.randn(100, 3)
Xc = X - X.mean(axis=0)

cov = np.cov(Xc, rowvar=False)
eigvals, eigvecs = np.linalg.eig(cov)

print("\nACP - valeurs propres:\n", eigvals)
print("Racines (étirements):\n", np.sqrt(eigvals))


data = pd.DataFrame({
    "A": [20, 10, 5],
    "B": [15, 25, 10],
    "C": [25, 15, 20],
    "D": [10, 20, 10]
}, index=["Jeune", "Adulte", "Senior"])


n = data.values.sum()
row_totals = data.sum(axis=1)
col_totals = data.sum(axis=0)

print("Totaux lignes:\n", row_totals)
print("\nTotaux colonnes:\n", col_totals)
print("\nTotal général:", n)


row_profiles = data.div(row_totals, axis=0)
print("\nProfils lignes:\n", row_profiles)


p_j = col_totals / n


def chi2_distance(profile1, profile2, p_j):
    return np.sum((profile1 - profile2)**2 / p_j)

clients = row_profiles.index
for i in range(len(clients)):
    for j in range(i+1, len(clients)):
        d = chi2_distance(row_profiles.iloc[i], row_profiles.iloc[j], p_j)
        print(f"d²({clients[i]}, {clients[j]}) = {d:.4f}")


data = pd.DataFrame({
    "Action": [30, 25, 10, 5],
    "Comedie": [20, 30, 20, 10],
    "Drame": [10, 20, 25, 20],
    "Documentaire": [5, 10, 15, 25],
    "SF": [15, 15, 10, 5]
}, index=["18-25", "26-35", "36-50", "51+"])

n = data.values.sum()
P = data / n

r = P.sum(axis=1).values      
c = P.sum(axis=0).values     

Dr_inv_sqrt = np.diag(1 / np.sqrt(r))
Dc_inv_sqrt = np.diag(1 / np.sqrt(c))


rc = np.outer(r, c)

Z = Dr_inv_sqrt @ (P.values - rc) @ Dc_inv_sqrt

U, sigma, VT = np.linalg.svd(Z, full_matrices=False)

print("Valeurs singulières:\n", sigma)
print("\nValeurs propres (inerties):\n", sigma**2)

F = Dr_inv_sqrt @ U @ np.diag(sigma)
F_df = pd.DataFrame(F[:, :2], index=data.index, columns=["Axe 1", "Axe 2"])
print("\nCoordonnées factorielles lignes:\n", F_df)

G = Dc_inv_sqrt @ VT.T @ np.diag(sigma)
G_df = pd.DataFrame(G[:, :2], index=data.columns, columns=["Axe 1", "Axe 2"])
print("\nCoordonnées factorielles colonnes:\n", G_df)

plt.figure(figsize=(8, 8))

plt.scatter(F_df["Axe 1"], F_df["Axe 2"], marker="o")
for i, txt in enumerate(F_df.index):
    plt.text(F_df.iloc[i, 0], F_df.iloc[i, 1], txt)


plt.scatter(G_df["Axe 1"], G_df["Axe 2"], marker="s")
for i, txt in enumerate(G_df.index):
    plt.text(G_df.iloc[i, 0], G_df.iloc[i, 1], txt)

plt.axhline(0)
plt.axvline(0)
plt.xlabel("Axe 1")
plt.ylabel("Axe 2")
plt.title("Plan factoriel AFC (Axe 1 vs Axe 2)")
plt.grid()
plt.show()


X = np.array([
    [10, 20, 30],
    [20, 15, 25],
    [30, 25, 20]
])

df = pd.DataFrame(X, index=["X", "Y", "Z"], columns=["A", "B", "C"])

n = X.sum()

P = X / n

P_df = pd.DataFrame(P, index=df.index, columns=df.columns)

print("Tableau X :\n", df)
print("\nTotal général n =", n)
print("\nMatrice de fréquences P :\n", P_df)


r = P.sum(axis=1)


c = P.sum(axis=0)

r_df = pd.Series(r, index=df.index, name="r")
c_df = pd.Series(c, index=df.columns, name="c")

print("\nMarges lignes r :\n", r_df)
print("\nMarges colonnes c :\n", c_df)


Dr_inv_sqrt = np.diag(1 / np.sqrt(r))
Dc_inv_sqrt = np.diag(1 / np.sqrt(c))


rc = np.outer(r, c)


Z = Dr_inv_sqrt @ (P - rc) @ Dc_inv_sqrt

Z_df = pd.DataFrame(Z, index=df.index, columns=df.columns)

print("\nMatrice standardisée Z :\n", Z_df)

import numpy as np

def print_section(title):
    print("\n" + "="*60)
    print(title)
    print("="*60)
print_section("EXERCICE 1")

N1 = np.array([[40, 60],
               [30, 70]])

total1 = N1.sum()

# matrice des fréquences
P1 = N1 / total1

# masses
r1 = P1.sum(axis=1)
c1 = P1.sum(axis=0)

# matrice théorique
N0_1 = np.outer(r1, c1) * total1

# résidus
R1 = N1 - N0_1

print("Matrice des fréquences P\n", P1)
print("Masses lignes r =", r1)
print("Masses colonnes c =", c1)
print("Matrice d'indépendance N0\n", N0_1)
print("Matrice des résidus R\n", R1)


print_section("EXERCICE 2")

N2 = np.array([[25, 35, 40],
               [30, 30, 40]])

total2 = N2.sum()

P2 = N2 / total2
r2 = P2.sum(axis=1)
c2 = P2.sum(axis=0)

N0_2 = np.outer(r2, c2) * total2
R2 = N2 - N0_2

# Distance khi2 L1-L2
f1_2 = N2[0] / N2[0].sum()
f2_2 = N2[1] / N2[1].sum()
d12_2 = ((f1_2 - f2_2)**2 / c2).sum()

print("Matrice des fréquences P\n", P2)
print("Masses lignes r =", r2)
print("Masses colonnes c =", c2)
print("Matrice d'indépendance N0\n", N0_2)
print("Matrice des résidus R\n", R2)
print("Distance Khi2 entre L1 et L2 =", d12_2)

print_section("EXERCICE 3")

N3 = np.array([[20, 30, 50],
               [30, 20, 50],
               [50, 50, 100]])

total3 = N3.sum()
P3 = N3 / total3  # matrice des fréquences

# masses lignes et colonnes
r3 = P3.sum(axis=1)
c3 = P3.sum(axis=0)

# matrice théorique d'indépendance
N0_3 = np.outer(r3, c3) * total3

# résidus
R3 = N3 - N0_3

# distance chi2 entre L1 et L2
f1 = N3[0] / N3[0].sum()
f2 = N3[1] / N3[1].sum()
d12 = ((f1 - f2)**2 / c3).sum()

print("Matrice des fréquences P\n", P3)
print("Masses lignes r =", r3)
print("Masses colonnes c =", c3)
print("Matrice d'indépendance N0\n", N0_3)
print("Matrice des résidus R\n", R3)
print("Distance Khi2 entre L1 et L2 =", d12)

print_section("EXERCICE 4")

N4 = np.array([[10, 5, 5],
               [5, 10, 5]])

total4 = N4.sum()
P4 = N4 / total4
r4 = P4.sum(axis=1)
c4 = P4.sum(axis=0)

print("Matrice des fréquences P\n", P4)
print("Masses lignes r =", r4)
print("Masses colonnes c =", c4)

print_section("EXERCICE 5")

N5 = np.array([[20, 15, 10, 5],
               [15, 20, 10, 5],
               [10, 10, 20, 10]])

total5 = N5.sum()

# Profils lignes
F5 = N5 / N5.sum(axis=1, keepdims=True)

# masses colonnes
c5 = N5.sum(axis=0) / total5

# distances Khi2 entre profils
d12_5 = ((F5[0] - F5[1])**2 / c5).sum()
d13_5 = ((F5[0] - F5[2])**2 / c5).sum()
d23_5 = ((F5[1] - F5[2])**2 / c5).sum()

#for i,j in combinations(range(N.shape[0]),2):
    #d2=np.sum

print("Profils lignes F\n", F5)
print("Masses colonnes c =", c5)
print("Distance L1-L2 =", d12_5)
print("Distance L1-L3 =", d13_5)
print("Distance L2-L3 =", d23_5)

print_section("EXERCICE 6")

N6 = np.array([[20, 10, 20],
               [10, 30, 10],
               [20, 20, 10]])

total6 = N6.sum()

# profils lignes
F6 = N6 / N6.sum(axis=1, keepdims=True)

# masses colonnes
c6 = N6.sum(axis=0) / total6

# distances khi2
d12_6 = ((F6[0] - F6[1])**2 / c6).sum()
d13_6 = ((F6[0] - F6[2])**2 / c6).sum()

print("Profils lignes F\n", F6)
print("Masses colonnes c =", c6)
print("Distance L1-L2 =", d12_6)
print("Distance L1-L3 =", d13_6)

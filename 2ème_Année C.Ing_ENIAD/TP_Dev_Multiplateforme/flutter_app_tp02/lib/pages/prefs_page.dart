import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';

class PrefsPage extends StatefulWidget {
  const PrefsPage({super.key});

  @override
  State<PrefsPage> createState() => _PrefsPageState();
}

class _PrefsPageState extends State<PrefsPage> {
  final TextEditingController nameController = TextEditingController();

  bool darkMode = false;
  int cartCount = 0;
  bool loaded = false;

  @override
  void initState() {
    super.initState();
    loadPrefs();
  }

  // 🔹 Charger les préférences sauvegardées
  Future<void> loadPrefs() async {
    final prefs = await SharedPreferences.getInstance();

    setState(() {
      nameController.text = prefs.getString("username") ?? "";
      darkMode = prefs.getBool("darkmode") ?? false;
      cartCount = prefs.getInt("cart") ?? 0;
      loaded = true;
    });
  }

  // 🔹 Sauvegarder les préférences
  Future<void> savePrefs() async {
    final prefs = await SharedPreferences.getInstance();

    await prefs.setString("username", nameController.text);
    await prefs.setBool("darkmode", darkMode);
    await prefs.setInt("cart", cartCount);

    ScaffoldMessenger.of(context).showSnackBar(
      const SnackBar(content: Text("Préférences sauvegardées ✅")),
    );
  }

  @override
  Widget build(BuildContext context) {
    if (!loaded) {
      return const Scaffold(
        body: Center(child: CircularProgressIndicator()),
      );
    }

    return Scaffold(
      appBar: AppBar(
        title: const Text("Préférences"),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: ListView(
          children: [
            // ---- NOM UTILISATEUR ----
            const Text(
              "Nom de l'utilisateur",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 5),
            TextField(
              controller: nameController,
              decoration: const InputDecoration(
                hintText: "Entrez votre nom",
                border: OutlineInputBorder(),
              ),
            ),

            const SizedBox(height: 20),

            // ---- MODE SOMBRE ----
            SwitchListTile(
              title: const Text("Mode sombre"),
              subtitle: const Text("Visuel uniquement"),
              value: darkMode,
              onChanged: (value) {
                setState(() => darkMode = value);
              },
              secondary: const Icon(Icons.dark_mode),
            ),

            const Divider(),

            // ---- NOMBRE D'ARTICLES PANIER ----
            const Text(
              "Nombre d'articles dans le panier",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 10),
            Row(
              children: [
                IconButton(
                  icon: const Icon(Icons.remove),
                  onPressed: () {
                    if (cartCount > 0) {
                      setState(() => cartCount--);
                    }
                  },
                ),
                Text(
                  cartCount.toString(),
                  style: const TextStyle(fontSize: 20),
                ),
                IconButton(
                  icon: const Icon(Icons.add),
                  onPressed: () {
                    setState(() => cartCount++);
                  },
                ),
              ],
            ),

            const SizedBox(height: 30),

            // ---- BOUTON SAUVEGARDER ----
            ElevatedButton.icon(
              icon: const Icon(Icons.save),
              label: const Text("Sauvegarder les préférences"),
              onPressed: savePrefs,
              style: ElevatedButton.styleFrom(
                padding: const EdgeInsets.all(15),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

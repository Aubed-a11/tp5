import 'package:flutter/material.dart';

class SettingsPage extends StatefulWidget {
  const SettingsPage({super.key});

  @override
  State<SettingsPage> createState() => _SettingsPageState();
}

class _SettingsPageState extends State<SettingsPage> {
  bool darkMode = false;
  double textSize = 16;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Paramètres"),
      ),
      body: ListView(
        children: [
          // ---- MODE SOMBRE ----
          SwitchListTile(
            title: const Text("Mode sombre"),
            subtitle: const Text("Activer le thème sombre (visuel)"),
            value: darkMode,
            onChanged: (value) {
              setState(() {
                darkMode = value;
              });
            },
            secondary: const Icon(Icons.dark_mode),
          ),

          const Divider(),

          // ---- SLIDER ----
          ListTile(
            title: const Text("Taille du texte"),
            subtitle: Slider(
              min: 12,
              max: 30,
              divisions: 9,
              value: textSize,
              label: textSize.toInt().toString(),
              onChanged: (value) {
                setState(() {
                  textSize = value;
                });
              },
            ),
            trailing: Text(
              "${textSize.toInt()} px",
              style: const TextStyle(fontWeight: FontWeight.bold),
            ),
          ),

          const Divider(),

          // ---- AUTRES OPTIONS ----
          ListTile(
            leading: const Icon(Icons.info),
            title: const Text("À propos"),
            subtitle: const Text("Application SmartShop"),
            onTap: () {
              showAboutDialog(
                context: context,
                applicationName: "SmartShop",
                applicationVersion: "1.0.0",
                children: const [
                  Text("Projet Flutter – Développement Mobile"),
                ],
              );
            },
          ),

          ListTile(
            leading: const Icon(Icons.logout),
            title: const Text("Déconnexion"),
            onTap: () {
              ScaffoldMessenger.of(context).showSnackBar(
                const SnackBar(content: Text("Déconnexion simulée")),
              );
            },
          ),
        ],
      ),
    );
  }
}

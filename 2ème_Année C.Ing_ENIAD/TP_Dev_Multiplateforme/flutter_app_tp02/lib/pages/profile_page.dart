import 'package:flutter/material.dart';
import '../services/log.dart';

class ProfilePage extends StatelessWidget {
  const ProfilePage({super.key});

  @override
  Widget build(BuildContext context) {
    Log.actions.add("Ouverture page Profil");

    return Scaffold(
      appBar: AppBar(title: const Text("Mon Profil")),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          children: [
            const CircleAvatar(
              radius: 50,
              backgroundImage: AssetImage("assets/logo.png"),
            ),
            const SizedBox(height: 10),
            const Text("HORTICE ADOGNIBO",
                style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
            const Text("GINF2 / IA2 / ROC2"),
            const Divider(),
            const ListTile(
              leading: Icon(Icons.email),
              title: Text("hortice@email.com"),
            ),
            const ListTile(
              leading: Icon(Icons.phone),
              title: Text("+212 6 00 00 00 00"),
            ),
            const ListTile(
              leading: Icon(Icons.location_city),
              title: Text("Casablanca"),
            ),
            const SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {},
              child: const Text("Modifier mes informations"),
            ),
          ],
        ),
      ),
    );
  }
}

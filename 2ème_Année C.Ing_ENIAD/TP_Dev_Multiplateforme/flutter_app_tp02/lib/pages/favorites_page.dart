import 'package:flutter/material.dart';

class FavoritesPage extends StatefulWidget {
  const FavoritesPage({super.key});

  @override
  State<FavoritesPage> createState() => _FavoritesPageState();
}

class _FavoritesPageState extends State<FavoritesPage> {
  // Liste simulée des favoris
  List<Map<String, String>> favorites = [
    {
      "name": "Smartphone Android Pro",
      "price": "2999 DH",
      "image": "assets/products/phone.png"
    },
    {
      "name": "Laptop Gamer",
      "price": "7999 DH",
      "image": "assets/products/laptop.png"
    },
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Mes Favoris"),
      ),
      body: favorites.isEmpty
          ? const Center(child: Text("Aucun favori pour le moment"))
          : ListView.separated(
              itemCount: favorites.length,
              separatorBuilder: (_, __) => const Divider(),
              itemBuilder: (context, index) {
                final fav = favorites[index];
                return ListTile(
                  leading: Image.asset(
                    fav["image"]!,
                    width: 50,
                  ),
                  title: Text(fav["name"]!),
                  subtitle: Text(fav["price"]!),
                  trailing: IconButton(
                    icon: const Icon(Icons.delete, color: Colors.red),
                    onPressed: () {
                      setState(() {
                        favorites.removeAt(index);
                      });
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(
                          content: Text("Produit retiré des favoris"),
                        ),
                      );
                    },
                  ),
                );
              },
            ),
    );
  }
}

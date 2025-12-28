import 'package:flutter/material.dart';
import '../services/json_service.dart';
import '../widgets/product_card.dart';
import '../models/product.dart';
import 'product_page.dart';
import 'search_page.dart';
import 'favorites_page.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("SmartShop"),
        actions: [
          IconButton(
            icon: const Icon(Icons.search),
            onPressed: () => Navigator.push(context,
              MaterialPageRoute(builder: (_) => const SearchPage())),
          ),
          IconButton(
            icon: const Icon(Icons.favorite),
            onPressed: () => Navigator.push(context,
              MaterialPageRoute(builder: (_) => const FavoritesPage())),
          ),
        ],
      ),
      body: FutureBuilder<List<Product>>(
        future: JsonService.loadProducts(),
        builder: (context, snapshot) {
          if (!snapshot.hasData) {
            return const Center(child: CircularProgressIndicator());
          }
          final products = snapshot.data!;
          return GridView.count(
            crossAxisCount: 2,
            padding: const EdgeInsets.all(10),
            children: products.map((p) {
              return ProductCard(
                product: p,
                onTap: () {
                  Navigator.push(context,
                    MaterialPageRoute(
                      builder: (_) => ProductPage(product: p),
                    ),
                  );
                },
              );
            }).toList(),
          );
        },
      ),
    );
  }
}

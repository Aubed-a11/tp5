import 'package:flutter/material.dart';
import '../models/product.dart';

class ProductCard extends StatelessWidget {
  final Product product;
  final VoidCallback onTap;

  const ProductCard({super.key, required this.product, required this.onTap});

  @override
  Widget build(BuildContext context) {
    return Card(
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(15)),
      child: Column(
        children: [
          Expanded(child: Image.asset(product.image)),
          Text(product.name, style: const TextStyle(fontWeight: FontWeight.bold)),
          Text(product.price),
          ElevatedButton(onPressed: onTap, child: const Text("Détails"))
        ],
      ),
    );
  }
}

import 'package:flutter/material.dart';
import '../models/product.dart';
import '../services/log.dart';

class ProductPage extends StatefulWidget {
  final Product product;
  const ProductPage({super.key, required this.product});

  @override
  State<ProductPage> createState() => _ProductPageState();
}

class _ProductPageState extends State<ProductPage> {
  bool added = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Détails du produit")),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          children: [
            Image.asset(widget.product.image, height: 200),
            const SizedBox(height: 20),
            Text(widget.product.name, style: const TextStyle(fontSize: 22)),
            Text(widget.product.price),
            Text(widget.product.desc),
            const Spacer(),
            ElevatedButton.icon(
              icon: Icon(added ? Icons.check : Icons.add_shopping_cart),
              label: Text(added ? "Retirer du panier" : "Ajouter au panier"),
              onPressed: () {
                setState(() => added = !added);
                Log.actions.add("Produit ${widget.product.name} ajouté");
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(content: Text(added
                      ? "Ajouté au panier"
                      : "Retiré du panier")),
                );
              },
            )
          ],
        ),
      ),
    );
  }
}

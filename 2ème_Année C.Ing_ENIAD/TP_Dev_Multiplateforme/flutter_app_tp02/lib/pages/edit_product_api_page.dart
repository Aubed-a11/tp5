import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class EditProductApiPage extends StatefulWidget {
  final Map product;

  const EditProductApiPage({super.key, required this.product});

  @override
  State<EditProductApiPage> createState() => _EditProductApiPageState();
}

class _EditProductApiPageState extends State<EditProductApiPage> {
  final _formKey = GlobalKey<FormState>();

  late TextEditingController titleController;
  late TextEditingController priceController;
  late TextEditingController descriptionController;
  late TextEditingController imageController;

  bool isLoading = false;

  @override
  void initState() {
    super.initState();

    titleController =
        TextEditingController(text: widget.product['title']);
    priceController =
        TextEditingController(text: widget.product['price'].toString());
    descriptionController =
        TextEditingController(text: widget.product['description']);
    imageController =
        TextEditingController(text: widget.product['image']);
  }

  // 🔹 Mise à jour du produit (PUT)
  Future<void> updateProduct() async {
    setState(() => isLoading = true);

    final productId = widget.product['id'];
    final url = Uri.parse('https://fakestoreapi.com/products/$productId');

    final response = await http.put(
      url,
      headers: {"Content-Type": "application/json"},
      body: jsonEncode({
        "title": titleController.text,
        "price": double.parse(priceController.text),
        "description": descriptionController.text,
        "image": imageController.text,
        "category": widget.product['category'],
      }),
    );

    setState(() => isLoading = false);

    if (response.statusCode == 200) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text("Produit modifié avec succès ✅")),
      );

      Navigator.pop(context, true); // succès
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text("Erreur de modification ❌")),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Modifier le produit"),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Form(
          key: _formKey,
          child: ListView(
            children: [
              // ---- TITRE ----
              TextFormField(
                controller: titleController,
                decoration: const InputDecoration(
                  labelText: "Titre",
                  border: OutlineInputBorder(),
                ),
                validator: (value) =>
                    value!.isEmpty ? "Champ obligatoire" : null,
              ),

              const SizedBox(height: 15),

              // ---- PRIX ----
              TextFormField(
                controller: priceController,
                keyboardType: TextInputType.number,
                decoration: const InputDecoration(
                  labelText: "Prix",
                  border: OutlineInputBorder(),
                ),
                validator: (value) =>
                    value!.isEmpty ? "Champ obligatoire" : null,
              ),

              const SizedBox(height: 15),

              // ---- DESCRIPTION ----
              TextFormField(
                controller: descriptionController,
                maxLines: 3,
                decoration: const InputDecoration(
                  labelText: "Description",
                  border: OutlineInputBorder(),
                ),
                validator: (value) =>
                    value!.isEmpty ? "Champ obligatoire" : null,
              ),

              const SizedBox(height: 15),

              // ---- IMAGE ----
              TextFormField(
                controller: imageController,
                decoration: const InputDecoration(
                  labelText: "URL Image",
                  border: OutlineInputBorder(),
                ),
                validator: (value) =>
                    value!.isEmpty ? "Champ obligatoire" : null,
              ),

              const SizedBox(height: 30),

              // ---- BOUTON MODIFIER ----
              ElevatedButton.icon(
                icon: isLoading
                    ? const SizedBox(
                        width: 20,
                        height: 20,
                        child: CircularProgressIndicator(
                          strokeWidth: 2,
                          color: Colors.white,
                        ),
                      )
                    : const Icon(Icons.save),
                label: const Text("Modifier le produit"),
                onPressed: isLoading
                    ? null
                    : () {
                        if (_formKey.currentState!.validate()) {
                          updateProduct();
                        }
                      },
                style: ElevatedButton.styleFrom(
                  padding: const EdgeInsets.all(15),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

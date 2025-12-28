import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class AddProductApiPage extends StatefulWidget {
  const AddProductApiPage({super.key});

  @override
  State<AddProductApiPage> createState() => _AddProductApiPageState();
}

class _AddProductApiPageState extends State<AddProductApiPage> {
  final _formKey = GlobalKey<FormState>();

  final TextEditingController titleController = TextEditingController();
  final TextEditingController priceController = TextEditingController();
  final TextEditingController descriptionController = TextEditingController();
  final TextEditingController imageController = TextEditingController();

  bool isLoading = false;

  // 🔹 Envoi du produit à l’API (POST)
  Future<void> addProduct() async {
    setState(() => isLoading = true);

    final url = Uri.parse('https://fakestoreapi.com/products');

    final response = await http.post(
      url,
      headers: {
        "Content-Type": "application/json",
      },
      body: jsonEncode({
        "title": titleController.text,
        "price": double.parse(priceController.text),
        "description": descriptionController.text,
        "image": imageController.text,
        "category": "electronics",
      }),
    );

    setState(() => isLoading = false);

    if (response.statusCode == 200 || response.statusCode == 201) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text("Produit ajouté avec succès ✅")),
      );

      Navigator.pop(context); // retour page précédente
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text("Erreur lors de l'ajout ❌")),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Ajouter un produit (API)"),
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
                  labelText: "Titre du produit",
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

              // ---- IMAGE URL ----
              TextFormField(
                controller: imageController,
                decoration: const InputDecoration(
                  labelText: "URL de l'image",
                  border: OutlineInputBorder(),
                ),
                validator: (value) =>
                    value!.isEmpty ? "Champ obligatoire" : null,
              ),

              const SizedBox(height: 30),

              // ---- BOUTON AJOUT ----
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
                    : const Icon(Icons.add),
                label: const Text("Ajouter le produit"),
                onPressed: isLoading
                    ? null
                    : () {
                        if (_formKey.currentState!.validate()) {
                          addProduct();
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

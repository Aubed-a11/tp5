import 'package:flutter/material.dart';
import '../models/product.dart';
import '../services/json_service.dart';
import '../services/log.dart';

class SearchPage extends StatefulWidget {
  const SearchPage({super.key});

  @override
  State<SearchPage> createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage> {
  List<Product> all = [];
  List<Product> filtered = [];

  @override
  void initState() {
    super.initState();
    JsonService.loadProducts().then((value) {
      setState(() {
        all = value;
        filtered = value;
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Recherche")),
      body: Column(
        children: [
          TextField(
            decoration: const InputDecoration(
              hintText: "Rechercher un produit...",
              prefixIcon: Icon(Icons.search),
            ),
            onChanged: (value) {
              Log.actions.add("Recherche effectuée");
              setState(() {
                filtered = all
                    .where((p) =>
                        p.name.toLowerCase().contains(value.toLowerCase()))
                    .toList();
              });
            },
          ),
          Expanded(
            child: ListView(
              children: filtered
                  .map((p) => ListTile(
                        title: Text(p.name),
                        subtitle: Text(p.price),
                        leading: Image.asset(p.image, width: 40),
                      ))
                  .toList(),
            ),
          ),
        ],
      ),
    );
  }
}

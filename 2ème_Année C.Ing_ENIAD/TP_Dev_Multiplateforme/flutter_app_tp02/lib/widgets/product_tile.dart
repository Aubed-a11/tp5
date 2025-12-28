import 'package:flutter/material.dart';

class ProductTile extends StatelessWidget {
  final String name;
  final String price;
  final String imagePath;

  const ProductTile({
    super.key,
    required this.name,
    required this.price,
    required this.imagePath,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Image.asset(imagePath, width: 50),
        const SizedBox(width: 10),
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(name, style: const TextStyle(fontWeight: FontWeight.bold)),
            Text(price),
          ],
        ),
        const Spacer(),
        const Icon(Icons.favorite_border),
      ],
    );
  }
}

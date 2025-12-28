import 'dart:convert';
import 'package:flutter/services.dart';
import '../models/product.dart';

class JsonService {
  static Future<List<Product>> loadProducts() async {
    final data = await rootBundle.loadString('assets/products/products.json');
    final List jsonResult = jsonDecode(data);
    return jsonResult.map((e) => Product.fromJson(e)).toList();
  }
}

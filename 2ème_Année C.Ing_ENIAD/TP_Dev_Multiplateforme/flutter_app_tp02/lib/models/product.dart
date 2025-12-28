class Product {
  final String name;
  final String price;
  final String image;
  final String desc;

  Product({
    required this.name,
    required this.price,
    required this.image,
    required this.desc,
  });

  factory Product.fromJson(Map<String, dynamic> json) {
    return Product(
      name: json['name'],
      price: json['price'],
      image: json['image'],
      desc: json['desc'],
    );
  }
}

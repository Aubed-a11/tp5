import 'package:sqflite/sqflite.dart';
import 'package:path/path.dart';

class DbService {
  static Database? _database;

  // Singleton
  static final DbService instance = DbService._internal();
  DbService._internal();

  // 🔹 Accès à la base
  Future<Database> get database async {
    if (_database != null) return _database!;
    _database = await _initDb();
    return _database!;
  }

  // 🔹 Initialisation DB
  Future<Database> _initDb() async {
    final dbPath = await getDatabasesPath();
    final path = join(dbPath, 'smartshop.db');

    return await openDatabase(
      path,
      version: 1,
      onCreate: _onCreate,
    );
  }

  // 🔹 Création des tables
  Future<void> _onCreate(Database db, int version) async {
    await db.execute('''
      CREATE TABLE favorites (
        id INTEGER PRIMARY KEY,
        title TEXT,
        price REAL,
        image TEXT
      )
    ''');
  }

  // ==========================
  // 🔹 FAVORIS
  // ==========================

  // ➕ Ajouter aux favoris
  Future<void> addFavorite(Map<String, dynamic> product) async {
    final db = await database;
    await db.insert(
      'favorites',
      {
        'id': product['id'],
        'title': product['title'],
        'price': product['price'],
        'image': product['image'],
      },
      conflictAlgorithm: ConflictAlgorithm.replace,
    );
  }

  // 📥 Récupérer favoris
  Future<List<Map<String, dynamic>>> getFavorites() async {
    final db = await database;
    return await db.query('favorites');
  }

  // ❌ Supprimer favori
  Future<void> deleteFavorite(int id) async {
    final db = await database;
    await db.delete(
      'favorites',
      where: 'id = ?',
      whereArgs: [id],
    );
  }

  // 🔎 Vérifier si favori
  Future<bool> isFavorite(int id) async {
    final db = await database;
    final result = await db.query(
      'favorites',
      where: 'id = ?',
      whereArgs: [id],
    );
    return result.isNotEmpty;
  }

  // 🧹 Fermer la DB
  Future<void> close() async {
    final db = await database;
    await db.close();
  }
}

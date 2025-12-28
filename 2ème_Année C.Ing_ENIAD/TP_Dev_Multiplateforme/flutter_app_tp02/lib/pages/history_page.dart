import 'package:flutter/material.dart';
import '../services/log.dart';

class HistoryPage extends StatefulWidget {
  const HistoryPage({super.key});

  @override
  State<HistoryPage> createState() => _HistoryPageState();
}

class _HistoryPageState extends State<HistoryPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Historique")),
      body: ListView.builder(
        itemCount: Log.actions.length,
        itemBuilder: (context, i) {
          return ListTile(
            title: Text(Log.actions[i]),
            trailing: IconButton(
              icon: const Icon(Icons.delete),
              onPressed: () {
                setState(() => Log.actions.removeAt(i));
              },
            ),
          );
        },
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () => setState(() => Log.actions.clear()),
        child: const Icon(Icons.delete_forever),
      ),
    );
  }
}

# architecture

Pour lancer le projet correctement vous aurez besoin de creer deux fichers :
    - "Booking.json"
    - "Transaction.json"

Chacun de ces fichiers doit contenir seulement 
```
[]
```

Ils doivent etre crees dans le dossier : "Architecture/API_Archi/Tables".

Sur Linux, avec l'environnement dotnet :
Dans Architecture/Architecture lancez le front-end avec : `dotnet run --urls="http://localhost:5005"` (le port n'est pas important)
Dans Architecture/API Archi lancez : `dotnet run --urls="http://localhost:52880"` (le port est important)


Les requêtes vers le broker sont 'sensées' marcher (pb avec le réseau de l'école apparemment).
Les requêtes vers le groupe 7 ne marcheront pas si leur serveur n'est pas déployé. Leur clé d'API est hardcodée et les requêtes GET doivent marcher.
Les requêtes vers l'api externe (https://github.com/Sobert/AirTravel/blob/main/src/model.rs)

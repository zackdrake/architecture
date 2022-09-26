# architecture

Pour lancer le projet correctement vous aurez besoin de creer deux fichers :
  - Architecture/API Archi/Tables/Transaction.json    
  - Architecture/API Archi/Tables/Booking.json    

Chacun de ces fichiers doit contenir seulement 
```
[]
```

Sur Linux, avec l'environnement dotnet :\
Dans Architecture/Architecture lancez le front-end avec : `dotnet run --urls="http://localhost:5005"` (le port n'est pas important)\
Puis dans Architecture/API Archi lancez : `dotnet run --urls="http://localhost:52880"` (le port est important)\
Sur Windows avec Visual Studio ça se lance assez intuitivement.

Les requêtes vers l'api externe (https://github.com/Sobert/AirTravel/blob/main/src/model.rs) devraient fonctionner.\
Les requêtes GET et POST sur flight vers le broker sont 'sensées' marcher (pb avec le réseau de l'école apparemment).\
Les requêtes vers le groupe 7 ne marcheront pas si leur serveur n'est pas déployé (URL à renseigner dans Architecture/Architecture/Models/Request/Group7RequestLauncher.cs). Leur clé d'API est hardcodée et les requêtes GET doivent marcher.

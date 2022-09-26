# architecture

Pour lancer le projet correctement vous aurez besoin de creer deux fichers :
    - "Booking.json"
    - "Transaction.json"

Il faut les creer dans : "API_Archi/Tables".
Attention, le dossier "Tables" peut ne pas exister. Dans ce cas, il faut egalement le creer.

Sur Linux, avec l'environnement dotnet :
Dans Architecture/Architecture lancez le front-end avec : `dotnet run --urls="http://localhost:5005"` (le port n'est pas important)
Dans Architecture/API Archi lancez : `dotnet run --urls="http://localhost:52880"` (le port est important)
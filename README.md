

![Sample](https://user-images.githubusercontent.com/97392968/213940754-005a3525-f906-400d-a44b-64add07a32fa.PNG)
Ecran principale

Versions de projet:
  Backend: .Net 6, EF 7.0.2
Front-End: Angular 15.1.2
Configuration de projet pour utiliser SQL Server
1. Vérifier la chaine de connexion de votre serveur de base de donnés:
appsetings.json:
"ConnectionStrings": {
    "DbContext": "Server=(server);Database=StockAPI;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True"
  }
  
  
Dans le projet "Stocking.Infrastructure" au niveau de la class "StockContext", verifier la connexion de votre serveur:


protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
optionsBuilder.UseSqlServer(
                @"Server=(server);Database=StockAPI;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True");
        }
				
				
2.Update database:

Mettez le projet Stocking.Infrastructure en démarrage par défaut et executer la command EF suivant:

Update-DataBase


![Sample1](https://user-images.githubusercontent.com/97392968/213940846-4031d58f-fb0c-45ab-a143-568876fc9ca0.PNG)

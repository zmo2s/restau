Projet de test -> Restaurant Test
Ce projet contient : 
- TestFinancier la ou on à fait tout les scopes des testes unitaires.
- TestIntegration la ou on à définit les testes d'intégration avec simulation de bdd.  
- TestSysteme la ou sont les testes systèmes.


Test de recette : 

Etant donner un restaurant qui vend des burgers.
Quand il est 15 heure.
Alors les burgers sont en promotion à hauteur de 50%.


Test d'integration : 

Etant donnee une base de donnee qui vend des burgers disposant d'une table Restaurant
Lorsque on consulte la bdd.
Alors on récupère la liste des serveur qui travaille dans le restaurant portant le nom "Macdonald"


Test Système : 
Etant donné changement d'heure
Quand un serveur reçoit une commande.
Alors les boissons contenant plus de 15 % d'alchool ne peuvent etre servi après 1h59 donc la commande n'es pas prise en compte
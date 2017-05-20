SERVICE ORIENTED COMPUTING - RENDU DU TD6

Vincent RAYBAUD & Rémy KALOUSTIAN

1) Explication de l'arborescence:
Le dossier DatVelib-Service contient le projet Visual studio métier.
C'est une application console qui travaille avec les services de Veib et Google Maps API.
Nous avons opté pour une application console car la présence de la console rend le debuggage plus pratique,
et c'est finalement le même principe qu'une bibliothèque de service --> on appelle des fonctions d'un projet référencé.

Le dossier DatVeli-UI contient le projet dédié à l'interface homme machine.
C'est un projet WPF. Nous avons préféré faire un WPF car la conception de l'interface et l'insertion de composants
est plus pratique et mieux finalisée que sur un projet WinForms. De plus la customisation des composants permet
de créer un vrai design pour l'application. De plus l'un de nous avait déjà travaillé sur WPF (http://remykaloustian.com/epic/)

Service Oriented Computing - Question 2.pdf est la réponse à la question 2.

Le dossier Resources contient les preuves que notre application marche.

2) Comment ça marche :
Le projet DatVelib-UI représente ce que le client lance. Il a une référence vers le projet DatVelib-Service pour appeler
les fonctions de ce dernier. Le traitement des données est entièrement fait dans DatVeli-Service,
DatVelib-UI sert just à afficher les données. Nous avons ainsi une bonne séparation des responsabilités.

Pour faire fonctionner l'application :
-Ouvrir le projet DatVelib-UI avec Visual Studio
-Cliquer sur le bouton Démarrer (ou Ctrl+F5)
-Taper les adresses départ et arrivée
-Cliquer sur Trouver un trajet
- Le trajet s'affiche en spécifiant la station de Vélib la plus proche qui a des vélibs disponibles
et la station de vélib d'arrivée. Le chemin à suivre est également affiché.


3) WARNING
Si l'application ne fonctionne pas sur votre ordinateur, assurez-vous que votre version de Visual studio est celle
de 2015, et que tout est à jour. Si vous ne parvenez pas à identifier le problème, vous pouvez nous contacter
à remy.kaloustian@etu.unice.fr. Vous pouvez également voir dans le dossier Resources des captures d'écran de l'application 
fonctionnant sur nos machines.




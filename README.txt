SERVICE ORIENTED COMPUTING - RENDU DU TD6

Vincent RAYBAUD & R�my KALOUSTIAN

1) Explication de l'arborescence:
Le dossier DatVelib-Service contient le projet Visual studio m�tier.
C'est une application console qui travaille avec les services de Veib et Google Maps API.
Nous avons opt� pour une application console car la pr�sence de la console rend le debuggage plus pratique,
et c'est finalement le m�me principe qu'une biblioth�que de service --> on appelle des fonctions d'un projet r�f�renc�.

Le dossier DatVeli-UI contient le projet d�di� � l'interface homme machine.
C'est un projet WPF. Nous avons pr�f�r� faire un WPF car la conception de l'interface et l'insertion de composants
est plus pratique et mieux finalis�e que sur un projet WinForms. De plus la customisation des composants permet
de cr�er un vrai design pour l'application. De plus l'un de nous avait d�j� travaill� sur WPF (http://remykaloustian.com/epic/)

Service Oriented Computing - Question 2.pdf est la r�ponse � la question 2.

Le dossier Resources contient les preuves que notre application marche.

2) Comment �a marche :
Le projet DatVelib-UI repr�sente ce que le client lance. Il a une r�f�rence vers le projet DatVelib-Service pour appeler
les fonctions de ce dernier. Le traitement des donn�es est enti�rement fait dans DatVeli-Service,
DatVelib-UI sert just � afficher les donn�es. Nous avons ainsi une bonne s�paration des responsabilit�s.

Pour faire fonctionner l'application :
-Ouvrir le projet DatVelib-UI avec Visual Studio
-Cliquer sur le bouton D�marrer (ou Ctrl+F5)
-Taper les adresses d�part et arriv�e
-Cliquer sur Trouver un trajet
- Le trajet s'affiche en sp�cifiant la station de V�lib la plus proche qui a des v�libs disponibles
et la station de v�lib d'arriv�e. Le chemin � suivre est �galement affich�.


3) WARNING
Si l'application ne fonctionne pas sur votre ordinateur, assurez-vous que votre version de Visual studio est celle
de 2015, et que tout est � jour. Si vous ne parvenez pas � identifier le probl�me, vous pouvez nous contacter
� remy.kaloustian@etu.unice.fr. Vous pouvez �galement voir dans le dossier Resources des captures d'�cran de l'application 
fonctionnant sur nos machines.




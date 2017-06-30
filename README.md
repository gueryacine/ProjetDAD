# ProjetDAD

## Contexte:
Une Agence de cyber-sécurité souhaite identifier une adresse mail dans des documents chiffrés de manière non-asymétrique. En lien avec cette agence une solution distribué doit être monté.

## Prévision au vu du sujet:

### Livrable : 
  - WBS -> Bundown Chart
  - Matrice avec critéres de reussite (perf)
  - Github
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Sch%C3%A9mas/VisioProjetLivrable.PNG "Projet Livrable")

Type____________________________________________Temps_____________________________Incertitude   
### UML :

    Use case                                  2H                               1
    Activité                                  1/2J                             1
    Séquence                                  1/2J                             2
    Composants -> Archi + "9 couches"         1/2J                             5
    Classe                                    1/2J                             5
    Deploiment -> Serveurs                    2H                               2  
    
### Dev :

            - Client .NET                                                      3
            - Serv IIS + WCF                                                   3
            - Serv J2EE -> JMS / MOM                                           2
                        -> Views / JPS                                         1
                        -> Traitement                                          5
            - Déploiment Docker                                                5
            - Tests                                                            3
## Etude d'une solution:

## Analyse:

### Découpage fonctionnelle :

![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Sch%C3%A9mas/DecoupageFonctionnel.PNG "DecoupageFonctionnel")

### Analyse Fonction :

![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Sch%C3%A9mas/Suivi_De_Projet_Code_Couleur.PNG "Explication")
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Sch%C3%A9mas/Suivi_De_Projet_1.PNG "Fonction 1")
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Sch%C3%A9mas/Suivi_De_Projet_2.PNG "Fonction 2")

### UML :

#### Diagramme de USE CASE

Pour le client .NET
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/USE%20CASE%201.PNG "UseCaseClient.Net")

Pour la partie Web
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/USE%20CASE%202.PNG "UseCaseWeb.JSF")

#### Diagramme de Activity

Pour le client .NET
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Activity%201.PNG "ActivityClient.Net 1")
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Acitivity%202.PNG "ActivityClient.Net 2")

Pour le client .JEE
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Activity%203.PNG "ActivityJEE.Net 1")

#### Diagramme de Sequence 

![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Sequence%202.PNG "Sequence 1")
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Sequence%201.PNG "Sequence 2")

## Solution :
### Diagramme de Composant

![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Component%201.PNG "Component 1")
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Component%202.PNG "Component 2")

### Diagramme de Classes

![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Class%201.PNG "Classe 1")
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Class%202.PNG "Classe 2")
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Class%203.PNG "Classe 3")

### Diagramme de Classes
![alt text](https://github.com/gueryacine/ProjetDAD/blob/master/Diagrammes/Deployement.PNG "Deployement")

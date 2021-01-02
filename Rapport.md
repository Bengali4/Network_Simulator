# Rapport de Projet : Simulateur de réseaux électriques
### Cours : Programmation Orientée Objets
### Programmeurs : Louis-Antoine Devos (18168) et Elliott Lengelé (18189)
### Enseignants : Q. Lurkin et A. Lorge
     
---

#     Documentation :
## I. Création d'un réseau électrique :
Pour créer correctement un réseau électrique, il est important de suivre les étapes suivantes que vous ferez dans la classe de votre réseau avec une méthode du genre .Initialize()
### 1. Implémentation des éléments du réseau :
- Pour pouvoir implémenter les centrales/villes/noeuds de concentration ou distribution. Il est nécessaire de commencer par implémenter les lignes qui leurs seront connecter.
- Pour intancier une ligne, vous devez donner en argument le nom de celle-ci et la puissance maximale.
- Pour intancier une centrale, les arguments sont respectivements son nom, sa ligne de sortie, son coût de production et sa rapport de production de CO2.
- Pour intancier une ville, il faut donner son nom, sa ligne d'entrée et son coût d'achat d'électicité.
- Pour instancier un distributeur, les arguments sont dans l'odre suivant, son nom, sa ligne d'entrée, un liste de ses lignes de sortie et le rapport de distribution.
- Pour instancier un concentrateur, les arguments sont dans l'odre suivant, son nom, une liste de ses lignes d'entrée, sa ligne de sortie.
### 2. Connections des lignes :
Une fois les lignes créer, il faut leurs dire à quels noeuds elles sont connectés.
Pour se faire, il faut utiliser une de leur méthode .SetNodes avec le noeud d'entrée en premier argument et le noeud de sortie en deuxième argument.
### 3. Mise en place du centre de contrôle :
Maintenant que tous les élements du réseau ont été créés et connectés entre eux. Vous pouvez mettre en place le centre de contrôle du réseau.
- Le plus simple pour lui donner tous les élements composants le réseau est de créer des listes pour chaque type d'éléments (producteurs, consommateurs, distributeurs, concentrateurs et lignes).
- Ensuite, vous pouvez instancier le centre de contrôle avec en arguments les listes de chaque type dans le même ordre que cité cis-dessus
## II. Méthodes pour effectuer des actions sur le réseau électrique :
Lorsqu'on voudra mettre à jour le réseau avec certains évenements, il est utile de créer des méthodes pour votre classe réseau.
- Par exemple une méthode pour démarer le réseau .Start() :
-> Pour allumer une centrale, appelez la méthode .On() sur l'objet centrale avec la valeur de la puissance qu'elle produira.
-> Pour dire la consommation du ville, appelez la méthode .SetPowerConsumed() sur l'objet ville avec la valeur de la puissance qu'elle consommera.
- Par exemple une méthode pour modifier une production ou consommation .Change() :
-> Vous pouvez modifier la production avec la méthode .SetPowerTo() avec la puissance à produire /!\ Seulement possible pour les centrales le permettant comme les centrales à Gaz.
- Par exemple une méthode pour arrêter le réseau .Stop() :
-> Pour éteindre une centrale, il existe la méthode .Off() qui arrêtera la production de l'objet centrale sur lequel la méthode est appliquée.
-> Pour que les villes ne consomment plus rien, il faut cete fois mettre la valeur de la puissance consommée à 0 avec .SetPowerConsommed()


**Remarques**
- Pour chaque méthode du réseau codées, après avoir utiliser les méthodes propres aux éléments, celle-ci doit absolument retourner une chaîne de caractères expliquant ce que fait la méthode. Sinon, lorsque vous appelerez une des méthodes du réseau dans le centre de contôle, il ne sera pas capable de vous afficher ce qu'il se passe...
- Il est important aussi de faire une méthode du genre .ShowPanel() qui revoit l'evement en string, dans cette méthode on fait un .ShowPanel sur l'objet centre de contrôle du réseau en lui passant l'évenement. Cette méthode permettra en une ligne dans le main de voir l'état du réseau lors d'une modification sur le réseau.
```typescript 
public void ShowPanel(string pevent)
    {
        controlCentreBelgium.ShowPanel(pevent);
    }
```


## III. Utiliser le réseau électrique :
Dans le Main du programme, vous allez maintenant pouvoir simuler votre réseau, c'est à dire l'intancier, le mettre à jour avec vos méthodes et afficher l'état du réseau avec la méthode du panneau de contrôle.
-> Intancier votre réseau
-> Appeler la méthode .ShowPanel() sur l'objet réseau et avec la modification souhaitée en argument (exemple reseau.Start()). Dans la logique des choses : initialise - démarre - n changements - éteind.
-> Mettre un délai pour avoir le temps de lire les valeurs du réseau entre chaque mise à jour:  System.Threading.Thread.Sleep(duree_en_ms)

Exemple : 
```typescript=
using System;

namespace Electrical_Network
{
    class Program
    {
        static void Main(string[] args)
        {
            ENetwork BelgiumNetwork = new ENetwork();
            BelgiumNetwork.ShowPanel(BelgiumNetwork.Initialize());
            System.Threading.Thread.Sleep(5000);
            BelgiumNetwork.ShowPanel(BelgiumNetwork.Start());
            System.Threading.Thread.Sleep(5000);
            BelgiumNetwork.ShowPanel(BelgiumNetwork.Change1());
            System.Threading.Thread.Sleep(5000);
            BelgiumNetwork.ShowPanel(BelgiumNetwork.Stop());
            System.Threading.Thread.Sleep(5000);
        }
    }
}
```


---

#     Diagramme de classe :
![](https://i.imgur.com/s9hNMnq.png)

---

#     Diagramme de séquence :
![](https://i.imgur.com/2SbGgTQ.png)


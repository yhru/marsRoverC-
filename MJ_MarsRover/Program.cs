using System;
using System.Runtime.CompilerServices;
using MaximJoseau_MarsRover.Ressources;

namespace MaximJoseau_MarsRover
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //création du rover, de la planète rouge et de la map
            Rover rover = new Rover();
            Mars mars = new Mars();
            string userInput;
            string deplacement;
            char obstacle = 'X';
            char[,] tableauMars = new char[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tableauMars [i, j] = ' ';
                    //ajout d'obstacles
                    tableauMars [5, 5] = obstacle;
                }
            }
            
            //Affichage de la map de mars
            afficherTableauMars(tableauMars);

            //récupération de la position (initiale)
            Console.WriteLine("Rover info : \n\t- Coordonées X du Rover : " + rover.RoverX + "\n\t- Coordonées Y du Rover : " + rover.RoverY + "\n\t- Le rover est actuellement face au : " + rover.DirectionRover);

            //création du tableau
            void afficherTableauMars(char[,] planeteMars)
            {
                Console.WriteLine("Map Mars : ");
                //Affiche la position du rover sur la map
                tableauMars [rover.getRoverX(), rover.getRoverY()] = 'R';
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(" _ _ _ _ _ _ _ _ _ _");
                    Console.WriteLine("|" + planeteMars[i, 0] + "|" + planeteMars[i, 1] + "|" + planeteMars[i, 2] + "|" + planeteMars[i, 3] + "|" + planeteMars[i, 4] + "|" + planeteMars[i, 5] + "|" + planeteMars[i, 6] + "|" + planeteMars[i, 7] + "|" + planeteMars[i, 8] + "|" + planeteMars[i, 9] + "| ");
                }
            }
            
            do
            {
                Console.WriteLine("Entrez la(les) instruction(s) pour le Rover [F, R, L, Q] ('X' Représente un obstacle) : \n ");
                userInput = Console.ReadLine().ToUpper();
                tableauMars [rover.getRoverX(), rover.getRoverY()] = ' ';
                deplacement = rover.Deplacement(userInput);
                afficherTableauMars(tableauMars );
                Console.WriteLine("Votre position est donc " + deplacement);
            } while (userInput != "Q");
        }
    }
}
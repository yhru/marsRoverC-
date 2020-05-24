using System;
using System.Security.Cryptography.X509Certificates;

namespace MaximJoseau_MarsRover.Ressources
{
    public class Rover
    {
        public enum Direction
        {
            N = 1,
            S = 2,
            E = 3,
            W = 4
        }
        
        public int RoverX;
        public int RoverY;
        public char obstacleMars;
        public Direction DirectionRover { get; set; }

        public Rover()
        {
            RoverX = 0;
            RoverY = 0;
            DirectionRover = Direction.N;
        }

        //Récupération du X de notre Rover
        public int getRoverX()
        {
            return RoverX;
        }
        
        //Récupération du Y de notre Rover
        public int getRoverY()
        {
            return RoverY;
        }

        public Direction getDirectionRover()
        {
            return DirectionRover;
        }

        //Méthode pour tourner a droite en fonction de la direction du rover
        private void RotateRight()
        {
            switch (DirectionRover)
            {
                case Direction.N:
                    DirectionRover = Direction.E;
                    break;
                case Direction.S:
                    DirectionRover = Direction.W;
                    break;
                case Direction.E:
                    DirectionRover = Direction.S;
                    break;
                case Direction.W:
                    DirectionRover = Direction.N;
                    break;
                default: 
                    break;
            }
        }
        
        //Méthode pour tourner a gauche en fonction de la direction du rover
        private void RotateLeft()
        {
            switch (DirectionRover)
            {
                case Direction.N:
                    DirectionRover = Direction.W;
                    break;
                case Direction.S:
                    DirectionRover = Direction.E;
                    break;
                case Direction.E:
                    DirectionRover = Direction.N;
                    break;
                case Direction.W:
                    DirectionRover = Direction.S;
                    break;
                default: 
                    break;
            }
        }

        //Méthode pour avancer en fonction de la direction du rover
        private bool MoveForward()
        {
            switch (DirectionRover)
            {
                case Direction.S:
                    if (RoverX == 4 && RoverY == 5)
                    {
                        RoverX = (getRoverX()) % Mars.MarsSizeX;
                    }
                    else
                    {
                        RoverX = (getRoverX() + 1) % Mars.MarsSizeX;
                    }
                    return false;
                case Direction.N:
                    if (RoverX == 0)
                    {
                        RoverX = 10;
                    }
                    if (RoverX == 6 && RoverY == 5)
                    {
                        RoverX = (getRoverX()) % Mars.MarsSizeX;
                    }
                    else
                    {
                        RoverX = (getRoverX() - 1) % Mars.MarsSizeX;
                    }
                    return false;
                case Direction.E:
                    if (RoverX == 5 && RoverY == 4)
                    {
                        RoverY = (getRoverY()) % Mars.MarsSizeY;
                    }
                    else
                    {
                        RoverY = (getRoverY() + 1) % Mars.MarsSizeY;
                    }
                    return false;
                case Direction.W:
                    if (RoverY == 0)
                    {
                        RoverY = 10;
                    }
                    if (RoverX == 5 && RoverY == 6)
                    {
                        RoverY = (getRoverY()) % Mars.MarsSizeY;
                    }
                    else
                    {
                        RoverY = (getRoverY() - 1) % Mars.MarsSizeY;
                    }
                    break;
                default:
                    break;
            }
            return true;
        }

        //Déplacement du rover
        public string Deplacement(string instructionRover)
        {
            foreach (var instruction in instructionRover)
            {
                switch (instruction)
                {
                    case 'R':
                        RotateRight();
                        break;
                    case 'L':
                        RotateLeft();
                        break;
                    case 'F':
                        MoveForward();
                        break;
                    case 'Q':
                        break;
                }
            }
            return "Cordonnées Rover:\n\t X -> " + RoverX + "\n\t Y -> " + RoverY + "\n\t Direction -> "+ DirectionRover.ToString();
        }
    }
}


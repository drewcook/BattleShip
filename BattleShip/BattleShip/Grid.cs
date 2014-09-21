using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum PlaceShipDirection
        {
            Horizontal, Vertical
        }
    class Grid
    {
        //define properties
        public Point[,] Ocean { get; set; }
        public List<Ship> ListOfShips = new List<Ship>();
        public bool AllShipsDestroyed { get { return ListOfShips.All(x => x.IsDestroyed); } }
        public int CombatRound {get; set;}


        //define constructor
        public Grid()
        {
            //initialize the Ocean
            this.Ocean = new Point[10, 10];
            //this is what the code will look like for each point run through two loops
            //for each row, then for each column, write the pointstatus
            //this.Ocean[1, 1] = new Point(1, 1, Point.PointStatus.Empty);
            //fill each ocean with a point
            for (int y = 0; y <= 9; y++)
            {
                for (int x = 0; x <= 9; x++)
                {
                    this.Ocean[y, x] = new Point(y, x, Point.PointStatus.Empty); 
                }
            }

            //make a list of ships
            this.ListOfShips = new List<Ship>() { new Ship(Ship.ShipType.Carrier), new Ship(Ship.ShipType.Battleship), new Ship(Ship.ShipType.Cruiser), new Ship(Ship.ShipType.Submarine), new Ship(Ship.ShipType.Minesweeper) };

            
        }

            //place each ship in the list of ships using placeship()
            public void PlaceShip (Ship shipToPlace, PlaceShipDirection direction, int startX, int startY)
            {
                for (int i = 1; i < shipToPlace.Length; i++)
			    {
			        var startingPoint =  Ocean[startX, startY];
                    startingPoint.Status = Point.PointStatus.Ship;
                    shipToPlace.OccupiedPoints.Add(startingPoint);
                    if (direction == PlaceShipDirection.Horizontal)
	                    {
		                    startX++;
	                    }
                    else
	                    {
                            startY++;
	                    }


			    }
            }
               //this displays the grid to the user
            public void DisplayOcean()
            {

                Console.WriteLine("0 1 2 3 4 5 6 7 8 9 X");
                Console.WriteLine("0 ||");
                Console.WriteLine("1 ||");
                Console.WriteLine("2 ||");
                Console.WriteLine("3 ||");
                Console.WriteLine("4 ||");
                Console.WriteLine("5 ||");
                Console.WriteLine("6 ||");
                Console.WriteLine("7 ||");
                Console.WriteLine("8 ||");
                Console.WriteLine("9 ||");
                for (int y = 0; y <= 9; y++)
                {
                    for (int x = 0; x <= 9; x++)
                    {
                        if (Ocean[x, y].Status == Point.PointStatus.Hit)
                        {
                            Console.Write("[X]");
                        }
                        else if (Ocean[x, y].Status == Point.PointStatus.Miss)
                        {
                            Console.Write("[O]");
                        }
                        else if (Ocean[x, y].Status == Point.PointStatus.Empty)
                        {
                            Console.Write("[ ]");
                        }

                    }
                    Console.WriteLine();
                }

            }

            public void Target(int x, int y)
            {
                if (Ocean[x,y].Status == Point.PointStatus.Ship)
                {
                    Ocean[x,y].Status = Point.PointStatus.Hit;
                }
                else if (Ocean[x,y].Status == Point.PointStatus.Empty)
                {
                    Ocean[x, y].Status = Point.PointStatus.Miss;
                }
            }

            public void PlayGame()
            {
                while (!AllShipsDestroyed)
                {
                    //display the ocean
                    DisplayOcean();
                    //ask user to enter coordinates
                    Console.WriteLine("Please enter an X coordinate.");
                    Console.WriteLine();
                    int inputX = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Please enter a Y coordiante.");
                    Console.WriteLine();
                    int inputY = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    //call target method for userinputs
                    Target(inputX, inputY);

                    //increase one to combat round
                    CombatRound++;
                }
            }

            



        
    }
}

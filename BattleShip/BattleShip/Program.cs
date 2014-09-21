using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //create new grid
            Grid grid = new Grid();
            
            //let new grid play game
            grid.PlayGame();

            //keep console open
            Console.ReadLine();
        }
    }
}

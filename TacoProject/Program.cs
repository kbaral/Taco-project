using System;

namespace TacoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter number of drones");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the starting positions with space separated");

                string position = Console.ReadLine();
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine("Enter the coordinate for the drone with space separated");
                    string coordinates = Console.ReadLine();

                    Console.WriteLine("Enter the direction from chipotle");
                    string directions = Console.ReadLine();

                    BuildInput build = new BuildInput(position, coordinates, directions);
                    Console.WriteLine($" x coordinates {build.GridCoordinate().X}");
                    Console.WriteLine($" y coordinates {build.GridCoordinate().Y}");
                    Console.WriteLine($" direction {build.GridCoordinate().Direction}");
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception occured {e.Message}");
            }
        }
    }

    
}

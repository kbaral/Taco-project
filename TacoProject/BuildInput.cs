using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacoProject
{
    class BuildInput
    {
        public string Position { get; set; }
        public string Coordinates { get; set; }
        public string Controls { get; set; }
        public BuildInput(string position, string coordinates, string controls)
        {
            this.Coordinates = coordinates;
            this.Position = position;
            this.Controls = controls;
        }

        public PositionDrones DecodePosition()
        {
            PositionDrones initial = new PositionDrones();
            string[] position = Position.Split(' ');
            try
            {
                initial.X = Convert.ToInt32(position[0]);
                initial.Y = Convert.ToInt32(position[1]);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured on position {e.Message}");
            }
            return initial;
        }

        public GridCoordinate DecodeCoordinates()
        {
            GridCoordinate coordinates = new GridCoordinate();
            string[] grid = Coordinates.Split(' ');
            try
            {
                coordinates.X = Convert.ToInt32(grid[0]);
                coordinates.Y = Convert.ToInt32(grid[1]);
                coordinates.Direction = grid[2];

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured on coordinates {e.Message}");
            }
            return coordinates;
        }

        public List<string> DecodeControls()
        {
            var directions = new List<string>();
            string[] controls = Controls.Select(c => c.ToString()).ToArray();
            try
            {
                foreach (var item in controls)
                {
                    directions.Add(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured on controls {e.Message}");
            }


            return directions;
        }

       

        public GridCoordinate GridCoordinate()
        {
            var grid = new GridCoordinate();
            //var positions = new string[] { "E", "W", "N", "S" };
            var gridPoint = DecodeCoordinates();
            var controls = DecodeControls();
            var positionDrones = DecodePosition();
            foreach(var item in controls)
            {
                var initial = gridPoint.Direction;
                if(item == "M")
                {
                    if (gridPoint.Direction == "N")
                    {
                        gridPoint.Y++;
                    }
                    if (gridPoint.Direction == "E")
                    {
                        gridPoint.X++;
                    }
                    if (gridPoint.Direction == "W")
                    {
                        gridPoint.X--;
                    }
                    if (gridPoint.Direction == "S")
                    {
                        gridPoint.Y--;
                    }
                    
                }
                else if (item == "L"){
                    if (gridPoint.Direction == "N")
                    {
                        gridPoint.Direction = "W";
                    }
                    if (gridPoint.Direction == "E")
                    {
                        gridPoint.Direction = "N";
                    }
                    if (gridPoint.Direction == "W")
                    {
                        gridPoint.Direction = "S";
                    }
                    if (gridPoint.Direction == "S")
                    {
                        gridPoint.Direction = "W";
                    }

                }
                else if (item == "R")
                {
                    if (gridPoint.Direction == "N")
                    {
                        gridPoint.Direction = "E";
                    }
                    if (gridPoint.Direction == "E")
                    {
                        gridPoint.Direction = "S";
                    }
                    if (gridPoint.Direction == "W")
                    {
                        gridPoint.Direction = "N";
                    }
                    if (gridPoint.Direction == "S")
                    {
                        gridPoint.Direction = "W";
                    }

                }

                grid = gridPoint;
               
            }

            return gridPoint;

        }

    }



    public class PositionDrones
    {
        public int X { get; set; }
        public int Y { get; set; }

    }

    public class GridCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }

    }

    public class DronesControl
    {
        public int Instructions { get; set; }
    }

}

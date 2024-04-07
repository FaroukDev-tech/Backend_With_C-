using System;
using task_shapes;

namespace Task_2{
    public class Program{
        public static void Main(string[] args){
            // Initialized objects of derived classes
            Circle circle = new ("circle", 10);
            Rectangle rectangle = new ("rectangle", 20, 40);
            Triangle triangle  = new ("triangle", 10, 5);

            // Executing PrintShapeArea on initialized objects
            PrintShapeArea(circle);
            PrintShapeArea(rectangle);
            PrintShapeArea(triangle);
        }

        public static void PrintShapeArea(Shape obj){
            Console.WriteLine($"Name of shape is {obj.Name}.");
            Console.WriteLine($"Its area is {obj.CalculateArea()}\n");
        }
    }
}

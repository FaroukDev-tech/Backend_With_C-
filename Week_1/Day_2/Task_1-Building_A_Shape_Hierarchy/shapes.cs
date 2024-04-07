using System;

namespace task_shapes{
    public abstract class Shape (string name){
        public string? Name {get; set;} = name;
        public virtual double CalculateArea() => 0;
    }

    public class Circle(string name, double radius) : Shape(name){
        public double Radius {get; set;} = radius;

        public override double CalculateArea(){
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle(string name, double width, double height) : Shape(name){
        public double Width {get; set;} = width;
        public double Height {get; set;} = height;

        public override double CalculateArea(){
            return Width * Height;
        }
    }

    public class Triangle(string name, double @base, double height) : Shape(name){
        public double Base {get; set;} = @base;
        public double Height {get; set;} = height;

        public override double CalculateArea(){
            return Base * Height/2;
        }
    }
}

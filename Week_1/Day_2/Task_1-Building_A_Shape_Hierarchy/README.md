### NB: Main program is run in Program.cs file while shapes' classes are implemented in shapes.cs 

## Shape Hierarchy Implementation in C#

This C# project implements a shape hierarchy using object-oriented programming concepts, focusing on encapsulation, inheritance, polymorphism, and access modifiers.

### Classes Implemented:

- **Shape Class**:
  - **Properties**:
    - `Name` (string): Stores the name of the shape.
  - **Methods**:
    - `virtual double CalculateArea()`: A virtual method to calculate the area of the shape. This method is intended to be overridden by derived classes.

- **Circle Class** (Derived from Shape):
  - **Properties**:
    - `Radius` (double): Stores the radius of the circle.
  - **Methods**:
    - `override double CalculateArea()`: Overrides the `CalculateArea()` method to calculate the area of the circle using the formula: `Area = π * Radius * Radius`.

- **Rectangle Class** (Derived from Shape):
  - **Properties**:
    - `Width` (double): Stores the width of the rectangle.
    - `Height` (double): Stores the height of the rectangle.
  - **Methods**:
    - `override double CalculateArea()`: Overrides the `CalculateArea()` method to calculate the area of the rectangle using the formula: `Area = Width * Height`.

- **Triangle Class** (Derived from Shape):
  - **Properties**:
    - `Base` (double): Stores the length of the base of the triangle.
    - `Height` (double): Stores the height of the triangle.
  - **Methods**:
    - `override double CalculateArea()`: Overrides the `CalculateArea()` method to calculate the area of the triangle using the formula: `Area = (Base * Height) / 2`.

### Utility Method:

- **PrintShapeArea(Shape shape)**:
  - This method takes a `Shape` object as a parameter and prints its name and area using the `CalculateArea()` method. It demonstrates polymorphism by dynamically calling the appropriate `CalculateArea()` method based on the actual type of the shape object.

### Usage Example:

In the `Main` method of the application, instances of `Circle`, `Rectangle`, and `Triangle` classes are created and passed to the `PrintShapeArea()` method to display their names and areas.

This implementation showcases:
- **Encapsulation**: Each shape class encapsulates its specific properties and behaviors.
- **Inheritance**: Derived classes inherit common properties and behaviors from the base `Shape` class.
- **Polymorphism**: The `CalculateArea()` method is overridden in derived classes to provide specific implementations for calculating the area of each shape.
- **Access Modifiers**: Properties and methods are appropriately encapsulated using access modifiers (`public`, `private`, `protected`) to control visibility and accessibility.

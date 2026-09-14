using System.Drawing;

namespace depi_day7
{
   
        
        // 1. Car Class - Multiple Constructors
       

        class Car
        {
            public int Id { get; set; }
            public string Brand { get; set; }
            public double Price { get; set; }

            // Default Constructor
            public Car()
            {
                Id = 0;
                Brand = "Unknown";
                Price = 0;
            }

            // Constructor with one parameter
            public Car(int id)
            {
                Id = id;
                Brand = "Unknown";
                Price = 0;
            }

            // Constructor with two parameters
            public Car(int id, string brand)
            {
                Id = id;
                Brand = brand;
                Price = 0;
            }

            // Constructor with three parameters
            public Car(int id, string brand, double price)
            {
                Id = id;
                Brand = brand;
                Price = price;
            }

            public override string ToString()
            {
                return $"Id: {Id}, Brand: {Brand}, Price: {Price}";
            }
        }


        
        // 2. Calculator - Method Overloading
       

        class Calculator
        {
            // Add two integers
            public int Sum(int a, int b)
            {
                return a + b;
            }

            // Add three integers
            public int Sum(int a, int b, int c)
            {
                return a + b + c;
            }

            // Add two doubles
            public double Sum(double a, double b)
            {
                return a + b;
            }
        }


       
        // 3. Parent and Child - Constructor Chaining
        
        class Parent
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Parent(int x, int y)
            {
                X = x;
                Y = y;
            }

            // Virtual method for override example
            public virtual int Product()
            {
                return X * Y;
            }

            // ToString
            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }


        class Child : Parent
        {
            public int Z { get; set; }

            // Constructor chaining to Parent constructor
            public Child(int x, int y, int z) : base(x, y)
            {
                Z = z;
            }

            // Override using override keyword
            public override int Product()
            {
                return X * Y * Z;
            }

            // ToString override
            public override string ToString()
            {
                return $"({X}, {Y}, {Z})";
            }
        }


        
        // 4. Demonstrating new keyword
       
        class ChildNew : Parent
        {
            public int Z { get; set; }

            public ChildNew(int x, int y, int z) : base(x, y)
            {
                Z = z;
            }

            // new hides the Parent method
            public new int Product()
            {
                return X * Y * Z;
            }
        }

 // 5. Interface IShape and Rectangle
       
        interface IShape
        {
            double Area { get; }

            void Draw();

            // Default implementation - C# 8.0
            void PrintDetails()
            {
                Console.WriteLine("This is a shape.");
            }
        }


        class Rectangle : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public double Area
            {
                get
                {
                    return Width * Height;
                }
            }

public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public void Draw()
            {
                Console.WriteLine("Drawing Rectangle");
            }
        }


       
        // 6. Circle implementing IShape
       

        class Circle : IShape
        {
            public double Radius { get; set; }

            public Circle(double radius)
            {
                Radius = radius;
            }

            public double Area
            {
                get
                {
                    return Math.PI * Radius * Radius;
                }
            }

            public void Draw()
            {
                Console.WriteLine("Drawing Circle");
            }
        }


       
        // 7. IMovable Interface and Car
       
        interface IMovable
        {
            void Move();
        }


        class MovableCar : IMovable
        {
            public void Move()
            {
                Console.WriteLine("Car is moving.");
            }
        }


        
        // 8. Multiple Interfaces
      

        interface IReadable
        {
            void Read();
        }


        interface IWritable
        {
            void Write();
        }


        class MyFile : IReadable, IWritable
        {
            public void Read()
            {
                Console.WriteLine("Reading from file.");
            }

            public void Write()
            {
                Console.WriteLine("Writing to file.");
            }
        }


        // 9. Shape - Virtual and Abstract Methods
       
        abstract class Shape
        {
            // Virtual method
            public virtual void Draw()
            {
                Console.WriteLine("Drawing Shape");
            }

            // Abstract method
            public abstract double CalculateArea();
        }


        class ShapeRectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public ShapeRectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            // Override virtual method
            public override void Draw()
            {
                Console.WriteLine("Drawing Rectangle");
            }

            // Implement abstract method
            public override double CalculateArea()
            {
                return Width * Height;
            }
        }


        
        // Main
       

        class Program
        {
            static void Main(string[] args)
            {
                
                // 1. Car Constructors
                

                Console.WriteLine("Car Constructors ");

                Car car1 = new Car();
                Car car2 = new Car(1);
                Car car3 = new Car(2, "BMW");
                Car car4 = new Car(3, "Mercedes", 1500000);

                Console.WriteLine(car1);
                Console.WriteLine(car2);
                Console.WriteLine(car3);
                Console.WriteLine(car4);


               
                // 2. Calculator Overloading
              
                Console.WriteLine("\n Calculator Overloading ");

                Calculator calculator = new Calculator();

                Console.WriteLine(calculator.Sum(10, 20));
                Console.WriteLine(calculator.Sum(10, 20, 30));
                Console.WriteLine(calculator.Sum(10.5, 20.5));

               

// 3. Constructor Chaining

Console.WriteLine("\n Constructor Chaining ");

                Child child = new Child(2, 3, 4);

                Console.WriteLine($"X = {child.X}");
                Console.WriteLine($"Y = {child.Y}");
                Console.WriteLine($"Z = {child.Z}");


                
                // 4. new vs override
                

                Console.WriteLine("\n new vs override ");

                // new keyword
                ChildNew childNew = new ChildNew(2, 3, 4);

                Parent parentReference1 = childNew;

                Console.WriteLine("Using ChildNew reference:");
                Console.WriteLine(childNew.Product());

                Console.WriteLine("Using Parent reference:");
                Console.WriteLine(parentReference1.Product());


                // override keyword
                Child childOverride = new Child(2, 3, 4);

                Parent parentReference2 = childOverride;

                Console.WriteLine("\nUsing Child reference:");
                Console.WriteLine(childOverride.Product());

                Console.WriteLine("Using Parent reference:");
                Console.WriteLine(parentReference2.Product());


               
                // 5. ToString and Polymorphism
                
                Console.WriteLine("\n ToString and Polymorphism");

                Parent parent = new Parent(5, 10);
                Child child2 = new Child(5, 10, 15);

                Console.WriteLine(parent.ToString());
                Console.WriteLine(child2.ToString());

                Parent polymorphicChild = new Child(5, 10, 15);
                Console.WriteLine(polymorphicChild.ToString());


                
                // 6. IShape - Rectangle
               
                Console.WriteLine("\n IShape - Rectangle ");

                IShape rectangle = new Rectangle(10, 5);

                rectangle.Draw();
                Console.WriteLine($"Area = {rectangle.Area}");


               
                // 7. Default Interface Implementation
                

                Console.WriteLine("\nDefault Interface Implementation ");

                IShape circle = new Circle(5);

                circle.Draw();
                Console.WriteLine($"Area = {circle.Area}");

                circle.PrintDetails();


                
                // 8. Interface Reference - IMovable
               
                Console.WriteLine("\n Interface Reference ");

                IMovable movableCar = new MovableCar();

                movableCar.Move();


                
                // 9. Multiple Interfaces
                

                Console.WriteLine("\n Multiple Interfaces ");

                MyFile file = new MyFile();

                file.Read();
                file.Write();


               
                // 10. Virtual and Abstract Methods
                
                Console.WriteLine("\n Virtual and Abstract Methods ");

                Shape shape = new ShapeRectangle(10, 5);

                shape.Draw();
                Console.WriteLine($"Area = {shape.CalculateArea()}");


                Console.WriteLine("\n Program Finished" );

            }
        }
    }


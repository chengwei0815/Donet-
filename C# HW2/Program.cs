/*
 1.	What are the six combinations of access modifier keywords and what do they do?
=> public, private, protected, internal, protected internal, and private protected.
   - public: Accessible from any other code.
   - private: Accessible only within the containing class or struct.
   - protected: Accessible within the containing class and by derived class instances.
   - internal: Accessible only within files in the same assembly.
   - protected internal: Accessible within the same assembly or from derived classes.
   - private protected: Accessible within the containing class or types derived from the containing class within the same assembly.

2.	What is the difference between the static, const, and readonly keywords when applied to a type member?
=> static: Belongs to the type itself rather than to any specific instance. Can be changed.
   => const: A compile-time constant. Its value is set at compile time and cannot be changed.
   => readonly: A runtime constant. Its value can be set in the constructor but cannot be changed afterwards.

3.	What does a constructor do?
=> A constructor is a special method that is called when an instance of a class is created. It initializes the object and can set initial values for fields and properties.

4.	Why is the partial keyword useful?
=> The partial keyword allows the definition of a class, struct, or interface to be split across multiple files. This is useful for organizing code, especially in large projects or when using code generation tools.

5.	What is a tuple?
=> A tuple is a data structure that can hold a fixed number of items of different types. It is useful for grouping related values together without creating a separate class or struct.

6.	What does the C# record keyword do?
=> The record keyword is used to define a reference type that provides built-in functionality for value-based equality, immutability, and concise syntax for defining data-centric types. Records are typically used for data transfer objects and immutable data structures.

7.	What does overloading and overriding mean?
=> Overloading refers to defining multiple methods with the same name but different parameter lists within the same scope. It allows methods to perform similar functions with different types or numbers of arguments.
   => Overriding refers to providing a new implementation for a method in a derived class that is already defined in its base class. The method in the base class must be marked as virtual, abstract, or override.

8.	What is the difference between a field and a property?
=> A field is a variable that is declared directly in a class or struct and holds data. It can be public, private, or protected.
   => A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. Properties can have get and set accessors to control access to the underlying field.

9.	How do you make a method parameter optional?
=> You can make a method parameter optional by providing a default value for it in the method signature. If the caller does not provide a value for that parameter, the default value will be used.

10.	What is an interface and how is it different from an abstract class?
=> An interface is a contract that defines a set of methods, properties, events, or indexers that a class must implement. It does not provide any implementation itself.
   => An abstract class is a class that cannot be instantiated and can contain both abstract methods (without implementation) and concrete methods (with implementation). A class can inherit from only one abstract class but can implement multiple interfaces.

11.	What accessibility level are members of an interface by default?
=> Members of an interface are public by default. They cannot have any other access modifiers.

12.	True/False: Polymorphism allows derived classes to provide different implementations of the same method.
=>  T

13.	True/False: The override keyword is used to indicate that a method in a derived class is providing its own implementation.
=> T
14.	True/False: The new keyword is used to indicate that a method in a derived class is providing its own implementation.
=> F
15.	True/False: Abstract methods can be used in a normal (non-abstract) class.
=> F
16.	True/False: Normal (non-abstract) methods can be used in an abstract class.
=> T
17.	True/False: Derived classes can override methods that were virtual in the base class.
=> T
18.	True/False: Derived classes can override methods that were abstract in the base class.
=> T
19.	True/False: Derived classes must override the abstract methods from the base class.
=> T
20.	True/False: In a derived class, you can override a method that was neither virtual nor abstract in the base class.
=> F
21.	True/False: A class that implements an interface does not have to provide an implementation for all of the members of the interface.
=> F
22.	True/False: A class that implements an interface is allowed to have other members in addition to the interface members.
=> T
23.	True/False: A class can inherit from more than one base class.
=> F
24.	True/False: A class can implement more than one interface.
=> T
 */

//  Create 3 classes in Program.cs:

using System;
using System.Collections.Generic;

namespace HW2
{
    /*
        a. Person class
        ●	Create an abstract class Person with the following members:

        ○	An Id property (int).

        ○	A private field salary with a public property Salary that only accepts positive values; throw an exception if a negative value is assigned.

        ○	A DateOfBirth property (DateTime).

        ○	An Address property (List of strings).

         */
    public abstract class Person
    {
        public int Id { get; set; }
        private decimal _salary;
        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary must be a positive value.");
                }
                _salary = value;
            }
        }

        public DateTime DateOfBirth { get; set; }
        public List<string> Address { get; set; } = new List<string>();
    }

    /*
     b. Instructor class
        ●	Create a class Instructor that inherits from Person.

        ○	Add a DepartmentId property (int).

     */
    public class Instructor : Person
    {
        public int DepartmentId { get; set; }

        /*
         c. Student class
●	Create a class Student that inherits from Person.

○	Add a property SelectedCourses, which is a list of Course objects.
*/

        public class Student : Person
        {
            public List<Course> SelectedCourses { get; set; } = new List<Course>();
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Example Instructor
                Instructor instructor = new Instructor
                {
                    Id = 1,
                    Salary = 5000,
                    DateOfBirth = new DateTime(1985, 5, 12),
                    DepartmentId = 101
                };
                instructor.Address.Add("123 Main Street");
                instructor.Address.Add("City, Country");

                Console.WriteLine($"Instructor Id: {instructor.Id}, Salary: {instructor.Salary}, DOB: {instructor.DateOfBirth.ToShortDateString()}, Department: {instructor.DepartmentId}");
                Console.WriteLine("Instructor Address: " + string.Join(", ", instructor.Address));

                // Example Student
                Student student = new Student
                {
                    Id = 2,
                    Salary = 0, // maybe stipend/assistantship
                    DateOfBirth = new DateTime(2000, 9, 5),
                };
                student.Address.Add("456 College Road");


                Console.WriteLine($"\nStudent Id: {student.Id}, DOB: {student.DateOfBirth.ToShortDateString()}");
                Console.WriteLine("Student Address: " + string.Join(", ", student.Address));
                Console.WriteLine("Enrolled Courses:");

            }
        }
    }
}













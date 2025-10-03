/*
1.	Describe the problem generics address.
=> 
Generics address the problem of code reusability and type safety. They allow developers to create classes, methods, and data structures that can operate with any data type while ensuring that type errors are caught at compile time rather than at runtime. This helps to reduce code duplication and increases flexibility by enabling the same code to work with different types without sacrificing performance or safety.

2.	How would you create a list of strings, using the generic List class?
=>
List<string> stringList = new List<string>();


3.	How many generic type parameters does the Dictionary class have?
=> 
The Dictionary class has two generic type parameters: one for the key type and one for the value type, typically represented as Dictionary<TKey, TValue>.


4.	True/False. When a generic class has multiple type parameters, they must all match.
=> 
False. When a generic class has multiple type parameters, they do not have to match; each type parameter can be a different type. For example, you can have a generic class like `MyClass<T1, T2>` where `T1` and `T2` can be different types.

5.	What method is used to add items to a List object?
=>
The method used to add items to a List object is `Add()`. For example, you can use `stringList.Add("example");` to add a string to the list.

6.	Name two methods that cause items to be removed from a List.
=>
`Remove()` and `RemoveAt()`. The `Remove()` method removes the first occurrence of a specific object from the list, while `RemoveAt()` removes the item at a specified index.

7.	How do you indicate that a class has a generic type parameter?
=>
You indicate that a class has a generic type parameter by using angle brackets (`< >`) after

8.	True/False. Generic classes can only have one generic type parameter.
=> 
False. Generic classes can have multiple generic type parameters. For example, you can define a generic 
class like `MyClass<T1, T2>` with two type parameters.


9.	True/False. Generic type constraints limit what can be used for the generic type.
=> 
True. Generic type constraints limit what types can be used for the generic type parameter. They allow you to specify requirements that the type must meet, such as inheriting from a specific class, implementing an interface, or being a value type.

10.	True/False. Constraints let you use the methods of the thing you are constraining to.
=>
True. Constraints let you use the methods and properties of the type you are constraining to, as they ensure that the type meets certain criteria, allowing you to safely call those methods and access those properties.

 */

/*
 Task 1:
 Define a generic class called MyStack<T> with the following requirements:
1.	Use Stack<T> internally to store the data.

2.	Implement a Count() method that returns the number of elements in the stack.

3.	Implement a Pop() method that returns and removes the top element of the stack.

4.	Implement a Push(T obj) method that adds an element to the stack.

Finally, create an instance of MyStack<int>, push two integers into it, and print out the current number of elements in the stack.
*/

using System;
//using System.Collections.Generic;

public class MyStack<T>
{
    private Stack<T> stack = new Stack<T>();
    public int Count()
    {
        return stack.Count;
    }
    public T Pop()
    {
        return stack.Pop();
    }
    public void Push(T obj)
    {
        stack.Push(obj);
    }

}
public class Program
{
    public static void Main(string[] args)
    {
        MyStack<int> mystack = new MyStack<int>();
        mystack.Push(10);
        mystack.Push(5);
        Console.WriteLine($"number of elements is {mystack.Count()} ");
    }
}






/*
Task 2:
 Create a generic repository pattern in C# with the following requirements:
1.	Define a generic interface IGenericRepository<T> where T : class.

○	The interface should declare the following methods:

■	Add(T item)

■	Remove(T item)

■	Save()

■	IEnumerable<T> GetAll()

■	T GetById(int id)

2.	Implement a class GenericRepository<T> that inherits from IGenericRepository<T>.

○	Use a private List<T> field to store the data.
○	In the constructor, initialize the list as a new empty List<T>.
○	Provide method implementations for Add, Remove, GetAll, GetById. No actual implementation is needed for Save.

 */
namespace RepositoryPatternDemo { 
    public interface IGenericRepository<T> where T : class 
    {
        void Add(T obj);
        void Remove(T obj);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly List<T> _items;
        public GenericRepository()
        {
            _items = new List<T>();
        }
        public void Add(T obj)
        {
            _items.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        public T GetById(int id)
        {
            var prop = _items[id];
            return prop;
        }

        public void Remove(T obj)
        {
            _items.Remove(obj);
        }

        public void Save()
        {
        }
    }

}



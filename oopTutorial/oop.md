# Complete OOP (Object-Oriented Programming) Course Outline
## C# Focused - Beginner to Advanced

---

## 📚 Table of Contents
1. [Course Overview](#-course-overview)
2. [Beginner Level](#-beginner-level)
3. [Intermediate Level](#-intermediate-level)
4. [Advanced Level](#-advanced-level)
5. [Master Level](#-master-level)
6. [OOP Principles Deep Dive](#-oop-principles-deep-dive)
7. [Design Patterns](#-design-patterns)
8. [Code Examples](#-code-examples)
9. [Projects](#-projects)
10. [Best Practices](#-best-practices)

---

## 🎯 Course Overview

### What You'll Learn
- Fundamental OOP concepts and principles
- How to design object-oriented systems
- Clean code practices for OOP
- Design patterns and when to use them
- SOLID principles
- Testing OOP code
- Real-world application development

### Prerequisites
- Basic C# syntax knowledge
- Understanding of data types and variables
- Familiarity with control flow statements
- Willingness to learn and practice

### Course Duration
- Beginner: 2-3 weeks
- Intermediate: 3-4 weeks
- Advanced: 4-6 weeks
- Master: 6+ weeks

---

## 🟢 BEGINNER LEVEL
**Duration: 2-3 weeks**

### 1. Introduction to OOP

#### 1.1 What is Object-Oriented Programming?
- [ ] Understanding programming paradigms
- [ ] Procedural vs Object-Oriented programming
- [ ] Benefits of OOP
- [ ] When to use OOP
- [ ] OOP in real-world applications

#### 1.2 Classes and Objects
- [ ] What is a class?
- [ ] What is an object?
- [ ] Class vs Object relationship
- [ ] Creating your first class
- [ ] Instantiating objects
- [ ] Understanding object identity

#### 1.3 The Anatomy of a Class
```csharp
// Class declaration
public class Car
{
    // Fields (private data)
    private string _brand;
    private int _year;
    
    // Properties (public interface)
    public string Brand
    {
        get { return _brand; }
        set { _brand = value; }
    }
    
    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }
    
    // Constructors
    public Car()
    {
        _brand = "Unknown";
        _year = 2020;
    }
    
    public Car(string brand, int year)
    {
        _brand = brand;
        _year = year;
    }
    
    // Methods (behavior)
    public void Start()
    {
        Console.WriteLine("Engine started!");
    }
    
    public void Stop()
    {
        Console.WriteLine("Engine stopped!");
    }
    
    // Destructor (finalizer)
    ~Car()
    {
        // Cleanup code
    }
}
```

### 2. Properties and Fields

#### 2.1 Fields
- [ ] Instance fields
- [ ] Static fields
- [ ] Read-only fields (readonly keyword)
- [ ] Constant fields (const keyword)
- [ ] Field initialization
- [ ] Backing fields

#### 2.2 Properties
- [ ] Auto-properties
- [ ] Full properties with backing fields
- [ ] Read-only properties
- [ ] Write-only properties
- [ ] Computed properties
- [ ] Property validation
- [ ] Expression-bodied properties

#### 2.3 Access Modifiers
```csharp
public class AccessModifiersExample
{
    // Private - only accessible within the class
    private string _privateField;
    
    // Public - accessible from anywhere
    public string PublicField;
    
    // Protected - accessible within class and derived classes
    protected string _protectedField;
    
    // Internal - accessible within the same assembly
    internal string _internalField;
    
    // Protected internal - accessible within assembly or derived classes
    protected internal string _protectedInternalField;
    
    // Private protected - accessible within derived classes in same assembly
    private protected string _privateProtectedField;
}
```

### 3. Constructors

#### 3.1 Constructor Basics
- [ ] Default constructor
- [ ] Parameterized constructor
- [ ] Constructor overloading
- [ ] Constructor chaining (this keyword)
- [ ] Static constructor
- [ ] Private constructor
- [ ] Constructor execution order

#### 3.2 Constructor Examples
```csharp
public class ConstructorExample
{
    private string _name;
    private int _age;
    private readonly DateTime _createdDate;
    
    // Default constructor
    public ConstructorExample()
    {
        _name = "Default";
        _age = 0;
        _createdDate = DateTime.Now;
    }
    
    // Parameterized constructor
    public ConstructorExample(string name, int age)
    {
        _name = name;
        _age = age;
        _createdDate = DateTime.Now;
    }
    
    // Constructor chaining
    public ConstructorExample(string name) : this(name, 25)
    {
    }
    
    // Static constructor
    static ConstructorExample()
    {
        Console.WriteLine("Static constructor called");
    }
}
```

### 4. Methods

#### 4.1 Method Fundamentals
- [ ] Method declaration
- [ ] Parameters and arguments
- [ ] Return types
- [ ] Method overloading
- [ ] Optional parameters
- [ ] Named arguments
- [ ] Expression-bodied methods

#### 4.2 Method Examples
```csharp
public class MethodExamples
{
    // Simple method
    public void Greet(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
    
    // Method with return value
    public int Add(int a, int b)
    {
        return a + b;
    }
    
    // Method with optional parameters
    public void DisplayInfo(string name, int age = 25)
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }
    
    // Method overloading
    public void Print(int number)
    {
        Console.WriteLine($"Number: {number}");
    }
    
    public void Print(string text)
    {
        Console.WriteLine($"Text: {text}");
    }
    
    public void Print(int number, string label)
    {
        Console.WriteLine($"{label}: {number}");
    }
    
    // Expression-bodied method
    public int Multiply(int a, int b) => a * b;
    
    // Recursive method
    public int Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }
}
```

### 5. Encapsulation

#### 5.1 Understanding Encapsulation
- [ ] Data hiding
- [ ] Information hiding
- [ ] Access control
- [ ] Public interface design
- [ ] Getters and setters
- [ ] Validation logic
- [ ] Immutability patterns

#### 5.2 Encapsulation Examples
```csharp
public class BankAccount
{
    private decimal _balance;
    private readonly string _accountNumber;
    private readonly List<string> _transactions;
    
    // Public properties with validation
    public string AccountNumber => _accountNumber;
    
    public decimal Balance
    {
        get { return _balance; }
        private set
        {
            if (value < 0)
                throw new ArgumentException("Balance cannot be negative");
            _balance = value;
        }
    }
    
    // Constructor
    public BankAccount(string accountNumber, decimal initialBalance = 0)
    {
        _accountNumber = accountNumber;
        _transactions = new List<string>();
        Balance = initialBalance;
    }
    
    // Public methods (public interface)
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive");
        
        Balance += amount;
        _transactions.Add($"Deposited: {amount} on {DateTime.Now}");
    }
    
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive");
        
        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds");
        
        Balance -= amount;
        _transactions.Add($"Withdrawn: {amount} on {DateTime.Now}");
    }
    
    public IReadOnlyList<string> GetTransactionHistory()
    {
        return _transactions.AsReadOnly();
    }
}
```

### 6. Beginner Practice Exercises

#### Exercise 1: Student Class
Create a Student class with:
- Fields: Name, Age, Grade
- Properties with validation
- Methods: CalculateGPA(), DisplayInfo()
- Constructors

#### Exercise 2: Rectangle Class
Create a Rectangle class with:
- Fields: Length, Width
- Auto-properties
- Methods: CalculateArea(), CalculatePerimeter(), IsSquare()
- Constructor validation

#### Exercise 3: Temperature Converter
Create a Temperature class with:
- Celsius and Fahrenheit properties
- Automatic conversion between units
- Methods to display in different formats

---

## 🟡 INTERMEDIATE LEVEL
**Duration: 3-4 weeks**

### 7. Inheritance

#### 7.1 Understanding Inheritance
- [ ] What is inheritance?
- [ ] Base class and derived class
- [ ] "is-a" relationship
- [ ] Method overriding
- [ ] base keyword
- [ ] Protected access modifier
- [ ] Constructor inheritance

#### 7.2 Inheritance Examples
```csharp
// Base class (parent)
public class Animal
{
    protected string Name { get; set; }
    protected int Age { get; set; }
    
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    public virtual void MakeSound()
    {
        Console.WriteLine("Some sound");
    }
    
    public void Move()
    {
        Console.WriteLine($"{Name} is moving");
    }
    
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

// Derived class (child)
public class Dog : Animal
{
    public string Breed { get; set; }
    
    public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed;
    }
    
    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }
    
    public void Fetch()
    {
        Console.WriteLine($"{Name} is fetching the ball");
    }
    
    // Using base keyword to call parent method
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Breed: {Breed}");
    }
}

// Another derived class
public class Cat : Animal
{
    public bool IsIndoor { get; set; }
    
    public Cat(string name, int age, bool isIndoor) : base(name, age)
    {
        IsIndoor = isIndoor;
    }
    
    public override void MakeSound()
    {
        Console.WriteLine("Meow! Meow!");
    }
    
    public void Purr()
    {
        Console.WriteLine($"{Name} is purring");
    }
}
```

#### 7.3 Method Hiding with 'new' Keyword
```csharp
public class BaseClass
{
    public void Display()
    {
        Console.WriteLine("BaseClass Display");
    }
}

public class DerivedClass : BaseClass
{
    // Hides the base method
    public new void Display()
    {
        Console.WriteLine("DerivedClass Display");
    }
}
```

### 8. Polymorphism

#### 8.1 Understanding Polymorphism
- [ ] Compile-time polymorphism (method overloading)
- [ ] Runtime polymorphism (method overriding)
- [ ] Virtual methods
- [ ] Abstract methods
- [ ] Override keyword
- [ ] Polymorphic behavior
- [ ] Type checking (is/as operators)

#### 8.2 Polymorphism Examples
```csharp
public class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
    
    public virtual void Display()
    {
        Console.WriteLine("This is a shape");
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }
    
    public Circle(double radius)
    {
        Radius = radius;
    }
    
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
    
    public override void Display()
    {
        Console.WriteLine($"Circle with radius: {Radius}");
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    
    public override double CalculateArea()
    {
        return Width * Height;
    }
    
    public override void Display()
    {
        Console.WriteLine($"Rectangle: {Width} x {Height}");
    }
}

// Using polymorphism
public class AreaCalculator
{
    public double CalculateTotalArea(List<Shape> shapes)
    {
        double total = 0;
        
        foreach (var shape in shapes)
        {
            total += shape.CalculateArea();
        }
        
        return total;
    }
    
    public void DisplayAllShapes(List<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            shape.Display(); // Polymorphic call
        }
    }
}
```

### 9. Abstract Classes and Methods

#### 9.1 Understanding Abstraction
- [ ] Abstract classes
- [ ] Abstract methods
- [ ] Cannot instantiate abstract classes
- [ ] Partial implementation
- [ ] Sealed vs Abstract

#### 9.2 Abstract Class Examples
```csharp
public abstract class Vehicle
{
    protected string _brand;
    protected int _year;
    
    public Vehicle(string brand, int year)
    {
        _brand = brand;
        _year = year;
    }
    
    // Abstract method - must be implemented by derived classes
    public abstract void StartEngine();
    
    public abstract void StopEngine();
    
    // Regular method - optional to override
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Vehicle: {_brand}, Year: {_year}");
    }
}

public class Car : Vehicle
{
    private bool _engineRunning;
    
    public Car(string brand, int year) : base(brand, year)
    {
        _engineRunning = false;
    }
    
    public override void StartEngine()
    {
        _engineRunning = true;
        Console.WriteLine("Car engine started");
    }
    
    public override void StopEngine()
    {
        _engineRunning = false;
        Console.WriteLine("Car engine stopped");
    }
    
    public override void DisplayInfo()
    {
        Console.WriteLine($"Car: {_brand}, Year: {_year}, Engine Running: {_engineRunning}");
    }
}

public class Motorcycle : Vehicle
{
    public Motorcycle(string brand, int year) : base(brand, year)
    {
    }
    
    public override void StartEngine()
    {
        Console.WriteLine("Motorcycle engine started");
    }
    
    public override void StopEngine()
    {
        Console.WriteLine("Motorcycle engine stopped");
    }
}
```

### 10. Interfaces

#### 10.1 Understanding Interfaces
- [ ] What is an interface?
- [ ] Interface vs Abstract class
- [ ] Interface declaration
- [ ] Interface implementation
- [ ] Multiple interface implementation
- [ ] Interface inheritance
- [ ] Default interface methods (C# 8+)

#### 10.2 Interface Examples
```csharp
// Interface declaration
public interface IDriveable
{
    void Start();
    void Stop();
    int Speed { get; set; }
}

public interface ISerializable
{
    string Serialize();
    void Deserialize(string data);
}

public interface ICloneable
{
    object Clone();
}

// Class implementing multiple interfaces
public class Car : IDriveable, ISerializable, ICloneable
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Speed { get; set; }
    private bool _isRunning;
    
    public void Start()
    {
        _isRunning = true;
        Console.WriteLine("Car started");
    }
    
    public void Stop()
    {
        _isRunning = false;
        Speed = 0;
        Console.WriteLine("Car stopped");
    }
    
    public string Serialize()
    {
        return $"{Brand},{Model},{Speed}";
    }
    
    public void Deserialize(string data)
    {
        var parts = data.Split(',');
        Brand = parts[0];
        Model = parts[1];
        Speed = int.Parse(parts[2]);
    }
    
    public object Clone()
    {
        return new Car { Brand = Brand, Model = Model, Speed = Speed };
    }
}
```

#### 10.3 Default Interface Methods (C# 8+)
```csharp
public interface ILogger
{
    void Log(string message);
    
    // Default implementation
    void LogError(string message)
    {
        Log($"ERROR: {message}");
    }
    
    void LogWarning(string message)
    {
        Log($"WARNING: {message}");
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}
```

### 11. Composition vs Inheritance

#### 11.1 Understanding Composition
- [ ] "Has-a" relationship
- [ ] Favor composition over inheritance
- [ ] When to use composition
- [ ] Composition examples

#### 11.2 Composition vs Inheritance Examples
```csharp
// Inheritance approach (tightly coupled)
public class Engine
{
    public void Start() => Console.WriteLine("Engine started");
    public void Stop() => Console.WriteLine("Engine stopped");
}

public class CarWithInheritance : Engine // Car "is an" Engine
{
    public void Drive() => Console.WriteLine("Car is driving");
}

// Composition approach (loosely coupled)
public class CarWithComposition
{
    private Engine _engine; // Car "has an" Engine
    
    public CarWithComposition(Engine engine)
    {
        _engine = engine;
    }
    
    public void Start()
    {
        _engine.Start();
    }
    
    public void Drive()
    {
        Console.WriteLine("Car is driving");
    }
}

// Better composition with interface
public interface IEngine
{
    void Start();
    void Stop();
}

public class ElectricEngine : IEngine
{
    public void Start() => Console.WriteLine("Electric engine started");
    public void Stop() => Console.WriteLine("Electric engine stopped");
}

public class HybridEngine : IEngine
{
    public void Start() => Console.WriteLine("Hybrid engine started");
    public void Stop() => Console.WriteLine("Hybrid engine stopped");
}

public class FlexibleCar
{
    private IEngine _engine;
    
    public FlexibleCar(IEngine engine)
    {
        _engine = engine;
    }
    
    public void Start()
    {
        _engine.Start();
    }
}
```

### 12. Intermediate Practice Exercises

#### Exercise 1: Shape Hierarchy
Create a shape hierarchy with:
- Abstract Shape class
- Circle, Rectangle, Triangle, Square classes
- Methods: CalculateArea(), CalculatePerimeter()
- Polymorphic shape calculator

#### Exercise 2: Animal Kingdom
Create an animal hierarchy with:
- Animal base class
- Mammal, Bird, Fish derived classes
- Specific animals with unique behaviors
- Override MakeSound(), Move(), Eat()

#### Exercise 3: File System
Create a file system with:
- FileSystemItem interface
- File and Directory classes
- Composition for directory contents
- Methods: GetSize(), Display()

---

## 🔴 ADVANCED LEVEL
**Duration: 4-6 weeks**

### 13. SOLID Principles

#### 13.1 Single Responsibility Principle (SRP)
```csharp
// VIOLATION: Multiple responsibilities
public class UserService
{
    public void CreateUser(User user) { /* ... */ }
    public void SendEmail(User user) { /* ... */ }
    public void WriteToLog(string message) { /* ... */ }
    public void ValidateUser(User user) { /* ... */ }
}

// FOLLOWING SRP: Single responsibility
public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;
    
    public UserService(IUserRepository userRepository, IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }
    
    public void CreateUser(User user)
    {
        // Business logic only
    }
}

public class EmailService : IEmailService
{
    public void SendEmail(User user, string message) { /* ... */ }
}

public class UserValidator
{
    public bool Validate(User user) { /* ... */ }
}

public class UserRepository : IUserRepository
{
    public void Save(User user) { /* ... */ }
}
```

#### 13.2 Open/Closed Principle (OCP)
```csharp
// VIOLATION: Must modify to add new shapes
public class AreaCalculatorBad
{
    public double CalculateArea(object shape)
    {
        if (shape is Circle) { /* ... */ }
        if (shape is Rectangle) { /* ... */ }
        // Must modify this method for new shapes
    }
}

// FOLLOWING OCP: Open for extension, closed for modification
public interface IShape
{
    double CalculateArea();
}

public class Circle : IShape
{
    public double Radius { get; set; }
    public double CalculateArea() => Math.PI * Radius * Radius;
}

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double CalculateArea() => Width * Height;
}

public class AreaCalculatorGood
{
    public double CalculateArea(IShape shape)
    {
        return shape.CalculateArea(); // Works with any IShape
    }
}
```

#### 13.3 Liskov Substitution Principle (LSP)
```csharp
// VIOLATION: Liskov principle violated
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying");
    }
}

public class Penguin : Bird
{
    // Cannot fly! This violates LSP
    public override void Fly()
    {
        throw new NotImplementedException("Penguins cannot fly");
    }
}

// FOLLOWING LSP: Proper inheritance
public interface IFlyable
{
    void Fly();
}

public interface ISwimmable
{
    void Swim();
}

public class Eagle : IFlyable
{
    public void Fly() => Console.WriteLine("Eagle flying");
}

public class Penguin : ISwimmable
{
    public void Swim() => Console.WriteLine("Penguin swimming");
}
```

#### 13.4 Interface Segregation Principle (ISP)
```csharp
// VIOLATION: Fat interface
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

// FOLLOWING ISP: Segregated interfaces
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public interface IRestable
{
    void Sleep();
}

public class Robot : IWorkable
{
    public void Work() => Console.WriteLine("Robot working");
}

public class Human : IWorkable, IFeedable, IRestable
{
    public void Work() => Console.WriteLine("Human working");
    public void Eat() => Console.WriteLine("Human eating");
    public void Sleep() => Console.WriteLine("Human sleeping");
}
```

#### 13.5 Dependency Inversion Principle (DIP)
```csharp
// VIOLATION: High-level module depends on low-level module
public class MySQLDatabase
{
    public void Save(string data) { /* ... */ }
}

public class DataProcessor
{
    private MySQLDatabase _database = new MySQLDatabase();
    
    public void Process(string data)
    {
        _database.Save(data);
    }
}

// FOLLOWING DIP: Both depend on abstractions
public interface IDatabase
{
    void Save(string data);
}

public class MySQLDatabase : IDatabase
{
    public void Save(string data) { /* ... */ }
}

public class PostgreSQLDatabase : IDatabase
{
    public void Save(string data) { /* ... */ }
}

public class DataProcessor
{
    private readonly IDatabase _database;
    
    // Dependency injected via constructor
    public DataProcessor(IDatabase database)
    {
        _database = database;
    }
    
    public void Process(string data)
    {
        _database.Save(data);
    }
}
```

### 14. Advanced OOP Patterns

#### 14.1 Factory Pattern
```csharp
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Email: {message}");
}

public class SMSNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"SMS: {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Push: {message}");
}

public enum NotificationType
{
    Email,
    SMS,
    Push
}

public static class NotificationFactory
{
    public static INotification Create(NotificationType type)
    {
        switch (type)
        {
            case NotificationType.Email:
                return new EmailNotification();
            case NotificationType.SMS:
                return new SMSNotification();
            case NotificationType.Push:
                return new PushNotification();
            default:
                throw new ArgumentException("Invalid notification type");
        }
    }
}

// Usage
var email = NotificationFactory.Create(NotificationType.Email);
email.Send("Hello via Email!");
```

#### 14.2 Repository Pattern
```csharp
public interface IRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

public class EntityRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public EntityRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }
    
    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
    
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }
    
    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
    
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}
```

#### 14.3 Dependency Injection Container
```csharp
public interface IService
{
    void Execute();
}

public class ServiceA : IService
{
    public void Execute() => Console.WriteLine("ServiceA executed");
}

public class ServiceB : IService
{
    public void Execute() => Console.WriteLine("ServiceB executed");
}

public class Consumer
{
    private readonly IService _service;
    
    public Consumer(IService service)
    {
        _service = service;
    }
    
    public void DoWork()
    {
        _service.Execute();
    }
}

// Using DI Container (ASP.NET Core example)
public void ConfigureServices(IServiceCollection services)
{
    // Transient - new instance each time
    services.AddTransient<IService, ServiceA>();
    
    // Scoped - new instance per request
    services.AddScoped<Consumer>();
    
    // Singleton - single instance for all requests
    services.AddSingleton<IService, ServiceB>();
}
```

### 15. Advanced OOP Concepts

#### 15.1 Covariance and Contravariance
```csharp
// Covariance (out keyword)
public interface IEnumerable<out T> : IEnumerable
{
    IEnumerator<T> GetEnumerator();
}

// IAnimal is convertible to IEnumerable<Animal>
// IEnumerable<Animal> is also IEnumerable<Dog> if Dog : Animal
IEnumerable<Animal> animals = new List<Dog>();

// Contravariance (in keyword)
public interface IComparer<in T>
{
    int Compare(T x, T y);
}

// Can use IComparer<Animal> where IComparer<Animal> is expected
IComparer<Animal> animalComparer = new AnimalComparer();
IComparer<Dog> dogComparer = animalComparer;
```

#### 15.2 Records (C# 9+)
```csharp
// Traditional class
public class PersonClass
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public PersonClass(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

// Record (immutable by default)
public record PersonRecord(string FirstName, string LastName);

// With methods
public record Person(string FirstName, string LastName)
{
    public string FullName => $"{FirstName} {LastName}";
    
    public void Deconstruct(out string firstName, out string lastName)
    {
        firstName = FirstName;
        lastName = LastName;
    }
}

// Record with inheritance
public abstract record PersonBase(string Name, int Age);
public record Employee(string Name, int Age, string Department) : PersonBase(Name, Age);

// Non-destructive mutation (with expression)
var employee = new Employee("John", 30, "IT");
var updatedEmployee = employee with { Department = "HR" };
```

### 16. Advanced Practice Exercises

#### Exercise 1: E-Commerce System
Create an e-commerce system with:
- Product, Customer, Order, Payment classes
- Repository pattern implementation
- SOLID principles compliance
- Dependency injection setup

#### Exercise 2: Game Character System
Create a game character system with:
- Character base class and interfaces
- Different character types (Warrior, Mage, Archer)
- Inventory system using composition
- Factory pattern for character creation

---

## 🏆 MASTER LEVEL
**Duration: 6+ weeks**

### 17. Domain-Driven Design (DDD) Fundamentals

#### 17.1 DDD Building Blocks
```csharp
// Entity
public class Customer : Entity
{
    public CustomerId Id { get; private set; }
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    
    public Customer(CustomerId id, Name name, Email email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public void ChangeAddress(Address newAddress)
    {
        // Business logic validation
        if (newAddress == null)
            throw new ArgumentNullException(nameof(newAddress));
        
        Address = newAddress;
    }
}

// Value Object
public class Address : ValueObject
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    
    public Address(string street, string city, string zipCode)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return ZipCode;
    }
}

// Aggregate Root
public class Order : AggregateRoot
{
    public OrderId Id { get; private set; }
    private readonly List<OrderLine> _orderLines = new List<OrderLine>();
    public IReadOnlyCollection<OrderLine> OrderLines => _orderLines.AsReadOnly();
    public OrderStatus Status { get; private set; }
    
    public void AddOrderLine(OrderLine orderLine)
    {
        _orderLines.Add(orderLine);
    }
    
    public void Submit()
    {
        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException("Order already submitted");
        
        Status = OrderStatus.Submitted;
    }
}

// Domain Service
public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public void PlaceOrder(Order order)
    {
        // Domain logic that spans multiple aggregates
        order.Submit();
        _orderRepository.Save(order);
    }
}
```

### 18. Event-Driven Architecture

#### 18.1 Domain Events
```csharp
public interface IDomainEvent
{
    DateTime OccurredAt { get; }
}

public class OrderPlacedEvent : IDomainEvent
{
    public DateTime OccurredAt { get; } = DateTime.UtcNow;
    public OrderId OrderId { get; }
    public CustomerId CustomerId { get; }
    public decimal TotalAmount { get; }
    
    public OrderPlacedEvent(OrderId orderId, CustomerId customerId, decimal totalAmount)
    {
        OrderId = orderId;
        CustomerId = customerId;
        TotalAmount = totalAmount;
    }
}

// Domain event dispatcher
public interface IEventDispatcher
{
    void Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent;
}

// Implementation using MediatR
public class MediatRDispatcher : IEventDispatcher
{
    private readonly IMediator _mediator;
    
    public MediatRDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public void Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent
    {
        _mediator.Publish(@event);
    }
}

// Domain event handler
public class OrderPlacedEventHandler : INotificationHandler<OrderPlacedEvent>
{
    private readonly IEmailService _emailService;
    private readonly IInventoryService _inventoryService;
    
    public OrderPlacedEventHandler(IEmailService emailService, IInventoryService inventoryService)
    {
        _emailService = emailService;
        _inventoryService = inventoryService;
    }
    
    public Task Handle(OrderPlacedEvent notification, CancellationToken cancellationToken)
    {
        // Send confirmation email
        _emailService.SendOrderConfirmation(notification.OrderId);
        
        // Update inventory
        _inventoryService.ReserveItems(notification.OrderId);
        
        return Task.CompletedTask;
    }
}
```

### 19. CQRS (Command Query Responsibility Segregation)

#### 19.1 CQRS Implementation
```csharp
// Command
public class CreateCustomerCommand : IRequest<CustomerDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

// Command Handler
public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    
    public CreateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.FirstName, request.LastName, request.Email);
        await _repository.AddAsync(customer);
        
        return _mapper.Map<CustomerDto>(customer);
    }
}

// Query
public class GetCustomerByIdQuery : IRequest<CustomerDto>
{
    public int Id { get; set; }
}

// Query Handler (separate from command handler)
public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly ICustomerReadRepository _readRepository;
    private readonly IMapper _mapper;
    
    public GetCustomerByIdQueryHandler(ICustomerReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }
    
    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _readRepository.GetByIdAsync(request.Id);
        return _mapper.Map<CustomerDto>(customer);
    }
}

// Different models for read and write
public class CustomerDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
}
```

### 20. Testing OOP Code

#### 20.1 Unit Testing with xUnit
```csharp
public class CalculatorTests
{
    [Fact]
    public void Add_TwoNumbers_ReturnsSum()
    {
        // Arrange
        var calculator = new Calculator();
        
        // Act
        var result = calculator.Add(5, 3);
        
        // Assert
        Assert.Equal(8, result);
    }
    
    [Theory]
    [InlineData(5, 3, 8)]
    [InlineData(10, 20, 30)]
    [InlineData(-5, 5, 0)]
    public void Add_VariousNumbers_ReturnsCorrectSum(int a, int b, int expected)
    {
        // Arrange
        var calculator = new Calculator();
        
        // Act
        var result = calculator.Add(a, b);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        // Arrange
        var calculator = new Calculator();
        
        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }
}

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock;
    private readonly Mock<IEmailService> _emailServiceMock;
    private readonly OrderService _orderService;
    
    public OrderServiceTests()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _emailServiceMock = new Mock<IEmailService>();
        _orderService = new OrderService(_orderRepositoryMock.Object, _emailServiceMock.Object);
    }
    
    [Fact]
    public void PlaceOrder_ValidOrder_SavesOrderAndSendsEmail()
    {
        // Arrange
        var order = new Order(/* valid order */);
        _orderRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Order>()))
            .Returns(Task.CompletedTask);
        
        // Act
        _orderService.PlaceOrder(order);
        
        // Assert
        _orderRepositoryMock.Verify(r => r.AddAsync(order), Times.Once);
        _emailServiceMock.Verify(e => e.SendOrderConfirmation(order.Id), Times.Once);
    }
}
```

### 21. Clean Code for OOP

#### 21.1 Naming Conventions
```csharp
// Bad naming
public class C
{
    private int d;
    
    public void doIt(int x)
    {
        d = x;
    }
}

// Good naming
public class Customer
{
    private DateTime _registrationDate;
    
    public void Register(DateTime registrationDate)
    {
        _registrationDate = registrationDate;
    }
}
```

#### 21.2 Method Design
```csharp
// Bad method
public void ProcessData(List<object> data, bool flag1, bool flag2, int x)
{
    if (flag1)
    {
        // Process one way
    }
    else
    {
        // Process another way
    }
}

// Good method
public OrderProcessingResult ProcessOrder(Order order)
{
    if (!order.IsValid)
    {
        return OrderProcessingResult.Failed("Invalid order");
    }
    
    var processedOrder = await _orderProcessor.ProcessAsync(order);
    return OrderProcessingResult.Success(processedOrder);
}
```

---

## 📋 OOP Principles Deep Dive

### Encapsulation Checklist
- [ ] Make fields private or protected
- [ ] Use properties to control access
- [ ] Validate data in setters
- [ ] Keep methods focused
- [ ] Hide implementation details
- [ ] Provide clear public interface

### Inheritance Checklist
- [ ] Use inheritance for "is-a" relationships
- [ ] Prefer composition over inheritance
- [ ] Use virtual methods for extensibility
- [ ] Don't break Liskov substitution principle
- [ ] Use sealed when inheritance isn't needed

### Polymorphism Checklist
- [ ] Use interfaces for abstraction
- [ ] Leverage virtual/override keywords
- [ ] Design for extensibility
- [ ] Avoid type checking in conditionals
- [ ] Use polymorphism instead of switches

### Abstraction Checklist
- [ ] Define clear interfaces
- [ ] Hide complexity behind simple interfaces
- [ ] Use abstract classes for shared behavior
- [ ] Don't expose unnecessary details
- [ ] Keep abstractions stable

---

## 🎯 Design Patterns Reference

### Creational Patterns
| Pattern | Purpose | Use Case |
|---------|---------|----------|
| Singleton | Single instance | Configuration, logging |
| Factory Method | Object creation | Creating objects without specifying class |
| Abstract Factory | Family of objects | Creating related objects |
| Builder | Complex construction | Building objects step by step |
| Prototype | Cloning objects | Copying expensive objects |

### Structural Patterns
| Pattern | Purpose | Use Case |
|---------|---------|----------|
| Adapter | Interface conversion | Integrating incompatible interfaces |
| Bridge | Abstraction separation | Decoupling interface from implementation |
| Composite | Tree structures | Part-whole hierarchies |
| Decorator | Adding behavior | Extending functionality dynamically |
| Facade | Simplified interface | Hiding complex subsystems |
| Flyweight | Sharing objects | Memory optimization |

### Behavioral Patterns
| Pattern | Purpose | Use Case |
|---------|---------|----------|
| Observer | Event handling | Notifications, subscriptions |
| Strategy | Algorithm selection | Interchangeable algorithms |
| Command | Encapsulating requests | Queuing, undo operations |
| Iterator | Traversal | Sequential access |
| Mediator | Centralized communication | Decoupling objects |
| Memento | State restoration | Undo functionality |

---

## 📂 Projects

### Beginner Projects
1. **Student Management System**
   - Create Student, Course, Grade classes
   - Implement basic CRUD operations
   - Calculate GPA

2. **Library System**
   - Book, Member, Loan classes
   - Track borrowed books
   - Calculate fines

3. **Bank Account System**
   - Account, Transaction classes
   - Deposit, withdraw, transfer
   - Transaction history

### Intermediate Projects
1. **E-Commerce System**
   - Product, Order, Customer, Payment
   - Shopping cart functionality
   - Order processing

2. **Restaurant Management**
   - Menu, Order, Table, Reservation classes
   - Order tracking
   - Table management

3. **Social Media System**
   - User, Post, Comment, Like classes
   - Feed generation
   - Friendship/following

### Advanced Projects
1. **Online Learning Platform**
   - Course, Lesson, Enrollment, Progress
   - Video streaming integration
   - Quiz system

2. **Inventory Management System**
   - Warehouse, Product, Stock, Supplier
   - Automatic reordering
   - Expiry tracking

### Master Projects
1. **Microservices E-Commerce Platform**
   - Product, Order, Payment, Notification services
   - Event-driven architecture
   - CQRS implementation

2. **Healthcare Management System**
   - Patient, Appointment, Prescription, Billing
   - DDD implementation
   - Complex business rules

---

## ✅ Mastery Checklist

### Beginner Skills
- [ ] Can create classes and objects
- [ ] Understands access modifiers
- [ ] Can implement properties and methods
- [ ] Understands constructor usage
- [ ] Can implement encapsulation

### Intermediate Skills
- [ ] Can implement inheritance hierarchies
- [ ] Understands polymorphism
- [ ] Can create and use interfaces
- [ ] Understands composition vs inheritance
- [ ] Can apply SOLID principles

### Advanced Skills
- [ ] Can design complex systems
- [ ] Understands design patterns
- [ ] Can implement DDD concepts
- [ ] Can create maintainable codebases
- [ ] Can write comprehensive tests

### Master Skills
- [ ] Leads architectural decisions
- [ ] Mentors development team
- [ ] Evaluates trade-offs
- [ ] Drives best practices
- [ ] Creates scalable systems

---

## 📚 Additional Resources

### Books
- "Clean Code" by Robert C. Martin
- "Design Patterns" by Gang of Four
- "Refactoring" by Martin Fowler
- "Domain-Driven Design" by Eric Evans
- "Applying Domain-Driven Design and Patterns" by Jimmy Nilsson

### Online Resources
- Microsoft Learn OOP Documentation
- Pluralsight OOP Courses
- Refactoring Guru (refactoring.guru)
- Sourcemaking (sourcemaking.com)

### Practice Platforms
- LeetCode
- HackerRank
- Exercism
- Codewars

---

*Last Updated: 2025*
*Version: 1.0*
*Course Author: C# Developer Course*

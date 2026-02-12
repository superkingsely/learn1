
-----

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

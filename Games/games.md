# C# Console Games Learning Path

A curated list of C# console games to help you learn C# from beginner to advanced level, with the new topics you'll learn while building each game.

---

## 🟢 Beginner Level (Fundamentals)

### 1. Hello World
Print "Hello, World!" to the console.

**Topics Learned:**
- Basic C# syntax
- `Main()` method (entry point)
- `Console.WriteLine()`
- Comments (`//`, `/* */`)

---

### 2. Calculator
A simple calculator that performs basic arithmetic operations (add, subtract, multiply, divide).

**Topics Learned:**
- Variables and data types (`int`, `double`)
- User input with `Console.ReadLine()`
- Type conversion (`int.Parse()`, `Convert.ToInt32()`)
- Arithmetic operators (`+`, `-`, `*`, `/`)
- `if-else` statements
- `switch` statements

---

### 3. Number Guessing Game
The computer generates a random number, and the player has to guess it with hints.

**Topics Learned:**
- Random number generation (`Random` class)
- `while` and `do-while` loops
- Comparison operators (`<`, `>`, `==`, `!=`)
- `break` and `continue` statements
- Compound assignment operators (`+=`, `-=`)
- Logical operators (`&&`, `||`, `!`)

---

### 4. Multiplication Table
Print multiplication tables for a user-specified number.

**Topics Learned:**
- `for` loops
- Nested loops
- `foreach` loops
- Variable scope

---

### 5. Simple Quiz Game
A multiple-choice quiz with scoring.

**Topics Learned:**
- Arrays (one-dimensional)
- String manipulation
- Conditional logic
- `if-else if-else` chains
- Accumulator variables

---

### 6. Temperature Converter
Convert temperatures between Celsius, Fahrenheit, and Kelvin.

**Topics Learned:**
- Methods/functions
- Method parameters
- Return values
- `void` methods
- Method overloading (optional)

---

### 7. Palindrome Checker
Check if a word or phrase is a palindrome.

**Topics Learned:**
- String methods (`ToLower()`, `Replace()`, `Trim()`)
- `for` loop with decrement
- `char` data type
- String indexing

---

## 🟡 Intermediate Level (OOP & Data Structures)

### 8. Tic-Tac-Toe
A classic two-player Tic-Tac-Toe game.

**Topics Learned:**
- Two-dimensional arrays
- Enums (for player marks)
- Methods with multiple return values (out parameters)
- Pass by reference (`ref` keyword)
- Input validation
- Game loop logic

---

### 9. Hangman
The classic word-guessing game with a limited number of attempts.

**Topics Learned:**
- Arrays and `Array.Length`
- `List<T>` collection
- `foreach` loop with collections
- String builder concepts (conceptual)
- Character comparison
- Boolean flags

---

### 10. Snake Game
The classic Snake game where you control a snake that grows when it eats food.

**Topics Learned:**
- Queue data structure (`Queue<T>`)
- `List<T>` manipulation
- Object-Oriented Programming basics (classes)
- `DateTime` for game timing
- Coordinate systems (x, y)
- Collision detection
- `Console.SetCursorPosition()`
- `Console.KeyAvailable`

---

### 11. Blackjack
A simplified version of the card game Blackjack.

**Topics Learned:**
- Classes and objects
- Class constructors
- Properties (get/set)
- `Random` selection
- Enum for card suits/ranks
- List of objects
- Game state management
- Method parameters and return types

---

### 12. To-Do List
A simple console-based to-do list application.

**Topics Learned:**
- Custom classes
- Object collections
- File I/O (basic text file operations)
- `File.ReadAllText()`, `File.WriteAllText()`
- Serialization concepts
- CRUD operations (Create, Read, Update, Delete)

---

### 13. Contact Book
Store and manage contacts with names and phone numbers.

**Topics Learned:**
- Dictionary<TKey, TValue>
- Key-value pair operations
- LINQ basics (`Where()`, `FirstOrDefault()`)
- Data validation
- Search functionality
- Dictionary.ContainsKey()

---

### 14. Text-Based RPG
A simple role-playing game with characters, inventory, and battles.

**Topics Learned:**
- Inheritance (`base` keyword)
- Polymorphism (`virtual`, `override`)
- Abstract classes
- Encapsulation (access modifiers)
- Composition (objects within objects)
- Static members (`static` keyword)
- Constant values (`const`)

---

### 15. Minesweeper
The classic minesweeper game with grid and bomb detection.

**Topics Learned:**
- 2D arrays
- Recursion (flood fill algorithm)
- Enum flags
- Bitwise operators (optional advanced)
- Neighbor cell calculation
- Game state enumeration

---

## 🔴 Advanced Level (Professional C#)

### 16. Chess (Simplified)
A basic chess implementation with piece movement rules.

**Topics Learned:**
- Advanced inheritance hierarchy
- Interface implementation (`interface` keyword)
- Strategy pattern
- Command pattern (for moves)
- Board representation (bitboards optional)
- Complex game logic
- Move validation

---

### 17. Connect Four with AI
Connect Four game with a basic AI opponent.

**Topics Learned:**
- Minimax algorithm
- Alpha-beta pruning (optional)
- Delegates (`delegate` keyword)
- Lambda expressions
- Func and Action delegates
- Recursive algorithms
- Game tree traversal

---

### 18. Conway's Game of Life
The cellular automaton game with adjustable grid size.

**Topics Learned:**
- Multi-dimensional arrays
- Array.Copy() for grid cloning
- Generics (if creating a Grid class)
- Event-driven programming concepts
- Timer/Tick events
- Neighbor counting algorithms
- Double buffering technique

---

### 19. Tower Defense Game
A text-based tower defense game with multiple tower types and enemies.

**Topics Learned:**
- Interface-based design
- Multiple classes and objects
- Event handling (`event` keyword)
- Custom delegates
- LINQ queries (`Where`, `Select`, `OrderBy`, `GroupBy`)
- Anonymous types
- Yield return (for wave generation)

---

### 20. JSON-Based Inventory System
An inventory system that persists data to JSON files.

**Topics Learned:**
- JSON serialization (`System.Text.Json`)
- JSON deserialization
- Custom attributes
- Reflection (`Type`, `PropertyInfo`)
- File I/O with streams
- Using statements (resource management)
- Error handling (`try-catch-finally`)

---

### 21. Async File Processor
A game or utility that processes game data asynchronously.

**Topics Learned:**
- `async` and `await` keywords
- Task Parallel Library (`Task`)
- `async Main()` method
- CancellationToken
- Exception handling with async
- `ConfigureAwait()`
- Asynchronous I/O

---

### 22. Multi-Player Server (Basic)
A simple server that allows multiple clients to play a game together.

**Topics Learned:**
- TCP/UDP networking (`TcpClient`, `TcpListener`)
- Threading (`Thread`, `ThreadPool`)
- `Monitor` and `lock` keyword
- Concurrent collections (`ConcurrentDictionary`)
- Thread synchronization
- Stream handling

---

### 23. Plugin System
A game with support for plugins/extensions loaded at runtime.

**Topics Learned:**
- Reflection (`Assembly.LoadFrom()`)
- `Type` and `MethodInfo`
- Dependency injection basics
- Plugin architecture
- Interface-based plugin contracts
- Dynamic loading
- Assembly resolution

---

### 24. Unit Testing Framework
Build your own simple unit testing framework.

**Topics Learned:**
- Attributes (`[Attribute]`)
- Custom attributes
- Reflection for test discovery
- Expression trees (advanced)
- Delegate invocation
- Stack trace analysis
- Console color customization

---

### 25. Memory Game with Patterns
A pattern-matching memory game with configurable difficulty.

**Topics Learned:**
- Builder pattern
- Factory pattern
- LINQ expressions
- Custom iterators (`IEnumerable`, `yield`)
- IDisposable pattern
- IDisposable for resource cleanup
- Dependency injection container (basic)

---

## 📚 Learning Path Summary

| Level | Games | Core Concepts |
|-------|-------|---------------|
| Beginner | 1-7 | Variables, loops, conditionals, methods, arrays, strings |
| Intermediate | 8-15 | OOP (classes, inheritance, polymorphism), collections, file I/O, enums |
| Advanced | 16-25 | Delegates, events, async/await, reflection, LINQ, threading, patterns |

---

## 🚀 Recommended Order

1. **Start with Beginner games** to master fundamentals
2. **Move to Intermediate** when comfortable with basic syntax
3. **Tackle Advanced** projects after understanding OOP well

Each game builds on previous concepts, but feel free to skip around based on your interests!

---

## 📖 Additional Resources

- [Microsoft C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/)
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)

---

*Happy Coding! 🎮*

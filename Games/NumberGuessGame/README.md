# Number Guess Game - C# Learning Guide

## Overview
A beginner-friendly console game that teaches fundamental C# programming concepts.

## Game Rules
- Computer generates a random number (1-100)
- Player guesses the number
- Game gives hints: "Too High" or "Too Low"
- Track number of attempts

---

## C# Concepts Explained

### 1. Variables & Data Types

Variables are named containers that store data.

```csharp
int attempts = 0;          // int = whole numbers (-2B to +2B)
bool isCorrect = false;    // bool = true/false values
string name = "Player";    // string = text/characters
Random random = new Random();  // Random = special class for random numbers
```

### 2. Console Input/Output

Communicate with the user through the console.

```csharp
// OUTPUT - Print to screen
Console.WriteLine("Hello!");     // Prints text + new line
Console.Write("Enter: ");       // Prints text without new line

// INPUT - Read from keyboard
string input = Console.ReadLine();  // Waits for user to type and press Enter
```

### 3. Type Conversion

Convert data from one type to another.

```csharp
// PROBLEM: ReadLine returns string, but we need int for math
string userInput = Console.ReadLine();

// DANGEROUS - Throws error if input isn't a number
int number = int.Parse(userInput);

// SAFE - Returns true/false instead of crashing
bool success = int.TryParse(userInput, out int number);
```

### 4. Random Number Generation

Generate unpredictable numbers.

```csharp
Random random = new Random();
int number = random.Next(1, 101);  // Returns 1-100 (101 is exclusive)
```

### 5. Control Flow (if/else)

Make decisions in code.

```csharp
if (guess == secretNumber)
{
    Console.WriteLine("You win!");
}
else if (guess > secretNumber)
{
    Console.WriteLine("Too high!");
}
else
{
    Console.WriteLine("Too low!");
}
```

### 6. Loops (while)

Repeat code while condition is true.

```csharp
bool isCorrect = false;

while (!isCorrect)  // Repeat while isCorrect is false
{
    // Code here runs repeatedly
    // Loop exits when isCorrect becomes true
}
```

### 7. Comparison Operators

Compare values.

| Operator | Meaning | Example |
|----------|---------|---------|
| `==` | Equal to | `5 == 5` → true |
| `!=` | Not equal | `5 != 3` → true |
| `>` | Greater than | `5 > 3` → true |
| `<` | Less than | `3 < 5` → true |
| `>=` | Greater or equal | `5 >= 5` → true |
| `<=` | Less or equal | `3 <= 5` → true |

### 8. Logical Operators

Combine conditions.

| Operator | Meaning | Example |
|----------|---------|---------|
| `&&` | AND (both true) | `x > 1 && x < 100` |
| `\|\|` | OR (at least one) | `x == 1 \|\| x == 100` |
| `!` | NOT (reverses) | `!isCorrect` |

---

## Code Structure

```
Program.cs
├── using System;          // Import built-in functions
├── namespace NumberGuessGame  // Groups related code
└── class Program
    ├── Main()             // Entry point
    └── RunGame()          // Game logic
```

---

## Running the Game

```bash
# In terminal
dotnet run

# Or press F5 in VSCode
```

---

## Next Steps to Practice

1. Add difficulty levels (Easy: 1-50, Medium: 1-100, Hard: 1-1000)
2. Add a high score system
3. Add time tracking
4. Add multiple rounds
5. Add a "give up" option

---

## Learning Path

After this project, practice:
- Arrays and Lists
- Methods with parameters
- Classes and Objects
- File I/O
- Exception Handling

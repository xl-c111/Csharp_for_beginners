# C# `var` Cheat Sheet

## What is `var`?

`var` means the C# compiler automatically infers the variable type from the value on the right-hand side.

```csharp
var age = 25;        // int
var name = "Anna";   // string
var isActive = true; // bool
```

## Key Mental Rule

```text
var does not mean "any type".
var means "compiler, please infer the type from the right-hand side".
```

C# is still strongly typed.

```csharp
var number = 10;
number = "Hello"; // Error: number is already inferred as int
```

## `var` Type Is Fixed

Once the compiler infers the type, the variable type cannot change.

```csharp
var score = 90;  // score is int
score = 95;      // OK
score = "High";  // Error
```

## You Must Initialize `var`

This is invalid:

```csharp
var name; // Error
```

The compiler needs a value to infer the type.

Correct:

```csharp
var name = "Anna";
```

## Common Use Cases

### 1. When the Type Is Obvious

```csharp
var person = new Person();
var numbers = new List<int>();
```

This is readable because the type is clear from the right-hand side.

### 2. With LINQ Queries

```csharp
var adults = people.Where(person => person.Age >= 18);
```

LINQ return types can be long, so `var` keeps the code cleaner.

### 3. With Anonymous Types

```csharp
var result = people.Select(person => new
{
    person.Name,
    person.Age
});
```

Anonymous types do not have a simple type name that you can write directly, so `var` is commonly used.

## When Not to Use `var`

Avoid `var` when it makes the code less clear.

Less clear:

```csharp
var result = GetData();
```

Clearer:

```csharp
List<Person> result = GetData();
```

Use the explicit type when it helps the reader understand the code faster.

## Where `var` Can Be Used

`var` is mainly used for local variables inside methods.

```csharp
public void PrintMessage()
{
    var message = "Hello";
    Console.WriteLine(message);
}
```

## Where `var` Cannot Be Used

### Method Parameters

```csharp
public void PrintName(var name) // Error
{
    Console.WriteLine(name);
}
```

Use the actual type:

```csharp
public void PrintName(string name)
{
    Console.WriteLine(name);
}
```

### Class Properties

```csharp
public class Person
{
    public var Name { get; set; } // Error
}
```

Use the actual type:

```csharp
public class Person
{
    public string Name { get; set; }
}
```

## Simple Explanation

> In C#, `var` allows the compiler to infer the variable type from the right-hand side. It does not mean the variable can hold any type. C# remains strongly typed, so once the type is inferred, it cannot change. I usually use `var` when the type is obvious, with LINQ queries, or with anonymous types. If using `var` makes the code less readable, I prefer writing the explicit type.

## Final Mental Rules

```text
var = type inference, not dynamic typing.
var must have an initial value.
var type is fixed after inference.
Use var when the type is obvious.
Use explicit types when clarity is better.
LINQ and anonymous types often use var.
```

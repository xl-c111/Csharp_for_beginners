# C# Missing Key Topics 

## 1. String Interpolation

### What is string interpolation?

String interpolation is a cleaner way to insert variables directly into a string.

Example:

```csharp
string name = "Alice";
int age = 25;

Console.WriteLine($"Name: {name}, Age: {age}");
```

Output:

```text
Name: Alice, Age: 25
```

Without interpolation, you might write:

```csharp
Console.WriteLine("Name: " + name + ", Age: " + age);
```

**Mental rule:**

> `$"..."` lets you put variables directly inside `{}`.

Strong answer:

> String interpolation improves readability when building strings with variables. It is commonly used in logging, console output, messages, and simple formatting.

---

## 2. `var` Keyword

### What is `var`?

`var` lets the compiler infer the variable type from the right-hand side.

Example:

```csharp
var name = "Alice";   // string
var age = 25;         // int
var price = 19.99;    // double
```

This does **not** mean the variable has no type. C# is still strongly typed.

```csharp
var age = 25;
age = "hello"; // invalid
```

**Mental rule:**

> `var` means compiler decides the type, not runtime.

Strong answer:

> I use `var` when the type is obvious from the right-hand side, especially with LINQ or object creation. But I avoid it when it makes the code harder to read.

Good use:

```csharp
var users = new List<User>();
```

Less clear:

```csharp
var result = service.GetData();
```

---

## 3. Access Modifiers

### What are access modifiers?

Access modifiers control where a class, method, or field can be accessed from.

Common ones:

| Modifier | Meaning |
|---|---|
| `public` | Accessible from anywhere |
| `private` | Accessible only inside the same class |
| `protected` | Accessible inside the class and subclasses |
| `internal` | Accessible inside the same project/assembly |
| `protected internal` | Accessible from same assembly or subclasses |

Example:

```csharp
public class User
{
    private string password;

    public string Name { get; set; }
}
```

**Mental rule:**

> Access modifiers control visibility.

Strong answer:

> I usually keep fields private and expose controlled access through public methods or properties. This supports encapsulation and prevents unsafe changes to object state.

---

## 4. Properties: `get`, `set`, `init`

### What are properties?

Properties provide controlled access to object data.

Example:

```csharp
public class User
{
    public string Name { get; set; }
}
```

This is cleaner than manually writing getter and setter methods.

### `init`

`init` means the property can only be set during object creation.

```csharp
public class User
{
    public string Name { get; init; }
}
```

Usage:

```csharp
var user = new User { Name = "Alice" };
```

After creation:

```csharp
user.Name = "Bob"; // invalid if Name has init only
```

**Mental rule:**

> `set` allows later changes. `init` only allows setup during creation.

Strong answer:

> Properties are commonly used in C# to expose object state. `init` is useful when I want an object to be immutable after creation.

---

## 5. Generics

### What are generics?

Generics allow classes, methods, and collections to work with different types while keeping type safety.

Example:

```csharp
List<string> names = new List<string>();
List<int> numbers = new List<int>();
```

The same `List<T>` class works with different types.

Generic method:

```csharp
public T GetFirst<T>(List<T> items)
{
    return items[0];
}
```

**Mental rule:**

> Generics let code work with many types safely.

Strong answer:

> Generics reduce duplication and improve type safety. Instead of using `object` and casting, we can use `T` and let the compiler check the type.

Bad old-style approach:

```csharp
ArrayList items = new ArrayList();
items.Add("Alice");
items.Add(123); // allowed, but risky
```

Better generic approach:

```csharp
List<string> names = new List<string>();
names.Add("Alice");
// names.Add(123); // compile-time error
```

---

## 6. `IEnumerable<T>` vs `List<T>`

### What is `IEnumerable<T>`?

`IEnumerable<T>` represents something that can be looped over.

```csharp
IEnumerable<string> names = new List<string> { "Alice", "Bob" };
```

It is more general than `List<T>`.

### Difference

| Type | Meaning |
|---|---|
| `IEnumerable<T>` | Can be iterated |
| `List<T>` | Concrete collection with storage and methods like `Add`, `Remove`, `Count` |

Example:

```csharp
public IEnumerable<User> GetUsers()
{
    return users.Where(user => user.IsActive);
}
```

**Mental rule:**

> `IEnumerable` means “you can read/loop”. `List` means “actual collection”.

Strong answer:

> I would return `IEnumerable<T>` when the caller only needs to iterate. I would use `List<T>` when I need list-specific operations like adding, removing, or indexing.

---

## 7. Deferred Execution in LINQ

### What is deferred execution?

Deferred execution means a LINQ query is not executed immediately. It runs when you actually enumerate it.

Example:

```csharp
var numbers = new List<int> { 1, 2, 3, 4 };

var query = numbers.Where(n => n > 2);

numbers.Add(5);

foreach (var number in query)
{
    Console.WriteLine(number);
}
```

Output:

```text
3
4
5
```

The query includes `5` because it runs later during the `foreach`.

**Mental rule:**

> LINQ query runs when you use it, not always when you write it.

To execute immediately:

```csharp
var result = numbers.Where(n => n > 2).ToList();
```

Strong answer:

> Deferred execution is useful because it avoids unnecessary work, but it can surprise people if the underlying data changes before the query is enumerated.

---

## 8. Common LINQ Methods

You should know these at associate level.

### `Where`

Filters data.

```csharp
var adults = people.Where(p => p.Age >= 18);
```

### `Select`

Transforms data.

```csharp
var names = people.Select(p => p.Name);
```

### `OrderBy`

Sorts data.

```csharp
var sorted = people.OrderBy(p => p.Age);
```

### `GroupBy`

Groups data.

```csharp
var groups = people.GroupBy(p => p.Department);
```

### `FirstOrDefault`

Gets the first matching item or default value.

```csharp
var user = users.FirstOrDefault(u => u.Id == id);
```

### `Any`

Checks whether at least one item matches.

```csharp
bool hasAdults = people.Any(p => p.Age >= 18);
```

**Mental rule:**

> `Where` filters, `Select` transforms, `OrderBy` sorts, `GroupBy` groups, `Any` checks existence.

Strong answer:

> LINQ helps write collection-processing code in a clear, declarative style. But I still need to understand performance and deferred execution.

---

## 9. Extension Methods

### What are extension methods?

Extension methods allow you to add methods to an existing type without modifying the original class.

Example:

```csharp
public static class StringExtensions
{
    public static bool IsBlank(this string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
}
```

Usage:

```csharp
string name = " ";
bool result = name.IsBlank();
```

**Mental rule:**

> Extension method makes a static method look like an instance method.

Strong answer:

> Many LINQ methods, such as `Where` and `Select`, are extension methods on `IEnumerable<T>`.

---

## 10. `async` and `await`

### What are `async` and `await`?

`async` and `await` are used to write asynchronous code in a readable way.

Example:

```csharp
public async Task<string> GetDataAsync()
{
    string data = await httpClient.GetStringAsync("https://example.com");
    return data;
}
```

This allows the program to wait for I/O without blocking the thread.

**Mental rule:**

> `await` means: pause this method, not the whole thread.

Strong answer:

> `async` and `await` are especially useful for I/O-bound work such as database calls, API requests, and file operations. They improve scalability because threads are not blocked while waiting.

Common return types:

```csharp
public async Task DoWorkAsync()
public async Task<string> GetNameAsync()
```

Avoid:

```csharp
async void
```

except for event handlers.

---

## 11. `Task` vs `Thread`

### Difference between Task and Thread

A `Thread` is a lower-level execution unit.

A `Task` is a higher-level abstraction representing asynchronous or parallel work.

Example:

```csharp
Task task = Task.Run(() =>
{
    Console.WriteLine("Running work");
});
```

**Mental rule:**

> Thread is low-level worker. Task is higher-level work unit.

Strong answer:

> In modern C#, I usually use `Task` and `async/await` instead of manually creating threads. Manual threads are lower-level and harder to manage.

---

## 12. `using` and `IDisposable`

### What is `IDisposable`?

`IDisposable` is used for objects that need cleanup, such as files, database connections, or network resources.

Example:

```csharp
using var reader = new StreamReader("data.txt");
string content = reader.ReadToEnd();
```

At the end of the scope, `reader.Dispose()` is called automatically.

Older syntax:

```csharp
using (var reader = new StreamReader("data.txt"))
{
    string content = reader.ReadToEnd();
}
```

**Mental rule:**

> `using` means clean this resource automatically.

Strong answer:

> Garbage collection handles managed memory, but some resources like files or database connections should be released promptly. `using` helps ensure `Dispose()` is called.

---

## 13. `is`, `as`, and Pattern Matching

### `is`

Checks whether an object is a certain type.

```csharp
if (obj is User user)
{
    Console.WriteLine(user.Name);
}
```

### `as`

Attempts to cast and returns `null` if it fails.

```csharp
User user = obj as User;

if (user != null)
{
    Console.WriteLine(user.Name);
}
```

Modern C# often prefers pattern matching with `is`.

**Mental rule:**

> `is` checks and safely captures. `as` tries and returns null.

Strong answer:

> Pattern matching with `is` is usually clearer because it checks the type and creates a strongly typed variable in one step.

---

## 14. `record` vs `class`

### What is a record?

A record is a reference type designed mainly for immutable data models and value-based equality.

Example:

```csharp
public record UserDto(int Id, string Name);
```

Two records with the same values are considered equal.

```csharp
var a = new UserDto(1, "Alice");
var b = new UserDto(1, "Alice");

Console.WriteLine(a == b); // true for records
```

**Mental rule:**

> Class usually means identity/object behavior. Record usually means data/value.

Strong answer:

> I would use a record for simple data-carrying objects, DTOs, or immutable models. I would use a class when the object has identity, behavior, or mutable state.

---

## 15. `struct` vs `class`

### Difference between struct and class

| Feature | struct | class |
|---|---|---|
| Type category | Value type | Reference type |
| Stored | Often stack or inline | Heap |
| Null by default | No, unless nullable | Yes |
| Best for | Small immutable values | Objects with identity/behavior |

Example:

```csharp
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}
```

**Mental rule:**

> struct = small value. class = object with identity.

Strong answer:

> I would use structs for small, simple values. For most business objects, I would use classes.

---

## 16. `enum`

### What is an enum?

An enum defines a set of named constants.

Example:

```csharp
public enum OrderStatus
{
    Pending,
    Paid,
    Shipped,
    Cancelled
}
```

Usage:

```csharp
OrderStatus status = OrderStatus.Paid;
```

**Mental rule:**

> enum gives names to fixed options.

Strong answer:

> Enums make code clearer and safer than using magic strings or numbers for fixed categories.

Bad:

```csharp
string status = "paid";
```

Better:

```csharp
OrderStatus status = OrderStatus.Paid;
```

---

## 17. Nullable Types

### Nullable value types

Value types normally cannot be null.

```csharp
int age = null; // invalid
```

But nullable value types can be null:

```csharp
int? age = null;
```

### Nullable reference types

```csharp
string name = "Alice";
string? optionalName = null;
```

**Mental rule:**

> `?` means this value may be missing.

Strong answer:

> Nullable types help make missing data explicit. This is especially useful when dealing with database values, optional fields, and API responses.

---

## 18. `ref` and `out`

### `ref`

`ref` passes a variable by reference. The variable must already be assigned.

```csharp
public void AddOne(ref int number)
{
    number++;
}
```

Usage:

```csharp
int x = 10;
AddOne(ref x);
```

### `out`

`out` is used when a method needs to return an additional value. The variable does not need to be assigned before the call.

```csharp
bool success = int.TryParse("123", out int number);
```

**Mental rule:**

> `ref` means pass existing value by reference.  
> `out` means method will assign the value.

Strong answer:

> `out` is commonly used in Try-pattern methods like `int.TryParse`, where we want to return success/failure and also output a parsed value.

---

## 19. `TryParse` Pattern

### What is `TryParse`?

`TryParse` safely tries to convert a string into another type without throwing an exception for normal invalid input.

Example:

```csharp
bool success = int.TryParse("123", out int number);

if (success)
{
    Console.WriteLine(number);
}
```

For invalid input:

```csharp
bool success = int.TryParse("abc", out int number);
```

This returns `false` instead of throwing an exception.

**Mental rule:**

> Use `TryParse` when failure is expected and normal.

Strong answer:

> I prefer `TryParse` over `Parse` when user input may be invalid, because invalid input should not always be treated as an exceptional situation.

---

## 20. Value Equality vs Reference Equality

### Reference equality

Two variables point to the same object.

```csharp
var a = new User(1);
var b = a;

Console.WriteLine(object.ReferenceEquals(a, b)); // true
```

### Value equality

Two objects have the same meaningful values.

```csharp
var a = new User(1);
var b = new User(1);
```

They are different objects, but we may consider them logically equal if their IDs are the same.

**Mental rule:**

> Reference equality = same object.  
> Value equality = same meaning.

Strong answer:

> For domain objects, equality should be designed carefully. Sometimes identity matters, such as user ID. Sometimes all values matter, such as records or value objects.

---

## 21. ASP.NET Core Basics

For an Associate Software Engineer, especially backend roles, basic ASP.NET Core knowledge is useful.

### What is ASP.NET Core?

ASP.NET Core is a framework for building web APIs and web applications in C#.

Example controller:

```csharp
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        return Ok(new { Id = id, Name = "Alice" });
    }
}
```

**Mental rule:**

> ASP.NET Core is the C# framework for web APIs.

Strong answer:

> I understand that ASP.NET Core handles routing, controllers, dependency injection, middleware, configuration, and request/response processing.

---

## 22. Dependency Injection in ASP.NET Core

ASP.NET Core has built-in dependency injection.

Example registration:

```csharp
builder.Services.AddScoped<IUserService, UserService>();
```

Usage:

```csharp
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }
}
```

**Mental rule:**

> Register dependency once, inject it where needed.

Common lifetimes:

| Lifetime | Meaning |
|---|---|
| Singleton | One instance for the whole app |
| Scoped | One instance per request |
| Transient | New instance every time |

Strong answer:

> In web applications, scoped is commonly used for services that work within one request, especially when they depend on database contexts.

---

## 23. Middleware

### What is middleware?

Middleware is code that runs during the HTTP request/response pipeline.

Examples:

- authentication,
- authorization,
- logging,
- error handling,
- routing.

Conceptual flow:

```text
Request
  ↓
Middleware 1
  ↓
Middleware 2
  ↓
Controller
  ↓
Response
```

**Mental rule:**

> Middleware is a chain that each request passes through.

Strong answer:

> Middleware lets us handle cross-cutting concerns like logging, authentication, and error handling in one place instead of duplicating logic in every controller.

---

# Common C# Interview “Good to Know” List

## Core language

- `var`
- string interpolation
- access modifiers
- field vs property
- `get`, `set`, `init`
- value type vs reference type
- boxing and unboxing
- nullable types
- `struct`, `class`, `record`
- `enum`
- `ref` and `out`
- `TryParse`

## Collections and LINQ

- `IEnumerable<T>` vs `List<T>`
- deferred execution
- common LINQ methods:
  - `Where`
  - `Select`
  - `OrderBy`
  - `GroupBy`
  - `FirstOrDefault`
  - `Any`
- extension methods

## Async and concurrency

- `Task`
- `async` / `await`
- `Task` vs `Thread`
- `lock`
- deadlock
- `ConcurrentDictionary`

## Object-oriented design

- access modifiers
- properties
- abstract class vs interface
- dependency injection
- design patterns
- equality design

## .NET / backend basics

- .NET SDK vs Runtime vs CLR
- garbage collection
- `IDisposable`
- `using`
- ASP.NET Core basics
- controllers
- middleware
- dependency injection lifetimes

---

# Final Add-On Summary

If I were interviewing an Associate Software Engineer for C#, and they already knew the main list, I would be even more confident if they could also explain:

> C# is not just “Java with different syntax.” Good C# code uses properties, LINQ, nullable types, async/await, dependency injection, and .NET conventions. For an associate role, I would expect the candidate to understand the basics of these features and know when they improve readability, safety, or maintainability.

A strong self-summary would be:

> In addition to core OOP, collections, exceptions, memory, and concurrency, I am also familiar with C#-specific features such as properties, string interpolation, `var`, LINQ, async/await, nullable types, records, and dependency injection. I understand these at an application level and can explain why they are useful in real code, especially for building maintainable backend applications with .NET.

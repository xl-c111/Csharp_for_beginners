# C# Data Types Cheat Sheet

## 1. Main Categories

C# data types can be grouped into several main categories:

| Category | Meaning | Examples |
|---|---|---|
| Value types | Store the actual value directly | `int`, `double`, `bool`, `char` |
| Reference types | Store a reference to an object | `string`, `class`, `array`, `List<T>` |
| Nullable types | Allow a value type to be `null` | `int?`, `bool?`, `double?` |
| Custom types | Types you define yourself | `class`, `struct`, `enum`, `record` |

---

## 2. Integer Types

Integer types store whole numbers.

| Type | Meaning | Example |
|---|---|---|
| `int` | Most common whole number type | `int age = 30;` |
| `long` | Larger whole number | `long population = 8000000000;` |
| `short` | Smaller whole number | `short score = 100;` |
| `byte` | Whole number from 0 to 255 | `byte level = 5;` |

### Example

```csharp
int age = 25;
long bigNumber = 9000000000;
short score = 100;
byte level = 5;
```

### Beginner Rule

Use `int` for most whole numbers unless you clearly need a larger or smaller type.

---

## 3. Decimal Number Types

Decimal number types store numbers with decimal points.

| Type | Meaning | Example |
|---|---|---|
| `double` | Most common decimal number type | `double height = 1.75;` |
| `float` | Smaller decimal number, needs `f` | `float price = 9.99f;` |
| `decimal` | Best for money, needs `m` | `decimal salary = 5000.50m;` |

### Example

```csharp
double height = 1.75;
float temperature = 36.5f;
decimal price = 19.99m;
```

### Beginner Rule

Use:

- `double` for normal decimal numbers
- `decimal` for money or financial calculations
- `float` only when specifically needed

---

## 4. Boolean Type

`bool` stores only two possible values:

```csharp
true
false
```

### Example

```csharp
bool isActive = true;
bool isLocked = false;
```

### Common Usage

```csharp
if (isActive)
{
    Console.WriteLine("User is active.");
}
```

### Beginner Rule

Use `bool` when something is a yes/no or true/false condition.

---

## 5. Character Type

`char` stores one single character.

### Example

```csharp
char grade = 'A';
char symbol = '#';
char initial = 'T';
```

### Important Rule

Use single quotes for `char`:

```csharp
char letter = 'A';
```

Do not use double quotes for `char`:

```csharp
char letter = "A"; // Error
```

---

## 6. String Type

`string` stores text.

### Example

```csharp
string name = "Tong";
string message = "Hello";
```

### Important Rule

Use double quotes for `string`:

```csharp
string word = "Hello";
```

### `char` vs `string`

| Type | Meaning | Quotes | Example |
|---|---|---|---|
| `char` | One character | Single quotes | `'A'` |
| `string` | Text | Double quotes | `"Hello"` |

---

## 7. Object Type

`object` can store values of any type.

### Example

```csharp
object value1 = 123;
object value2 = "Hello";
object value3 = true;
```

---

## 8. Arrays

An array stores multiple values of the same type.

### Example

```csharp
int[] numbers = { 1, 2, 3 };
string[] names = { "Alice", "Ben", "Cathy" };
```

### Access Array Values

```csharp
Console.WriteLine(numbers[0]); // 1
Console.WriteLine(names[1]);   // Ben
```

### Beginner Rule

Arrays have a fixed size. If you need to add or remove items often, use `List<T>` instead.

---

## 9. Lists

`List<T>` stores multiple values of the same type, but it is more flexible than an array.

### Example

```csharp
List<string> names = new List<string>();

names.Add("Alice");
names.Add("Ben");
names.Add("Cathy");
```

### Access List Values

```csharp
Console.WriteLine(names[0]); // Alice
```

### Beginner Rule

Use `List<T>` when you need a collection that can `grow` or `shrink`.

---

## 10. Dictionaries

`Dictionary<TKey, TValue>` stores key-value pairs.

### Example

```csharp
Dictionary<string, int> ages = new Dictionary<string, int>();

ages["Alice"] = 25;
ages["Ben"] = 30;
```
### Add or Update a value
```csharp
// add a value
ages["David"] = 35;
// update an existing value
ages["Alice"] = 26;
```
### Access Dictionary Values by key

```csharp
Console.WriteLine(ages["Alice"]); // 26
```
### Access Dictionary Values by `TryGetValue`
```csharp
if (ages.TryGetValue("Alice", out int age))
{
    Console.WriteLine(age);
}
else
{
    Console.WriteLine("Alice was not found.");
}
```

### Loop through keys 
You can access all keys using `.Keys`.

```csharp
foreach (string name in ages.Keys){
    Console.WriteLine(name);
}
```
### loop through values 
You can access all values using `.Values`.

```csharp
foreach (int age in ages.Values){
    Console.WriteLine(age);
}
```

### loop through key-value pairs
You can access all values using `pair`.

```csharp
foreach (var pair in ages){
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}
```
### Remove a key-value pair
```csharp
ages.Remove("Ben");
```
### Check whether a key exists
```csharp
if (ages.ContainsKey("Alice")){
    Console.WriteLine("Alice exists.");
}
```

### Check whether a value exists
```csharp
if (ages.ContainsValue(30)){
    Console.WriteLine("Someone is 30 years old.");
}
```
---

## 11. Custom Class Types

You can create your own type using `class`.

### Example

```csharp
class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

### Use the Class

```csharp
User user1 = new User();

user1.Name = "Tong";
user1.Age = 30;
```

### Beginner Rule

Use a class when you want to model a real-world thing, such as:

- User
- Product
- Order
- Customer
- BankAccount

---

## 12. Enum Types

`enum` is used when a value should be one of several fixed options.

### Example

```csharp
enum OrderStatus
{
    Pending,
    Paid,
    Shipped,
    Cancelled
}
```

### Use the Enum

```csharp
OrderStatus status = OrderStatus.Paid;
```

### Beginner Rule

Use `enum` when you have a fixed list of possible values.

Examples:

```csharp
enum UserRole
{
    Admin,
    Customer,
    Guest
}
```

```csharp
enum PaymentStatus
{
    Pending,
    Completed,
    Failed
}
```

---

## 13. Nullable Types

Normally, value types like `int`, `bool`, and `double` cannot be `null`.

```csharp
int age = null; // Error
```

You can use `?` to allow `null`.

### Example

```csharp
int? age = null;
bool? isActive = null;
double? score = null;
```

For strings:

```csharp
string? name = null;
```

### Beginner Rule

Use nullable types when a value may be missing or unknown.

Example:

```csharp
int? middleNameLength = null;
```
---

## 14. Simple Interview Answer

### Question

What are the common data types in C#?

### Answer

C# has several common data types. For whole numbers, we often use `int` or `long`. For decimal numbers, we use `double`, `float`, or `decimal`, where `decimal` is usually preferred for money. For true or false values, we use `bool`. For single characters, we use `char`, and for text, we use `string`.

C# also supports arrays and collections such as `List<T>` and `Dictionary<TKey, TValue>`. In object-oriented programming, we can define our own custom types using `class`, `struct`, `enum`, or `record`.

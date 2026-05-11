# C# Hello World and Strings Cheat Sheet

## 1. String values

A string is a sequence of characters used to store text data.

```csharp
string name = "Bill";
Console.WriteLine(name);
```

Meaning:

```text
string = the type
name   = the variable name
"Bill" = the value stored in the variable
```

---

## 2. Variables

A variable is a named storage location for a value.

```csharp
string aFriend = "Bill";
Console.WriteLine(aFriend);

aFriend = "Maira";
Console.WriteLine(aFriend);
```

The same variable can store a new value later.

---

## 3. String concatenation

You can combine strings using `+`.

```csharp
string aFriend = "Maira";
Console.WriteLine("Hello " + aFriend);
```
---

## 4. String interpolation

String interpolation lets you insert variables directly inside a string. It makes string formatting cleaner and easier to read than using many `+` operators.

```csharp
string aFriend = "Maira";
Console.WriteLine($"Hello {aFriend}");
```

Important syntax:

```text
$ before the string
{ } around the variable
```

Mental rule:

> `$"Hello {name}"` means C# replaces `{name}` with the value of `name`.


---

## 5. Multiple variables in one string

```csharp
string firstFriend = "Maria";
string secondFriend = "Sage";

Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");
```

Output:

```text
My friends are Maria and Sage
```

---

## 6. String length

`Length` returns the number of characters in a string.

```csharp
string firstFriend = "Maria";

Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters.");
```

Output:

```text
The name Maria has 5 letters.
```

Mental rule:

> `someString.Length` gives the number of characters.

---

## 7. Methods and properties

A method performs an action.

```csharp
Console.WriteLine("Hello");
```

`WriteLine()` is a method.

A property stores information about an object.

```csharp
firstFriend.Length
```

`Length` is a property.

Simple difference:

```text
Method   = does something
Property = gives information
```

---

## 8. Removing whitespace

Whitespace means spaces, tabs, or similar invisible characters.

```csharp
string greeting = "      Hello World!       ";

Console.WriteLine(greeting.TrimStart());
Console.WriteLine(greeting.TrimEnd());
Console.WriteLine(greeting.Trim());
```

Meaning:

```text
TrimStart() = removes spaces at the start
TrimEnd()   = removes spaces at the end
Trim()      = removes spaces at both start and end
```

Important point:

> String methods return a new string. They do not change the original string in place.

Example:

```csharp
string greeting = "      Hello World!       ";
string trimmedGreeting = greeting.Trim();

Console.WriteLine(greeting);        // original string
Console.WriteLine(trimmedGreeting); // new trimmed string
```

Mental Rule:

> In C#, strings are immutable, so methods like `Trim()` and `Replace()` return a new string rather than modifying the original one.

---

## 9. Replace text in a string

`Replace()` searches for text and replaces it with new text.

```csharp
string sayHello = "Hello World!";
sayHello = sayHello.Replace("Hello", "Greetings");

Console.WriteLine(sayHello);
```

Output:

```text
Greetings World!
```

Syntax:

```csharp
someString.Replace("old text", "new text");
```

---

## 10. Convert case

```csharp
string message = "Hello World!";

Console.WriteLine(message.ToUpper());
Console.WriteLine(message.ToLower());
```

Output:

```text
HELLO WORLD!
hello world!
```

Use cases:

```text
ToUpper() = normalize text for comparison or display
ToLower() = normalize text for comparison or display
```

---

## 11. Search inside strings

`Contains()` checks whether a string contains some text.

```csharp
string songLyrics = "You say goodbye, and I say hello";

Console.WriteLine(songLyrics.Contains("goodbye"));
Console.WriteLine(songLyrics.Contains("greetings"));
```

Output:

```text
True
False
```

`Contains()` returns a `bool`.

```text
bool = true or false value
```

---

## 12. StartsWith and EndsWith

`StartsWith()` checks the beginning of a string.

`EndsWith()` checks the end of a string.

```csharp
string songLyrics = "You say goodbye, and I say hello";

Console.WriteLine(songLyrics.StartsWith("You"));      // True
Console.WriteLine(songLyrics.StartsWith("goodbye"));  // False

Console.WriteLine(songLyrics.EndsWith("hello"));      // True
Console.WriteLine(songLyrics.EndsWith("goodbye"));    // False
```

Mental rule:

```text
Contains()   = anywhere in the string
StartsWith() = beginning only
EndsWith()   = end only
```

---

## 13. Common questions

### Q1. What does `Console.WriteLine()` do?

`Console.WriteLine()` prints a line of text to the console.

---

### Q2. What is a variable?

A variable is a named place to store a value. The value can be used later and can often be changed.

Example:

```csharp
string name = "Bill";
name = "Maira";
```

---

### Q3. What is a string?

A string is a type used to store text.

Example:

```csharp
string message = "Hello";
```

---

### Q4. What is string interpolation?

String interpolation is a clean way to insert variables into a string.

```csharp
string name = "Maira";
Console.WriteLine($"Hello {name}");
```

The `$` allows C# to replace `{name}` with the variable value.

---

### Q5. What is the difference between a method and a property?

A method performs an action.

```csharp
message.ToUpper()
```

A property gives information.

```csharp
message.Length
```

Simple rule:

> Method does something. Property describes something.

---

### Q6. Are C# strings mutable?

No. C# strings are immutable. Methods such as `Trim()` and `Replace()` return a new string instead of changing the original string directly.

---

### Q7. What does `Contains()` return?

`Contains()` returns a `bool`: either `true` or `false`.

```csharp
string text = "Hello World";
Console.WriteLine(text.Contains("World")); // True
```

---

## Final mental model

```text
Console.WriteLine() = print output
string              = text type
variable            = named storage for a value
$"Hello {name}"     = string interpolation
.Length             = number of characters
Trim()              = remove outer spaces
Replace()           = replace text
ToUpper()/ToLower() = change text case
Contains()          = search anywhere
StartsWith()        = check beginning
EndsWith()          = check ending
```



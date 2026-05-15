# C# `List<T>` Collection Cheat Sheet

## 1. What is `List<T>`?

`List<T>` is a generic collection in C# used to store a sequence of elements of the same type.

```csharp
List<string> names = ["Coco", "Anna", "Ben"];
```

Here, `T` is `string`, so this list can only store strings.

**Mental rule:**  
`List<T>` means “a resizable list of one specific type”.

Examples:

```csharp
List<string> names = ["Coco", "Anna", "Ben"];
List<int> numbers = [1, 2, 3];
List<double> scores = [88.5, 91.0, 76.5];
```

---

## 2. Why use `List<T>` instead of an array?

A `List<T>` can grow or shrink. You can add and remove items after creating it.

```csharp
names.Add("Maria");
names.Remove("Anna");
```

An array has a fixed size once created.

**Mental rule:**  
Use an array when the size is fixed. Use `List<T>` when the size may change.

---

## 3. Looping through a list

The most common way to read every item is `foreach`.

```csharp
foreach (var name in names)
{
    Console.WriteLine($"Hello {name}");
}
```

`foreach` is useful when you only need the item, not the index.

**Mental rule:**  
Use `foreach` when you want to visit every item safely and simply.

---

## 4. Accessing items by index

You can access a specific item using square brackets.

```csharp
Console.WriteLine(names[0]);
Console.WriteLine(names[1]);
```

C# indexes start at `0`.

For a list with 3 items:

```text
Index:  0       1       2
Value: Coco    Anna    Ben
```

**Mental rule:**  
First item is index `0`; last item is `Count - 1`.

```csharp
var lastName = names[names.Count - 1];
```

---

## 5. `Count`

`Count` tells you how many items are in the list.

```csharp
Console.WriteLine(names.Count);
```

Do not confuse this with the last index.

```csharp
int lastIndex = names.Count - 1;
```

**Mental rule:**  
`Count` is the number of items.  
`Count - 1` is the last valid index.

---

## 6. Avoid accessing outside the list

This is wrong if the list has only 3 items:

```csharp
Console.WriteLine(names[3]);
```

Valid indexes would be:

```text
0, 1, 2
```

Trying to access past the end of the list causes an error.

**Mental rule:**  
Before using an index, make sure it is between `0` and `Count - 1`.

---

## 7. Adding items

`Add()` appends an item to the end of the list.

```csharp
names.Add("Maria");
```

If the list was:

```text
Coco, Anna, Ben
```

After adding Maria:

```text
Coco, Anna, Ben, Maria
```

**Mental rule:**  
`Add()` means “put this at the end”.

---

## 8. Removing items

`Remove()` removes the first matching item.

```csharp
names.Remove("Anna");
```

If `"Anna"` exists, it is removed. If it does not exist, nothing major happens; the method returns `false`.

```csharp
bool removed = names.Remove("Anna");
```

**Mental rule:**  
`Remove(value)` removes by value, not by index.

---

## 9. Searching with `IndexOf`

`IndexOf()` searches for an item and returns its index.

```csharp
int index = names.IndexOf("Ben");
```

If the item is found, it returns the index.

If the item is not found, it returns `-1`.

```csharp
if (index == -1)
{
    Console.WriteLine("Not found");
}
else
{
    Console.WriteLine($"Found at index {index}");
}
```

**Mental rule:**  
Always check for `-1` before using the result of `IndexOf`.

Bad:

```csharp
Console.WriteLine(names[index]);
```

Better:

```csharp
if (index != -1)
{
    Console.WriteLine(names[index]);
}
```

---

## 10. Sorting a list

`Sort()` sorts the list in place.

```csharp
names.Sort();
```

For strings, it sorts alphabetically.

Important: `Sort()` changes the original list.

```csharp
names.Sort();

foreach (var name in names)
{
    Console.WriteLine(name);
}
```

**Mental rule:**  
`Sort()` does not create a new sorted list; it modifies the existing list.

---

## 11. Lists can store different types

`List<T>` can store any type, but each list has one element type.

```csharp
List<int> fibonacciNumbers = [1, 1];
```

You can then work with numbers:

```csharp
var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

fibonacciNumbers.Add(previous + previous2);
```

**Mental rule:**  
`List<string>` stores strings.  
`List<int>` stores integers.  
`List<Player>` stores Player objects.

---

## 12. Common example: Fibonacci list

```csharp
List<int> fibonacciNumbers = [1, 1];

while (fibonacciNumbers.Count < 20)
{
    var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
    var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

    fibonacciNumbers.Add(previous + previous2);
}

foreach (var number in fibonacciNumbers)
{
    Console.WriteLine(number);
}
```

Key idea:

```csharp
fibonacciNumbers[fibonacciNumbers.Count - 1]
```

means “get the last number”.

```csharp
fibonacciNumbers[fibonacciNumbers.Count - 2]
```

means “get the second last number”.

**Mental rule:**  
Use `Count - 1` and `Count - 2` when you need the last two items.

---

# Associate Interview-Level Takeaways

## You should be able to explain this clearly

`List<T>` is a generic, resizable collection. It stores items of one type, supports adding and removing items, allows index-based access, and provides useful methods such as `Add`, `Remove`, `IndexOf`, and `Sort`.

A good interview answer:

> In C#, `List<T>` is a generic collection that stores items of a specific type. Unlike an array, it can grow or shrink dynamically. We can add items using `Add`, remove items using `Remove`, access items by zero-based index, check the size using `Count`, search with `IndexOf`, and sort with `Sort`.

---

# Common Interview Questions

## 1. What does `T` mean in `List<T>`?

`T` is the type of item stored in the list.

```csharp
List<string> names;
List<int> numbers;
```

**Mental rule:**  
`T` answers: “What type of thing does this list hold?”

---

## 2. What is the difference between `List<T>` and array?

An array has a fixed size. A `List<T>` can grow or shrink.

```csharp
int[] array = new int[3];
List<int> list = new List<int>();
```

Use `List<T>` when the number of items may change.

---

## 3. What happens if you access `names[names.Count]`?

It causes an error because the last valid index is `names.Count - 1`.

```csharp
names[names.Count] // Wrong
names[names.Count - 1] // Correct
```

**Mental rule:**  
`Count` is one past the last valid index.

---

## 4. What does `IndexOf` return if the item is not found?

It returns `-1`.

```csharp
int index = names.IndexOf("Unknown");

if (index == -1)
{
    Console.WriteLine("Not found");
}
```

---

## 5. Does `Sort()` return a new list?

No. `Sort()` changes the existing list.

```csharp
names.Sort();
```

**Mental rule:**  
`Sort()` mutates the list.

---

# Simple Mental Rules Summary

| Concept | Mental rule |
|---|---|
| `List<T>` | A resizable list of one type |
| `T` | The type of item stored |
| `Add()` | Add to the end |
| `Remove(value)` | Remove by value |
| `Count` | Number of items |
| Last index | `Count - 1` |
| `IndexOf()` | Returns index or `-1` |
| `Sort()` | Sorts the existing list |
| `foreach` | Best for reading every item |
| Array vs List | Array = fixed size; List = flexible size |

---

# Very short version for interview

> `List<T>` is a generic collection in C# that stores a sequence of items of the same type. It is more flexible than an array because it can grow or shrink. We can use `Add` to append items, `Remove` to delete items, `Count` to check the size, square brackets to access items by zero-based index, `IndexOf` to search, and `Sort` to order the list. A key thing to remember is that the last valid index is always `Count - 1`, and `IndexOf` returns `-1` when the item is not found.

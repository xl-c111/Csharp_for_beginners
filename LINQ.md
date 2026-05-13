# LINQ in C# — Cheat Sheet

## 1. What is LINQ?

**LINQ** stands for **Language Integrated Query**.

It lets you query data directly in C# using a consistent syntax.

You can use LINQ with:

- arrays
- lists
- collections
- XML
- databases through LINQ providers such as Entity Framework
- any data source that exposes `IEnumerable<T>` or `IQueryable<T>`

### Mental rule

> LINQ is a way to ask questions about data.

Example:

```csharp
var result = numbers.Where(num => num > 10);
```

This means:

> From `numbers`, give me only the numbers greater than 10.

---

## 2. What is a query?

A **query** describes:

1. where the data comes from
2. what data to retrieve
3. how to filter, sort, group, or transform the data

A query is **not always the result itself**.

Example:

```csharp
IEnumerable<int> highScoresQuery =
    from score in scores
    where score > 80
    orderby score descending
    select score;
```

This query says:

> From `scores`, keep scores greater than 80, order them descending, and return the score values.

### Mental rule

> A query is the instruction. The result is produced when the query runs.

---

## 3. Query syntax vs method syntax

C# supports two main LINQ styles.

### Query syntax

Query syntax looks more like SQL.

```csharp
IEnumerable<int> result =
    from num in numbers
    where num % 2 == 0
    orderby num
    select num;
```

### Method syntax

Method syntax uses method chaining.

```csharp
IEnumerable<int> result = numbers
    .Where(num => num % 2 == 0)
    .OrderBy(num => num);
```

Both examples return the same result.

### Mental rule

> Query syntax and method syntax are usually equivalent.
> Query syntax is often easier to read.
> Method syntax is often more common in real C# code.

---

## 4. Query Syntax vs Method Syntax Matching Rules
C# supports two main LINQ styles:


```csharp
// Query syntax
from item in collection
where condition
orderby sortKey
select result
```
Matches

```csharp
// Method syntax
collection
    .Where(eachItem => condition)              // Keep items that satisfy the condition
    .OrderBy(eachItem => sortKey)              // Sort items from small to large / A to Z
    .OrderByDescending(eachItem => sortKey)    // Sort items from large to small / Z to A
    .Select(eachItem => result)                // Transform each item into the result you want
    .Count();                                  // Count how many items are in the result
```

### Mental rule

> Query syntax is nice-looking syntax.
> Method syntax is what the compiler turns it into.

---

## 5. LINQ uses extension methods

Methods such as:

- `Where`
- `Select`
- `OrderBy`
- `GroupBy`
- `Join`
- `Count`
- `Max`
- `Average`

are standard LINQ query operators.

They are available through `System.Linq`.

```csharp
using System.Linq;
```

Even though `IEnumerable<T>` itself does not directly define a `Where` method, LINQ adds it as an **extension method**.

### Mental rule

> LINQ methods look like normal methods, but many are extension methods added by `System.Linq`.

---

## 6. Query variables

A **query variable** stores a query, not necessarily the final data.

Example:

```csharp
IEnumerable<int> scoreQuery =
    from score in scores
    where score > 80
    select score;
```

Here, `scoreQuery` is a query variable. It does not immediately store all matching scores. It stores the query `logic`.

The query runs when you iterate over it:

```csharp
foreach (int score in scoreQuery)
{
    Console.WriteLine(score);
}
```

### Mental rule

> If the variable type is `IEnumerable<T>` and it can be looped through later, it is likely a query variable.

---

## 7. Deferred execution

Many LINQ queries use **deferred execution**.

This means the query does not run when you define it. It runs when you iterate over it.

Example:

```csharp
var query = numbers.Where(num => num > 10);

foreach (int num in query)
{
    Console.WriteLine(num);
}
```

The query runs during the `foreach`.

### Important point

If the source data changes before the query is executed, the result may also change.

Example:

```csharp
var numbers = new List<int> { 1, 2, 3 };

var query = numbers.Where(num => num > 1);

numbers.Add(4);

foreach (int num in query)
{
    Console.WriteLine(num);
}
```

Output:

```text
2
3
4
```

### Mental rule

> LINQ often waits until the last moment to run.

---

## 8. Immediate execution

Some LINQ methods return a single value or a concrete collection. These execute immediately.

Examples:

```csharp
int count = numbers.Count(num => num > 10);
int max = numbers.Max();
double average = numbers.Average();
List<int> list = numbers.Where(num => num > 10).ToList();
```

Common immediate execution methods:

- `Count()`
- `Max()`
- `Min()`
- `Average()`
- `Sum()`
- `First()`
- `FirstOrDefault()`
- `Single()`
- `SingleOrDefault()`
- `ToList()`
- `ToArray()`

### Mental rule

> If LINQ returns one value or a real collection like `List<T>`, it executes now.

---

## 9. Basic query syntax structure

A query expression must:

1. start with `from`
2. end with `select` or `group`

Basic structure:

```csharp
var result =
    from item in source
    where condition
    orderby item
    select item;
```

### Required clauses

```csharp
from item in source
select item;
```

### Optional clauses

- `where`
- `orderby`
- `join`
- `let`
- extra `from`
- `into`

### Mental rule

> Query syntax starts with `from` and ends with `select` or `group`.

---

## 10. `from`

`from` chooses the data source and creates a range variable.

Example:

```csharp
var result =
    from name in names
    select name;
```

Here:

- `names` is the source
- `name` is the range variable
- `name` represents one item at a time

### Mental rule

> `from name in names` means: take one item at a time from the collection.

---

## 11. `where`

`where` filters data.

Example:

```csharp
var result =
    from num in numbers
    where num > 10
    select num;
```

Method syntax:

```csharp
var result = numbers.Where(num => num > 10);
```

Multiple conditions:

```csharp
var result = numbers.Where(num => num > 3 && num < 7);
```

### Mental rule

> `where` keeps only the items that make the condition true.

---

## 12. `orderby`

`orderby` sorts data.

Ascending order is the default.

```csharp
var result =
    from num in numbers
    orderby num
    select num;
```

This is the same as:

```csharp
var result =
    from num in numbers
    orderby num ascending
    select num;
```

Descending order:

```csharp
var result =
    from num in numbers
    orderby num descending
    select num;
```

Method syntax:

```csharp
var result = numbers.OrderBy(num => num);
var resultDescending = numbers.OrderByDescending(num => num);
```

### Mental rule

> No keyword means ascending by default.

---

## 13. Secondary sorting

You can sort by more than one value.

Query syntax:

```csharp
var result =
    from student in students
    orderby student.Age, student.Score descending
    select student;
```

Method syntax:

```csharp
var result = students
    .OrderBy(student => student.Age)
    .ThenByDescending(student => student.Score);
```

### Mental rule

> `OrderBy` starts sorting.
> `ThenBy` adds another sorting rule.

---

## 14. `select`

`select` decides the shape of the output.

### Return the original item

```csharp
var result =
    from student in students
    select student;
```

### Return one property

```csharp
var names =
    from student in students
    select student.Name;
```

### Transform the output

```csharp
var messages =
    from score in scores
    select $"The score is {score}";
```

### Return an anonymous type

```csharp
var result =
    from student in students
    select new
    {
        student.Name,
        student.Score
    };
```

### Mental rule

> `select` answers: what do I want each output item to look like?

---

## 15. Projection

A **projection** means transforming source data into another shape.

Example:

```csharp
var result = students.Select(student => student.Name);
```

This transforms:

```text
Student objects
```

into:

```text
student names
```

Another example:

```csharp
var result = students.Select(student => new
{
    student.Name,
    Passed = student.Score >= 60
});
```

### Mental rule

> Projection means selecting or reshaping the output.

---

## 16. `group`

`group` groups items by a key.

Example:

```csharp
var result =
    from student in students
    group student by student.Age;
```

Method syntax:

```csharp
var result = students.GroupBy(student => student.Age);
```

The result type is often:

```csharp
IEnumerable<IGrouping<TKey, TElement>>
```

Example loop:

```csharp
foreach (var group in result)
{
    Console.WriteLine($"Age: {group.Key}");

    foreach (var student in group)
    {
        Console.WriteLine(student.Name);
    }
}
```

### Mental rule

> `group.Key` is the value used to form the group.

---

## 17. `join`

`join` combines data from two sources using matching keys.

Example:

```csharp
var result =
    from student in students
    join department in departments
        on student.DepartmentId equals department.Id
    select new
    {
        student.Name,
        DepartmentName = department.Name
    };
```

### Important syntax

Use:

```csharp
on leftKey equals rightKey
```

Not:

```csharp
on leftKey == rightKey
```

### Mental rule

> `join` matches items from two collections using a common value.

---

## 18. `let`

`let` creates a temporary variable inside a query.

Example:

```csharp
var result =
    from name in names
    let firstName = name.Split(' ')[0]
    select firstName;
```

This is useful when:

- the expression is long
- you want to reuse a calculated value
- you want the query to read more clearly

### Mental rule

> `let` means: calculate this once and give it a name inside the query.

---

## 19. Multiple `from` clauses

Use multiple `from` clauses when each item contains another collection.

Example:

```csharp
var cityQuery =
    from country in countries
    from city in country.Cities
    where city.Population > 10000
    select city;
```

This means:

> Go through each country, then go through each city inside that country.

Method syntax usually uses `SelectMany`.

```csharp
var cityQuery = countries
    .SelectMany(country => country.Cities)
    .Where(city => city.Population > 10000);
```

### Mental rule

> Multiple `from` clauses flatten nested collections.

---

## 20. `into`

`into` continues a query after `group` or `select`.

Example:

```csharp
var result =
    from student in students
    group student by student.Age into ageGroup
    where ageGroup.Count() > 1
    select ageGroup;
```

Here:

- `group student by student.Age` creates groups
- `into ageGroup` gives those groups a new name
- the query continues using `ageGroup`

### Mental rule

> Use `into` when you need to keep querying after grouping or selecting.

---

## 21. Lambda expressions

Method syntax commonly uses lambda expressions.

Example:

```csharp
var result = numbers.Where(num => num > 10);
```

The lambda is:

```csharp
num => num > 10
```

Meaning:

> Take `num` as input and return whether `num > 10`.

Another example:

```csharp
var names = students.Select(student => student.Name);
```

Meaning:

> Take each student and return the student's name.

### Mental rule

> Left side of `=>` is the input.
> Right side of `=>` is the logic/result.

---

## 22. Common LINQ methods

### Filtering

```csharp
Where()
```

Example:

```csharp
var adults = students.Where(student => student.Age >= 18);
```

### Sorting

```csharp
OrderBy()
OrderByDescending()
ThenBy()
ThenByDescending()
```

Example:

```csharp
var result = students
    .OrderBy(student => student.Age)
    .ThenByDescending(student => student.Score);
```

### Projection

```csharp
Select()
```

Example:

```csharp
var names = students.Select(student => student.Name);
```

### Flattening

```csharp
SelectMany()
```

Example:

```csharp
var allCities = countries.SelectMany(country => country.Cities);
```

### Grouping

```csharp
GroupBy()
```

Example:

```csharp
var groups = students.GroupBy(student => student.Age);
```

### Joining

```csharp
Join()
```

Example:

```csharp
var result = students.Join(
    departments,
    student => student.DepartmentId,
    department => department.Id,
    (student, department) => new
    {
        student.Name,
        DepartmentName = department.Name
    });
```

### Aggregation

```csharp
Count()
Sum()
Average()
Min()
Max()
```

Example:

```csharp
int passCount = students.Count(student => student.Score >= 60);
```

### Materialization

```csharp
ToList()
ToArray()
```

Example:

```csharp
List<string> names = students
    .Select(student => student.Name)
    .ToList();
```

---

## 23. `Contains` in LINQ

`Contains` is useful when checking whether a value exists in another collection.

Example:

```csharp
int[] ids = { 1, 3, 5 };

var result = students.Where(student => ids.Contains(student.ID));
```

This means:

> Keep students whose ID is in the `ids` array.

### Mental rule

> `ids.Contains(student.ID)` means `student.ID` is one of the allowed IDs.

---

## 24. Mixed query syntax and method syntax

Sometimes you combine both styles.

Example:

```csharp
var count = (
    from num in numbers
    where num > 3 && num < 7
    select num
).Count();
```

Better method syntax:

```csharp
var count = numbers.Count(num => num > 3 && num < 7);
```

### Mental rule

> Use query syntax for readable filtering/sorting/grouping.
> Use method syntax for `Count`, `Max`, `Average`, `ToList`, and similar methods.

---

## 25. `var` with LINQ

`var` lets the compiler infer the type.

Example:

```csharp
var result = students.Where(student => student.Age >= 18);
```

The compiler understands the type from the right side.

This is especially useful with anonymous types:

```csharp
var result = students.Select(student => new
{
    student.Name,
    student.Score
});
```

You cannot easily write the explicit type for anonymous types, so `var` is required.

### Mental rule

> `var` does not mean dynamic.
> The type is still fixed at compile time.

---

## 26. `IEnumerable<T>` vs `IQueryable<T>`

### `IEnumerable<T>`

Usually used for in-memory collections.

Examples:

```csharp
List<int>
int[]
```

LINQ runs in C# memory.

### `IQueryable<T>`

Often used for database queries, such as Entity Framework.

The query can be translated into another language, such as SQL.

### Mental rule

> `IEnumerable<T>` usually means LINQ to objects.
> `IQueryable<T>` usually means LINQ that may be translated by a provider, such as a database provider.

---

## 27. Null handling in LINQ

Collections can contain `null`.

If you access a property on a null item, you may get a `NullReferenceException`.

Unsafe:

```csharp
var result = products.Select(product => product.Name);
```

If `product` is null, this can fail.

Safer:

```csharp
var result = products
    .Where(product => product != null)
    .Select(product => product.Name);
```

With nullable reference types, you may write:

```csharp
var result = products
    .Where(product => product is not null)
    .Select(product => product!.Name);
```

### Mental rule

> Filter out nulls before accessing properties.

---

## 28. Exceptions and LINQ execution

Because many LINQ queries use deferred execution, exceptions may happen when the query is executed, not when it is defined.

Example:

```csharp
var query = files.Select(file => SomeMethodThatMightThrow(file));

foreach (var item in query)
{
    Console.WriteLine(item);
}
```

If `SomeMethodThatMightThrow` throws, the exception happens during the `foreach`.

Safer pattern:

```csharp
try
{
    foreach (var item in query)
    {
        Console.WriteLine(item);
    }
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
```

### Mental rule

> For deferred LINQ queries, the risky part is often the loop, not the query definition.

---

## 29. Side effects in LINQ

Avoid methods inside LINQ that modify external state.

Avoid this style:

```csharp
var result = numbers.Select(num =>
{
    total += num;
    return num * 2;
});
```

Better:

```csharp
int total = numbers.Sum();
var doubled = numbers.Select(num => num * 2);
```

### Mental rule

> LINQ should describe data transformation, not secretly change things.

---

## 30. Common beginner mistakes

### Mistake 1: Forgetting that LINQ is often deferred

```csharp
var query = numbers.Where(num => num > 10);
```

This does not immediately run.

Use:

```csharp
var list = numbers.Where(num => num > 10).ToList();
```

when you want results now.

---

### Mistake 2: Using `Where` when you want a count

Wrong:

```csharp
var count = numbers.Where(num => num > 3 && num < 7);
```

This returns a filtered sequence, not a number.

Correct:

```csharp
var count = numbers.Count(num => num > 3 && num < 7);
```

---

### Mistake 3: Thinking `select` always returns the same type

```csharp
var result = students.Select(student => student.Name);
```

This returns names, not students.

---

### Mistake 4: Forgetting `ThenBy`

Wrong:

```csharp
var result = students
    .OrderBy(student => student.Age)
    .OrderBy(student => student.Score);
```

The second `OrderBy` starts a new ordering.

Better:

```csharp
var result = students
    .OrderBy(student => student.Age)
    .ThenBy(student => student.Score);
```

---

### Mistake 5: Using `==` in query syntax joins

Wrong:

```csharp
join department in departments
    on student.DepartmentId == department.Id
```

Correct:

```csharp
join department in departments
    on student.DepartmentId equals department.Id
```

---

## 31. Interview explanation: Query syntax vs method syntax

You can say:

> LINQ can be written using query syntax or method syntax. Query syntax looks more like SQL and can be easier to read for complex filtering, sorting, grouping, or joins. Method syntax uses extension methods such as `Where`, `Select`, and `OrderBy`, and is very common in real C# code. The compiler translates query syntax into method calls, so they are usually semantically equivalent.

---

## 32. Interview explanation: Deferred execution

You can say:

> Many LINQ queries use deferred execution. This means defining the query does not immediately run it. The query runs when we iterate over it, for example with `foreach`, or when we call a method such as `ToList`, `Count`, or `Max`. This is useful because it avoids unnecessary work, but we need to remember that changes to the source collection before execution can affect the result.

---

## 33. Interview explanation: `IEnumerable<T>`

You can say:

> `IEnumerable<T>` represents a sequence of items that can be iterated over. Many LINQ methods return `IEnumerable<T>`, which means the result can be used in a `foreach` loop. It is also closely related to deferred execution because the sequence may not be evaluated until it is enumerated.

---

## 34. Interview explanation: `Select` vs `Where`

You can say:

> `Where` filters items. It keeps or removes items based on a condition. `Select` transforms items. It decides what each output item should look like. So `Where` changes the number of items, while `Select` changes the shape of each item.

Example:

```csharp
var adults = students.Where(student => student.Age >= 18);
var names = students.Select(student => student.Name);
```

---

## 35. Interview explanation: `GroupBy`

You can say:

> `GroupBy` groups elements by a key. The result is a sequence of groups. Each group has a `Key`, and each group contains the items that share that key.

Example:

```csharp
var groups = students.GroupBy(student => student.Age);

foreach (var group in groups)
{
    Console.WriteLine(group.Key);
}
```

---

## 36. Small practice examples

Assume:

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

var students = new List<Student>
{
    new Student { ID = 1, Name = "Anna", Age = 20, Score = 85 },
    new Student { ID = 2, Name = "Ben", Age = 17, Score = 72 },
    new Student { ID = 3, Name = "Coco", Age = 22, Score = 95 }
};
```

### Get numbers greater than 5

```csharp
var result = numbers.Where(num => num > 5);
```

### Get even numbers sorted ascending

```csharp
var result = numbers
    .Where(num => num % 2 == 0)
    .OrderBy(num => num);
```

### Get student names only

```csharp
var result = students.Select(student => student.Name);
```

### Get adult students

```csharp
var result = students.Where(student => student.Age >= 18);
```

### Get names of students who passed

```csharp
var result = students
    .Where(student => student.Score >= 60)
    .Select(student => student.Name);
```

### Count numbers between 3 and 7

```csharp
var count = numbers.Count(num => num > 3 && num < 7);
```

### Find students whose IDs are in a list

```csharp
var ids = new List<int> { 1, 3 };

var result = students.Where(student => ids.Contains(student.ID));
```

### Sort students by score descending and return names

```csharp
var result = students
    .OrderByDescending(student => student.Score)
    .Select(student => student.Name);
```

---

## 37. High-yield mental rules

1. **LINQ asks questions about data.**
2. **`Where` filters.**
3. **`Select` transforms.**
4. **`OrderBy` sorts.**
5. **`GroupBy` groups.**
6. **`Join` combines two data sources.**
7. **`Count`, `Max`, `Average`, `ToList` execute the query.**
8. **Most `IEnumerable<T>` queries are deferred.**
9. **`var` is still strongly typed.**
10. **Query syntax starts with `from` and ends with `select` or `group`.**
11. **Method syntax uses lambda expressions.**
12. **The compiler translates query syntax into method calls.**

---

## 38. One-minute summary

LINQ is a C# feature for querying data from collections, databases, XML, and other sources. A LINQ query can filter, sort, group, join, or transform data. You can write LINQ using query syntax or method syntax. Query syntax starts with `from` and ends with `select` or `group`; method syntax uses extension methods such as `Where`, `Select`, and `OrderBy`. Many LINQ queries are deferred, meaning they run only when iterated or when methods such as `ToList`, `Count`, or `Max` are called. For interviews, the most important concepts are `IEnumerable<T>`, deferred execution, lambda expressions, `Where` vs `Select`, and query syntax vs method syntax.

---

## References

- Microsoft Learn: Query expression basics
- Microsoft Learn: Write LINQ queries

# C# Numbers Cheat Sheet

**For Associate Software Engineer Interview Prep**

Based on Microsoft’s C# numbers tutorial:  
<https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/numbers-in-csharp>

---

## 1. Main Numeric Types

| Type | Meaning | Best Used For |
|---|---|---|
| `int` | Whole numbers | Counts, indexes, IDs, simple integer math |
| `long` | Larger whole numbers | Large counts or values that may exceed `int` |
| `double` | Floating-point decimal numbers | Measurements, statistics, scientific calculations |
| `decimal` | High-precision decimal numbers | Money, prices, tax, financial calculations |

---

## 2. Integer Math with `int`

`int` stores whole numbers.

```csharp
int a = 18;
int b = 6;

int c = a + b;  // addition
c = a - b;      // subtraction
c = a * b;      // multiplication
c = a / b;      // division
```

Common operators:

```text
+   add
-   subtract
*   multiply
/   divide
%   remainder
```

**Mental rule:**

> `int` means whole-number math.

---

## 3. Integer Division

When both numbers are `int`, division gives an `int` result.

```csharp
int a = 7;
int b = 4;

Console.WriteLine(a / b);
```

Output:

```text
1
```

Not:

```text
1.75
```

Because C# removes the decimal part in integer division.

To get the remainder:

```csharp
int remainder = a % b;
Console.WriteLine(remainder); // 3
```

**Mental rule:**

> `int / int` gives `int`.

To get a decimal result, at least one value must be a decimal type:

```csharp
Console.WriteLine(7.0 / 4); // 1.75
```

---

## 4. Order of Operations

C# follows normal math rules.

```csharp
int result = 5 + 4 * 2;
Console.WriteLine(result); // 13
```

Multiplication happens before addition.

Use parentheses to control the order:

```csharp
int result = (5 + 4) * 2;
Console.WriteLine(result); // 18
```

**Mental rule:**

> Parentheses first, then `*` and `/`, then `+` and `-`.

---

## 5. Integer Limits and Overflow

`int` has a fixed range:

```csharp
int max = int.MaxValue;
int min = int.MinValue;
```

`int` cannot store numbers beyond its range. If a calculation goes too large, overflow can happen.

Example:

```csharp
int max = int.MaxValue;
int result = max + 3;
Console.WriteLine(result);
```

The result may be incorrect because the value exceeds the `int` range.

**Mental rule:**

> `int` is not infinite. Large calculations can overflow.

Mental Rule:

> If I expect values to exceed the `int` range, I would use a larger numeric type such as `long`, or check for overflow depending on the business requirement.

Example with `long`:

```csharp
int a = 2100000000;
int b = 2100000000;

long c = (long)a + b;
Console.WriteLine(c);
```

Why this works:

```text
(long)a converts a to long before addition.
Then C# performs long + int as long arithmetic.
```

**Mental rule:**

> The right-hand side is calculated first. The left-hand type does not automatically make the calculation safe.

---

## 6. `double`

`double` stores decimal numbers and can represent very large or very small values.

```csharp
// The result keeps the decimal part.
double a = 5;
double b = 4;
double c = 2;

double result = (a + b) / c;
Console.WriteLine(result); // 4.5
```

Use `double` for:

```text
measurements
statistics
probabilities
scientific calculations
geometry
machine learning
```

Example:

```csharp
double radius = 2.50;
double area = Math.PI * radius * radius;
Console.WriteLine(area);
```

**Mental rule:**

> Use `double` when approximate decimal math is acceptable.

---

## 7. `double` Rounding Issue

`double` is not always exact for decimal values.

```csharp
double third = 1.0 / 3.0;
Console.WriteLine(third);
```

The result is an approximation.

Mental Rule:

> `double` is fast and has a large range, but it may introduce small rounding errors because it represents floating-point numbers in binary.

Example:

```csharp
double a = 0.1;
double b = 0.2;
Console.WriteLine(a + b);
```

The result may not be exactly `0.3`.

---

## 8. `decimal`

`decimal` has a smaller range than `double`, but it gives better decimal precision.

```csharp
decimal c = 1.0M;
decimal d = 3.0M;

Console.WriteLine(c / d);
```

The `M` suffix means the number is a `decimal`.

```csharp
decimal price = 19.99M;
decimal tax = 0.10M;
decimal total = price * (1 + tax);
```

Without `M`, C# treats decimal-looking constants such as `1.0` as `double` by default.

**Mental rule:**

> Money uses `decimal`.

---

## 9. When to Use `decimal`

Use `decimal` when the value is counted in base-10 and exactness matters.

Common examples:

```text
money
price
salary
tax
interest rate
invoice amount
bank balance
financial calculation
```

Simple explanation:

> If humans count it in decimal and small rounding errors are not acceptable, use `decimal`.

Example:

```csharp
decimal price = 99.95M;
decimal discount = 0.15M;
decimal finalPrice = price * (1 - discount);
```

---

## 10. `double` vs `decimal`

| Question | Use |
|---|---|
| Is it money, price, tax, salary, invoice, or bank balance? | `decimal` |
| Is it measurement, probability, statistics, physics, or geometry? | `double` |
| Do I need speed and large numeric range? | `double` |
| Do I need accurate base-10 decimal calculation? | `decimal` |

Simple rule:

```text
Money -> decimal
Science / statistics / measurement -> double
Whole numbers -> int
Large whole numbers -> long
```

---

## 11. Type Suffixes

```csharp
decimal money = 10.50M;
```

`M` tells C#:

> This number is a `decimal`, not a `double`.

Mental Rule:
> The suffix matters because the compiler assumes decimal constants like `1.0` are `double` unless we explicitly mark them as `decimal`.

---

## 12. Common Questions

### Q1. What is the difference between `int`, `double`, and `decimal`?

`int` stores whole numbers. `double` stores approximate decimal numbers and is good for scientific or measurement-based calculations. `decimal` stores high-precision decimal numbers and is better for money or financial calculations.

---

### Q2. Why does `7 / 4` return `1` in C#?

Because both operands are `int`, so C# performs integer division. The decimal part is removed.

```csharp
Console.WriteLine(7 / 4); // 1
```

To get a decimal result:

```csharp
Console.WriteLine(7.0 / 4); // 1.75
```

---

### Q3. When would you use `decimal` instead of `double`?

I would use `decimal` for financial calculations, such as prices, tax, salary, invoice amounts, or bank balances, because decimal precision matters and small rounding errors are not acceptable.

---

### Q4. What is integer overflow?

Integer overflow happens when a calculation produces a value outside the range that `int` can store. The result may wrap around and become incorrect.

---

### Q5. Why do we use parentheses in numeric expressions?

Parentheses make the order of operations explicit. They also make the code easier to read and reduce misunderstanding.

```csharp
int result = (a + b) * c;
```

---

### Q6. Why do we write `(long)a + b` instead of just `long c = a + b`?

Because the right-hand side is calculated first.

If both `a` and `b` are `int`, then `a + b` is calculated as `int + int`. If the result is too large, overflow can happen before the value is stored in `long`.

```csharp
long c = (long)a + b;
```

This forces the calculation to use `long` arithmetic.

---

## 13. Final Mental Model

```text
int      = whole numbers
long     = bigger whole numbers
double   = fast approximate decimal numbers
decimal  = precise decimal numbers, especially money
```


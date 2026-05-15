# C# String and Null Checking Cheat Sheet

## 1. `string.IsNullOrWhiteSpace(value)`

Checks whether a string is:

- `null`
- empty: `""`
- only spaces, tabs, or new lines

```csharp
string.IsNullOrWhiteSpace(null);      // true
string.IsNullOrWhiteSpace("");        // true
string.IsNullOrWhiteSpace("   ");     // true
string.IsNullOrWhiteSpace("\t\n");   // true
string.IsNullOrWhiteSpace("abc");     // false
```

Use this when you want to reject input that has no meaningful content.

```csharp
if (string.IsNullOrWhiteSpace(username))
{
    Console.WriteLine("Username is required.");
}
```

---

## 2. `string.IsNullOrEmpty(value)`

Checks whether a string is:

- `null`
- empty: `""`

It does **not** treat spaces as empty.

```csharp
string.IsNullOrEmpty(null);   // true
string.IsNullOrEmpty("");     // true
string.IsNullOrEmpty("   ");  // false
string.IsNullOrEmpty("abc");  // false
```

Use this when spaces are allowed or when you only care about `null` and empty strings.

```csharp
if (string.IsNullOrEmpty(password))
{
    Console.WriteLine("Password cannot be empty.");
}
```

---

## 3. `value == null`

Checks whether the variable does not point to any object.

```csharp
string name = null;

if (name == null)
{
    Console.WriteLine("Name is null.");
}
```

This only checks `null`.

```csharp
string name = "";

name == null; // false
```

---

## 4. `value == ""`

Checks whether the string is exactly empty.

```csharp
string name = "";

if (name == "")
{
    Console.WriteLine("Name is empty.");
}
```

This does not check `null`.

```csharp
string name = null;

name == ""; // false
```

Usually, prefer one of these:

```csharp
string.IsNullOrEmpty(name);
string.IsNullOrWhiteSpace(name);
```

---

## 5. `value.Length == 0`

Checks whether the string has no characters.

```csharp
string name = "";

if (name.Length == 0)
{
    Console.WriteLine("Name is empty.");
}
```

This will crash if `name` is `null`.

```csharp
string name = null;

name.Length == 0; // error
```

Only use this when you are sure the string is not `null`.

---

## 6. `value.Trim().Length == 0`

Checks whether the string becomes empty after removing spaces at the beginning and end.

```csharp
"   ".Trim().Length == 0;      // true
"  abc  ".Trim().Length == 0;  // false
```

This will crash if the value is `null`.

```csharp
string name = null;

name.Trim().Length == 0; // error
```

Usually, prefer:

```csharp
string.IsNullOrWhiteSpace(name);
```

---

## 7. `value.Contains("abc")`

Checks whether a string contains certain text.

```csharp
string email = "tong@example.com";

email.Contains("@"); // true
email.Contains("#"); // false
```

Example:

```csharp
if (!email.Contains("@"))
{
    Console.WriteLine("Email is invalid.");
}
```

---

## 8. `value.StartsWith("abc")`

Checks whether a string starts with certain text.

```csharp
string url = "https://example.com";

url.StartsWith("https"); // true
```

Example:

```csharp
if (!url.StartsWith("https"))
{
    Console.WriteLine("URL should start with https.");
}
```

---

## 9. `value.EndsWith("abc")`

Checks whether a string ends with certain text.

```csharp
string fileName = "report.pdf";

fileName.EndsWith(".pdf"); // true
```

Example:

```csharp
if (!fileName.EndsWith(".pdf"))
{
    Console.WriteLine("File must be a PDF.");
}
```

---

## 10. `value.Equals(otherValue)`

Checks whether two strings have the same content.

```csharp
string a = "hello";
string b = "hello";

a.Equals(b); // true
```

A safer version when `a` might be `null`:

```csharp
string.Equals(a, b);
```

Example:

```csharp
if (string.Equals(inputPassword, password))
{
    Console.WriteLine("Password is correct.");
}
```

---

## 11. Case-insensitive comparison

Checks whether two strings are equal while ignoring uppercase and lowercase differences.

```csharp
string.Equals(
    input,
    "admin",
    StringComparison.OrdinalIgnoreCase
);
```

Example:

```csharp
if (string.Equals(role, "admin", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("User is admin.");
}
```

This treats these as equal:

```csharp
"Admin"
"ADMIN"
"admin"
```

---

## 12. `value.Length < number`

Checks whether a string is shorter than a required length.

```csharp
if (password.Length < 8)
{
    Console.WriteLine("Password must be at least 8 characters.");
}
```

Safer version:

```csharp
if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
{
    Console.WriteLine("Password is invalid.");
}
```

---

# Most Useful Rules

## Rule 1: For required text input, use this

```csharp
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Input is required.");
}
```

Use for:

- username
- name
- email
- title
- address

---

## Rule 2: For password length, check null/empty first

```csharp
if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
{
    Console.WriteLine("Password must be at least 8 characters.");
}
```

---

## Rule 3: For comparing strings safely, use `string.Equals`

```csharp
if (string.Equals(inputPassword, password))
{
    Console.WriteLine("Correct password.");
}
```

---

## Rule 4: For ignoring uppercase/lowercase, use this

```csharp
if (string.Equals(input, expected, StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Matched.");
}
```

---

# Quick Comparison Table

| Check | What it checks | Example |
|---|---|---|
| `value == null` | No object | `name == null` |
| `value == ""` | Empty string only | `name == ""` |
| `string.IsNullOrEmpty(value)` | Null or empty | `null`, `""` |
| `string.IsNullOrWhiteSpace(value)` | Null, empty, or spaces | `null`, `""`, `"   "` |
| `value.Length == 0` | Empty string | `""` |
| `value.Trim().Length == 0` | Empty after trimming spaces | `"   "` |
| `value.Contains("x")` | Contains text | `"hello".Contains("e")` |
| `value.StartsWith("x")` | Starts with text | `"hello".StartsWith("he")` |
| `value.EndsWith("x")` | Ends with text | `"file.pdf".EndsWith(".pdf")` |
| `string.Equals(a, b)` | Same content | `"hi"` and `"hi"` |
| `string.Equals(a, b, StringComparison.OrdinalIgnoreCase)` | Same content, ignoring case | `"Hi"` and `"hi"` |

---

# Simple Recommendation

For most beginner C# projects, remember these four first:

```csharp
string.IsNullOrWhiteSpace(value);
```

```csharp
string.IsNullOrEmpty(value);
```

```csharp
string.Equals(a, b);
```

```csharp
value.Length < 8;
```

These four are enough for many validation checks.

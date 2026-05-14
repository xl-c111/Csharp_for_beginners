# C# Modifiers — Clear Rules and Examples

This note summarises common C# modifiers using simple decision rules.

---

## Big Picture

C# modifiers answer questions such as:

- **Who can use this?**
- **Does this need object-specific data?**
- **Can child classes change it?**
- **Can this value change later?**
- **Does this method use `await`?**

---

# 1. Access Modifiers

Access modifiers decide **who can access a class, method, property, or field**.

---

## `public`

### Clear rule

> If other code needs to call or use it directly, make it `public`.

### Example

```csharp
public bool Login(string inputPassword)
{
    return inputPassword == password;
}
```

Outside code can call:

```csharp
user.Login("abc123");
```

### Common use cases

```csharp
public void Deposit(int amount)
public bool Withdraw(int amount)
public string GetUsername()
public int GetBalance()
```

### Mental rule

```text
This is a safe action I want other code to use → public
```

---

## `private`

### Clear rule

> If it is an internal detail or helper method, make it `private`.

### Example

```csharp
private bool IsPasswordCorrect(string inputPassword)
{
    return inputPassword == password;
}
```

Outside code should not call:

```csharp
user.IsPasswordCorrect("abc123"); // not allowed
```

Instead, outside code should call the safe public method:

```csharp
user.Login("abc123");
```

### Common use cases

```csharp
private string password;
private int failedLoginAttempts;
private void RecordFailedLogin()
private bool IsPasswordCorrect(string inputPassword)
```

### Mental rule

```text
This is internal logic, not part of the public API → private
```

---

## `protected`

### Clear rule

> If child classes need access, but normal outside code should not, use `protected`.

### Example

```csharp
class UserAccount
{
    protected bool IsStrongPassword(string password)
    {
        return password.Length >= 8;
    }
}

class AdminAccount : UserAccount
{
    public bool CheckPasswordRule(string password)
    {
        return IsStrongPassword(password);
    }
}
```

Outside code cannot call:

```csharp
user.IsStrongPassword("abc12345"); // not allowed
```

But a child class can call it.

### Mental rule

```text
Only this class and child classes need it → protected
```

---

## `internal`

### Clear rule

> If it should be visible inside this project, but hidden from other projects, use `internal`.

### Example

```csharp
internal class UserRepository
{
    public void Save(User user)
    {
        // save user
    }
}
```

### Simple explanation

```text
internal = public inside this project, private outside this project
```

### Common use cases

```csharp
internal class DatabaseConnection
internal class UserRepository
internal class FileStorageService
```

### Mental rule

```text
Useful inside this project, but not part of the external API → internal
```

---

# 2. Object Relationship Modifier

---

## `static`

### Clear rule

> If a method does not need object-specific fields/properties, and can do its job using only parameters or fixed constants, it can be `static`.

> If a method needs this object’s data, use non-static.

### Static example

```csharp
public static bool IsValidEmail(string email)
{
    return email.Contains("@");
}
```

Call it from the class:

```csharp
bool result = EmailHelper.IsValidEmail("test@example.com");
```

This method only uses the parameter `email`, so it does not need an object.

### Non-static example

```csharp
public bool Login(string inputPassword)
{
    return inputPassword == password;
}
```

`Login()` is non-static because it needs this user’s stored password.

### Mental rule

```text
Only uses parameters or fixed class rules → static
Uses this object’s data → non-static
```

---

# 3. Inheritance Modifiers

Inheritance modifiers control whether child classes can change behaviour.

---

## `virtual`

### Clear rule

> If the parent provides a default version, but child classes may customise it, use `virtual`.

### Example

```csharp
class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal sound");
    }
}
```

A child class can override it:

```csharp
class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof");
    }
}
```

### Mental rule

```text
Parent has default behaviour, child can change it → virtual
```

---

## `override`

### Clear rule

> If the child class is changing the parent’s method, use `override`.

### Example

```csharp
class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof");
    }
}
```

You can only use `override` if the parent method is marked as one of these:

```csharp
virtual
abstract
override
```

### Mental rule

```text
Child changes parent behaviour → override
```

---

## `abstract`

### Clear rule

> If the parent only defines the rule and child classes must implement it, use `abstract`.

### Example

```csharp
abstract class Animal
{
    public abstract void Speak();
}
```

Child class must implement it:

```csharp
class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof");
    }
}
```

An abstract method has no body:

```csharp
public abstract void Speak();
```

### Common use cases

```csharp
abstract class Animal
abstract class Shape
abstract class PaymentMethod
abstract class Report
```

### Mental rule

```text
Parent defines the contract, child must provide the behaviour → abstract
```

---

## `sealed`

### Clear rule

> If this class should be final and not extended, use `sealed`.

### Example

```csharp
sealed class BankAccount
{
}
```

This is not allowed:

```csharp
class SavingsAccount : BankAccount
{
}
```

You can also seal an overridden method:

```csharp
class Dog : Animal
{
    public sealed override void Speak()
    {
        Console.WriteLine("Woof");
    }
}
```

That means future child classes cannot override `Speak()` again.

### Mental rule

```text
Do not allow further inheritance or overriding → sealed
```

---

# 4. Value Stability Modifiers

These modifiers control whether a value can change.

---

## `readonly`

### Clear rule

> If the value is set when the object is created and should not change later, use `readonly`.

### Example

```csharp
class UserAccount
{
    private readonly string username;

    public UserAccount(string username)
    {
        this.username = username;
    }
}
```

After construction, this is not allowed:

```csharp
username = "newName"; // not allowed outside constructor
```

### Common use cases

```csharp
private readonly string id;
private readonly DateTime createdAt;
private readonly string username;
```

### Mental rule

```text
Set once during construction, then never change → readonly
```

---

## `const`

### Clear rule

> If the value is a permanent fixed rule known at compile time, use `const`.

### Example

```csharp
private const int MaxLoginAttempts = 3;
private const int PassingScore = 50;
```

### Common use cases

```csharp
private const int MinimumAge = 18;
private const double TaxRate = 0.1;
private const string DefaultRole = "User";
```

### Mental rule

```text
Fixed rule that never changes → const
```

### Difference between `const` and `readonly`

```text
const = fixed at compile time
readonly = assigned when object is created, then cannot change
```

---

# 5. Async Modifier

---

## `async`

### Clear rule

> If the method awaits an operation, mark it `async`.

### Example

```csharp
public async Task<string> ReadFileAsync()
{
    string text = await File.ReadAllTextAsync("data.txt");
    return text;
}
```

### Common use cases

```text
API calls
database calls
file reading/writing
network requests
```

### Example

```csharp
public async Task<User> GetUserByIdAsync(int id)
{
    return await database.FindUserAsync(id);
}
```

### Mental rule

```text
Uses await → async
```

---

# 6. Other Modifiers

---

## `new`

### Clear rule

> If the child method has the same name as the parent method but is not overriding it, use `new`.

### Example

```csharp
class Animal
{
    public void Speak()
    {
        Console.WriteLine("Animal sound");
    }
}

class Dog : Animal
{
    public new void Speak()
    {
        Console.WriteLine("Woof");
    }
}
```

This is less common for beginners.

Usually, prefer `virtual` + `override` when you want polymorphism.

### Mental rule

```text
Same method name, but not true overriding → new
```

---

## `partial`

### Clear rule

> If one class is defined in more than one file, use `partial`.

### Example

File 1:

```csharp
public partial class UserAccount
{
    public string Username { get; set; }
}
```

File 2:

```csharp
public partial class UserAccount
{
    public void Login()
    {
        Console.WriteLine("Logging in...");
    }
}
```

### Common use cases

```text
generated code
UI code
large projects
```

### Mental rule

```text
One class split across files → partial
```

---

## `extern`

### Clear rule

> If C# only declares the method but another system provides the implementation, use `extern`.

### Example

```csharp
public extern void NativeMethod();
```

As a beginner, you almost never need this.

### Mental rule

```text
Implemented outside C# → extern
```

---

# Most Important Summary Table

| Modifier | Clear rule |
|---|---|
| `public` | Other code should call/use it |
| `private` | Only this class should use it |
| `protected` | This class and child classes can use it |
| `internal` | Only code in this project/assembly can use it |
| `static` | Does not need object-specific data |
| `virtual` | Parent gives default behaviour, child can change it |
| `override` | Child changes parent behaviour |
| `abstract` | Parent defines the rule, child must implement it |
| `sealed` | Prevent further inheritance or overriding |
| `readonly` | Set in constructor, then cannot change |
| `const` | Fixed value known at compile time |
| `async` | Method uses `await` |
| `new` | Hide parent method instead of overriding |
| `partial` | Split one class across multiple files |
| `extern` | Implementation is outside C# |

---

# Grouped Mental Model

## Access

```csharp
public
private
protected
internal
```

```text
Who can use it?
```

---

## Object Relationship

```csharp
static
non-static
```

```text
Does it need object-specific data?
```

---

## Inheritance

```csharp
virtual
override
abstract
sealed
```

```text
Can child classes change it?
```

---

## Value Stability

```csharp
readonly
const
```

```text
Can this value change?
```

---

## Async

```csharp
async
```

```text
Does it use await?
```

---

# Recommended Learning Order

For your current C# OOP stage, focus on these first:

```csharp
public
private
protected
internal
static
readonly
const
```

Then practise inheritance with:

```csharp
virtual
override
abstract
sealed
```

Then practise async later with:

```csharp
async
```

---

# Final Core Rules

```text
public = other code should use it
private = only this class should use it
protected = this class and child classes should use it
internal = only this project should use it
static = does not need object-specific data
virtual = parent allows child to change behaviour
override = child changes parent behaviour
abstract = parent defines rule, child must implement
sealed = stop further inheritance or overriding
readonly = set once during construction
const = fixed forever at compile time
async = uses await
```

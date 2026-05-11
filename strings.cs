Console.WriteLine("Hello C#!");

// concatenate string
String firstFriend = "Merry";
String lastFriend = "Sage";

Console.WriteLine($"My friends are {firstFriend} and {lastFriend}");

// trim string
string greeting = "     Hello World     ";
string trimmedGreeting = greeting.TrimStart();
Console.WriteLine($"{trimmedGreeting}");

trimmedGreeting = greeting.TrimEnd();
Console.WriteLine($"{trimmedGreeting}");

// trimmedGreeting = greeting.Trim();
Console.WriteLine($"{trimmedGreeting.Trim()}");

// replace string
string friends = $"My friends are {firstFriend} and {lastFriend}";
Console.WriteLine(friends);
Console.WriteLine(friends.Replace("Sage", "Scott"));
// replace doesn't change the actual variable friends, it creates and returns a new string
// string in C# is immutable
Console.WriteLine(friends);

// if you want to change the string friends, you need to assign the result back, it changes what the variable refers to.
friends = friends.Replace("Sage", "Scott");
Console.WriteLine(friends);

// contains 
Console.WriteLine(friends.Contains("Merry"));

// Uppercase and Lowercase
Console.WriteLine(friends.ToLower());
Console.WriteLine(friends.ToUpper());

// get the length of string
Console.WriteLine(friends.Length);

// StartsWith() vs EndsWith()
Console.WriteLine(friends.StartsWith("M"));
Console.WriteLine(friends.EndsWith("M"));


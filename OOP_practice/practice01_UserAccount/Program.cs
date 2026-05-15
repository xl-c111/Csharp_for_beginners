class Program
{
    static void Main()
    {
        Console.WriteLine("=== Test 1: Create a valid account ===");
        UserAccount user = new UserAccount("Emily", "password123");
        Console.WriteLine($"Username: {user.GetName()}");
        Console.WriteLine($"Is locked? {user.IsAccountLocked()}");
        Console.WriteLine();

        Console.WriteLine("=== Test 2: Login with correct password ===");
        bool loginResult1 = user.Login("password123");
        Console.WriteLine($"Login result: {loginResult1}");
        Console.WriteLine($"Is locked? {user.IsAccountLocked()}");
        Console.WriteLine();

        Console.WriteLine("=== Test 3: Login with wrong password once ===");
        bool loginResult2 = user.Login("wrongpass");
        Console.WriteLine($"Login result: {loginResult2}");
        Console.WriteLine($"Is locked? {user.IsAccountLocked()}");
        Console.WriteLine();

        Console.WriteLine("=== Test 4: Login with wrong password until locked ===");
        user.Login("wrongpass");
        user.Login("wrongpass");
        Console.WriteLine($"Is locked? {user.IsAccountLocked()}");
        Console.WriteLine();

        Console.WriteLine("=== Test 5: Try correct password after account is locked ===");
        bool loginResult3 = user.Login("password123");
        Console.WriteLine($"Login result: {loginResult3}");
        Console.WriteLine($"Is locked? {user.IsAccountLocked()}");
        Console.WriteLine();

        Console.WriteLine("=== Test 6: Try changing password after locked ===");
        bool changeResult1 = user.ChangePassword("password123", "newpassword123");
        Console.WriteLine($"Change password result: {changeResult1}");
        Console.WriteLine();

        Console.WriteLine("=== Test 7: Create another account and change password successfully ===");
        UserAccount user2 = new UserAccount("Alice", "oldpassword123");

        bool changeResult2 = user2.ChangePassword("oldpassword123", "newpassword123");
        Console.WriteLine($"Change password result: {changeResult2}");

        Console.WriteLine("Try login with old password:");
        bool oldLogin = user2.Login("oldpassword123");
        Console.WriteLine($"Old password login result: {oldLogin}");

        Console.WriteLine("Try login with new password:");
        bool newLogin = user2.Login("newpassword123");
        Console.WriteLine($"New password login result: {newLogin}");
        Console.WriteLine();

        Console.WriteLine("=== Test 8: Try creating account with invalid username ===");

        try
        {
            UserAccount invalidUser1 = new UserAccount("", "password123");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught error: {ex.Message}");
        }

        Console.WriteLine();

        Console.WriteLine("=== Test 9: Try creating account with invalid password ===");

        try
        {
            UserAccount invalidUser2 = new UserAccount("Bob", "short");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught error: {ex.Message}");
        }
    }
}

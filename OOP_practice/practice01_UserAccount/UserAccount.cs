/*
Class name: 
- class UserAccount {}


Fields/properties:
- public string userName{get; private set;}
- private string password;
- private int FailedLoginAttempts;
- private bool isLocked;

Constructor:
- public userAccount(string username, string password){
  - validate username
  - validate password
}


Public methods: (outside is allowed to call)
- public bool Login(){} -> true/false
- public void ChangePassword(string oldpassword, string newpassword){} 
- public string GetName() -> string


Private helper methods: (small internal checks used by class itself)
- private bool IsCorrectPassword(string inputpassword){} -> bool
- private bool IsLocked()-> true/false

*/



class UserAccount
{
    public string UserName
    {
        get; private set;
    }

    private string Password;
    private int failedLoginAttempts;
    private bool isLocked;

    // constructor 
    public UserAccount(string username, string password)
    {
        // step 1: validate inputs
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("username must be provided.");
        }

        if (!IsValidPassword(password))
        {
            throw new ArgumentException("Password must be valid.");
        }

        // step 2: assign properties
        UserName = username;
        Password = password;

        // step 3: set default statu
        failedLoginAttempts = 0;
        isLocked = false;
    }

    public bool Login(string inputPassword)
    {
        if (isLocked)
        {
            Console.WriteLine("Account is locked, login failed.");
            return false;
        }

        // return true only the password is correct and account is not locked.
        if (IsCorrectPassword(inputPassword))
        {
            Console.WriteLine("Login succeeded.");
            failedLoginAttempts = 0;
            return true;
        }

        failedLoginAttempts++;

        if (failedLoginAttempts >= 3)
        {
            isLocked = true;
            Console.WriteLine("Account is locked.");
        }
        else
        {
            Console.WriteLine("Password is not correct, please try again.");
        }
        // overall return false.
        return false;
    }

    public bool ChangePassword(string oldPassword, string newPassword)
    {
        // check all failure cases first, return false early.
        if (isLocked)
        {
            Console.WriteLine("Account is locked.");
            return false;
        }

        if (!IsCorrectPassword(oldPassword))
        {
            Console.WriteLine("Old password is not correct");
            return false;
        }

        if (!IsValidPassword(newPassword))
        {
            Console.WriteLine("New password is not valid.");
            return false;
        }

        // if all checks pass, do the real action at the end
        Password = newPassword;
        return true;
    }

    public bool IsAccountLocked()
    {
        return isLocked == true;
    }
    public string GetName()
    {
        return UserName;
    }

    private bool IsValidPassword(string inputPassword)
    {
        // check whether user input is empty or has at least 8 chars
        return !string.IsNullOrWhiteSpace(inputPassword) && inputPassword.Length >= 8;
    }

    private bool IsCorrectPassword(string inputPassword)
    {
        // check whether user input matches the stored password
        return inputPassword == Password;
    }
}

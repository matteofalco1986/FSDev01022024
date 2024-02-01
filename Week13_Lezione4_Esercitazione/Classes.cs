public class Functions
{
    public static void PrintMenu()
    {
        Console.WriteLine("\n===============OPERAZIONI==============");
        Console.WriteLine("\nScegli l'operazione da effettuare");
        Console.WriteLine("1.: Login");
        Console.WriteLine("2.: Logout");
        Console.WriteLine("3.: Verifica ora e data di login");
        Console.WriteLine("4.: Lista degli accessi");
        Console.WriteLine("5.: Esci");
        Console.WriteLine("");
    }
}

public class User
{
    // Variables
    static string? _username = null;
    static string _password = "ciao";
    static bool _isLoggedIn = false;
    static List<DateTime> Logins = new List<DateTime>();

    // Getters and setters
    public static string InputPassword { get; set; }
    public static string Username
    {
        get
        {
            return _username;
        }
        set
        {
            if (value.Length > 0)
            {
                _username = value;
            }
            else
            {
                Console.Clear();
                throw new Exception("Lo username deve essere di almeno 1 carattere\n");
            }
        }
    }
    public static bool isPasswordCorrect()
    {
        return (_password == InputPassword);
    }
    

    // Methods
    public static void PrintLastAccess()
    {
        IsUserLoggedIn();
        Console.Clear();
        Console.WriteLine(Logins.Last());
    }
    public static void PrintAccessList()
    {
        IsUserLoggedIn();
        Console.Clear();
        if(Logins.Count > 0)
        {
            foreach (var Login in Logins)
            {
                Console.WriteLine(Login);
            }

        }
        else
        {
            throw new Exception("You have no logins to display");
        }
    }
    public static void Login()
    {
        VerifyLogin();
        VerifyCredentials();
        SetLoginStatus();
        AddLoginDate();
    }
    public static void VerifyCredentials()
    {
        Console.Write("Username: ");
        Username = Console.ReadLine();

        Console.Write("Password: ");
        InputPassword = Console.ReadLine();
        if (!isPasswordCorrect())
        {
            Console.Clear();
            throw new Exception("La password non è corretta\n");
        }

        Console.Write("Confirm password: ");
        InputPassword = Console.ReadLine();
        if (!isPasswordCorrect())
        {
            Console.Clear();
            throw new Exception("La password non è corretta\n");
        }
    }
    public static void VerifyLogin()
    {
        if (_isLoggedIn)
        {
            Console.Clear();
            throw new Exception("Sei già loggato");
        }
    }
    public static void IsUserLoggedIn()
    {
        if (!_isLoggedIn)
        {
            Console.Clear();
            throw new Exception("Devi prima fare il login\n");
        }
    }
    public static void AddLoginDate()
    {
        Logins.Add(DateTime.Now);
    }
    public static void SetUsername()
    {
        Username = "";
        Console.Write("Username: ");
        Username = Console.ReadLine();
    }
    public static void SetLoginStatus()
    {
        _isLoggedIn = true;
        Console.Clear();
        Console.WriteLine("Hai effettuato il login");
    }
    public static void Logout()
    {
        if (_isLoggedIn)
        {
            _isLoggedIn = false;
            _username = null;
            Console.Clear();
            Console.WriteLine("Logout effettuato\n");
        }
        else
        {
            Console.Clear();
            throw new Exception("Devi prima fare il login\n");
        }
    }
    public static void TerminateProgram()
    {
        Console.Clear();
        Console.WriteLine("Grazie per aver usato il programma. Bye!\n");
    }
    public static void PrintNotValidOption()
    {
        Console.Clear();
        Console.WriteLine("Opzione non valida");
    }
}
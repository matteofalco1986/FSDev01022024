
namespace LoginProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Introduction
            Console.WriteLine("Welcome to a brand new program. Press any key to continue");

            bool isDone = false;
            while (!isDone)
            {
                // Print menu and prompt user to choose
                Console.ReadKey();
                Functions.PrintMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        if (User.IsLoggedIn)
                        {
                            Console.WriteLine("\nSei già loggato. Premi un tasto per andare avanti e scegli un'altra opzione");
                            break;
                        }

                        // Check if username is valid
                        bool isUsernameValid = false;
                        bool isPasswordCorrect = false;
                        while (!isUsernameValid)
                        {
                            try
                            {
                                Console.Write("\nInserisci uno username: ");
                                User.Username = Console.ReadLine();
                                isUsernameValid = true;
                            }
                            catch
                            {
                                Console.WriteLine("Il nome deve essere almeno di due caratteri. Prova ancora");
                            }
                        }
                        while (!isPasswordCorrect)
                        {
                            try
                            {
                                Console.Write("\nInserisci una password: ");
                                User.InputPassword = Console.ReadLine();
                                if (User.InputPassword == User.Password)
                                {
                                    isPasswordCorrect = true;
                                    User.Login();
                                    Console.Clear();
                                    Console.WriteLine($"Benvenuto {User.Username}. Clicca un tasto qualunque per proseguire. Dopodichè, scegli un'opzione");
                                    Console.Read();
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch
                            {
                                Console.WriteLine("La password non è corretta. Prova di nuovo\n");
                            }
                        }
                        break;
                    case "2":
                        if (!User.IsLoggedIn)
                        {
                            Console.WriteLine("\nDevi fare il login prima di poter fare il logout");
                        }
                        else
                        {
                            Console.WriteLine("\nHai fatto il logout con successo. Ora scegli un'opzione\n");
                        }
                        break;
                    case "5":
                        isDone = true;
                        Console.WriteLine("\nGrazie per aver usato il nostro programma. Arrivederci");
                        break;
                    default:
                        Console.WriteLine("\nL'opzione che hai selezionato non è valida. Premi un tasto qualunque per andare avanti e poi seleziona un'opzione valida");
                        break;
                }

            }
        }
    }
    public class User
    {
        private static string _username;
        private static string _password = "ciao";
        private static bool _isLoggedIn = false;
        private static List<DateTime> logTimes;
        private static string _inputPassword;

        public static string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value.Length > 2)
                {
                    _username = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public static string Password
        {
            get
            {
                return _password;
            }
        }
        public static string InputPassword
        {
            get
            {
                return _inputPassword;
            }
            set
            {
                _inputPassword = value;
            }
        }
        public static bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }
        }
        public static void Login()
        {
            if (!_isLoggedIn)
            {
                _isLoggedIn = true;
                logTimes.Add(DateTime.Now);
                Console.WriteLine($"Hi {Username}, you have successfully logged in");
            }
            else
            {
                // Throw exception
            }
        }
        public static void Logout()
        {
            if (_isLoggedIn)
            {
                _isLoggedIn = false;
                logTimes.Add(DateTime.Now);
                Console.WriteLine($"Hi {Username}, you have successfully logged in");
            }
            else
            {
                // Throw exception
            }
        }
    }
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
}
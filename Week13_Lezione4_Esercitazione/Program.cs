
namespace LoginProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Functions.PrintMenu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    // Login
                    case "1":
                        try
                        {
                            User.Login();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    // Logout
                    case "2":
                        try
                        {
                            User.Logout();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    // Print last login
                    case "3":
                        try
                        {
                            User.PrintLastAccess();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    // Print login list
                    case "4":
                        try
                        {
                            User.PrintAccessList();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "5":
                        User.TerminateProgram();
                        return;
                    default:
                        User.PrintNotValidOption();
                        break;
                }
            }
        }
    }
}
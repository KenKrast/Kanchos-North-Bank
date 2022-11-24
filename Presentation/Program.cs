using System;
using KanchoBank.Presentation;
class Program
{
    static void Main()
    {
        //Display title
        Console.WriteLine("***********KANCHO BANK**********");
        Console.WriteLine("::Login Page::");

        //declare a variables to store user name and pass
        string userName = null, password = null;

        //Read user name from the console
        Console.Write("Enter username: ");
        userName = Console.ReadLine();

        //Read password from console
        if (userName != "")
        {
            Console.Write("Enter password: ");
            password = Console.ReadLine();
        }
        
        //Check username and password
        
            if (userName == "system" && password == "manager")
            {
                    //Deklare a variable to store menu choice
                    int menuChoice = -1;
                do
                {

                    Console.WriteLine("\n:::MAIN MENU:::");
                    Console.WriteLine("1.Customers");
                    Console.WriteLine("2.Accounts");
                    Console.WriteLine("3.Funds Transfer");
                    Console.WriteLine("4.Transfer Statements");
                    Console.WriteLine("5.Account Statements");
                    Console.WriteLine("0.Exit");

                    Console.Write("\nEnter option: ");
                    menuChoice = int.Parse(Console.ReadLine());

                    //switch the menu choice
                    switch (menuChoice)
                    {
                        case 1: CustomersMenu();
                            break;
                        case 2:AccountsMenu();
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                    }

                } while (menuChoice != 0);
            }
            
            else
            {
                 Console.WriteLine("Access denied. Invalid username or password");
            }
            
            Console.WriteLine("Thank you for using Kancho Bank, Goodbye!");
    }
    
    static void CustomersMenu()
    {
        //Variable that store customers menu
        int customerMenuChoice = -1;

        //do-while
        do
        {
            //Print customers menu
            Console.WriteLine("\n:::CUSTOMERS MENU:::");
            Console.WriteLine("1.Add Customer");
            Console.WriteLine("2.Delete Customer");
            Console.WriteLine("3.Update Customer");
            Console.WriteLine("4.Search Customers");
            Console.WriteLine("5.View Customer");
            Console.WriteLine("0.Back to main menu");

            //Accept customers menu choice
            Console.Write("\nEnter option: ");
            customerMenuChoice = int.Parse(Console.ReadLine());
            switch (customerMenuChoice)
            {
                case 1:CustomersPresentation.AddCustomer();break;
                case 5: CustomersPresentation.ViewCustomers();break;
                default:
                    break;
            }
        } while (customerMenuChoice != 0);
    }
    static void AccountsMenu()
    {
        //Variable that store accounts menu
        int accountsMenuChoice = -1;

        //do-while
        do
        {
            //Print customers menu
            Console.WriteLine("\n:::ACCOUNTS MENU:::");
            Console.WriteLine("1.Add Account");
            Console.WriteLine("2.Delete Account");
            Console.WriteLine("3.Update Account");
            Console.WriteLine("4.View Account");
            Console.WriteLine("0.Back to main menu");

            //Accept account menu choice
            Console.Write("\nEnter option: ");
            accountsMenuChoice = int.Parse(Console.ReadLine());
        } while (accountsMenuChoice != 0);
    }
    static void FundsTransfer()
    {
        
    }
}
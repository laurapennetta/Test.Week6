using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public static class InsuranceManagment
    {
        static IRepositoryClient repoClient = new RepositoryClient();
        static IRepositoryPolicy repoPolicy = new RepositoryPolicy();

        internal static bool Menu()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine();
            Console.WriteLine("1. Add new client");
            Console.WriteLine("2. Add new policy for a client");
            Console.WriteLine("3. See and print info about policies client");
            Console.WriteLine("4. Exit");
            int choice = InputVerification(5);
            Console.Clear();
            return ChoiceManagment(choice);
        }

        private static bool ChoiceManagment(int choice)
        {
            bool cicle = true;
            switch (choice)
            {
                case 1:
                    AddClient();
                    break;
                case 2:
                    AddPolicy();
                    break;
                case 3:
                    Print();
                    break;
                default:
                    cicle = false;
                    Console.WriteLine("GoodBye!");
                    break;
            }
            return cicle;
        }

        private static void AddPolicy()
        {
            Console.WriteLine("What kind of policy do you want to add?");
            Console.WriteLine();
            Console.WriteLine("1. Car Policy");
            Console.WriteLine("1. Theft Policy");
            Console.WriteLine("1. Life Policy");
            int choice = InputVerification(3);
            if (choice == 1)
            {
                AddCarPolicy();
            }
            else if (choice == 2)
            {
                AddTheftPolicy();
            }
            else if (choice == 3)
            {
                AddLifePolicy();
            }
            else
            {
                Console.WriteLine("Please, insert a correct value");
                AddPolicy();
            }
        }

        private static void AddCarPolicy()
        {
            Console.WriteLine("Insert Policy's Number:");
            int policyNumber = IntVerification();
            Console.WriteLine("Insert Policy's StartDate:");
            DateTime startDate = DateVerification();
            Console.WriteLine("Insert Policy's Price:");
            decimal price = DecimalVerification();
            Console.WriteLine("Insert Policy's Instalment:");
            decimal instalment = DecimalVerification();
            Console.WriteLine("Insert Car's Plate:");
            string plate = Console.ReadLine();
            int displacement = IntVerification();
            Policy policy = new CarRC()
            {
                Number = policyNumber,
                StartDate = startDate,
                Price = price,
                Instalment = instalment,
                Plate = plate,
                Displacement = displacement
            };
            string clientCF = CFChoice();
            if (clientCF != null || clientCF.Length != 0)
            {
                repoClient.AddClient(clientCF, policy);
            }
        }

        private static string CFChoice()
        {
            
        }

        private static decimal DecimalVerification()
        {
            bool verification = Decimal.TryParse(Console.ReadLine(), out decimal price);
            while (!verification || price < 0)
            {
                verification = Decimal.TryParse(Console.ReadLine(), out price);
            }
            return price;
        }

        private static DateTime DateVerification()
        {
            bool verification = DateTime.TryParse(Console.ReadLine(), out DateTime date);
            while (!verification)
            {
                verification = DateTime.TryParse(Console.ReadLine(), out date);
            }
            return date;
        }

        private static int IntVerification()
        {
            bool verification = Int32.TryParse(Console.ReadLine(), out int number);
            while (!verification || number < 0)
            {
                verification = Int32.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        private static void AddClient()
        {
            Console.WriteLine("Insert Client's CF:");
            string clientCF = Console.ReadLine();
            Console.WriteLine("Insert Client's Name:");
            string clientName = Console.ReadLine();
            Console.WriteLine("Insert Client's Surname:");
            string clientSurname = Console.ReadLine();
            Console.WriteLine("Insert Client's Address:");
            string clientAddress = Console.ReadLine();
            var clientCreated = repoClient.Create(new Client()
            {
                CF = clientCF,
                Name = clientName,
                Surname = clientSurname,
                Address = clientAddress
            });
            if (clientCreated != null)
            {
                Console.WriteLine(clientCreated);
            }
            else
            {
                Console.WriteLine("Operation Failed.");
            }
        }

        private static int InputVerification(int maxChoice)
        {
            Console.Write("Choice: ");
            bool verification = Int32.TryParse(Console.ReadLine(), out int choice);
            while (choice > maxChoice || choice < 0 || verification == false)
            {
                Console.WriteLine("Please, insert a correct value.");
                verification = Int32.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }
    }
}

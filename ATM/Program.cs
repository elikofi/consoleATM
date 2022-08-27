try
{
    int correctPin = 1234;
    int tryLimit = 3;
    double balance = 10000.00;
    int tries = 0;
    bool outOfTries = false;
    bool makeNewTransaction = true;

    Console.Clear();
    Console.Title = "My ATM App";

    Console.WriteLine("Welcome to my ATM app.");
    Console.WriteLine("______________________");


    while (tries != tryLimit && !outOfTries && makeNewTransaction == true)
    {
        Console.ResetColor();
        Console.WriteLine("\n\nEnter your PIN to continue:");
        int pin = int.Parse(Console.ReadLine());

        if (pin == correctPin)
        {
            Console.WriteLine("\n\nSelect a transaction type:");
            Console.WriteLine("\t 1: Withdrawal.");
            Console.WriteLine("\t 2: Deposit.");
            Console.WriteLine("\t 3: Check balance.");
            string type = Console.ReadLine();

            if (type == "1")
            {
                Console.Write("Enter amount you want to withdraw: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                if (amount > balance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou have insufficient funds.");
                    Console.ResetColor();
                    Console.WriteLine($"\nYour current balance is: {balance}.");
                }
                else
                {
                    double currentBalance = Withdrawal(balance, amount);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYour withdrawal was successful.");
                    Console.ResetColor();
                    Console.WriteLine($"\nYour current balance is: {currentBalance}.");
                }
            }
            else if (type == "2")
            {
                Console.Write("\nEnter amount you want to deposit: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                double currentBalance = Deposit(balance, amount);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYour deposit was successful.");
                Console.ResetColor();
                Console.WriteLine($"\nYour current balance is: {currentBalance}.");
            }
            else if (type == "3")
            {
                Console.ResetColor();
                Console.WriteLine($"Your current balance is: {balance}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid transaction type.");
            }
            Console.ResetColor();
            Console.WriteLine("\nDo you want to make another transaction? ( Y / N)");
            string response = Console.ReadLine().ToUpper();
            if (response == "Y")
            {
                makeNewTransaction = true;
            }
            else
            {
                makeNewTransaction = false;
            }
        }
        else
        {
            tries++;

            if (tries < 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Wrong PIN. Try again.");
            }
            else if (tries == 3)
            {
                outOfTries = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid PIN. Card blocked. Go to your bank for any further assistance.");
            }
        }

    }
}
catch (Exception ex)
{
    Console.WriteLine("Invalid input!");
}



//methods
static double Withdrawal(double balance, double amount)
{
    return balance - amount;
}


static double Deposit(double balance, double amount)
{
    return balance + amount;
}
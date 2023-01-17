// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;


public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance; 

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }   
    public string getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin; 
    }
    public string getfirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;    
    }
    public double getbalance()
    {
         return balance;
    }
    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setfirstName(string newfirstName)
    {
        firstName = newfirstName;
    }
    public void setlastName(string newlastName)
    {
        lastName = newlastName;
    }
    public void setbalance(double newbalance)
    {
        balance = newbalance;
    }
    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Show Balance");
            Console.WriteLine("4.Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setbalance(currentUser.getbalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getbalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdraw = Double.Parse(Console.ReadLine());
            // Check if the user has enough money
            if(currentUser.getbalance() < withdraw)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                currentUser.setbalance(currentUser.getbalance() - withdraw);
                Console.WriteLine("Thank you!");
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getbalance());
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("0987654321", 1234, "Peter", "Samuel", 5500));
        cardHolders.Add(new cardHolder("1234567890", 9087, "Rick", "James", 7500));
        cardHolders.Add(new cardHolder("9871234567", 2341, "Dick", "Waldor", 10500));
        cardHolders.Add(new cardHolder("2345678091", 6879, "Dawn", "Quentin", 145000));
        cardHolders.Add(new cardHolder("1357924680", 6784, "Bella", "King", 60000000));

        //Prompt User
        Console.WriteLine("Welcome to PracticeATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;    
        while (true)
        {
            try
            {
               userPin = int.Parse(Console.ReadLine());
                //check againt db
                if (currentUser.getPin()==userPin) { break; }
                else { Console.WriteLine("Incorrect Pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect Pin. Please try again"); }
        }
        Console.WriteLine("Welcome"+ currentUser.getfirstName());
        int option = 0;
        do
        {
            printOptions();
            try 
            {
                option = int.Parse(Console.ReadLine()); 
            }
            
            catch { }
            if(option == 1) { deposit (currentUser); }
            else if(option == 2) { withdraw (currentUser); }
            else if(option ==3) { balance (currentUser); } 
            else if (option == 4) { break; }
            else { option = 0; }    
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day");
    }
}
using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum,
    int pin,
    String firstName,
    String lastName,
    double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;

        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum() { return cardNum; }
    public int getPin() { return pin; }
    public String getFirstName() { return firstName; }
    public String getLastName() { return lastName; }
    public double getBalance() { return balance; }

    public void setNum(String newCardNum) { cardNum = newCardNum; }
    public void setPin(int newPin) { pin = newPin; }
    public void setFirstName(String newFirstName) { firstName = newFirstName; }
    public void setLastName(String newLastName) { lastName = newLastName; }
    public void setBalance(double newBalance) { balance = newBalance; }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following products...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. WithDraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Change Pin");
            Console.WriteLine("5. Exit");

        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank You for your $$. Your new Balnace is :" + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check  if user has enough money
            if (currentUser.getBalance() < withdrawal)
                Console.WriteLine("Insufficient Amount :( ");
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are Good to Go! Thank You :) ");
            }
        }

        void changepin(cardHolder currentUser)
        {

            Console.WriteLine("Please Enter your last pin number");
            long lastpin = long.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter new Pin Number :) ");
            long newpin = long.Parse(Console.ReadLine());
            Console.WriteLine("Your pin is successfully changed to : " + newpin);

        }




        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance :" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("76236868482", 2453, "Saurabh", "Dubey", 90000));
        cardHolders.Add(new cardHolder("76236468682", 1234, "Udyan", "Trivedi", 89045));
        cardHolders.Add(new cardHolder("76374868482", 8947, "Prateeksha", "Pawar", 45975));
        cardHolders.Add(new cardHolder("84653868482", 7464, "Ashok", "Velamala", 77883));
        cardHolders.Add(new cardHolder("97654868482", 8574, "Rashmi", "Ranjan", 89632));
        cardHolders.Add(new cardHolder("13643868482", 8582, "Rituraj", "Vats", 11000));

        //Prompt User
        Console.WriteLine("Welcome to Simple ATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized, please try again"); }
            }

            catch { Console.WriteLine("Card not recognized, please try again"); }
        }

        Console.WriteLine("Please Enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect Pin, please try again"); }
            }

            catch { Console.WriteLine("Incorrect Pin, please try again"); }



        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + ") ");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());

            }
            catch { }

            switch (option)
            {
                case 1:
                    deposit(currentUser);
                    break;
                case 2:
                    withdraw(currentUser);
                    break;
                case 3:
                    balance(currentUser);
                    break;
                case 4:
                    changepin(currentUser);
                    break;
                case 5:
                    break;
            }
        }
        while (option != 6);
        Console.WriteLine("Thank You! Have a Nice Day :) ");



    }


}
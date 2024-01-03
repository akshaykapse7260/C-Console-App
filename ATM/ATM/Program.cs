using System;
using System.Collections.Generic;

public class CardHolder
{
    private string cardNum;
    private int pin;
    private string firstName;
    private string lastName;
    private double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    // Properties for getters
    public string CardNum { get { return cardNum; } }
    public int Pin { get { return pin; } }
    public string FirstName { get { return firstName; } }
    public string LastName { get { return lastName; } }
    public double Balance { get { return balance; } }

    // Methods for setters
    public void SetCardNum(string newCardNum) { cardNum = newCardNum; }
    public void SetPin(int newPin) { pin = newPin; }
    public void SetFirstName(string newFirstName) { firstName = newFirstName; }
    public void SetLastName(string newLastName) { lastName = newLastName; }
    public void SetBalance(double newBalance) { balance = newBalance; }
}

class Program
{
    static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much Money you want to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.SetBalance(currentUser.Balance + deposit);
            Console.WriteLine("Thank you for your Money, Your new balance is: " + currentUser.Balance);
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much Money you want to withdraw: ");
            double withdraw = Double.Parse(Console.ReadLine());
            // Check if the user has enough money
            if (currentUser.Balance < withdraw)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.SetBalance(currentUser.Balance - withdraw);
                Console.WriteLine("You're good to go! Thank You: ");
            }
        }

        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.Balance);
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("4532772818527395", 1235, "Venketesh", "Joshi", 150.31));
        cardHolders.Add(new CardHolder("4632772818527396", 1236, "Dyanu", "Joshi", 175.43));
        cardHolders.Add(new CardHolder("4732772818527397", 1237, "Akshay", "Kapse", 250.65));
        cardHolders.Add(new CardHolder("4832772818527398", 1238, "Vihan", "Kapse", 350.76));
        cardHolders.Add(new CardHolder("4932772818527399", 1239, "Gajanan", "Joshi", 111.34));

        // Prompt user
        Console.WriteLine("Welcome to Simple ATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        CardHolder currentUser = null;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.CardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (currentUser.Pin == userPin)
                {
                    break;
                }
                else { Console.WriteLine("Incorrect pin. Please try again: "); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.FirstName + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { Console.WriteLine("Invalid option. Please try again"); }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (option != 4);

        Console.WriteLine("Thank You...! Have a nice day :) ");
    }
}

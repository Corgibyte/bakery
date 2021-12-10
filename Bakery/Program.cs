using Bakery.Models;
using System;

public class Program
{

  private static Order currentOrder = new Order();
  private static string[] breads = { "Brioche", "Foccacia", "Ciabatta", "Rye" };
  private static string[] pastries = { "Kouign-Amann", "Canele", "Macaron", "Mille-feuille", "Eclair", "Religieuse" };

  static void Main()
  {
    PrintMenu();
    string menuChoice = Console.ReadLine();
    if (menuChoice == "1")
    {
      OrderItem();
    }
    else if (menuChoice == "2")
    {
      Console.WriteLine($"\nCurrent Order:\n\n{currentOrder}\n");
      Console.ReadKey();
      Main();
    }
    else if (menuChoice == "3")
    {
      Console.WriteLine("\nOrder reset!\n");
      currentOrder.ClearAll();
      Main();
    }
    else if (menuChoice == "4")
    {
      Console.WriteLine($"\nThank you for coming to Corgibite Bakery! Here is your order:\n{currentOrder}");
      Console.ReadKey();
      Console.WriteLine("\nWould you like to start a new order? [y for new order]");
      bool newOrder = Console.ReadLine().ToLower() == "y";
      if (newOrder)
      {
        currentOrder = new();
        Main();
      }
    }
  }

  static void OrderItem()
  {
    Console.WriteLine("\nWhat would you like to order?\n(0) Back to main menu\n(1) Bread\n(2) Pastry");
    string menuResponse = Console.ReadLine();
    if (menuResponse == "1")
    {
      OrderBread();
    }
    else if (menuResponse == "2")
    {
      OrderPastry();
    }
    else if (menuResponse == "0")
    {
      Main();
    }
    else
    {
      Console.WriteLine("Invalid selection!");
      Console.ReadKey();
      OrderItem();
    }
  }

  static void OrderBread()
  {
    Console.WriteLine("\nWhat bread would you like?\n(0) Back to menu");
    for (int i = 0; i < breads.Length; i++)
    {
      Console.WriteLine($"({i + 1}) {breads[i]}");
    }
    try
    {
      int breadChoice = int.Parse(Console.ReadLine());
      if (breadChoice < 0 || breadChoice > breads.Length)
      {
        Console.WriteLine("Invalid selection\n");
        Console.ReadKey();
        OrderBread();
      }
      else if (breadChoice == 0)
      {
        Main();
      }
      else
      {
        Console.WriteLine($"\nA loaf is $5 or buy 2, get one free!\n\nHow many loaves of {breads[breadChoice - 1]} would you like?");
        try
        {
          int loafChoice = int.Parse(Console.ReadLine());
          if (loafChoice < 0)
          {
            Console.WriteLine("Number of loaves must be positive!");
            Console.ReadKey();
            OrderBread();
          }
          else
          {
            for (int i = 0; i < loafChoice; i++)
            {
              currentOrder.AddItem(new Bread(breads[breadChoice - 1]));
            }
            Console.WriteLine($"\n{loafChoice} loaves of {breads[breadChoice - 1]} added to your order!\n");
            Console.ReadKey();
            Main();
          }
        }
        catch
        {
          Console.WriteLine("Invalid selection!\n");
          Console.ReadKey();
          OrderBread();
        }
      }
    }
    catch
    {
      Console.WriteLine("Invalid selection\n");
      Console.ReadKey();
      OrderBread();
    }
  }

  static void OrderPastry()
  {
    Console.WriteLine("\nWhat pastry would you like?\n(0) Back to menu");
    for (int i = 0; i < pastries.Length; i++)
    {
      Console.WriteLine($"({i + 1}) {pastries[i]}");
    }
    try
    {
      int pastryChoice = int.Parse(Console.ReadLine());
      if (pastryChoice < 0 || pastryChoice > pastries.Length)
      {
        Console.WriteLine("Invalid selection\n");
        Console.ReadKey();
        OrderPastry();
      }
      else if (pastryChoice == 0)
      {
        Main();
      }
      else
      {
        Console.WriteLine($"\nA pastry is $2, or 3 for $5!\n\nHow many pastries of {pastries[pastryChoice - 1]} would you like?");
        try
        {
          int loafChoice = int.Parse(Console.ReadLine());
          if (loafChoice < 0)
          {
            Console.WriteLine("Number of pastries must be positive!");
            Console.ReadKey();
            OrderPastry();
          }
          for (int i = 0; i < loafChoice; i++)
          {
            currentOrder.AddItem(new Pastry(pastries[pastryChoice - 1]));
          }
          Console.WriteLine($"\n{loafChoice} pastries of {pastries[pastryChoice - 1]} added to your order!\n");
          Console.ReadKey();
          Main();
        }
        catch
        {
          Console.WriteLine("Invalid selection!\n");
          Console.ReadKey();
          OrderPastry();
        }
      }
    }
    catch
    {
      Console.WriteLine("Invalid selection\n");
      Console.ReadKey();
      OrderPastry();
    }
  }

  static void PrintMenu()
  {
    //Print menu
    Console.WriteLine("   ************************************");
    Console.WriteLine("   * Welcome to the Corgibite Bakery! *");
    Console.WriteLine("   ************************************");
    Console.WriteLine("___________________________________________");
    Console.WriteLine("|                MENU                     |");
    Console.WriteLine("|                                         |");
    Console.WriteLine("| Bread :    $5 each : Buy 2, get 1 free! |");
    Console.WriteLine("|   -Brioche  -Foccacia  -Ciabatta  -Rye  |");
    Console.WriteLine("|   -Baguette  -Ficelle  -Fougasse        |");
    Console.WriteLine("| Pastry :   $2 each : 3 for 5$!          |");
    Console.WriteLine("|   -Kouign-Amann  -Canele  -Macaron      |");
    Console.WriteLine("|   -Mille-feuille  -Eclair  -Religieuse  |");
    Console.WriteLine("|_________________________________________|");
    Console.WriteLine("\nWhat would you like to do?\n");
    Console.WriteLine("(1) Order item");
    Console.WriteLine("(2) View order");
    Console.WriteLine("(3) Reset order");
    Console.WriteLine("(4) Checkout");
  }
}
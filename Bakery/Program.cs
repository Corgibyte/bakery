using Bakery.Models;
using System;

public class Program
{

  private static Order currentOrder = new Order();
  private static string[] breads = ["Brioche", "Foccacia", "Ciabatta", "Rye"];
  private static string[] pastries = ["Kouign-Amann", "Canele", "Macaron", "Mille-feuille", "Eclair", "Religieuse"];

  static void Main()
  {
    PrintMenu();
    string menuChoice = Console.ReadLine();
    if (menuChoice == "1")
    {
      //OrderItem();
      currentOrder.AddItem(new Bread("Brioche"));
      Main();
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
    }
  }

  static void OrderItem()
  {

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
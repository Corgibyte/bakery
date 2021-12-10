using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Order
  {
    private List<Orderable> _orderItems;

    public Order()
    {
      _orderItems = new List<Orderable> { };
    }

    public void AddItem(Orderable item)
    {
      _orderItems.Add(item);
    }

    public Orderable[] GetItems()
    {
      Orderable[] arr = new Orderable[_orderItems.Count];
      _orderItems.CopyTo(arr);
      return arr;
    }

    public void ClearAll()
    {
      _orderItems.Clear();
    }

    public int GetTotal()
    {
      //Create dictionary connecting types to functions to calculate cost
      Dictionary<Type, Func<int, int>> priceFunctions = new Dictionary<Type, Func<int, int>>
        {
          {typeof(Bread), (int x) => 5 * (x - (x / 3)) },
          {typeof(Pastry), (int x) => 2 * (x - (x / 3)) + 1 * (x / 3) }
        };
      //Create a new dictionary to hold total number of each type
      Dictionary<Type, int> counts = new Dictionary<Type, int> { };
      //Add or increment by 1 for each type in list
      foreach (Orderable item in _orderItems)
      {
        if (!counts.ContainsKey(item.GetType()))
        {
          counts[item.GetType()] = 1;
        }
        else
        {
          counts[item.GetType()]++;
        }
      }
      //Find cost of each type of orderable and add to sum
      int total = 0;
      foreach (KeyValuePair<Type, int> count in counts)
      {
        total += priceFunctions[count.Key](count.Value);
      }
      return total;
    }

    public override string ToString()
    {
      string answer = "";
      foreach (Orderable item in _orderItems)
      {
        answer += item;
        answer += "\n";
      }
      return answer;
    }
  }
}
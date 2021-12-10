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
      //TODO: implement
      return -1;
    }

    public override string ToString()
    {
      //TODO: implement
      return "a";
    }
  }
}
namespace Bakery.Models
{
  abstract public class Orderable
  {
    public string Description { get; }
    public string OrderableName { get; protected set; }

    public Orderable(string description)
    {
      Description = description;
    }
  }

  public class Bread : Orderable
  {
    public Bread(string description) : base(description)
    {
      OrderableName = "bread";
    }
  }

  public class Pastry : Orderable
  {

    public Pastry(string description) : base(description)
    {
      OrderableName = "Pastry";
    }
  }
}
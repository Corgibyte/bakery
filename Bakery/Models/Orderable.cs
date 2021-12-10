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

    public override string ToString()
    {
      return $"{OrderableName}: {Description}";
    }
  }

  public class Bread : Orderable
  {
    public Bread(string description) : base(description)
    {
      OrderableName = "Bread";
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
namespace Bakery.Models
{
  abstract public class Orderable
  {
    public string Description { get; }

    public Orderable(string description)
    {
      Description = description;
    }
  }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;
using System.Collections.Generic;

namespace Bakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    [TestMethod]
    public void BreadConstructor_CreatesInstanceOfBread_Bread()
    {
      string test = "testDescription";
      Bread newBread = new(test);
      Assert.AreEqual(typeof(Bread), newBread.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_DescriptionString()
    {
      string description = "Brioche";
      Bread testBread = new(description);
      string result = testBread.Description;
      Assert.AreEqual(description, result);
    }
  }

  [TestClass]
  public class PastryTests
  {
    [TestMethod]
    public void PastryConstructor_CreatesInstanceOfPastry_Pastry()
    {
      Pastry newPastry = new();
      Assert.AreEqual(typeof(Pastry), newPastry.GetType());
    }
  }
}
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
      Pastry newPastry = new("Tart");
      Assert.AreEqual(typeof(Pastry), newPastry.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_DescriptionString()
    {
      string description = "Tart";
      Pastry testPastry = new(description);
      string result = testPastry.Description;
      Assert.AreEqual(description, result);
    }
  }

  [TestClass]
  public class OrderTests
  {
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new();
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void AddItem_SingleItemAdded_OrderableArray()
    {
      string expectedString = "Brioche";
      Bread testBread = new(expectedString);
      Order testOrder = new();
      testOrder.AddItem(testBread);
      Orderable[] expectedArr = { testBread };
      Orderable[] actualArr = testOrder.GetItems();
      CollectionAssert.AreEqual(expectedArr, actualArr);
    }

    [TestMethod]
    public void AddItem_MultipleItemsAdded_OrderableArray()
    {
      string expectedString1 = "Brioche";
      string expectedString2 = "AppleBread";
      Bread testBread1 = new(expectedString1);
      Bread testBread2 = new(expectedString2);
      Order testOrder = new();
      testOrder.AddItem(testBread1);
      testOrder.AddItem(testBread2);
      Orderable[] expectedArr = { testBread1, testBread2 };
      Orderable[] actualArr = testOrder.GetItems();
      CollectionAssert.AreEqual(expectedArr, actualArr);
    }

    [TestMethod]
    public void ClearAll_MultipleItemsAddedAndCleared_EmptyOrderableArray()
    {
      string expectedString1 = "Brioche";
      string expectedString2 = "AppleBread";
      Bread testBread1 = new(expectedString1);
      Bread testBread2 = new(expectedString2);
      Order testOrder = new();
      testOrder.AddItem(testBread1);
      testOrder.AddItem(testBread2);
      testOrder.ClearAll();
      Orderable[] expectedArr = { };
      Orderable[] actualArr = testOrder.GetItems();
      CollectionAssert.AreEqual(expectedArr, actualArr);
    }

    [TestMethod]
    public void GetTotal_EmptyOrder_IntZero()
    {
      Order testOrder = new();
      Assert.AreEqual(0, testOrder.GetTotal());
    }

    [TestMethod]
    public void GetTotal_SingleBread_IntFive()
    {
      Order testOrder = new();
      Bread testBread = new("Brioche");
      testOrder.AddItem(testBread);
      Assert.AreEqual(5, testOrder.GetTotal());
    }
  }
}

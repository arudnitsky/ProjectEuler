using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace ProjectEulerTests
{
   [TestClass]
   public class Problem15Tests
   {
      [TestMethod]
      public void Treenode_WhenAddingLeftTurn_ChildIncrementsLeftTurnCount()
      {
         var root = new Treenode { Name = "" };
         var child = root.AddLeftTurn();

         Assert.AreEqual(root.LeftTurns + 1, child.LeftTurns);
         Assert.AreEqual(child.Name, "L");
      }

      [TestMethod]
      public void Treenode_WhenAddingRightTurn_ChildIncrementsRightTurnCount()
      {
         var root = new Treenode { Name = "" };
         var child = root.AddRightTurn();
         
         Assert.AreEqual(root.RightTurns + 1, child.RightTurns);
         Assert.AreEqual(child.Name, "R");
      }
      
   }
}

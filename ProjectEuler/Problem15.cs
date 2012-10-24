using System;
using System.Collections.Generic;

namespace ProjectEuler
{
   public class Treenode
   {
      public string Name { get; set; }

      public int LeftTurns { get; set; }
      public int RightTurns { get; set; }

      public Treenode LeftChild { get; set; }
      public Treenode RightChild { get; set; }

      public Treenode()
      {
         LeftTurns = 0;
         RightTurns = 0;
      }

      public Treenode AddLeftTurn()
      {
         var node = new Treenode()
         {
            Name = this.Name + "L",
            LeftTurns = this.LeftTurns + 1,
            RightTurns = this.RightTurns
         };
         this.LeftChild = node;
         return node;
      }

      public Treenode AddRightTurn()
      {
         var node = new Treenode()
         {
            Name = this.Name + "R",
            RightTurns = this.RightTurns + 1,
            LeftTurns = this.LeftTurns
         };
         this.RightChild = node;
         return node;
      }
   }

   public class MoveTree
   {
      public int GridSize { get; private set; }
      private readonly Treenode _root;

      public MoveTree( int gridSize )
      {
         GridSize = gridSize;
         _root = new Treenode();
         _root.AddLeftTurn();
         _root.AddRightTurn();
      }

      public void BuildTree()
      {
         var st = new Stack<Treenode>();
         st.Push(_root.LeftChild);
         st.Push(_root.RightChild);
         while ( st.Count > 0 )
         {
            var node = st.Pop();
            if ( node.LeftTurns < GridSize )
            {
               node.AddLeftTurn();
               st.Push(node.LeftChild);
            }
            if ( node.RightTurns < GridSize )
            {
               node.AddRightTurn();
               st.Push(node.RightChild);
            }
         }
      }

      public int CountLeaves()
      {
         int leafCount = 0;
 
         var st = new Stack<Treenode>();
         st.Push( _root );

         while ( st.Count > 0 )
         {
            var node = st.Pop();
            if ( node.LeftChild != null )
            {
               st.Push(node.LeftChild);
            }
            if ( node.RightChild != null )
            {
               st.Push(node.RightChild);
            }
            if ( node.LeftChild == null && node.RightChild == null )
            {
               ++leafCount;
               //Console.WriteLine(node.Name);
            }
          }
         return leafCount;
      }

      public static int CountPaths( int gridSize )
      {
         var tree = new MoveTree(gridSize);
         tree.BuildTree();
         return tree.CountLeaves();
      }
   }

   public class Problem15
   {
      public void Execute()
      {
         for ( int ii = 1; ii <= 20; ++ii )
         {
            Console.WriteLine("For a grid of size {0}, there are {1} paths.", ii, MoveTree.CountPaths(ii));
         }
      }
   }
}

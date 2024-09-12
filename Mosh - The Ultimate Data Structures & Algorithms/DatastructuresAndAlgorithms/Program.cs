using My = DataStructuresAndAlgorithms;

var tree = new My.Tree();

tree.Insert(7);
tree.Insert(4);
tree.Insert(9);
tree.Insert(1);
tree.Insert(6);
tree.Insert(8);
tree.Insert(10);
tree.TraversePreOrder();
Console.WriteLine();
tree.TraverseInOrderAsc();
Console.WriteLine();
tree.TraverseInOrderDesc();
Console.WriteLine(); 
tree.TraversePostOrder();
Console.WriteLine(); 
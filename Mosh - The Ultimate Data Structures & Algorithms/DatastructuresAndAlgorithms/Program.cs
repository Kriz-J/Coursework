using My = DataStructuresAndAlgorithms;

var tree = new My.Tree();
tree.Insert(7);
tree.Insert(4);
tree.Insert(9);
tree.Insert(1);
tree.Insert(6);
tree.Insert(8);
tree.Insert(10);
var temp = tree.GetNodesAtDistance(2);
Console.WriteLine(tree.IsBinarySearchTree());



var tree2 = new My.Tree();
tree2.Insert(1);
tree2.Insert(2);
tree2.Insert(3);

//tree2.Insert(7);
//tree2.Insert(4);
//tree2.Insert(9);
//tree2.Insert(1);
//tree2.Insert(6);
//tree2.Insert(8);
//tree2.Insert(10);

Console.WriteLine(tree.Equal(tree2));
tree.TraversePreOrder();
Console.WriteLine();
tree.TraverseInOrderAsc();
Console.WriteLine();
tree.TraverseInOrderDesc();
Console.WriteLine(); 
tree.TraversePostOrder();
Console.WriteLine(); 
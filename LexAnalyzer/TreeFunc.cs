/*Модуль який забезпечує роботу з комбінованою таблицею 
 * ідентифікаторів побудованою на основі хеш-функції і 
 * бінарного дерева
 */

using System;

namespace CursCompiler.LexAnalyzer
{
    public class TreeNode
    {
        public string Name;
        public double Value;
        public TreeNode Left, Right;

        public TreeNode(string name,double value)
        {
            Name = name;
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        private TreeNode _root;//reference to to root of binary tree
        private int _count;

        public BinaryTree()
        {
            _root = null;
            _count = 0;
        }

        //destroy binary tree or subtree
        private void DestroyTree(ref TreeNode tree)
        {
            if (tree != null)
            {
                DestroyTree(ref tree.Left);
                DestroyTree(ref tree.Right);
                tree = null;
            }
        }

        //cleaning the elements of tree

        public void ClearTree()
        {
            DestroyTree(ref _root);
            _count = 0;
        }

        //return amount of binary tree branches
        public int Count()
        {
            return _count;
        }

        /*Find name in binary tree
         Returns adress if symbol find
         and null if error
         Params name 
         * name -> name of branch wich we must find
         */

        public TreeNode FindNode(string name)
        {
            TreeNode tn = _root;
            int cmp;
            while (tn!=null)
            {
                cmp = String.CompareOrdinal(name, tn.Name);
                if (cmp == 0) //yohoo find!!
                    return tn;
                if (cmp < 0)
                    tn = tn.Left;
                else
                    tn = tn.Right;
            }
            return null;
        }

        //find empty slot in the tree and add new branch to the right place
        private void AddBranch(TreeNode node, ref TreeNode tree)
        {
            if (tree == null)
                tree = node;
            else
            {
             //if find branch with the same name this is the copy and we can't continue
                int comparison = String.CompareOrdinal(node.Name, tree.Name);
                if(comparison==0)
                    throw new Exception("The branch with the same name already exist");
                if(comparison<0)
                    AddBranch(node,ref tree.Left);
                else
                    AddBranch(node,ref tree.Right);
            }
        }

        //Add new element to binary tree if it not exist and return it address 
        //else return null, whitch means that element are already exist;
        /*Params
         * name -> Name of node 
         * value -> Value of node
         * 
         * return -> Return address of node if it was successfully added
         * or if node exist return null
         */

        public TreeNode Insert(string name, double value)
        {
            TreeNode node= new TreeNode(name,value);
            try
            {
                if (_root == null)
                    _root = node;
                else
                    AddBranch(node, ref _root);
                _count++;
                return node;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /* search the node by name
         * returns adress of parents if exists
         * else null 
         */

        private TreeNode FindParent(string name, ref TreeNode parent)
        {
            TreeNode tn = _root;
            parent = null;
            int cmp;
            while (tn!=null)
            {
                cmp = String.CompareOrdinal(name, tn.Name);
                if (cmp == 0) //we find!!
                    return tn;
                if (cmp < 0)
                {
                    parent = tn;
                    tn = tn.Left;
                }
                else
                {
                    parent = tn;
                    tn = tn.Right;
                }
            }
            return null;// returns null for throw exeption
        }

        /*
         * Search next node 
         * params
         * name-> StartNode (Key for search)
         * name-> ParentName - returns parent adress if success
         * return -> return node address if it exist
         */

        public TreeNode FindSuccessor(TreeNode startNode, ref TreeNode parent)
        {
            parent = startNode;
            startNode = startNode.Right;
            while (startNode.Left!=null)
            {
                parent = startNode;
                startNode = startNode.Left;
            }
            return startNode;
        }

        /*
         * Node deleting
         * params 
         * key -> name of node to delete
         */

        public void DeleteNode(string key)
        {
            TreeNode parent = null;
            //first we must find node to delete
            TreeNode nodeToDelete = FindParent(key, ref parent);
            if(nodeToDelete==null)
                throw new Exception("Unable to delete node:"+key);// can not to find node
            if((nodeToDelete.Left==null)&&(nodeToDelete.Right==null))
            {
                if (parent == null)
                {
                    _root = null;
                    return;
                }
                //search if right or left has reference and = null
                if (parent.Left == nodeToDelete)
                    parent.Left = null;
                else
                    parent.Right = null;
                _count--;
                return;
            }
            /*if one of reference of node == null
             * delete node and replace notnull adress to it place
             * 
             */
            if (nodeToDelete.Left == null)
            {
                //special condition if node is _root
                if (parent == null)
                {
                    _root = nodeToDelete.Right;
                    return;
                }
                if (parent.Left == nodeToDelete)
                    parent.Right = nodeToDelete.Right;
                else
                    parent.Left = nodeToDelete.Right;
                nodeToDelete = null;
                _count--;
                return;
            }
            /*if one of reference of node == null
             * delete node and replace notnull adress to it place
             * 
             */
            if (nodeToDelete.Right == null)
            {
                //special condition if _root
                if (parent == null)
                {
                    _root = nodeToDelete.Left;
                    return;
                }
                if (parent.Left == nodeToDelete)
                    parent.Left = nodeToDelete.Left;
                else
                    parent.Right = nodeToDelete.Left;
                nodeToDelete = null;
                _count--;
                return;
            }
            //if both node have value, search next and replace deleted node to next
            TreeNode successor = FindSuccessor(nodeToDelete, ref parent);
            //save temp copy of next node
            TreeNode tmp=new TreeNode(successor.Name,successor.Value);
            //We find, in which branch points successor predecessor 
            // And delete the successor
            if (parent.Left == successor)
                parent.Left = null;
            else
                parent.Right = null;
            //returns back value of successors
            nodeToDelete.Name = tmp.Name;
            nodeToDelete.Value = tmp.Value;
            _count--;
        }

        //Schematik draw tree method
        private string DrawNode(TreeNode tree)
        {
            if (tree == null)
                return "empty";
            if((tree.Left==null)&&(tree.Right==null))
                return tree.Name;
            if ((tree.Left != null) && (tree.Right == null))
                return tree.Name + "(" + DrawNode(tree.Left) + ",_)";

            if ((tree.Right != null) && (tree.Left == null))
                return tree.Name + "(_," + DrawNode(tree.Right) + ")";
            return tree.Name + "(" + DrawNode(tree.Left) + ", " + DrawNode(tree.Right) + ")";
        }
        //view binary tree as string 
        //"50(40(30(20, 35), 45(44, 46)), 60)"
        public string DrawTree()
        {
            return DrawNode(_root);
        }
    }

    class TreeFunc
    {
        //this is some awesume class
    }
}

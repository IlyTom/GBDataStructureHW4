public class RedBlackTree
{
    private Node root;

    private enum Color
    {
        Red,
        Black
    }

    private class Node
    {
        public int value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Color Color { get; set; }
    }

    public bool add (int value)
    {
        if (root != null)
        {
            bool result = addNode(root, value);
            root = rebalance(root);
            root.Color = Color.Black;
            return result;
        }
        else
        {
            root = new Node();
            root.Color = Color.Black;
            root.value = value;
            return true;
        }
    }

    private bool addNode(Node node, int value)
    {
        if (node.value == value)
            return false;
        else
        {
            if (node.value > value)
            {
                if (node.LeftChild != null)
                {
                    bool result = addNode(node.LeftChild, value);
                    node.LeftChild = rebalance(node.LeftChild);
                    return result;
                }
                else
                {
                    node.LeftChild = new Node();
                    node.LeftChild.Color = Color.Red;
                    node.LeftChild.value = value;
                    return true;
                }
            }
            else
            {
                if (node.RightChild != null)
                {
                    bool result = addNode(node.RightChild,value);
                    node.RightChild = rebalance(node.RightChild);
                    return result;
                }
                else
                {
                    node.RightChild = new Node();
                    node.RightChild.Color = Color.Red;
                    node.RightChild.value = value;
                    return true;
                }
            }
        }
    } 

    private Node rebalance(Node node)
    {
        Node result = node;
        bool needRebalance;
        do 
        {
            needRebalance = false;
            if (result.RightChild != null && result.RightChild.Color == Color.Red &&
             (result.LeftChild == null || result.LeftChild.Color == Color.Black))
                {
                    needRebalance = true;
                    result = rightSwap(result);
                }
            if  (result.LeftChild != null && result.LeftChild.Color == Color.Red &&
            result.LeftChild.LeftChild != null && result.LeftChild.LeftChild.Color == Color.Red)
                {
                    needRebalance = true;
                    result = leftSwap(result);
                }
            if (result.LeftChild != null && result.LeftChild.Color == Color.Red && 
            result.RightChild != null && result.RightChild.Color == Color.Red)
                {
                    needRebalance = true;
                    colorSwap(result);
                }
        }
        while (needRebalance);
        return result;
    }

    private Node rightSwap(Node node)
    {
        Node RightChild = node.RightChild;
        Node betweenChild = RightChild.LeftChild;
        RightChild.LeftChild = node;
        node.RightChild = betweenChild;
        RightChild.Color = node.Color;
        node.Color = Color.Red;
        return RightChild;
    }

    private Node leftSwap(Node node)
    {
        Node LeftChild = node.LeftChild;
        Node betweenChild = LeftChild.RightChild;
        LeftChild.RightChild = node;
        node.LeftChild = betweenChild;
        LeftChild.Color = node.Color;
        node.Color = Color.Red;
        return LeftChild;
    }

    private void colorSwap(Node node)
    {
        node.Color = Color.Red;
        node.RightChild.Color = Color.Black;
        node.LeftChild.Color = Color.Black;
    }
}
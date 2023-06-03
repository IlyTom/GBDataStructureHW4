class Program
{
    static void Main(string[] args)
    {
        RedBlackTree tree = new RedBlackTree();
            while (true)
        {
            try
            {
                tree.add(int.Parse(Console.ReadLine()!));
                System.Console.WriteLine("Finish");
            }
            catch
            {
                System.Console.WriteLine();
            }
        }
    }
}


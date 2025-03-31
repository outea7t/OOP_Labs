using Lab_1.Task_2;
using Lab_1.Task_3;

namespace Lab_1 
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Код для теста задания 2

            //IDatePrinter date1 = new EuropeanDate();
            //IDatePrinter decorated1 = new StarDecorator(date1);
            //decorated1.Print();

            //Console.WriteLine();

            //IDatePrinter date2 = new AmericanDate();
            //IDatePrinter decorated2 = new BracketDecorator(new StarDecorator(date1));
            //decorated2.Print();

            /*
             * Пример результата:
                 *** 31/03/2025 21:14:34 ***
                 [[ *** 31/03/2025 21:14:34 *** ]]
            */

            // Код для теста задания 3

            TreeNode root = new TreeNode("Root");

            TreeNode child1 = new TreeNode("Child 1");
            TreeNode child2 = new TreeNode("Child 2");

            TreeNode child11 = new TreeNode("Child 1.1");
            TreeNode child12 = new TreeNode("Child 1.2");
            TreeNode child21 = new TreeNode("Child 2.1");

            child1.AddChild(child11);
            child1.AddChild(child12);

            child2.AddChild(child21);

            root.AddChild(child1);
            root.AddChild(child2);

            root.PrintTree();

            /* Пример результата:
            └──Root
               ├──Child 1
               │  ├──Child 1.1
               │  └──Child 1.2
               └──Child 2
                  └──Child 2.1
            */
        }
    }
}

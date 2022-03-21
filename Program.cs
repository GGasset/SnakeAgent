using System;
using NN;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeNN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] networkTopology = { 45, 27, 16, 4 };
            int gridSize = 25;

            SnakeGame snakeGame = new SnakeGame(gridSize);
            ReinforcementAgent agent = new ReinforcementAgent(gridSize * gridSize, networkTopology, .1, NN.Libraries.Activation.ActivationFunctions.Relu);

            Console.Write("Want to read from disk? Y/N - ");
            if (Console.ReadLine().ToUpperInvariant() == "Y")
            {
                agent.n = new NN.NN(NN.Libraries.DiskHandler.ReadFromDisk("SnakeGameNN", Environment.CurrentDirectory));
            }
            do
            {
                Console.Write("Want to visualize current generation? Y/N - ");
                bool visualize = Console.ReadLine().ToUpperInvariant() == "Y";
                Console.WriteLine();
                if (visualize)
                {
                    SnakeGame toVisualize = new SnakeGame(gridSize);
                    //TODO
                }

                Console.Write("Want to save current snake to a file? Y/N - ");
                bool saveToFile = Console.ReadLine().ToUpperInvariant() == "Y";
                Console.WriteLine();
                if (saveToFile)
                {
                    NN.Libraries.DiskHandler.SaveToDisk("SnakeGameNN", Environment.CurrentDirectory, agent.n.ToString());
                }


                Console.Write("How many generations are next for training? - ");
                int generationsWithoutQuestions = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < generationsWithoutQuestions; i++)
                {
                    //TODO: Add OnEating Event & onDie to reward & make the snake play
                    snakeGame = new SnakeGame(gridSize);
                }
            }
            while (true);
        }

        static void HumanSupervisionQuestions(out bool visualize, out int generationsWithoutQuestions, out bool saveToFile)
        {
            Console.Write("Want to visualize current generation? Y/N - ");
            visualize = Console.ReadLine().ToUpperInvariant() == "Y";
            Console.WriteLine();
            Console.Write("Want to save current snake to a file? Y/N - ");
            saveToFile = Console.ReadLine().ToUpperInvariant() == "Y";
            Console.WriteLine();
            Console.Write("How many generations are next for training? - ");
            generationsWithoutQuestions = Convert.ToInt32(Console.ReadLine());
        }
    }
}

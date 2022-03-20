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

            
        }

        void HumanSupervisionQuestions(out bool visualize, out int generationsWithoutQuestions, out bool saveToFile)
        {
            Console.Write("Want to visualize current generation? Y/N - ");
            visualize = Console.ReadLine().ToUpperInvariant() == "Y"; ;
            Console.WriteLine();
            Console.Write("How many generations are next for training? - ");
            generationsWithoutQuestions = Convert.ToInt32(Console.ReadLine());
        }
    }
}

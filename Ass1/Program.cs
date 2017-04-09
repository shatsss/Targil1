using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;

namespace Ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.CompareSolvers();
        }
        public static void CompareSolvers()
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(100,100);
            Console.WriteLine(maze.ToString());
            ISearchable<Position> mazeObjectAdapter = new ObjectAdapter(maze);
            ISearcher<Position> BFS = new BFS<Position>();
            ISearcher<Position> DFS = new DFS<Position>();
            Solution<Position> solution = BFS.search(mazeObjectAdapter);
            Console.WriteLine("BFS solution: ");
            solution.printSolution();
            solution = DFS.search(mazeObjectAdapter);
            Console.WriteLine("DFS solution: ");
            solution.printSolution();
            Console.ReadKey();
        }
    }
}

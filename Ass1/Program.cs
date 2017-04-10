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
    public class Program
    {
        static void Main(string[] args)
        {
            Program.CompareSolvers();
        }
        public static void CompareSolvers()
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(3,3);
            Console.WriteLine(maze.ToString());
            ISearchable<Position> mazeObjectAdapter = new MazeAdapter(maze);
            ISearcher<Position> BFS = new BFS<Position>();
            ISearcher<Position> DFS = new DFS<Position>();
            Solution<Position> solution = BFS.Search(mazeObjectAdapter);
            Console.WriteLine("BFS solution: ");
            solution.PrintSolution();
            solution = DFS.Search(mazeObjectAdapter);
            Console.WriteLine("DFS solution: ");
            solution.PrintSolution();
            Console.ReadKey();
        }
    }
}

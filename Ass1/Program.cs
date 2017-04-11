using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;

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
            int x = 8;
            Console.WriteLine(x.ToString());
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(100, 100);
            //Console.WriteLine((int)MazeLib.Direction.Down);
            Console.WriteLine(maze.ToString());
            ISearchable<Position> mazeObjectAdapter = new MazeAdapter(maze);
            ISearcher<Position> BFS = new BFS<Position>();
            ISearcher<Position> DFS = new DFS<Position>();
            Solution<Position> solution = BFS.Search(mazeObjectAdapter);
            /*  Console.WriteLine("BFS solution: ");
              solution.PrintSolution();*/
            State<Position>.StatePool.ClearStatePool();
            solution = DFS.Search(mazeObjectAdapter);
            /*Console.WriteLine("DFS solution: ");
            solution.PrintSolution();*/
            Console.WriteLine("The Solution Is:");
            mazeObjectAdapter.PrintSolution(solution);
            Console.ReadKey();
        }
    }
}

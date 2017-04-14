﻿using System;
using MazeLib;
using MazeGeneratorLib;
using System.Collections.Generic;

namespace Ass1
{
    internal class Model : IModel
    {
        private Dictionary<string, Maze> mazes;
        private Dictionary<string, Solution<Position>> solutionsBFS;
        private Dictionary<string, Solution<Position>> solutionsDFS;
        private Dictionary<string, Maze> waitingMazes;

        private ISearcher<Position> BFS;
        private ISearcher<Position> DFS;
        public Model()
        {
            mazes = new Dictionary<string, Maze>();
            waitingMazes = new Dictionary<string, Maze>();
            solutionsBFS = new Dictionary<string, Solution<Position>>();
            solutionsDFS = new Dictionary<string, Solution<Position>>();
            BFS = new BFS<Position>();
            DFS = new DFS<Position>();

        }
        Maze IModel.GenerateMaze(string name, int rows, int cols)
        {
            Maze maze = this.GetMaze(name, rows, cols);
            mazes.Add(name, maze);
            return maze;
        }
        public Maze GetMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator generatorMaze = new DFSMazeGenerator();
            Maze maze = generatorMaze.Generate(rows, cols);
            maze.Name = name;
            return maze;
        }
        Solution<Position> IModel.GetBFSSolution(string name)
        {
            if (solutionsBFS.ContainsKey(name))
            {
                return solutionsBFS[name];
            }
            ISearchable<Position> mazeObjectAdapter = new MazeAdapter(mazes[name]);
            Solution<Position> solution = BFS.Search(mazeObjectAdapter);
            Console.WriteLine("BFS solution: ");
            return solution;
        }
        Solution<Position> IModel.GetDFSSolution(string name)
        {
            if (solutionsDFS.ContainsKey(name))
            {
                return solutionsDFS[name];
            }
            ISearchable<Position> mazeObjectAdapter = new MazeAdapter(mazes[name]);
            Solution<Position> solution = DFS.Search(mazeObjectAdapter);
            Console.WriteLine("DFS solution: ");
            return solution;
        }

        public void AddWaitingGame(string name, int rows, int cols)
        {
            Maze maze = this.GetMaze(name, rows, cols);
            waitingMazes.Add(name, maze);
        }

        public List<string> GetList()
        {
            List<string> namesList = new List<string>();
            foreach (string name in waitingMazes.Keys)
            {
                namesList.Add(name);
            }
            return namesList;
        }
    }
}
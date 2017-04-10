using System;
using System.Collections.Generic;
using MazeLib;
using SearchAlgorithmsLib;

namespace Ass1
{
    public class MazeAdapter : ISearchable<Position>
    {
        private Maze maze;
        public MazeAdapter(Maze maze)
        {
            this.maze = maze;
        }
        public State<Position> GetGoalState()
        {
            return State<Position>.StatePool.GetState(maze.GoalPos);
            //  return new State<Position>(maze.GoalPos);
        }
        public State<Position> GetInitialState()
        {
            return State<Position>.StatePool.GetState(maze.InitialPos);
            //return new State<Position>(maze.InitialPos);
        }
        public List<State<Position>> GetAllPossibleStates(State<Position> s)
        {
            List<State<Position>> neighbours = new List<State<Position>>();
            int i = s.GetPosition().Row;
            int j = s.GetPosition().Col;
            Position position;
            if (i + 1 < maze.Rows && maze[i + 1, j] == CellType.Free)
            {
                position = new Position(i + 1, j);
                AddToNeighbours(s, position, neighbours);
            }
            if (i > 0 && maze[i - 1, j] == CellType.Free)
            {
                position = new Position(i - 1, j);
                AddToNeighbours(s, position, neighbours);
            }
            if (j + 1 < maze.Cols && maze[i, j + 1] == CellType.Free)
            {
                position = new Position(i, j + 1);
                AddToNeighbours(s, position, neighbours);
            }
            if (j > 0 && maze[i, j - 1] == CellType.Free)
            {
                position = new Position(i, j - 1);
                AddToNeighbours(s, position, neighbours);
            }
            return neighbours;
        }
        private void AddToNeighbours(State<Position> stateOriginal, Position position, List<State<Position>> neighbours)
        {
            State<Position> state = State<Position>.StatePool.GetState(position);
            neighbours.Add(state);
        }
        public bool BetterDiraction(State<Position> Previous, State<Position> New)
        {
            return Previous.Cost > (New.Cost + 1);
        }
        public void UpdateCost(State<Position> Previous, State<Position> New)
        {
            Previous.Cost = New.Cost + 1;
        }
        public void UpdateCameFrom(State<Position> child, State<Position> father)
        {
            child.Parent = father;
        }
    }
}

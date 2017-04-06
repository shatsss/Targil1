using System;
using System.Collections.Generic;
using MazeLib;
using SearchAlgorithmsLib;


namespace Ass1
{
    public class ObjectAdapter : ISearchable<Position>
    {
        private Maze maze;
        public ObjectAdapter(Maze maze)
        {
            this.maze = maze;
        }
        public State<Position> getGoalState()
        {
            return new State<Position>(maze.GoalPos);
        }
        public State<Position> getInitialState()
        {
            return new State<Position>(maze.InitialPos);
        }
        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            return null;
        }
    }
}

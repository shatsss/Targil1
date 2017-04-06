using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeLib;
using MazeGeneratorLib;

namespace Ass1
{
    public class ObjectAdapter<Position> : ISearchable<Position>
    {
        private Maze maze;
        public ObjectAdapter()
        {
            this.maze = new Maze();
        }
        public State<Position> getGoalState()
        {
            //Position position = this.maze.
            State<Position> state = new State<Position>();
            return null;
        }
        public State<Position> getInitialState()
        {
            return null;
        }
        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {

            return null;
        }
    }
}

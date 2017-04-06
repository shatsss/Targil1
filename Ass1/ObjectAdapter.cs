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
    public class ObjectAdapter<T> : ISearchable<T>
    {
        private Maze maze;
        public ObjectAdapter()
        {
            this.maze = new Maze();
        }
        public List<State<T>> getAllPossibleStates(State<T> s)
        {
            return null;
        }
        public State<T> getGoalState()
        {
            return null;
        }
        public State<T> getInitialState()
        {
             return null;
        }
    }
}

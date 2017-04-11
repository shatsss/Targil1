using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    /// <summary>
    /// abstract class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GiveSolution<T>
    {
        /// <summary>
        /// Backs the trace.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="numberOfNodesEvaluated">The number of nodes evaluated.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Solution<T> BackTrace(State<T> state, int numberOfNodesEvaluated, string name)
        {
            Stack<State<T>> openStack = new Stack<State<T>>();
            List<State<T>> openList = new List<State<T>>();
            openStack.Push(state);
            while ((state = state.Parent) != null)
            {
                openStack.Push(state);
            }
            while (openStack.Count > 0)
            {
                openList.Add(openStack.Pop());
            }
            return new Solution<T>(openList, numberOfNodesEvaluated, name);
        }
    }
}

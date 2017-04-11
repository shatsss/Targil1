using System;
using System.Collections.Generic;
using System.Text;


namespace Ass1
{

    /// <summary>
    /// Abstract class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Ass1.ISearcher{T}" />
    public abstract class StackSearcher<T> : ISearcher<T>
    {
        private Stack<State<T>> openList;
        private int evaluatedNodes;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackSearcher{T}"/> class.
        /// </summary>
        public StackSearcher()
        {
            openList = new Stack<State<T>>();
            evaluatedNodes = 0;
        }

        /// <summary>
        /// Adds to open list.
        /// </summary>
        /// <param name="state">The state.</param>
        public void AddToOpenList(State<T> state)
        {
            openList.Push(state);
        }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEmpty()
        {
            if (this.openList.Count > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Pops the open list.
        /// </summary>
        /// <returns></returns>
        protected State<T> PopOpenList()
        {
            evaluatedNodes++;
            return openList.Pop();
        }

        /// <summary>
        /// Gets the number of nodes evaluated.
        /// </summary>
        /// <returns></returns>
        public virtual int GetNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        /// <summary>
        /// Searches the specified searchable.
        /// </summary>
        /// <param name="searchable">The searchable.</param>
        /// <returns></returns>
        public abstract Solution<T> Search(ISearchable<T> searchable);
    }
}
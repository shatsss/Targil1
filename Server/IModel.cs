using Ass1;
using MazeLib;
namespace Server
{
    public interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);
        Solution<Position> getBFSSolution(string name);
        Solution<Position> getDFSSolution(string name);



    }
}
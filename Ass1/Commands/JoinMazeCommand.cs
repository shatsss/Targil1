namespace Server
{
    internal class JoinMazeCommand : ICommand
    {
        private IModel model;

        public JoinMazeCommand(IModel model)
        {
            this.model = model;
        }
    }
}
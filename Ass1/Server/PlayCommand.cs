using Ass1;


namespace Server
{
    internal class PlayCommand : ICommand
    {
        private IModel model;

        public PlayCommand(IModel model)
        {
            this.model = model;
        }
    }
}
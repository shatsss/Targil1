namespace Server
{
    internal class CloseCommand : ICommand
    {
        private IModel model;

        public CloseCommand(IModel model)
        {
            this.model = model;
        }
    }
}
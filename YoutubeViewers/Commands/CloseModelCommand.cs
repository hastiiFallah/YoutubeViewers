using YoutubeViewers.Stores;

namespace YoutubeViewers.Commands
{
    public class CloseModelCommand : CommandBase
    {
        private readonly ModelNavigationStore _modelNavigation;

        public CloseModelCommand(ModelNavigationStore modelNavigation)
        {
            _modelNavigation = modelNavigation;
        }
        public override void Execute(object? parameter)
        {
            _modelNavigation.Close();
        }
    }
}

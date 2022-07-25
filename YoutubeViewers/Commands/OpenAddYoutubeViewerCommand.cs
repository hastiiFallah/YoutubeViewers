using System;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Commands
{
    public class OpenAddYoutubeViewerCommand : CommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YoutubeViewerStore _youtubeViewerStore;

        public OpenAddYoutubeViewerCommand(ModelNavigationStore modelNavigationStore, YoutubeViewerStore youtubeViewerStore)
        {
            _modelNavigationStore = modelNavigationStore;
            _youtubeViewerStore = youtubeViewerStore;
        }
        public override void Execute(object? parameter)
        {
            AddYoutubeViewersViewModel addYoutubeViewersViewModel = new AddYoutubeViewersViewModel(_modelNavigationStore,_youtubeViewerStore);
            _modelNavigationStore.CurrentViewModel = addYoutubeViewersViewModel;
        }
    }
}

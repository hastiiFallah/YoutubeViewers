using YoutubeViewers.Models;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Commands
{
    public class OpenEditYoutubeViewerCommand : CommandBase
    {
        private readonly YoutubeViewersListingItemViewModel youtubeViewersListingItemViewModel;
        private readonly YoutubeViewerStore youtubeViewerStore;
        private ModelNavigationStore modelNavigationStore;


       

        public OpenEditYoutubeViewerCommand(YoutubeViewersListingItemViewModel youtubeViewersListingItemViewModel, YoutubeViewerStore youtubeViewerStore, ModelNavigationStore modelNavigationStore)
        {
            this.youtubeViewersListingItemViewModel = youtubeViewersListingItemViewModel;
            this.youtubeViewerStore = youtubeViewerStore;
            this.modelNavigationStore = modelNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            YoutubeViewer youtubeviewer = youtubeViewersListingItemViewModel.YoutubeViewer;
            EditYoutubeViewersViewModel editYoutubeViewersViewModel = new EditYoutubeViewersViewModel(youtubeviewer,youtubeViewerStore , modelNavigationStore);
            modelNavigationStore.CurrentViewModel = editYoutubeViewersViewModel;
        }
    }
}

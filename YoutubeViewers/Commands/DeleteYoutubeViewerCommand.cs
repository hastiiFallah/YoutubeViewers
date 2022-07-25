using System;
using System.Threading.Tasks;
using YoutubeViewer.Domain.Models;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Commands
{
    public class DeleteYoutubeViewerCommand : AsyncCommandBase
    {
        private readonly YoutubeViewersListingItemViewModel _youtubeViewersListingItemViewModel;
        private readonly YoutubeViewerStore _youtubeViewerStore;
        public DeleteYoutubeViewerCommand(YoutubeViewersListingItemViewModel youtubeViewersListingItemViewModel, YoutubeViewerStore youtubeViewerStore)
        {
            _youtubeViewersListingItemViewModel = youtubeViewersListingItemViewModel;
            _youtubeViewerStore = youtubeViewerStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _youtubeViewersListingItemViewModel.IsDeleting = true;
            _youtubeViewersListingItemViewModel.ErrorMessage = null;
            YoutubeViewerModel youtubeviewer = _youtubeViewersListingItemViewModel.YoutubeViewer;
            try
            {
                await _youtubeViewerStore.Delete(youtubeviewer.Id);
            }
            catch (Exception)
            {
                _youtubeViewersListingItemViewModel.ErrorMessage = "faile To Delete YoutubeViewer. Please Restart the app";
            }
            finally
            {
                _youtubeViewersListingItemViewModel.IsDeleting = false;
            }
        }
    }
}

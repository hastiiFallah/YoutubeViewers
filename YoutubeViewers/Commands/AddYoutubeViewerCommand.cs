using System;
using System.Threading.Tasks;
using YoutubeViewer.Domain.Models;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Commands
{
    public class AddYoutubeViewerCommand : AsyncCommandBase
    {
        private readonly AddYoutubeViewersViewModel _addYoutubeViewersViewModel;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YoutubeViewerStore _youtubeViewerStore;

        public AddYoutubeViewerCommand(ViewModels.AddYoutubeViewersViewModel addYoutubeViewersViewModel, ModelNavigationStore modelNavigationStore, YoutubeViewerStore youtubeViewerStore)
        {
            _addYoutubeViewersViewModel = addYoutubeViewersViewModel;
            _modelNavigationStore = modelNavigationStore;
            _youtubeViewerStore = youtubeViewerStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            YoutubeViewersDetailFormViewModel formViewModel = _addYoutubeViewersViewModel._youtubeViewersDetailFormViewModel;
            formViewModel.ErrorMessage = null;
            formViewModel.IsSubmmiting = true;
            YoutubeViewerModel youtubeViewer = new YoutubeViewerModel(
                Guid.NewGuid(),
                formViewModel.UserName,
                formViewModel.IsSubscribed,
                formViewModel.IsMember);
            try
            {
                await _youtubeViewerStore.Add(youtubeViewer);
                _modelNavigationStore.Close();
            }
            catch (System.Exception)
            {

                formViewModel.ErrorMessage = "failed to add youtubeviewer.please restart the app";
            }
            finally
            {
                formViewModel.IsSubmmiting = false;
            }

        }
    }
}

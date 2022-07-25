using System;
using System.Threading.Tasks;
using YoutubeViewer.Domain.Models;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Commands
{
    public class EditYoutubeViewerCommand : AsyncCommandBase
    {
        private readonly EditYoutubeViewersViewModel _editYoutubeViewersViewModel;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YoutubeViewerStore _youtubeViewerStore;

        public EditYoutubeViewerCommand(ViewModels.EditYoutubeViewersViewModel editYoutubeViewersViewModel, ModelNavigationStore modelNavigationStore, YoutubeViewerStore youtubeViewerStore)
        {
            _editYoutubeViewersViewModel = editYoutubeViewersViewModel;
            _modelNavigationStore = modelNavigationStore;
            _youtubeViewerStore = youtubeViewerStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            YoutubeViewersDetailFormViewModel Detailforms = _editYoutubeViewersViewModel._youtubeViewersDetailFormViewModel;
            Detailforms.IsSubmmiting = true;
            Detailforms.ErrorMessage = null;
            YoutubeViewerModel youtubeViewer = new YoutubeViewerModel(
                _editYoutubeViewersViewModel.YotubeViewerId,
                Detailforms.UserName,
                Detailforms.IsSubscribed,
                Detailforms.IsMember);
            try
            {
                _youtubeViewerStore.Update(youtubeViewer);
                _modelNavigationStore.Close();
            }
            catch (Exception)
            {

               Detailforms.ErrorMessage="failed to add youtubeviewer.please restart the app";
            }

        }
    }
}

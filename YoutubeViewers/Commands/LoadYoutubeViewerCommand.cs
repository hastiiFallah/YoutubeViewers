using System;
using System.Threading.Tasks;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Commands
{
    public class LoadYoutubeViewerCommand : AsyncCommandBase
    {
        private readonly YoutubeViewersViewModel _youtubeViewersViewModel;
        private readonly YoutubeViewerStore _youtubeViewer;

        public LoadYoutubeViewerCommand(YoutubeViewersViewModel youtubeViewersViewModel, YoutubeViewerStore youtubeViewer)
        {
            _youtubeViewersViewModel = youtubeViewersViewModel;
            _youtubeViewer = youtubeViewer;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _youtubeViewersViewModel.ErrorMessage = null;
            _youtubeViewersViewModel.IsLaoding = true;
            try
            {
                await _youtubeViewer.Load();
            }
            catch (Exception)
            {

                _youtubeViewersViewModel.ErrorMessage = "failed to load youtube Viewer.Please Restart the Application";
            }
            finally
            {
                _youtubeViewersViewModel.IsLaoding = false;
            }
        }
    }
}

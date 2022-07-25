using System;
using System.Windows.Input;
using YoutubeViewers.Commands;
using YoutubeViewers.Models;
using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    public class EditYoutubeViewersViewModel : BaseViewModel
    {
        public Guid YotubeViewerId { get; }

        public YoutubeViewersDetailFormViewModel _youtubeViewersDetailFormViewModel { get; }
        public EditYoutubeViewersViewModel(YoutubeViewer youtubeviewer, YoutubeViewerStore youtubeViewerStore, ModelNavigationStore modelNavigation)
        {

            YotubeViewerId= youtubeviewer.Id;
            ICommand submitCommand = new EditYoutubeViewerCommand(this,modelNavigation,youtubeViewerStore);
            ICommand cancelCommand = new CloseModelCommand(modelNavigation);
            _youtubeViewersDetailFormViewModel = new YoutubeViewersDetailFormViewModel(submitCommand, cancelCommand)
            {
                UserName = youtubeviewer.UserName,
                IsMember = youtubeviewer.IsMember,
                IsSubscribed=youtubeviewer.IsSubscribed,
            };
        }
    }
}

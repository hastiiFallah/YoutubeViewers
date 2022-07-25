using System.Windows.Input;
using YoutubeViewers.Commands;
using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    public class AddYoutubeViewersViewModel : BaseViewModel
    {
        public YoutubeViewersDetailFormViewModel _youtubeViewersDetailFormViewModel { get; }


        public AddYoutubeViewersViewModel(ModelNavigationStore modelNavigation, YoutubeViewerStore _youtubeViewerStore)
        {
            ICommand submitCommand=new AddYoutubeViewerCommand(this,modelNavigation,_youtubeViewerStore);
            ICommand cancelCommand = new CloseModelCommand(modelNavigation);
            _youtubeViewersDetailFormViewModel = new YoutubeViewersDetailFormViewModel(submitCommand, cancelCommand);
        }
    }
}

using System.Windows.Input;
using YoutubeViewer.Domain.Models;
using YoutubeViewers.Commands;
using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    public class YoutubeViewersListingItemViewModel : BaseViewModel
    {
        public YoutubeViewerModel YoutubeViewer { get; private set; }

        private bool _isDeleting;
        public bool IsDeleting
        {
            get { return _isDeleting; }
            set { _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }
        public bool HasErrorMessage=>!string.IsNullOrEmpty(ErrorMessage);

        public string UserName => YoutubeViewer.UserName;
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }


        public YoutubeViewersListingItemViewModel(YoutubeViewerModel youtubeViewer, ModelNavigationStore modelNavigationStore, YoutubeViewerStore youtubeViewerStore)
        {
            YoutubeViewer = youtubeViewer;

            EditCommand = new OpenEditYoutubeViewerCommand(this, youtubeViewerStore, modelNavigationStore);
            DeleteCommand = new DeleteYoutubeViewerCommand(this, youtubeViewerStore);
        }

        public void Update(YoutubeViewerModel obj)
        {
            YoutubeViewer = obj;
            OnPropertyChanged(nameof(UserName));
        }
    }
}

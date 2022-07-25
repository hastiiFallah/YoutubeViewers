using System.Windows.Input;
using YoutubeViewers.Commands;
using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    public class YoutubeViewersViewModel : BaseViewModel
    {
        private readonly SelectedYoutubeViewersStore _selectedYoutubeViewersStore;

        private bool _IsLoading;
        public bool IsLaoding
        {
            get { return _IsLoading; }
            set { _IsLoading = value;
                OnPropertyChanged(nameof(IsLaoding));
            }
        }
        private string _errorMessgae;
        public string ErrorMessage
        {
            get { return _errorMessgae; }
            set
            {
                _errorMessgae = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public YoutubeViewersDetailsViewModel youtubeViewersDetailsViewModel { get; }
        public YoutubeViewersListingViewModel youtubeViewersListingViewModel { get; }

        public ICommand AddYoutubeViewrsCommand { get; }

        public ICommand LoadYoutubeViewerCommand { get; }
        public static YoutubeViewersViewModel LoadViewModel(YoutubeViewerStore youtubeViewerStore, SelectedYoutubeViewersStore selectedYoutubeViewersStore, ModelNavigationStore modelNavigationStore)
        {
            YoutubeViewersViewModel viewModel = new YoutubeViewersViewModel(youtubeViewerStore, modelNavigationStore, selectedYoutubeViewersStore);

            viewModel.LoadYoutubeViewerCommand.Execute(null);

            return viewModel;
        }
        public YoutubeViewersViewModel(YoutubeViewerStore youtubeViewerStore, ModelNavigationStore modelNavigationStore, SelectedYoutubeViewersStore selectedYoutubeViewersStore)
        {
            youtubeViewersDetailsViewModel = new YoutubeViewersDetailsViewModel(_selectedYoutubeViewersStore);
            LoadYoutubeViewerCommand=new LoadYoutubeViewerCommand(this,youtubeViewerStore);
            youtubeViewersListingViewModel =  new YoutubeViewersListingViewModel(youtubeViewerStore, _selectedYoutubeViewersStore, modelNavigationStore);
            AddYoutubeViewrsCommand = new OpenAddYoutubeViewerCommand(modelNavigationStore, youtubeViewerStore);
        }
   
    }
}

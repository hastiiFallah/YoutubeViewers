using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        public BaseViewModel CurrenModalViewModel => _modelNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modelNavigationStore.IsOpen;
        public YoutubeViewersViewModel _YoutubeViewersViewModel { get; }

        public MainViewModel(ModelNavigationStore modelNavigationStore, YoutubeViewersViewModel youtubeViewersViewModel)
        {
            _modelNavigationStore = modelNavigationStore;
            _YoutubeViewersViewModel = youtubeViewersViewModel;
            _modelNavigationStore.CurrentViewModelChanged += ModalNavigation_CurrentModalChanged;
        }
        protected override void Dispose()
        {
            _modelNavigationStore.CurrentViewModelChanged -= ModalNavigation_CurrentModalChanged;
            base.Dispose();
        }
        public void ModalNavigation_CurrentModalChanged()
        {
            OnPropertyChanged(nameof(CurrenModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }

    }
}

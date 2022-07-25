using YoutubeViewers.Models;
using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    public class YoutubeViewersDetailsViewModel : BaseViewModel
    {
        private readonly SelectedYoutubeViewersStore _selectedYoutubeViewersStore;
        private YoutubeViewer SelectedYoutubeViewer => _selectedYoutubeViewersStore.selecetedYoutubeViewer;
        public bool HasSelectedYoutubeViewer=>SelectedYoutubeViewer != null;
        public string UserName => SelectedYoutubeViewer?.UserName ?? "Unknown";
        public string IsSubscribedDisplay => (SelectedYoutubeViewer?.IsSubscribed ?? false) ? "Yes" : "No";
        public string IsMemberDispaly => (SelectedYoutubeViewer?.IsMember ?? false) ? "Yes" : "No";
        public YoutubeViewersDetailsViewModel(SelectedYoutubeViewersStore selectedYoutubeViewersStore)
        {
            _selectedYoutubeViewersStore = selectedYoutubeViewersStore;
            _selectedYoutubeViewersStore.selectedYoutubeViewersChanged += SelectedYoutubeViewersStore_selectedYoutubeViewersChanged;
        }
        protected override void Dispose()
        {
            _selectedYoutubeViewersStore.selectedYoutubeViewersChanged -= SelectedYoutubeViewersStore_selectedYoutubeViewersChanged;
            base.Dispose();
        }
        private void SelectedYoutubeViewersStore_selectedYoutubeViewersChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYoutubeViewer));
            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDispaly));
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using YoutubeViewer.Domain.Models;
using YoutubeViewers.Commands;
using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    public class YoutubeViewersListingViewModel : BaseViewModel
    {
        private readonly ObservableCollection<YoutubeViewersListingItemViewModel> _youtubeViewersListingItemViewModels;
        private readonly YoutubeViewerStore _youtubeViewerStore;
        private readonly SelectedYoutubeViewersStore _selectedYoutubeViewersStore;
        private readonly ModelNavigationStore _modelNavigationStore;
        public YoutubeViewersListingItemViewModel SelectedYoutubeViewerListingItemViewModel
        {
            get
            {
                return 
                    _youtubeViewersListingItemViewModels.FirstOrDefault
                    (y => y.YoutubeViewer.Id == _selectedYoutubeViewersStore.selecetedYoutubeViewer.Id);
            }
            set
            {
                _selectedYoutubeViewersStore.selecetedYoutubeViewer = value?.YoutubeViewer;
                
               
            }
        }
        
        public YoutubeViewersListingViewModel(YoutubeViewerStore youtubeViewerStore, SelectedYoutubeViewersStore selectedYoutubeViewersStore, ModelNavigationStore modelNavigationStore)
        {

            _youtubeViewerStore = youtubeViewerStore;
            _selectedYoutubeViewersStore = selectedYoutubeViewersStore;
            _modelNavigationStore = modelNavigationStore;
            _youtubeViewersListingItemViewModels = new ObservableCollection<YoutubeViewersListingItemViewModel>();

            _selectedYoutubeViewersStore.selectedYoutubeViewersChanged += _selectedYoutubeViewersStore_selectedYoutubeViewersChanged;
            _youtubeViewerStore.youtubeViewersAdded += _youtubeViewerStore_youtubeViewersAdded;
            _youtubeViewerStore.youtubeViewersUpdated += _youtubeViewerStore_youtubeViewersUpdated;
            _youtubeViewerStore.YoutubeViewerModelLoaded += _youtubeViewerStore_YoutubeViewerModelLoaded;
            _youtubeViewerStore.youtubeViewersDeleted += _youtubeViewerStore_youtubeViewersDeleted;
            _youtubeViewersListingItemViewModels.CollectionChanged += _youtubeViewersListingItemViewModels_CollectionChanged;


        }

        private void _youtubeViewersListingItemViewModels_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedYoutubeViewerListingItemViewModel));
        }

        private void _selectedYoutubeViewersStore_selectedYoutubeViewersChanged()
        {
            OnPropertyChanged(nameof(SelectedYoutubeViewerListingItemViewModel));
        }

        private void _youtubeViewerStore_youtubeViewersDeleted(Guid obj)
        {
            YoutubeViewersListingItemViewModel youtubeViewers =
                _youtubeViewersListingItemViewModels.FirstOrDefault(y => y.YoutubeViewer?.Id == obj);

            if(youtubeViewers is not null)
            {
                _youtubeViewersListingItemViewModels.Remove(youtubeViewers);
            }
        }

        private void _youtubeViewerStore_YoutubeViewerModelLoaded()
        {
            _youtubeViewersListingItemViewModels.Clear();
            foreach (YoutubeViewerModel youtubeViewerModel in _youtubeViewerStore.youtubeViewerModels)
            {
                AddYoutubeViewer(youtubeViewerModel);
            }
        }

  
        private void _youtubeViewerStore_youtubeViewersUpdated(YoutubeViewerModel obj)
        {
            YoutubeViewersListingItemViewModel youtubeViewersListingItem = _youtubeViewersListingItemViewModels
                  .FirstOrDefault(y => y.YoutubeViewer.Id == obj.Id);

            if (youtubeViewersListingItem is not null)
            {
                youtubeViewersListingItem.Update(obj);
            }
        }

        protected override void Dispose()
        {
            _youtubeViewerStore.youtubeViewersAdded -= _youtubeViewerStore_youtubeViewersAdded;
            _youtubeViewerStore.YoutubeViewerModelLoaded -= _youtubeViewerStore_YoutubeViewerModelLoaded;
            _selectedYoutubeViewersStore.selectedYoutubeViewersChanged-= _selectedYoutubeViewersStore_selectedYoutubeViewersChanged;
            base.Dispose();
        }

        private void _youtubeViewerStore_youtubeViewersAdded(YoutubeViewerModel obj)
        {
            AddYoutubeViewer(obj);
        }

        private void AddYoutubeViewer(YoutubeViewerModel youtubeViewer)
        {
            YoutubeViewersListingItemViewModel itemViewModel = new YoutubeViewersListingItemViewModel
                (youtubeViewer, _modelNavigationStore, _youtubeViewerStore);
            _youtubeViewersListingItemViewModels.Add(itemViewModel);
        }

    }
}

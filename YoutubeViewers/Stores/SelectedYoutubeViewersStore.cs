using System;
using YoutubeViewer.Domain.Models;

namespace YoutubeViewers.Stores
{
    public class SelectedYoutubeViewersStore
    {
        private YoutubeViewerModel _selecetedYoutubeViewer;
        private readonly YoutubeViewerStore _youtubeViewerStore;

        public YoutubeViewerModel selecetedYoutubeViewer
        {
            get
            {
                return _selecetedYoutubeViewer;
            }
            set
            {
                _selecetedYoutubeViewer = value;
                selectedYoutubeViewersChanged?.Invoke();
            }
        }
        public event Action selectedYoutubeViewersChanged;
        public SelectedYoutubeViewersStore(YoutubeViewerStore youtubeViewerStore)
        {
            _youtubeViewerStore = youtubeViewerStore;
            _youtubeViewerStore.youtubeViewersAdded += _youtubeViewerStore_youtubeViewersAdded;
            _youtubeViewerStore.youtubeViewersUpdated += _youtubeViewerStore_youtubeViewersUpdated;

        }

        private void _youtubeViewerStore_youtubeViewersAdded(YoutubeViewerModel youtubeViewer)
        {
            selecetedYoutubeViewer = youtubeViewer;
        }

        private void _youtubeViewerStore_youtubeViewersUpdated(YoutubeViewerModel youtubeViewer)
        {
            if (youtubeViewer.Id == selecetedYoutubeViewer.Id)
            {
                selecetedYoutubeViewer = youtubeViewer;
            }
        }
    }
}

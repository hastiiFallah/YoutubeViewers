using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubeViewer.Domain.Commands;
using YoutubeViewer.Domain.Models;
using YoutubeViewer.Domain.Queries;

namespace YoutubeViewers.Stores
{
    public class YoutubeViewerStore
    {
        private readonly IGetAllYoutubeViewerQuery _getAllYoutubeViewerQuery;
        private readonly ICreateYoutubeViewerCommand _createYoutubeViewerCommand;
        private readonly IDeleteYoutubeViewerCommand _deleteYoutubeViewerCommand;
        private readonly IUpdateYoutubeViewerCommand _updateYoutubeViewerCommand;
        private readonly List<YoutubeViewerModel> _youtubeViewerModels;
        public IEnumerable<YoutubeViewerModel> youtubeViewerModels => _youtubeViewerModels;

        public event Action<YoutubeViewerModel> youtubeViewersAdded;
        public event Action<YoutubeViewerModel> youtubeViewersUpdated;
        public event Action<Guid> youtubeViewersDeleted;
        public event Action YoutubeViewerModelLoaded;
        public YoutubeViewerStore(IGetAllYoutubeViewerQuery getAllYoutubeViewerQuery
            , ICreateYoutubeViewerCommand createYoutubeViewerCommand
            , IDeleteYoutubeViewerCommand deleteYoutubeViewerCommand
            , IUpdateYoutubeViewerCommand updateYoutubeViewerCommand)
        {
            _getAllYoutubeViewerQuery = getAllYoutubeViewerQuery;
            _createYoutubeViewerCommand = createYoutubeViewerCommand;
            _deleteYoutubeViewerCommand = deleteYoutubeViewerCommand;
            _updateYoutubeViewerCommand = updateYoutubeViewerCommand;
        }
        public async Task Load()
        {
            IEnumerable<YoutubeViewerModel> youtubeViewerModels = await _getAllYoutubeViewerQuery.Execute();
            _youtubeViewerModels.Clear();
            _youtubeViewerModels.AddRange(youtubeViewerModels);

            YoutubeViewerModelLoaded?.Invoke();
        }
        public async Task Add(YoutubeViewerModel youtubeViewer)
        {
           await _createYoutubeViewerCommand.Excute(youtubeViewer);
            _youtubeViewerModels.Add(youtubeViewer);
            youtubeViewersAdded?.Invoke(youtubeViewer);
        }
        public async Task Update(YoutubeViewerModel youtubeViewer)
        {
            await _updateYoutubeViewerCommand.Excute(youtubeViewer);
            int currentIndex = _youtubeViewerModels.FindIndex(y => y.Id == youtubeViewer.Id);
            if (currentIndex != -1)
            {
                _youtubeViewerModels[currentIndex] = youtubeViewer;
            }
            else
            {
                _youtubeViewerModels.Add(youtubeViewer);
            }
            youtubeViewersUpdated?.Invoke(youtubeViewer);
        }
        public async Task Delete(Guid id)
        {
            try
            {
                await _deleteYoutubeViewerCommand.Excute(id);
                _youtubeViewerModels.RemoveAll(y => y.Id == id);
                youtubeViewersDeleted?.Invoke(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

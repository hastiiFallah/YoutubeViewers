using YoutubeViewer.Domain.Models;

namespace YoutubeViewer.Domain.Queries
{
    public interface IGetAllYoutubeViewerQuery
    {
        Task<IEnumerable<YoutubeViewerModel>> Execute();
    }
}

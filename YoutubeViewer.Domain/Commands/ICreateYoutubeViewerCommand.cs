using YoutubeViewer.Domain.Models;

namespace YoutubeViewer.Domain.Commands
{
    public interface ICreateYoutubeViewerCommand
    {
        Task Excute(YoutubeViewerModel youtubeViewer);
    }
}

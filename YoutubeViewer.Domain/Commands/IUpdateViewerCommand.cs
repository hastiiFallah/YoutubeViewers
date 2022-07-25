using YoutubeViewer.Domain.Models;

namespace YoutubeViewer.Domain.Commands
{
    public interface IUpdateYoutubeViewerCommand
    {
        Task Excute(YoutubeViewerModel youtubeViewer);
    }
}

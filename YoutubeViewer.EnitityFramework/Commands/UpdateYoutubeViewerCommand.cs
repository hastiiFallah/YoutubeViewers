using YoutubeViewer.Domain.Commands;
using YoutubeViewer.Domain.Models;
using YoutubeViewer.EnitityFramework.DTOs;

namespace YoutubeViewer.EnitityFramework.Commands
{
    public class UpdateYoutubeViewerCommand : IUpdateYoutubeViewerCommand
    {
        private readonly YoutubeViewersDbContextFactory _factory;

        public UpdateYoutubeViewerCommand(YoutubeViewersDbContextFactory factory)
        {
            _factory = factory;
        }
        public async Task Excute(YoutubeViewerModel youtubeViewerModel)
        {
            using (YoutubeViewerDbContext context = _factory.Create())
            {
                YoutubeViewerDTO youtubeViewerDTO = new YoutubeViewerDTO()
                {
                    Id = youtubeViewerModel.Id,
                    UserName = youtubeViewerModel.UserName,
                    IsSubscribed = youtubeViewerModel.IsSubscribed,
                    IsMember = youtubeViewerModel.IsMember
                };

                context.youtubeViewers.Update(youtubeViewerDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}

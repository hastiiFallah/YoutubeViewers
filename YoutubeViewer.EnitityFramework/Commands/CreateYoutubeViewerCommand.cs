using YoutubeViewer.Domain.Commands;
using YoutubeViewer.Domain.Models;
using YoutubeViewer.EnitityFramework.DTOs;

namespace YoutubeViewer.EnitityFramework.Commands
{
    public class CreateYoutubeViewerCommand : ICreateYoutubeViewerCommand
    {
        private readonly YoutubeViewersDbContextFactory _factory;

        public CreateYoutubeViewerCommand(YoutubeViewersDbContextFactory factory)
        {
            _factory = factory;
        }

        public async Task Excute(YoutubeViewerModel youtubeViewer)
        {
            using (YoutubeViewerDbContext context = _factory.Create())
            {
                YoutubeViewerDTO youtubeViewerDTO = new YoutubeViewerDTO()
                {
                    Id = youtubeViewer.Id,
                    UserName = youtubeViewer.UserName,
                    IsSubscribed = youtubeViewer.IsSubscribed,
                    IsMember = youtubeViewer.IsMember
                };

                context.youtubeViewers.Add(youtubeViewerDTO);
                await context.SaveChangesAsync();
            }
        }

      
    }
}

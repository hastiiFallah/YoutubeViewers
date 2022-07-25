using YoutubeViewer.Domain.Commands;
using YoutubeViewer.EnitityFramework.DTOs;

namespace YoutubeViewer.EnitityFramework.Commands
{
    public class DeleteYoutubeViewerCommand : IDeleteYoutubeViewerCommand
    {
        private readonly YoutubeViewersDbContextFactory _factory;

        public DeleteYoutubeViewerCommand(YoutubeViewersDbContextFactory factory)
        {
            _factory = factory;
        }
        public async Task Excute(Guid  id)
        {
            using (YoutubeViewerDbContext context = _factory.Create())
            {
                YoutubeViewerDTO youtubeViewerDTO = new YoutubeViewerDTO()
                {
                    Id = id
                  
                };

                context.youtubeViewers.Remove(youtubeViewerDTO);
                await context.SaveChangesAsync();
            }
        }
     
    }
}

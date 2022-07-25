using Microsoft.EntityFrameworkCore;
using YoutubeViewer.Domain.Models;
using YoutubeViewer.Domain.Queries;
using YoutubeViewer.EnitityFramework.DTOs;

namespace YoutubeViewer.EnitityFramework.Queries
{
    public class GetAllYoutubeViewerQuery : IGetAllYoutubeViewerQuery
    {
        private readonly YoutubeViewersDbContextFactory _factory;

        public GetAllYoutubeViewerQuery(YoutubeViewersDbContextFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<YoutubeViewerModel>> Execute()
        {
            using (YoutubeViewerDbContext context= _factory.Create())
            {
                IEnumerable<YoutubeViewerDTO> youtubeViewerDTOs =await context.youtubeViewers.ToListAsync();
                return youtubeViewerDTOs.Select(y => new YoutubeViewerModel(y.Id, y.UserName, y.IsMember, y.IsSubscribed));
            }
        }
    }
}

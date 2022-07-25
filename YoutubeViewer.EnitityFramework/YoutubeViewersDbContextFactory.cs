using Microsoft.EntityFrameworkCore;

namespace YoutubeViewer.EnitityFramework
{
    public class YoutubeViewersDbContextFactory
    {
        private readonly DbContextOptions _options;

        public YoutubeViewersDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public YoutubeViewerDbContext Create()
        {
            return new YoutubeViewerDbContext(_options);
        }
    }
}

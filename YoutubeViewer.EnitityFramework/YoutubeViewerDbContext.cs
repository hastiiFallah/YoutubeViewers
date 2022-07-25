using Microsoft.EntityFrameworkCore;
using YoutubeViewer.EnitityFramework.DTOs;

namespace YoutubeViewer.EnitityFramework
{
    public class YoutubeViewerDbContext : DbContext
    {


        public YoutubeViewerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<YoutubeViewerDTO> youtubeViewers { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YoutubeViewer.EnitityFramework
{
    public class YoutubeViewersDesignTimeDbContextFactory:IDesignTimeDbContextFactory<YoutubeViewerDbContext>
    {
   

        public YoutubeViewerDbContext CreateDbContext(string[] args)
        {
            return new YoutubeViewerDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=YoutubeViewer.db").Options);
        }
    }
}

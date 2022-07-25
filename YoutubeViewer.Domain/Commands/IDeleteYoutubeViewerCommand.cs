using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeViewer.Domain.Commands
{
    public interface IDeleteYoutubeViewerCommand
    {
        Task Excute(Guid id);
    }
}

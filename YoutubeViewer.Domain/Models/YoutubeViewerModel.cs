namespace YoutubeViewer.Domain.Models
{
    public class YoutubeViewerModel
    {
        public Guid Id { get; }
        public string UserName { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public YoutubeViewerModel(Guid id, string userName, bool isSubscribed, bool isMember)
        {
            Id = id;
            UserName = userName;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }
    }
}

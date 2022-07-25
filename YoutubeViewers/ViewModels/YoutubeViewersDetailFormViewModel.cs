using System.Windows.Input;

namespace YoutubeViewers.ViewModels
{
    public class YoutubeViewersDetailFormViewModel : BaseViewModel
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }
        private bool _isSubscribed;

        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            set
            { 
                _isSubscribed = value;
                OnPropertyChanged(nameof(IsSubscribed));
            }
        }
        private bool _isMember;

        private bool _isSubmitting;

        public bool IsSubmmiting
        {
            get { return _isSubmitting; }
            set { _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmmiting));
            }
        }


        public bool IsMember
        {
            get { return _isMember; }
            set
            {
                _isMember = value;
                OnPropertyChanged(nameof(IsMember));
            }
        }

        private string _errrorMessage;

        public string ErrorMessage
        {
            get { 
                return _errrorMessage;
            }
            set {
                _errrorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
                 }
        }
        public bool HasErrorMessage=>!string.IsNullOrEmpty(ErrorMessage);   
        public bool CanSubmit=>!string.IsNullOrEmpty(UserName);
        public ICommand SubmitCommand { get;}
        public ICommand CancelCommand { get; }

        public YoutubeViewersDetailFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}

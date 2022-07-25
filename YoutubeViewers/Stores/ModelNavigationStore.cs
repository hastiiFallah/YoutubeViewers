using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Stores
{
    public class ModelNavigationStore
    {
        private BaseViewModel _currentViewModel;
        public bool IsOpen=>CurrentViewModel!=null;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            {
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }
        internal void Close()
        {
            CurrentViewModel = null;
        }

        public event Action CurrentViewModelChanged;

    }
}

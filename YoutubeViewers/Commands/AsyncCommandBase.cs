using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeViewers.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _IsExcuting;

        public bool isExcuting
        {
            get { return _IsExcuting; }
            set { _IsExcuting = value; }
        }

        public override bool CanExecute(object? parameter)
        {
            return !isExcuting && base.CanExecute(parameter);
        }
        public override async void Execute(object? parameter)
        {
            isExcuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception)
            {
            }
            finally
            {
                isExcuting = false;
            }

        }
        public abstract Task ExecuteAsync(object parameter);
    }
}

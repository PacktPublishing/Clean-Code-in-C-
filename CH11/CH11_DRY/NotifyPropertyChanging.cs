using PostSharp.Patterns.Model;
using System.ComponentModel;

namespace CH11_DRY
{
    [NotifyPropertyChanged]
    public abstract class NotifyPropertyChanging : INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler PropertyChanging;

        protected void OnPropertyChanging(string propertyName)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}

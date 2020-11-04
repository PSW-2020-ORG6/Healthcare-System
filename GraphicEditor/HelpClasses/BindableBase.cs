using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GraphicEditor.HelpClasses
{
    /// <summary>
    /// This class will be inherited by every ViewModel class.
    /// Its purpose is for enabling the dynamic change of values in the view of binded class properties.
    /// </summary>
    public class BindableBase : INotifyPropertyChanged
    {

        protected virtual void SetProperty<T>(ref T member, T val,
           [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}

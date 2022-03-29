using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UCSEditor.Extensions
{
    internal static class INotifyPropertyChangedExtensions
    {
        public static void OnPropertyChanged(this INotifyPropertyChanged obj, in PropertyChangedEventHandler evt, [CallerMemberName] in string propertyName = "")
        {
            evt?.Invoke(obj, new PropertyChangedEventArgs(propertyName));
        }
    }
}

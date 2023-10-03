using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UCSEditor.Extensions
{
    /// <summary>
    /// Extensions for the INotifyPropertyChanged interface.
    /// </summary>
    internal static class INotifyPropertyChangedExtensions
    {
        /// <summary>
        /// Invokes a PropertyChanged event via the specified handler.
        /// </summary>
        /// <param name="obj">The caller object, which is an instance of a class that implements `INotifyPropertyChanged`.</param>
        /// <param name="evt">The PropertyChanged event handler.</param>
        /// <param name="propertyName">The name of the property got assigned a new value. It is recommended to use the default value here, which is the caller member name (automatically fetched via the `CallerMemberName` attribute.</param>
        public static void OnPropertyChanged(this INotifyPropertyChanged obj, in PropertyChangedEventHandler evt, [CallerMemberName] in string propertyName = "")
        {
            evt?.Invoke(obj, new PropertyChangedEventArgs(propertyName));
        }
    }
}

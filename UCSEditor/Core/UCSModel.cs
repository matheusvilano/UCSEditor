using System.ComponentModel;
using System.IO;
using UCSEditor.Extensions;

namespace UCSEditor.Core
{
    /// <summary>
    /// The UCS model.
    /// </summary>
    public class UCSModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Parameterless constructor. Whenever possible, prefer a parameterized overload.
        /// </summary>
        public UCSModel() { }

        /// <summary>
        /// Parameterized constructor. Initializes all fields.
        /// </summary>
        /// <param name="originalPath">The audio file's original path.</param>
        /// <param name="cat">The category.</param>
        /// <param name="name">The file name.</param>
        /// <param name="creator">The name of the designer who created the sound in the audio file.</param>
        /// <param name="source">The source of the audio file. In other words, where it comes from (e.g. Sound Library X).</param>
        /// <param name="userData">Any additional information.</param>
        /// <param name="extension">The file format/extension (e.g. wav).</param>
        public UCSModel(in string originalPath, in string cat, in string name, in string creator, in string source, in string userData, in string extension) 
        {
            OriginalPath = originalPath;
            Category = cat;
            Name = name;
            Creator = creator;
            Source = source;
            UserData = userData;
            Extension = extension;
        }

        /// <summary>
        /// Part of the `INotifyPropertyChanged` interface. Invoked whenever a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The audio file's original path.
        /// </summary>
        private string originalPath = "";

        /// <summary>
        /// The folder where the audio file is located.
        /// </summary>
        private string directory = "C:";
        
        /// <summary>
        /// The category.
        /// </summary>
        private string category = "NULLNone";

        /// <summary>
        /// The file name.
        /// </summary>
        private string name = "Unnamed";

        /// <summary>
        /// The name of the designer who created the sound in the audio file.
        /// </summary>
        private string creator = "Unknown";

        /// <summary>
        /// The source of the audio file. In other words, where it comes from (e.g. Sound Library X).
        /// </summary>
        private string source = "Unknown";

        /// <summary>
        /// Any additional information.
        /// </summary>
        private string userData = "";

        /// <summary>
        /// The file format/extension (e.g. wav).
        /// </summary>
        private string extension = "wav";

        /// <summary>
        /// The audio file's original path.
        /// </summary>
        public string OriginalPath
        {
            get => originalPath;
            set
            {
                originalPath = value ?? "";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// The folder where the audio file is located.
        /// </summary>
        public string Directory
        {
            get => directory;
            set
            {
                directory = value ?? "C:";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// The category.
        /// </summary>
        public string Category
        {
            get => category;
            set
            {
                category = value != null ? value.KeepOnlyLetters() : "NULLNone";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// The file name.
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value != null ? value.KeepOnlyLettersAndDigits() : "Unnamed"; // TODO: letters, digits, and whitespace.
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// The name of the designer who created the sound in the audio file.
        /// </summary>
        public string Creator 
        {
            get => creator;
            set
            {
                creator = value ?? "Unknown";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// The source of the audio file. In other words, where it comes from (e.g. Sound Library X).
        /// </summary>
        public string Source 
        {
            get => source;
            set
            {
                source = value != null ? value.KeepOnlyLettersAndDigits() : "Unknown";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// Any additional information.
        /// </summary>
        public string UserData
        {
            get => userData;
            set
            {
                userData = value != null ? value : ""; // TODO: letters, digits, and whitespace.
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// The file format/extension (e.g. wav).
        /// </summary>
        public string Extension
        {
            get => extension;
            set
            {
                extension = value != null ? value.KeepOnlyLettersAndDigits() : "";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// Renames the file based on this object's new state. See `ToString` for context.
        /// </summary>
        public void RenameAtOriginalLocation()
        {
            new FileInfo(OriginalPath).Rename(ToString(true));
            OriginalPath = ToString(true);
        }

        /// <summary>
        /// Converts this object to a string.
        /// </summary>
        /// <returns>This object as a string: the `Category`, `Name`, `Creator`, `Source`, `UserData` (if any), and `Extension` properties' string representations separated by underscores.</returns>
        public override string ToString()
        {
            if (UserData == "")
            {
                return $"{Category}_{Name}_{Creator}_{Source}.{Extension}";
            }
            else
            {
                return $"{Category}_{Name}_{Creator}_{Source}_{UserData}.{Extension}";
            }
        }

        /// <summary>
        /// Converts this object to a string.
        /// </summary>
        /// <param name="requestFullPath">Whether to include the `Directory` (as the first part of the string).</param>
        /// <returns>This object as a string: the `Category`, `Name`, `Creator`, `Source`, `UserData` (if any), and `Extension` properties' string representations separated by underscores.</returns>
        public string ToString(in bool requestFullPath)
        {
            if (requestFullPath)
            {
                return $"{Directory}/{ToString()}";
            }
            else
            {
                return ToString();
            }
        }
    }
}

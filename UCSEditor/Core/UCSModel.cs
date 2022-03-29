using System.ComponentModel;
using System.IO;
using UCSEditor.Extensions;

namespace UCSEditor.Core
{
    public class UCSModel : INotifyPropertyChanged
    {
        public UCSModel() { }
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

        public event PropertyChangedEventHandler PropertyChanged;

        private string originalPath = "";
        private string directory = "C:";
        private string category = "NULLNone";
        private string name = "Unnamed";
        private string creator = "Unknown";
        private string source = "Unknown";
        private string userData = "";
        private string extension = "wav";

        public string OriginalPath
        {
            get => originalPath;
            set
            {
                originalPath = value ?? "";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        public string Directory
        {
            get => directory;
            set
            {
                directory = value ?? "C:";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        public string Category
        {
            get => category;
            set
            {
                category = value != null ? value.KeepOnlyLetters() : "NULLNone";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value != null ? value.KeepOnlyLettersAndDigits() : "Unnamed"; // TODO: letters, digits, and whitespace.
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        public string Creator 
        {
            get => creator;
            set
            {
                creator = value ?? "Unknown";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        public string Source 
        {
            get => source;
            set
            {
                source = value != null ? value.KeepOnlyLettersAndDigits() : "Unknown";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        public string UserData
        {
            get => userData;
            set
            {
                userData = value != null ? value : ""; // TODO: letters, digits, and whitespace.
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        public string Extension
        {
            get => extension;
            set
            {
                extension = value != null ? value.KeepOnlyLettersAndDigits() : "";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        public void RenameAtOriginalLocation()
        {
            new FileInfo(OriginalPath).Rename(ToString(true));
            OriginalPath = ToString(true);
        }

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

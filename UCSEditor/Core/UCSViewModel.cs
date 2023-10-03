using System.ComponentModel;
using System.IO;
using UCSEditor.Extensions;

namespace UCSEditor.Core
{
    /// <summary>
    /// The UCS ViewModel.
    /// </summary>
    public class UCSViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Default constructor for objects of the UCSViewModel class.
        /// </summary>
        public UCSViewModel()
        {
            UCSEntries = new BindingList<UCSModel>();
            UCSCategories = Core.UCSCategories.Get();
            UCSTokens = new string[] { "CAT ID", "FX Name", "Creator ID", "Source ID", "User Data" };

            // TODO: Remove the code below. It's temporary.
            string[] files = Directory.GetFiles("/Users/mattvilano/Downloads/Source Jam Beta 1/Ericka Florencia");
            GetUCSEntries(files);

            SelectedUCSEntry = UCSEntries[0];
        }

        /// <summary>
        /// Called whenever a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Runtime log. Used to display messages in the UI.
        /// </summary>
        private string tempLog = "";

        /// <summary>
        /// A list of all UCS file paths,
        /// </summary>
        private BindingList<UCSModel> ucsEntries;

        /// <summary>
        /// The currently-selected UCS entry.
        /// </summary>
        private UCSModel selectedUCSEntry;

        /// <summary>
        /// The available UCS categories.
        /// </summary>
        private string[] ucsCategories;

        /// <summary>
        /// An array of strings containing the USC token names.
        /// </summary>
        private string[] ucsTokens;

        /// <summary>
        /// A list of all UCS file paths,
        /// </summary>
        public BindingList<UCSModel> UCSEntries
        {
            get => ucsEntries;
            set
            {
                ucsEntries = value ?? ucsEntries;
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// The currently-selected UCS entry.
        /// </summary>
        public UCSModel SelectedUCSEntry
        {
            get => selectedUCSEntry;
            set
            {
                selectedUCSEntry = value;
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// The available UCS categories.
        /// </summary>
        public string[] UCSCategories
        {
            get => ucsCategories;
            set
            {
                ucsCategories = value ?? ucsCategories;
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// Runtime log. Used to display messages in the UI.
        /// </summary>
        public string TempLog
        {
            get => $"LOG: {tempLog}";
            set
            {
                tempLog = value ?? "";
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// An array of strings containing the USC token names.
        /// </summary>
        public string[] UCSTokens
        {
            get => ucsTokens;
            set
            {
                ucsTokens = value ?? new string[] { "" };
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        /// <summary>
        /// Renames (updates) all UCS entries currently loaded (and modified).
        /// </summary>
        /// <returns></returns>
        public uint RenameUCSEntries()
        {
            uint count = 0;

            foreach (var ucsEntry in UCSEntries)
            {
                ucsEntry.RenameAtOriginalLocation();
                ++count;
            }

            return count;
        }

        /// <summary>
        /// Updates the UCS data.
        /// </summary>
        /// <param name="paths">The paths to UCS-compatible files.</param>
        public void GetUCSEntries(string[] paths)
        {
            // Empty the collection before getting new UCS data.
            var newUCSEntries = new BindingList<UCSModel>();
            foreach (string path in paths)
            {
                // Initialize UCS entry.
                var newUCSEntry = new UCSModel();
                newUCSEntry.OriginalPath = Path.GetFullPath(path);

                // Full directory name (includes the directory itself, the file, and the extension).
                string nameDirectory = Path.GetDirectoryName(path);
                newUCSEntry.Directory = nameDirectory;

                // The names of the file itself and its extension.
                string[] nameFileWIthExtension = Path.GetFileName(path).Split('.');
                string nameFile = nameFileWIthExtension[0];
                string nameExtension = nameFileWIthExtension.GetLastObject(); // e.g. ".wav"
                newUCSEntry.Extension = nameExtension;

                // The different UCS "tokens" of the filename. We need to assign these separately.
                string[] tokensFile = nameFile.Split('_');
                for (byte token = 0; token < tokensFile.Length; ++token)
                {
                    switch (token)
                    {
                        case 0: newUCSEntry.Category = tokensFile[token];   break;
                        case 1: newUCSEntry.Name = tokensFile[token];       break;
                        case 2: newUCSEntry.Creator = tokensFile[token];    break;
                        case 3: newUCSEntry.Source = tokensFile[token];     break;
                        case 4: newUCSEntry.UserData = tokensFile[token];   break;
                        default:                                        break;
                    }
                }

                // Add this UCS entry to the collection.
                newUCSEntries.Add(newUCSEntry);
            }

            UCSEntries = newUCSEntries;
        }
    }
}

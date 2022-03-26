namespace NamingConventionUtilities
{
    internal class UCSName
    {
        public UCSName() { }
        public UCSName(in string cat, in string name, in string creator, in string source, in string userData, in string extension) 
        {
            CAT = cat;
            Name = name;
            Creator = creator;
            Source = source;
            UserData = userData;
            Extension = extension;
        }

        private string cat = "NULLNone";
        public string CAT
        {
            get => cat;
            set => cat = value is not null ? value.KeepOnlyLetters() : "NULLNone";
        }

        private string name = "Unnamed";
        public string Name
        {
            get => name;
            set => name = value is not null ? value.KeepOnlyLettersAndDigits() : "Unnamed";
        }

        private string creator = "Unknown";
        public string Creator 
        {
            get => creator;
            set => creator = value is not null ? value : "Unknown";
        }

        private string source = "Unknown";
        public string Source 
        {
            get => source;
            set => source = value is not null ? value.KeepOnlyLettersAndDigits() : "Unknown";
        }

        private string userData = "";
        public string UserData
        {
            get => userData;
            set => userData = value is not null ? value : "";
        }

        private string extension = "wav";
        public string Extension
        {
            get => extension;
            set => extension = value is not null ? value.KeepOnlyLettersAndDigits() : "";
        }

        public override string ToString()
        {
            string formattedTags = "";

            for (byte tag = 0; tag < Tags.Count; ++tag)
            {
                formattedTags += Tags[tag];

                if (tag != (Tags.Count - 1))
                {
                    formattedTags += ' ';
                }
            }

            return $"{CAT}_{Name}_{Creator}_{Source}_{UserData}.{Extension}";
        }
    }
}

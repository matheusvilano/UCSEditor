namespace NamingConventionUtilities
{
    internal class StandardizedName
    {
        public StandardizedName() { }
        public StandardizedName(in string type, in string[] tags, in string author, in string library) 
        {
            Type = type;
            foreach (string str in tags) Tags.AddTag(str);
            Author = author;
            Library = library;
        }

        private string type = "MISCOther";
        public string Type
        { 
            get => type;
            set => type = value is not null ? value.KeepOnlyLetters() : "MISCOther";
        }

        private ListOfTags tags = new ListOfTags(5) { "Tag1", "Tag2", "Tag3", "Tag4", "Tag5" };
        private ListOfTags Tags
        {
            get => tags;
            set => tags = value is not null ? value : new ListOfTags(5);
        }

        private string author = "Unknown";
        public string Author 
        {
            get => author;
            set => author = value is not null ? value : "Unknown";
        }

        private string library = "None";
        public string Library 
        {
            get => library;
            set => library = value is not null ? value.KeepOnlyLettersAndDigits() : "None";
        }

        public bool AddTag(in string tag)
        {
            return tags.AddTag(tag);
        }

        public bool SetTag(in int number)
        {
            return true;
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

            return $"{Type}_{Tags}_{Author}_{Library}";
        }
    }
}

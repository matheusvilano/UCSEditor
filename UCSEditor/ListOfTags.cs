namespace NamingConventionUtilities
{
    internal class ListOfTags : List<string>
    {
        public ListOfTags() { }
        public ListOfTags(in int capacity) : base(capacity) { }

        public bool AddTag(in string tag, in bool allowExpansion = false)
        {
            if (tag is not null)
            { 
                if (this.Count >= this.Capacity)
                {
                    if (allowExpansion)
                    {
                        this.Add(tag.KeepOnlyLettersAndDigits());
                        return true;
                    }
                }
                else
                {
                    this.Add(tag.KeepOnlyLettersAndDigits());
                    return true;
                }
            }

            // Adding didn't work.
            return false;
        }

        public bool EditTag(in string tag, in int index)
        {
            if (index < this.Count)
            {
                if (tag is not null)
                {
                    this[index] = tag.KeepOnlyLettersAndDigits();
                    return true;
                }
            }

            // Editing didn't work.
            return false;
        }
    }
}

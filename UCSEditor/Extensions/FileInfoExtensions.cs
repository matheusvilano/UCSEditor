using System.IO;

namespace UCSEditor.Extensions
{
    public static class FileInfoExtensions
    {
        public static void Rename(this FileInfo fileInfo, in string newName)
        {
            fileInfo.MoveTo(Path.Combine(fileInfo.Directory.FullName, newName));
        }
    }
}

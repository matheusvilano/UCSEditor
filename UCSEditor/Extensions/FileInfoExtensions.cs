using System.IO;

namespace UCSEditor.Extensions
{
    /// <summary>
    /// Entensions for the FileInfo class.
    /// </summary>
    public static class FileInfoExtensions
    {
        /// <summary>
        /// Renames the file represented by the FileInfo object.
        /// </summary>
        /// <param name="fileInfo">The caller object, which is an instance of the FileInfo class.</param>
        /// <param name="newName">The new name.</param>
        public static void Rename(this FileInfo fileInfo, in string newName)
        {
            fileInfo.MoveTo(Path.Combine(fileInfo.Directory.FullName, newName));
        }
    }
}

namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Class for work with files.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Gets the extension of some file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>Returs the file extension like string.</returns>
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return "The string does not contain a file extension!";
            }

            string extension = fileName.Substring(indexOfLastDot + 1);

            return extension;
        }

        /// <summary>
        /// Gets the the name of some file without extension.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>Returs the file name like string.</returns>
        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);

            return extension;
        }
    }
}
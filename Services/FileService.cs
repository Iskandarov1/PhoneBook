using System.IO;

namespace PhoneBoolWithFile1.Services
{
    internal class FileService : IFileService
    {
        private const string filePath = "/Users/iskandarovs/RiderProjects/ConsoleApp4/ConsoleApp4/Text.rtf";

        public FileService()
        {
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        public void Save(string fileName, string data)
        {
            File.WriteAllText(fileName, data);
        }

        public void Append(string fileName, string data)
        {
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.Write(data);
            }
        }

        public string Read(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public void Delete(string fileName)
        {
            File.Delete(fileName);
        }

        public bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}

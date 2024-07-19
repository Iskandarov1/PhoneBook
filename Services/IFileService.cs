namespace PhoneBoolWithFile1.Services
{
    public interface IFileService
    {
        void Save(string fileName, string data);
        void Append(string fileName, string data);
        string Read(string fileName);
        void Delete(string fileName);
        bool Exists(string fileName);
    }
}
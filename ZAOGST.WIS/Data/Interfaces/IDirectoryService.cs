using System.Collections.ObjectModel;

namespace ZAOGST.WIS.Data.Interfaces;

public interface IDirectoryService
{
    public List<DirectoryInfo> GetDirectoriesInfo(string path);
    public List<FileInfo> GetFilesInfo(string path);
    public DirectoryInfo Create(string uploadDirectoryPath);
    public ObservableCollection<Tuple<string, string, ContentType>> GetDirectoriesAndFiles(string uploadsDirectoryPath);
}

public enum ContentType
{
    Directory,
    File
}

namespace ZAOGST.WIS.Data.Interfaces;

public interface IDirectoryService
{
    public List<DirectoryInfo> GetDirectoriesInfo(string path);
    public List<FileInfo> GetFilesInfo(string path);
    public DirectoryInfo Create(string uploadDirectoryPath);
}

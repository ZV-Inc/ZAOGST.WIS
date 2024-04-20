namespace ZAOGST.WIS.Data.Services;

public class DirectoryService : IDirectoryService
{
    public List<DirectoryInfo> GetDirectoriesInfo(string uploadDirectoryPath)
    {
        List<DirectoryInfo> directoriesInfo = new();
        List<string> directories = Directory.GetDirectories(uploadDirectoryPath).ToList();

        foreach (var directory in directories)
        {
            DirectoryInfo directoryInfo = new(directory);
            directoriesInfo.Add(directoryInfo);
        }

        return directoriesInfo;
    }

    public List<FileInfo> GetFilesInfo(string path)
    {
        List<FileInfo> filesInfo = new();
        List<string> files = Directory.GetFiles(path).ToList();

        foreach (var file in files)
        {
            FileInfo fileInfo = new(file);
            filesInfo.Add(fileInfo);
        }

        return filesInfo;
    }

    public DirectoryInfo Create(string path) => Directory.CreateDirectory(path);
}

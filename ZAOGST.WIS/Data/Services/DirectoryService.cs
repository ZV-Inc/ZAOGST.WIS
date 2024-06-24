using MudBlazor;
using System.Collections.ObjectModel;

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

    public ObservableCollection<Tuple<string, string, ContentType>> GetDirectoriesAndFiles(string uploadsDirectoryPath)
    {
        ObservableCollection<Tuple<string, string, ContentType>> directoriesAndFiles = new();

        List<DirectoryInfo> directories = GetDirectoriesInfo(uploadsDirectoryPath);
        List<FileInfo> files = GetFilesInfo(uploadsDirectoryPath);

        foreach (DirectoryInfo directory in directories)
            directoriesAndFiles.Add(new Tuple<string, string, ContentType>(Icons.Material.Filled.Folder, directory.Name, ContentType.Directory));

        foreach (FileInfo file in files)
            directoriesAndFiles.Add(new Tuple<string, string, ContentType>(Icons.Material.Outlined.InsertDriveFile, file.Name, ContentType.File));

        return directoriesAndFiles;
    }
}

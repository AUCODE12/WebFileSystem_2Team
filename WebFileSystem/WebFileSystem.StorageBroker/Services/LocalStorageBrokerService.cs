using System.IO.Compression;

namespace WebFileSystem.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private readonly string Data;

    public LocalStorageBrokerService()
    {
        Data = Path.Combine(Directory.GetCurrentDirectory(), "data");

        if (!Directory.Exists(Data))
        {
            Directory.CreateDirectory(Data);
        }
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
        directoryPath = directoryPath ?? string.Empty;
        directoryPath = Path.Combine(Data, directoryPath);
        var parent = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parent.FullName))
        {
            throw new Exception("Parent folder not found");
        }
        Directory.CreateDirectory(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine(Data, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("not found folder");
        }
        Directory.Delete(directoryPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
        filePath = Path.Combine(Data, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception($"{filePath} does not exist.");
        }
        File.Delete(filePath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        filePath = Path.Combine(Data, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("not found file");
        }
        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        if (Path.GetExtension(directoryPath) != string.Empty)
        {
            throw new Exception("Directory not found directory");
        }
        directoryPath = Path.Combine(Data, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("file exists");
        }
        var zipPath = directoryPath + ".zip";
        ZipFile.CreateFromDirectory(directoryPath, zipPath);
        var result = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
        return result;
    }

    public async Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath)
    {
        directoryPath = Path.Combine(Data, directoryPath);
        var parent = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parent.FullName))
        {
            throw new Exception($"{directoryPath} is not a directory");
        }
        var allDirectory = Directory.GetFileSystemEntries(directoryPath).ToList();
        allDirectory = allDirectory.Select(p => p.Remove(0, directoryPath.Length + 1)).ToList();
        return allDirectory;
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        filePath = Path.Combine(Data, filePath);
        var parent = Directory.GetParent(filePath);
        if (!Directory.Exists(parent.FullName))
        {
            throw new Exception("folder not found");
        }
        using (var uloadedLocation = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(uloadedLocation);
        }
    }
}

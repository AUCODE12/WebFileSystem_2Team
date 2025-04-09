using WebFileSystem.StorageBroker.Services;

namespace WebFileSystem.Service.Services;

public class StorageService : IStorageService
{
    private readonly IStorageBrokerService StorageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        StorageBrokerService = storageBrokerService;
    }

    public Task CreateDirectoryAsync(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDirectoryAsync(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> DownloadFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public Task UploadFileAsync(string filePath, Stream stream)
    {
        throw new NotImplementedException();
    }
}

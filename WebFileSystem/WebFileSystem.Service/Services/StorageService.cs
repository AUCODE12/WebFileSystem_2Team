using WebFileSystem.StorageBroker.Services;

namespace WebFileSystem.Service.Services;

public class StorageService : IStorageService
{
    private readonly IStorageBrokerService StorageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        StorageBrokerService = storageBrokerService;
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
        await StorageBrokerService.CreateDirectoryAsync(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        await StorageBrokerService.DeleteDirectoryAsync(directoryPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
        await StorageBrokerService.DeleteFileAsync(filePath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        var res = await StorageBrokerService.DownloadFileAsync(filePath);
        return res;
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        var res = await StorageBrokerService.DownloadFolderAsZipAsync(directoryPath);
        return res;
    }

    public async Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath)
    {
        return await StorageBrokerService.GetAllFilesAndDirectoriesAsync(directoryPath);
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        await StorageBrokerService.UploadFileAsync(filePath, stream);
    }
}

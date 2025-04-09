namespace WebFileSystem.Service.Services;

public interface IStorageService
{
    Task UploadFileAsync(string filePath, Stream stream);
    Task CreateDirectoryAsync(string directoryPath);
    Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath);
    Task<Stream> DownloadFileAsync(string filePath);
    Task<Stream> DownloadFolderAsZipAsync(string directoryPath);
    Task DeleteFileAsync(string filePath);
    Task DeleteDirectoryAsync(string directoryPath);
}
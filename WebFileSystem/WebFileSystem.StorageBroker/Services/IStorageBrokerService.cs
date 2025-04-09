namespace WebFileSystem.StorageBroker.Services
{
    public interface IStorageBrokerService
    {
        void UploadFileAsync(string filePath, string destinationPath);
        void CreateDirectoryAsyns(string directoryPath);
        List<string> GetFilesAndDirectoryAsync(string directoryPath);
        Stream DownloadFileAsync(string filePath);
        Stream DownloadFolderAsZipAsync(string directoryPath);
        void DeleteFileAsyns(string filePath);
        void DeleteDirectoryAsyns(string filePath);
    }
}
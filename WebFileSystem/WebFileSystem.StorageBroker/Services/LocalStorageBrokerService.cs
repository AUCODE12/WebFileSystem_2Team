
namespace WebFileSystem.StorageBroker.Services
{
    public class LocalStorageBrokerService : IStorageBrokerService
    {
        private IStorageBrokerService _storageBrokerService;
        public LocalStorageBrokerService(IStorageBrokerService storageBrokerService)
        {
            _storageBrokerService = storageBrokerService;
        }

        public void CreateDirectoryAsyns(string directoryPath)
        {
            _storageBrokerService.CreateDirectoryAsyns(directoryPath);
        }

        public void DeleteDirectoryAsyns(string filePath)
        {
            _storageBrokerService.DeleteDirectoryAsyns(filePath);
        }

        public void DeleteFileAsyns(string filePath)
        {
            _storageBrokerService.DeleteFileAsyns(filePath);
        }

        public Stream DownloadFileAsync(string filePath)
        {
            return _storageBrokerService.DownloadFileAsync(filePath);
        }

        public Stream DownloadFolderAsZipAsync(string directoryPath)
        {
            return _storageBrokerService.DownloadFolderAsZipAsync(directoryPath);
        }

        public List<string> GetFilesAndDirectoryAsync(string directoryPath)
        {
            return _storageBrokerService.GetFilesAndDirectoryAsync(directoryPath);
        }

        public void UploadFileAsync(string filePath, string destinationPath)
        {
            _storageBrokerService.UploadFileAsync(filePath, destinationPath);
        }
    }

}

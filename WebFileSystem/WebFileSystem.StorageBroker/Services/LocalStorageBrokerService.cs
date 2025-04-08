using Microsoft.AspNetCore.Http;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace WebFileSystem.StorageBroker.Services
{
    public class LocalStorageBrokerService : IStorageBrokerService
    {
        private readonly string _storageRoot = Path.Combine(Directory.GetCurrentDirectory(), "storage");

        public async Task SaveFileAsync(string filePath, IFormFile file)
        {
            var fullPath = Path.Combine(_storageRoot, filePath);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

        public async Task CreateDirectoryAsync(string directoryPath)
        {
            var fullDirectoryPath = Path.Combine(_storageRoot, directoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<string>> GetAllFilesAndDirectoriesAsync(string directoryPath)
        {
            var fullDirectoryPath = Path.Combine(_storageRoot, directoryPath);
            if (Directory.Exists(fullDirectoryPath))
            {
                var directories = Directory.GetDirectories(fullDirectoryPath);
                var files = Directory.GetFiles(fullDirectoryPath);
                return directories.Concat(files);
            }
            return Enumerable.Empty<string>();
        }

        public async Task DeleteFileAsync(string filePath)
        {
            var fullFilePath = Path.Combine(_storageRoot, filePath);
            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }
            await Task.CompletedTask;
        }

        public async Task DeleteDirectoryAsync(string directoryPath)
        {
            var fullDirectoryPath = Path.Combine(_storageRoot, directoryPath);
            if (Directory.Exists(fullDirectoryPath))
            {
                Directory.Delete(fullDirectoryPath, true);
            }
            await Task.CompletedTask;
        }

        public async Task<string> DownloadFileAsync(string filePath)
        {
            var fullFilePath = Path.Combine(_storageRoot, filePath);
            if (File.Exists(fullFilePath))
            {
                return fullFilePath;
            }
            return string.Empty;
        }

        public async Task<string> DownloadFolderAsZipAsync(string directoryPath)
        {
            var fullDirectoryPath = Path.Combine(_storageRoot, directoryPath);
            var zipFilePath = Path.Combine(_storageRoot, $"{directoryPath}.zip");

            if (Directory.Exists(fullDirectoryPath))
            {
                ZipFile.CreateFromDirectory(fullDirectoryPath, zipFilePath);
                return zipFilePath;
            }

            return string.Empty;
        }
    }
}

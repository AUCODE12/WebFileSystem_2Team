using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; // Ensure this package is installed

namespace WebFileSystem.StorageBroker.Services
{
    public interface IStorageBrokerService
    {
        Task SaveFileAsync(string filePath, IFormFile file);
        Task CreateDirectoryAsync(string directoryPath);
        Task<IEnumerable<string>> GetAllFilesAndDirectoriesAsync(string directoryPath);
        Task DeleteFileAsync(string filePath);
        Task DeleteDirectoryAsync(string directoryPath);
        Task<string> DownloadFileAsync(string filePath);
        Task<string> DownloadFolderAsZipAsync(string directoryPath);
    }
}

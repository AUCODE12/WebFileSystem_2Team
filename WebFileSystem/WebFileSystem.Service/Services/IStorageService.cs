using Microsoft.AspNetCore.Http;    
namespace WebFileSystem.Service.Services
{
    public interface IStorageService
    {
        Task<(bool IsSuccess, string ErrorMessage)> UploadFileAsync(IFormFile file);
        Task<(bool IsSuccess, string ErrorMessage)> CreateDirectoryAsync(string folderName);
        Task<(bool IsSuccess, string ErrorMessage, object Data)> GetAllFilesAndDirectoriesAsync();
        Task<(bool IsSuccess, string ErrorMessage)> DeleteFileAsync(string filePath);
        Task<(bool IsSuccess, string ErrorMessage)> DeleteDirectoryAsync(string directoryPath);
        Task<(bool IsSuccess, string ErrorMessage, string FilePath)> DownloadFileAsync(string filePath);
        Task<(bool IsSuccess, string ErrorMessage, string ZipFilePath)> DownloadFolderAsZipAsync(string folderPath);
    }
}

using Microsoft.AspNetCore.Mvc;
using WebFileSystem.Service.Services;

namespace WebFileSystem.Api.Controllers;

[Route("api/storage")]
[ApiController]
public class StorageController : ControllerBase
{
    private readonly IStorageService StorageService;

    public StorageController(IStorageService storageService)
    {
        StorageService = storageService;
    }

    [HttpPost("uploadFile")]
    public async Task UploadFile(IFormFile formFilem, string? directoryPath)
    {
        throw new NotImplementedException();
    }

    [HttpPost("uploadFiles")]
    public async Task UploadFiles(List<IFormFile> formFiles, string? directoryPath)
    {
        throw new NotImplementedException();
    }

    [HttpPost("createFolder")]
    public async Task CreateFolder(string folderPath)
    {
        throw new NotImplementedException();
    }    
    
    [HttpGet("getAll")]
    public async Task<List<string>> GetAllInFolderPath(string? directoryPath)
    {
        throw new NotImplementedException();
    }

    [HttpGet("downloadFile")]
    public async Task<FileStreamResult> DownloadFile(string filePath)
    {
       throw new NotImplementedException();
    }

    [HttpGet("downloadFolderAsZip")]
    public async Task<FileStreamResult> DownloadFolderAsZip(string directoryPath)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("deleteFile")]
    public async Task DeleteFile(string filePath)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("deleteDirectory")]
    public async Task DeleteDirectory(string directoryPath)
    {
        throw new NotImplementedException();
    }
}

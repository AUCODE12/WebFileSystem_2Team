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

    // uploadFile endpoint yozildi 
    // IFormFile yordamida bitta fayl qabul qilinadi va wwwroot/uploads ga saqlanadi
    // Agar uploads papkasi mavjud bo‘lmasa, u avtomatik yaratiladi
    [HttpPost("uploadFile")]
    public async Task<IActionResult> UploadFile(IFormFile formFilem, string? directoryPath)
    {
        if (formFilem == null || formFilem.Length == 0)
            return BadRequest("Fayl yuborilmadi ❌");

        string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string uploadsPath = Path.Combine(rootPath, "uploads");

        if (!Directory.Exists(uploadsPath))
            Directory.CreateDirectory(uploadsPath);

        string filePath = Path.Combine(uploadsPath, formFilem.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await formFilem.CopyToAsync(stream);
        }

        string fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{formFilem.FileName}";

        return Ok(new
        {
            Message = "✅ Fayl muvaffaqiyatli yuklandi",
            FileName = formFilem.FileName,
            Url = fileUrl
        });
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

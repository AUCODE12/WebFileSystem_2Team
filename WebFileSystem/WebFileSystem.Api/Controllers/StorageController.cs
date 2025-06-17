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

    /// <summary>
    /// Ushbu endpoint foydalanuvchidan fayl va kategoriya nomini qabul qilib, faylni mos kategoriya papkasiga saqlaydi.
    /// Misol: POST /api/storage/uploadByCategory?category=Images
    /// Fayl "wwwroot/{category}" ichiga yuklanadi. Agar papka mavjud bo‘lmasa — avtomatik yaratiladi.
    /// Yuklangan faylning to‘liq URL manzili javob sifatida qaytariladi.
    /// Bu metod fayllarni bo‘limlarga ajratib saqlash uchun juda foydali.
    /// </summary>

    [HttpPost("uploadByCategory")]
    public async Task<IActionResult> UploadFileByCategory(IFormFile file, string category)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Fayl yuborilmadi ❌");

        // Kategoriyaga qarab wwwroot ichida papka yaratamiz
        string categoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", category);

        if (!Directory.Exists(categoryPath))
            Directory.CreateDirectory(categoryPath);

        string filePath = Path.Combine(categoryPath, file.FileName);

        using (var stream = file.OpenReadStream())
        {
            await StorageService.UploadFileAsync(filePath, stream);
        }

        string fileUrl = $"{Request.Scheme}://{Request.Host}/{category}/{file.FileName}";

        return Ok(new
        {
            Message = "✅ Fayl yuklandi",
            Category = category,
            FileName = file.FileName,
            Url = fileUrl
        });
    }

    [HttpPost("createFolder")]
    public async Task CreateFolder(string folderPath)
    {
        throw new NotImplementedException();
    }


    // Bu metod berilgan fayl turiga qarab (masalan: jpg, png, txt) 
    // wwwroot papkasi ichidagi fayllarni qidiradi va faqat shu turdagilarni chiqaradi.
    // Masalan, agar "jpg" bersang, faqat .jpg fayllarni qaytaradi.
    // directoryPath orqali qaysi papkadan qidirish kerakligini ko‘rsatish mumkin.
    // Agar directoryPath berilmasa, wwwrootning o‘zi olinadi.


    [HttpGet("filterByType")]
    public async Task<IActionResult> FilterFilesByType(string type, string? directoryPath)
    {

        string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string fullPath = string.IsNullOrEmpty(directoryPath)
            ? rootPath
            : Path.Combine(rootPath, directoryPath);
        var files = await StorageService.GetAllFilesAndDirectoriesAsync(fullPath);
        var filteredFiles = files
            .Where(file => file.EndsWith($".{type}", StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(filteredFiles);
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

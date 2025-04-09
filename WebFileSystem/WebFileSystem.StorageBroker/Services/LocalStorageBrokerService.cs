namespace WebFileSystem.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private readonly string Data;

    public LocalStorageBrokerService()
    {
        Data = Path.Combine(Directory.GetCurrentDirectory(), "data");
        
        if (!Directory.Exists(Data))
        {
            Directory.CreateDirectory(Data);
        }
    }

    public Task CreateDirectoryAsync(string directoryPath)
    {
        // Bizda Data degan asosiy folder bor o'shani ichida papka yaralishi kerak, directoryPath bu yaraladigan folder nomi 
        throw new NotImplementedException();
    }

    public Task DeleteDirectoryAsync(string directoryPath)
    {
        // shu Datani ichida bitta directory nomi keladi o'shani o'chirish kerak
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(string filePath)
    {
        // shu Datani ichidagi file nomi keladi masalan car.jpg o'shni o'chirish kerak
        throw new NotImplementedException();
    }

    public Task<Stream> DownloadFileAsync(string filePath)
    {
        // shu data ichidagi file nomi keladi o'shini download qilish kerak
        throw new NotImplementedException();
    }

    public Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        //data ichida papka nomi kaladi papkani zip qilib download qilish kerak
        throw new NotImplementedException();
    }

    public Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath)
    {
        // directoryPath da kelayotgan papka ichida nima bo'lsa ham hammasni nomini chiqarishi kerak
        throw new NotImplementedException();
    }

    public Task UploadFileAsync(string filePath, Stream stream)
    {
        // data ichiga fili upload qilish kerak stream orqalis saqlanishi kerak
        throw new NotImplementedException();
    }
}

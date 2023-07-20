using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProEShop.Services.Contracts;

namespace ProEShop.Services.Services;
public class UploadFileService : IUploadFileService
{
    private const int MaxBufferSize = 0x10000; // 64K. The artificial constraint due to win32 api limitations. Increasing the buffer size beyond 64k will not help in any circumstance, as the underlying SMB protocol does not support buffer lengths beyond 64k.
    private readonly IWebHostEnvironment _environment;

    public UploadFileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    public async Task SaveFile(IFormFile file, string fileName, string oldFileName, params string[] destinationDirectoryNames)
    {
        if (file == null || file.Length == 0)
        {
            return;
        }

        var uploadRootFolder = Path.Combine(_environment.WebRootPath);

        if (destinationDirectoryNames is not null)
        {
            foreach (var folderName in destinationDirectoryNames)
            {
                uploadRootFolder = Path.Combine(uploadRootFolder, folderName);
            }
        }

        if (!Directory.Exists(uploadRootFolder))
        {
            Directory.CreateDirectory(uploadRootFolder);
        }

        var filePath = Path.Combine(uploadRootFolder, fileName);
        if (oldFileName != null)
        {
            var oldFilePath = Path.Combine(uploadRootFolder, oldFileName);
            File.Delete(oldFilePath);
        }

        await using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, MaxBufferSize,
            //you have to explicity open the FileStream as asynchronous
            //or else you're just doing synchronous operations on a background thread.
            useAsync: true);
        await file.CopyToAsync(fileStream);
    }

    public void DeleteFile(string fileName, params string[] destinationDirectoryNames)
    {
        if (fileName == null || destinationDirectoryNames == null || !destinationDirectoryNames.Any())
        {
            return;
        }

        var uploadRootFolder = Path.Combine(_environment.WebRootPath);

        foreach (var folderName in destinationDirectoryNames)
        {
            uploadRootFolder = Path.Combine(uploadRootFolder, folderName);
        }

        if (!Directory.Exists(uploadRootFolder))
        {
            return;
        }

        var filePath = Path.Combine(uploadRootFolder, fileName);
        if (!File.Exists(filePath))
        {
            return;
        }

        File.Delete(filePath);
    }
}

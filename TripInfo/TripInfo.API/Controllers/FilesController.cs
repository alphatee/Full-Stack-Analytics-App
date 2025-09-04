using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; // ApiController, ControllerBase, Route
using Microsoft.AspNetCore.StaticFiles; // FileExtensionContentTypeProvider

namespace TripInfo.API.Controllers;

[Route("api/files")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

    // Inversion of Control(IoC) Container [powerful tool] will inject it -> fileExtensionContentTypeProvider 
    public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
    {
        _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
            ?? throw new System.ArgumentNullException(
                nameof(fileExtensionContentTypeProvider));
    }

    // FileContentResult: Accepts file bytes and a content type of the file
    // FileStreamResult: Accepts a stream of file bytes and a content type of the file
    // PhysicalFileResult: Accepts a file path and a content type of the file
    // VirtualFileResult: Accepts a virtual file path and a content type of the file

    [HttpGet("{fileid}")]
    public ActionResult GetFile(string fileId)
    {
        // This method(File()) is defined on the ControllerBase and acts as a wrapper around the aforementioned FileResult subclasses.


        // look up the actual file, depending on the fileId...
        // demo code 
        var pathToFile = Path.Combine("CSV", "ueDeliveryTrips.csv");

        // check whether the file exists
        if (!System.IO.File.Exists(pathToFile))
        {
            return NotFound();
        }

        // find the content type for file
        if(!_fileExtensionContentTypeProvider.TryGetContentType(
            pathToFile, out var contentType))
        {
            contentType = "application/octet-stream"; // set default media type, a catch all
        }

        var bytes = System.IO.File.ReadAllBytes(pathToFile);
        return File(bytes, contentType, Path.GetFileName(pathToFile));
    }
}

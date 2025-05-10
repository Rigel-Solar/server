using Azure.Storage.Blobs;
using RigelSolarAPI.Dto;

namespace RigelSolarAPI.Utils;

public class BlobStorage
{
    private readonly BlobContainerClient _filesContainer;
    private readonly IConfiguration _configuration;
    public BlobStorage(IConfiguration configuration)
    {
        _configuration = configuration;
        var blobServiceClient = new BlobServiceClient(_configuration.GetSection("Keys").GetValue<string>("AzureKey"));
        _filesContainer = blobServiceClient.GetBlobContainerClient("files");
    }

    public async Task<List<BlobRequest>> ListAsync()
    {
        List<BlobRequest> files = new List<BlobRequest>();

        await foreach (var file in _filesContainer.GetBlobsAsync())
        {
            string uri = _filesContainer.Uri.ToString();
            var name = file.Name;
            var fullUri = $"{uri}/{name}";

            files.Add(new BlobRequest
            {
                Uri = fullUri,
                Name = name,
                ContentType = file.Properties.ContentType
            });
        }

        return files;
    }

    public async Task<BlobResponse> UploadAsync(IFormFile blob)
    {
        BlobResponse response = new();
        BlobClient client = _filesContainer.GetBlobClient($"{Guid.NewGuid()}-{blob.FileName}");

        await using (Stream? data = blob.OpenReadStream())
        {
            await client.UploadAsync(data);
        }

        response.Status = $"File {blob.FileName} Uploaded successfully";
        response.Error = false;
        response.Blob.Uri = client.Uri.AbsoluteUri;
        response.Blob.Name = blob.Name;

        return response;
    }
}

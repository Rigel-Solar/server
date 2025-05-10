namespace RigelSolarAPI.Dto;

public class BlobResponse
{
    public string? Status { get; set; }
    public bool Error { get; set; }
    public BlobRequest Blob { get; set; }

    public BlobResponse()
    {
        Blob = new BlobRequest();
    }
}

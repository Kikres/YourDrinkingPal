using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using DataLayer.Models.Domain;
using Microsoft.Extensions.Configuration;
using System.Drawing;

namespace BusinessLayer.Services.CommonServices;

public class CommonServiceBlobStorage
{
    private readonly string _connectionString;
    private readonly string _defaultContainer;

    public CommonServiceBlobStorage(IConfiguration configuration)
    {
        _connectionString = configuration["StorageAccount:ConnectionString"];
        _defaultContainer = configuration["StorageAccount:DefaultContainer"];
    }

    public UploadedImage UploadImage(string blobName, Bitmap bitmap)
    {
        BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_defaultContainer);

        containerClient.CreateIfNotExists();

        BlobClient blobClient = containerClient.GetBlobClient(blobName);

        using MemoryStream stream = new MemoryStream();
        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        stream.Position = 0;

        blobClient.Upload(stream, new BlobUploadOptions
        {
            HttpHeaders = new BlobHttpHeaders
            {
                ContentType = "image/png"
            }
        });

        return new UploadedImage { Name = blobClient.Name, ImageUrl = blobClient.Uri.ToString(), Uploaded = DateTime.Now };
    }

    public void RemoveImage(string blobName)
    {
        var blobServiceClient = new BlobServiceClient(_connectionString);
        var container = blobServiceClient.GetBlobContainerClient(_defaultContainer);
        var blob = container.GetBlobClient(blobName);
        blob.Delete();
    }
}
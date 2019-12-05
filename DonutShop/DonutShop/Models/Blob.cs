using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models
{
    public class Blob
    {

        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuration)
        {
            var storageCredentials = new StorageCredentials(configuration["BlobAccount"], configuration["BlobKey"]);
            CloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }
        /// <summary>
        /// Takes in a string and returns a blob container with the string as the name, or creates it if it doesn't exist.
        /// </summary>
        /// <param name="containerName">Takes in the container's name.</param>
        /// <returns>Returns the blob container.</returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer container = CloudBlobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();

            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            return container;
        }
        /// <summary>
        /// Takes in the file name and file path to be uploaded and uploads it to the container input.
        /// </summary>
        /// <param name="container">Takes in the blob container to be uploaded to.</param>
        /// <param name="fileName">Takes in the file name.</param>
        /// <param name="filePath">Takes in the path to the file as a string.</param>
        public async Task UploadFile(CloudBlobContainer container, string fileName, string filePath)
        {
            var blobFile = container.GetBlockBlobReference(fileName);
            await blobFile.UploadFromFileAsync(filePath);
        }
        /// <summary>
        /// Deletes a blob from a specific container based on a filename.
        /// </summary>
        /// <param name="container">Takes in the container for the blob.</param>
        /// <param name="fileName">Takes in the filename to be deleted.</param>
        public async Task DeleteBlob(CloudBlobContainer container, string fileName)
        {
            var blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.DeleteAsync();
        }
    }
}

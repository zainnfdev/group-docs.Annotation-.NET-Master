﻿#if !NETCOREAPP
using GroupDocs.Annotation.Models;
using GroupDocs.Annotation.Models.AnnotationModels;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage.Loading
{
    /// <summary>
    /// This example demonstrates loading document from Azure.
    /// </summary>
    class LoadDocumentFromAzure
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            string blobName = "sample.pdf";
            using (Annotator annotator = new Annotator(DownloadFile(blobName)))
            {
                AreaAnnotation area = new AreaAnnotation()
                {
                    Box = new Rectangle(100, 100, 100, 100),
                    BackgroundColor = 65535,
                };
                annotator.Add(area);
                annotator.Save(outputPath);
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }

        public static Stream DownloadFile(string blobName)
        {
            CloudBlobContainer container = GetContainer();
            CloudBlob blob = container.GetBlobReference(blobName);
            MemoryStream memoryStream = new MemoryStream();
            blob.DownloadToStream(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }

        private static CloudBlobContainer GetContainer()
        {
            string accountName = "***";
            string accountKey = "***";
            string endpoint = $"https://{accountName}.blob.core.windows.net/";
            string containerName = "***";
            StorageCredentials storageCredentials = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(
                storageCredentials, new Uri(endpoint), null, null, null);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();
            return container;
        }
    }
}
#endif
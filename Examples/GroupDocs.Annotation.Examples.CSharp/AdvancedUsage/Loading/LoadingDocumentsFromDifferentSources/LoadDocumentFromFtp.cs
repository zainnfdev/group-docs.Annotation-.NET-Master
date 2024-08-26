﻿using GroupDocs.Annotation.Models;
using GroupDocs.Annotation.Models.AnnotationModels;
using System;
using System.IO;
using System.Net;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage.Loading
{
    /// <summary>
    /// This example demonstrates loading document from FTP.
    /// </summary>
    class LoadDocumentFromFtp
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            string filePath = "sample.pdf";
            using (Annotator annotator = new Annotator(GetFileFromFtp(filePath)))
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

        private static Stream GetFileFromFtp(string filePath)
        {
            Uri uri = new Uri(filePath);
            FtpWebRequest request = CreateRequest(uri);
            using (WebResponse response = request.GetResponse())
                return GetFileStream(response);
        }

        private static FtpWebRequest CreateRequest(Uri uri)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            return request;
        }

        private static Stream GetFileStream(WebResponse response)
        {
            MemoryStream fileStream = new MemoryStream();
            using (Stream responseStream = response.GetResponseStream())
                responseStream.CopyTo(fileStream);
            fileStream.Position = 0;
            return fileStream;
        }
    }
}

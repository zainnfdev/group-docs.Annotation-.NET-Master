﻿using System.IO;
using GroupDocs.Annotation.Options;

namespace GroupDocs.Annotation.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates generating preview of document without rendering comments
    /// </summary>
    class GeneratePreviewWithoutAnnotations
    {
        public static void Run()
        {
            using (Annotator annotator = new Annotator(Constants.ANNOTATED_DOCX))
            {
                PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
                {
                    var pagePath = $"result{pageNumber}.png";
                    return File.Create(pagePath);
                });

                previewOptions.PreviewFormat = PreviewFormats.PNG;
                previewOptions.PageNumbers = new int[] {1, 2, 3, 4, 5, 6};
                previewOptions.RenderAnnotations = false;
                annotator.Document.GeneratePreview(previewOptions);
            }
        }
    }
}

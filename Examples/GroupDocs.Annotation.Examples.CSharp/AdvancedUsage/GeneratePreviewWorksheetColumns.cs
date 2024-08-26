﻿using GroupDocs.Annotation;
using GroupDocs.Annotation.Options;
using System;
using System.IO;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates generating previews from document with specified worksheet columns
    /// </summary>
    internal class GeneratePreviewWorksheetColumns
    {
        public static void Run()
        {
            PreviewOptions previewOptions =
                new PreviewOptions(
                    pageNumber => new FileStream(Path.Combine(Constants.GetOutputDirectoryPath(), $"cells_page{pageNumber}.png"), FileMode.Create),
                    (number, stream) => stream.Dispose()
                    );
            previewOptions.WorksheetColumns.Add(new WorksheetColumnsRange("Sheet1", 2, 3));
            previewOptions.WorksheetColumns.Add(new WorksheetColumnsRange("Sheet1", 1, 1));

            using (Annotator annotator = new Annotator(Constants.CELLS_INPUT))
            {
                annotator.Document.GeneratePreview(previewOptions);
            }
            Console.WriteLine($"\nDocument previews generated successfully.\nCheck output in {Constants.GetOutputDirectoryPath()}.");
        }
    }
}
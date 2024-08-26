﻿using System;
using System.IO;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage.Saving
{
    /// <summary>
    /// This example demonstrates saving result document with specified pages
    /// </summary>
    class SavingSpecificPageRange
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            using (Annotator annotator = new Annotator(Constants.INPUT))
            {
                annotator.Save(outputPath, new Options.SaveOptions { FirstPage = 2, LastPage = 4 });
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}

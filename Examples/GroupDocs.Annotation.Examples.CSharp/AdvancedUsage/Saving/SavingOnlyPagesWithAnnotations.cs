﻿using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Annotation.Models;
using GroupDocs.Annotation.Models.AnnotationModels;
using GroupDocs.Annotation.Options;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage.Saving
{
    /// <summary>
    /// This example demonstrates saving result document with specified pages
    /// </summary>
    class SavingOnlyPagesWithAnnotations
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            using (Annotator annotator = new Annotator(Constants.INPUT))
            {
                AreaAnnotation area = new AreaAnnotation()
                {
                    Box = new Rectangle(100, 100, 100, 100),
                    BackgroundColor = 65535,
                    PageNumber = 1
                };
                EllipseAnnotation ellipse = new EllipseAnnotation()
                {
                    Box = new Rectangle(100, 100, 100, 100),
                    BackgroundColor = 123456,
                    PageNumber = 1
                };
                annotator.Add(new List<AnnotationBase>() { area, ellipse });
                annotator.Save(outputPath, new SaveOptions { OnlyAnnotatedPages = true});
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GroupDocs.Annotation.Models;
using GroupDocs.Annotation.Models.AnnotationModels;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage
{
    class PutImageAnnotationOverText
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result_for_zIndex" + Path.GetExtension(Constants.INPUT_ZINDEX));

            using (Annotator annotator = new Annotator(Constants.INPUT_ZINDEX))
            {
                ImageAnnotation image = new ImageAnnotation
                {
                    Box = new Rectangle(100, 100, 100, 100),
                    CreatedOn = DateTime.Now,
                    Opacity = 0.7,
                    PageNumber = 0,
                    ImagePath = Constants.PICTURE,
                    ZIndex = 3
                };
                annotator.Add(image);
                annotator.Save(outputPath);
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}

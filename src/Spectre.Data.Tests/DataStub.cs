using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Spectre.Data.Datasets;

namespace Spectre.Data.Tests
{
    public static class DataStub
    {
        static readonly string path = Path.Combine(TestContext.CurrentContext.TestDirectory, ".." , "..", "..", "..", "..", "test_files","Rois");
        public static string TestDirectoryPath = Path.GetFullPath(path);
        public static string TestReadFilesPath = Path.Combine(TestDirectoryPath, "image1.png");
        public static string TestWriteFilePath = Path.Combine(TestDirectoryPath, "writetestfile.png");
        public static int ExpectedNumberOfRoisInDirectory = 3;

        public static Roi ReadRoiDataset = new Roi("image1", 6, 6, new List<RoiPixel>
        {
            new RoiPixel(1, 1),
            new RoiPixel(2, 1),
            new RoiPixel(3, 1)
        });

        public static Roi WriteRoiDataset = new Roi("writetestfile", 10, 10, new List<RoiPixel>
        {
            new RoiPixel(1, 5),
            new RoiPixel(2, 5),
            new RoiPixel(3, 5),
            new RoiPixel(4, 5)
        });

        public static Roi AddRoiDataset = new Roi("addtestfile", 10, 10, new List<RoiPixel>
        {
            new RoiPixel(1, 6),
            new RoiPixel(2, 6),
            new RoiPixel(3, 6),
            new RoiPixel(4, 6)
        });

    }
}

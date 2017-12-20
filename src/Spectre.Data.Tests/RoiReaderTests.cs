/*
 * RoiReaderTests.cs
 * Class with tests for RoiReader class.

   Copyright 2017 Roman Lisak

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using NUnit.Framework;
using Spectre.Data.RoiIo;

namespace Spectre.Data.Tests
{
    [TestFixture]
    class RoiReaderTests
    {
        [Test]
        public void GetAllRoisFromDirectory_returns_proper_rois()
        {
            RoiReader service = new RoiReader();

            var allRoisFromDirectory = service.GetAllRoisFromDirectory(DataStub.TestDirectoryPath);

            Assert.AreEqual(actual: allRoisFromDirectory[0].Name, expected: DataStub.ReadRoiDataset.Name);
            Assert.AreEqual(actual: allRoisFromDirectory[1].Name, expected: DataStub.WriteRoiRataset.Name);
        }
        
        [Test]
        public void ReadRoi_returns_proper_roi_pixels()
        {
            RoiReader service = new RoiReader();
            var roi = service.RoiDownloader(DataStub.TestReadFilesPath);

            Assert.AreEqual(actual: roi.RoiPixels[0].XCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[0].XCoordinate);
            Assert.AreEqual(actual: roi.RoiPixels[0].YCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[0].YCoordinate);

            Assert.AreEqual(actual: roi.RoiPixels[1].XCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[1].XCoordinate);
            Assert.AreEqual(actual: roi.RoiPixels[1].YCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[1].YCoordinate);

            Assert.AreEqual(actual: roi.RoiPixels[2].XCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[2].XCoordinate);
            Assert.AreEqual(actual: roi.RoiPixels[2].YCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[2].YCoordinate);
        }

        [Test]
        public void ReadRoi_returns_proper_dimensions()
        {
            RoiReader service = new RoiReader();
            var roi = service.RoiDownloader(DataStub.TestReadFilesPath);

            Assert.AreEqual(actual: roi.Height, expected: DataStub.ReadRoiDataset.Height);
            Assert.AreEqual(actual: roi.Width, expected: DataStub.ReadRoiDataset.Width);
        }
    }
}

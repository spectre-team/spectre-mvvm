/*
 * RoiWriterTests.cs
 * Class with tests for RoiWriter class.

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
    class RoiWriterTests
    {
        [Test]
        public void WriteRoi_writes_file_properly()
        {
            RoiWriter service = new RoiWriter(DataStub.TestDirectoryPath);

            service.RoiUploader(DataStub.WriteRoiRataset);

            RoiReader checkIfProperlyWrittenService = new RoiReader();

            var writetestroi = checkIfProperlyWrittenService.RoiDownloader(DataStub.TestWriteFilePath);

            Assert.AreEqual(actual: writetestroi.RoiPixels[0].XCoordinate, expected: DataStub.WriteRoiRataset.RoiPixels[0].XCoordinate);
            Assert.AreEqual(actual: writetestroi.RoiPixels[0].YCoordinate, expected: DataStub.WriteRoiRataset.RoiPixels[0].YCoordinate);

            Assert.AreEqual(actual: writetestroi.RoiPixels[1].XCoordinate, expected: DataStub.WriteRoiRataset.RoiPixels[1].XCoordinate);
            Assert.AreEqual(actual: writetestroi.RoiPixels[1].YCoordinate, expected: DataStub.WriteRoiRataset.RoiPixels[1].YCoordinate);

            Assert.AreEqual(actual: writetestroi.RoiPixels[2].XCoordinate, expected: DataStub.WriteRoiRataset.RoiPixels[2].XCoordinate);
            Assert.AreEqual(actual: writetestroi.RoiPixels[2].YCoordinate, expected: DataStub.WriteRoiRataset.RoiPixels[2].YCoordinate);

            Assert.AreEqual(actual: writetestroi.RoiPixels[3].XCoordinate, expected: DataStub.WriteRoiRataset.RoiPixels[3].XCoordinate);
            Assert.AreEqual(actual: writetestroi.RoiPixels[3].YCoordinate, expected: DataStub.WriteRoiRataset.RoiPixels[3].YCoordinate);
        }
    }
}

/*
 * RoiDictionaryTests.cs
 * Class with tests for RoiDictionary class.

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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Spectre.Data.Datasets;

namespace Spectre.Data.Tests
{
    [TestFixture]
    public class RoiDictionaryTests
    {
        [Test]
        public void GetRoiOrDefault_returns_requested_roi([Values(0, 1, 2)] int iterator)
        {
            var roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();

            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("image1");
            var nonExistentRoi = roiDictionaryService.GetRoiOrDefault("nonexistentroi");

            Assert.AreEqual(actual: obtainedRoi.Name, expected: DataStub.ReadRoiDataset.Name, message: "Read name is incorrect.");
            Assert.AreEqual(actual: obtainedRoi.Height, expected: DataStub.ReadRoiDataset.Height, message: "Read height is incorrect.");
            Assert.AreEqual(actual: obtainedRoi.Width, expected: DataStub.ReadRoiDataset.Width, message: "Read width is incorrect.");

            Assert.AreEqual(actual: obtainedRoi.RoiPixels[iterator].XCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[iterator].XCoordinate, message: "Coordinates doesn't match.");
            Assert.AreEqual(actual: obtainedRoi.RoiPixels[iterator].YCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[iterator].YCoordinate, message: "Coordinates doesn't match.");
            
            Assert.IsNull(nonExistentRoi, "nonExistentRoi != null");
        }

        [Test]
        public void Add_adds_roi_properly()
        {
            var roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();

            roiDictionaryService.Remove("addtestfile");
            var nonExistentRoi = roiDictionaryService.GetRoiOrDefault("addtestfile");

            Assert.IsNull(nonExistentRoi, "nonExistentRoi != null");

            var pathForNonExistingFile = Path.Combine(DataStub.TestDirectoryPath, "addtestfile" + ".png");

            Assert.IsFalse(File.Exists(pathForNonExistingFile));

            roiDictionaryService.Add(DataStub.AddRoiDataset);

            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("addtestfile");

            Assert.AreEqual(actual: obtainedRoi.Name, expected: "addtestfile");
            Assert.IsTrue(File.Exists(Path.Combine(DataStub.TestDirectoryPath, "addtestfile" + ".png")));
        }

        [Test]
        public void Remove_removes_from_dictionary_properly()
        {
            var roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();

            Assert.IsTrue(File.Exists(Path.Combine(DataStub.TestDirectoryPath, "addtestfile" + ".png")));

            roiDictionaryService.Remove("addtestfile");

            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("addtestfile");

            Assert.IsNull(obtainedRoi);

            Assert.IsFalse(File.Exists(Path.Combine(DataStub.TestDirectoryPath, "addtestfile" + ".png")));

            roiDictionaryService.Add(DataStub.AddRoiDataset);
        }

        [Test]
        public void Roi_constructor_throws_when_pixels_out_of_image()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                code: () =>
                {
                    new Roi(
                        "randomname",
                        10,
                        10,
                        new List<RoiPixel>
                        {
                            new RoiPixel(15, 6),
                            new RoiPixel(1, 15)
                        });
                });
        }

        [Test]
        public void LoadAllRois_First_file_name_and_dimensions_loads_properly()
        {
            RoiDictionary roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();
            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("image1");

            Assert.AreEqual(actual: obtainedRoi.Name, expected: DataStub.ReadRoiDataset.Name, message: "Read name is incorrect.");
            Assert.AreEqual(actual: obtainedRoi.Height, expected: DataStub.ReadRoiDataset.Height, message: "Read height is incorrect.");
            Assert.AreEqual(actual: obtainedRoi.Width, expected: DataStub.ReadRoiDataset.Width, message: "Read width is incorrect.");
        }

        [Test]
        public void LoadAllRois_First_file_coordinates_loads_properly([Values(0, 1, 2)] int iterator)
        {
            RoiDictionary roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();
            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("image1");
            
            Assert.AreEqual(actual: obtainedRoi.RoiPixels[iterator].XCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[iterator].XCoordinate, message: "Coordinates doesn't match.");
            Assert.AreEqual(actual: obtainedRoi.RoiPixels[iterator].YCoordinate, expected: DataStub.ReadRoiDataset.RoiPixels[iterator].YCoordinate, message: "Coordinates doesn't match.");
        }

        [Test]
        public void LoadAllRois_Second_file_name_and_dimensions_loads_properly()
        {
            RoiDictionary roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();
            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("writetestfile");

            Assert.AreEqual(actual: obtainedRoi.Name, expected: DataStub.WriteRoiDataset.Name, message: "Read name is incorrect.");
            Assert.AreEqual(actual: obtainedRoi.Height, expected: DataStub.WriteRoiDataset.Height, message: "Read height is incorrect.");
            Assert.AreEqual(actual: obtainedRoi.Width, expected: DataStub.WriteRoiDataset.Width, message: "Read width is incorrect.");
        }

        [Test]
        public void LoadAllRois_Second_file_coordinates_loads_properly([Values(0, 1, 2, 3)] int iterator)
        {
            RoiDictionary roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();
            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("writetestfile");

            Assert.AreEqual(actual: obtainedRoi.RoiPixels[iterator].XCoordinate, expected: DataStub.WriteRoiDataset.RoiPixels[iterator].XCoordinate, message: "Coordinates doesn't match.");
            Assert.AreEqual(actual: obtainedRoi.RoiPixels[iterator].YCoordinate, expected: DataStub.WriteRoiDataset.RoiPixels[iterator].YCoordinate, message: "Coordinates doesn't match.");
        }

        [Test]
        public void LoadAllRois_Third_file_name_and_dimensions_loads_properly()
        {
            RoiDictionary roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();
            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("addtestfile");

            Assert.AreEqual(actual: obtainedRoi.Name, expected: DataStub.AddRoiDataset.Name, message: "Read name is incorrect.");
            Assert.AreEqual(actual: obtainedRoi.Height, expected: DataStub.AddRoiDataset.Height, message: "Read height is incorrect.");
            Assert.AreEqual(actual: obtainedRoi.Width, expected: DataStub.AddRoiDataset.Width, message: "Read width is incorrect.");
        }

        [Test]
        public void LoadAllRois_Third_file_coordinates_loads_properly([Values(0, 1, 2, 3)] int iterator)
        {
            RoiDictionary roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();
            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("addtestfile");

            Assert.AreEqual(actual: obtainedRoi.RoiPixels[iterator].XCoordinate, expected: DataStub.AddRoiDataset.RoiPixels[iterator].XCoordinate, message: "Coordinates doesn't match.");
            Assert.AreEqual(actual: obtainedRoi.RoiPixels[iterator].YCoordinate, expected: DataStub.AddRoiDataset.RoiPixels[iterator].YCoordinate, message: "Coordinates doesn't match.");
        }

        [Test]
        public void GetRoiNames_gets_proper_names()
        {
            var roiDictionaryService = new RoiDictionary();
            roiDictionaryService.SetDirectoryPath(DataStub.TestDirectoryPath);
            roiDictionaryService.LoadAllRois();
            var names = roiDictionaryService.GetRoiNames();

            Assert.AreEqual(actual: names[0], expected: "addtestfile");
            Assert.AreEqual(actual: names[1], expected: "image1");
            Assert.AreEqual(actual: names[2], expected: "writetestfile");
        }
    }
}
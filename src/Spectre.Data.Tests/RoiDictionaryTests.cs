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
using System.Linq;
using NUnit.Framework;
using Spectre.Data.Datasets;

namespace Spectre.Data.Tests
{
    [TestFixture]
    public class RoiDictionaryTests
    {
        [Test]
        public void RoiDictionary_GetRoiOrDefault_returns_proper_roi()
        {
            var roiDictionaryService = new RoiDictionary(DataStub.TestDirectoryPath);
            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("image1");

            Assert.AreEqual(actual: obtainedRoi.First().Name, expected: "image1");
        }

        [Test]
        public void RoiDictionary_Add_adds_roi_properly()
        {
            var roiDictionaryService = new RoiDictionary(DataStub.TestDirectoryPath);

            roiDictionaryService.Add(DataStub.AddRoiRataset);

            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("addtestfile");

            Assert.AreEqual(actual: obtainedRoi.First().Name, expected: "addtestfile");
        }

        [Test]
        public void RoiDictionary_Remove_removes_properly()
        {
            var roiDictionaryService = new RoiDictionary(DataStub.TestDirectoryPath);

            roiDictionaryService.Remove("image1");

            var obtainedRoi = roiDictionaryService.GetRoiOrDefault("image1");

            Assert.IsNull(obtainedRoi);
        }

        [Test]
        public void Roi_Constructor_Sets_RoiPixels_in_range()
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
    }
 }
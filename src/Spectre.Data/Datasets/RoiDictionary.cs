/*
    * RoiDictionary.cs
    * Class representing a set of tool to manage ROIs.
    * Allows getting ROIs by name, adding and removing by name.

    Copyright 2017 Roman LIsak

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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Spectre.Data.RoiIo;

namespace Spectre.Data.Datasets
{
    /// <summary>
    /// Class representing a set of tools to manage ROIs.
    /// </summary>
    /// <seealso cref="Spectre.Data.Datasets.IRoiDictionary" />
    public class RoiDictionary : IRoiDictionary
    {
        private List<Roi> _roiDataset;
        private RoiReader _roireader;
        private string _directoryPath;

        /// <summary>
        /// Sets the directory path.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        public void SetDirectoryPath(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        /// <summary>
        /// Loads all Rois from directory to the list.
        /// All elements in the list will be overwritten.
        /// </summary>
        public void LoadAllRois()
        {
            _roireader = new RoiReader(_directoryPath);
            _roiDataset = _roireader.GetAllRoisFromDirectory();
        }

        /// <summary>
        /// Loads the single roi from directory and adds to the Roi list.
        /// </summary>
        /// <param name="fileName">Name of the file with extension.</param>
        public void LoadSingleRoi(string fileName)
        {
            _roiDataset.Add(_roireader.GetSingleRoiFromDirectory(fileName));
        }

        /// <summary>
        /// Tries to get specified value from list by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// Returns roi with specified name.
        /// Returns null if no roi with specified name found.
        /// </returns>
        public Roi GetRoiOrDefault(string name) => _roiDataset.FirstOrDefault(r => r.Name == name);

        /// <summary>
        /// Adds the specified ROI to the dictionary and creates file on the disk.
        /// </summary>
        /// <param name="roi">The roi.</param>
        public void Add(Roi roi)
        {
            _roiDataset.Add(roi);

            var roiWriterService = new RoiWriter();

            roiWriterService.RoiWriterTool(roi, _directoryPath);
        }

        /// <summary>
        /// Removes the ROI with specified name from dictionary and from disk.
        /// </summary>
        /// <param name="name">The name.</param>
        public void Remove(string name)
        {
            var query = _roiDataset.FirstOrDefault(r => r.Name == name);
            _roiDataset.Remove(query);

            File.Delete(Path.Combine(_directoryPath, name + ".png"));
        }

        /// <summary>
        /// Gets the roi names.
        /// </summary>
        /// <returns>Names of all rois in dictionary.</returns>
        public IList<string> GetRoiNames()
        {
            var allNames = new List<string>();

            foreach (var roi in _roiDataset)
            {
                allNames.Add(roi.Name);
            }

            return allNames;
        }
    }
}

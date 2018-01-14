/*
    * IRoiDictionary.cs
    * Interface for RoiDictionary.

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

using System.Collections.Generic;

namespace Spectre.Data.Datasets
{
    /// <summary>
    /// Interface for RoiDictionary.
    /// </summary>
    public interface IRoiDictionary
    {
        /// <summary>
        /// Sets the directory path.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        void SetDirectoryPath(string directoryPath);

        /// <summary>
        /// Loads all Rois from directory to the list.
        /// All elements in the list will be overwritten.
        /// </summary>
        void LoadAllRois();

        /// <summary>
        /// Loads the single roi from directory and adds to the Roi list.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        void LoadSingleRoi(string fileName);

        /// <summary>
        /// Tries to get specified value from list by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// Returns roi with specified name.
        /// Returns null if no roi with specified name found.
        /// </returns>
        Roi GetRoiOrDefault(string name);

        /// <summary>
        /// Adds the specified ROI to the dictionary and creates file on the disk.
        /// </summary>
        /// <param name="roi">The roi.</param>
        void Add(Roi roi);

        /// <summary>
        /// Removes the ROI with specified name from dictionary and from disk.
        /// </summary>
        /// <param name="name">The name.</param>
        void Remove(string name);

        /// <summary>
        /// Gets the roi names from list .
        /// </summary>
        /// <returns>Names of all rois in dictionary.</returns>
        IList<string> GetRoiNames();
    }
}

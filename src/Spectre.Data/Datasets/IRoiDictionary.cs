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
        /// Tries to get specified ROI from list by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// Returns roi with specified name.
        /// Returns null if no roi with specified name found.
        /// </returns>
        Roi GetRoiOrDefault(string name);

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="roi">The roi.</param>
        void Add(Roi roi);

        /// <summary>
        /// Removes the record with specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        void Remove(string name);

        /// <summary>
        /// Gets the roi names.
        /// </summary>
        /// <returns>Names of all rois in dictionary.</returns>
        IList<string> GetRoiNames();
    }
}

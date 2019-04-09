// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

namespace FlexiMvvm.Persistence.Core
{
    /// <summary>
    /// Defines the contract for an object whose state needs to be persisted in view's persistent storage.
    /// <para>This interface is intended for internal use by the FlexiMvvm.</para>
    /// </summary>
    public interface IStateOwner
    {
        /// <summary>
        /// Imports the <paramref name="state"/> of the object from view's persistent storage.
        /// </summary>
        /// <param name="state">The state bundle. Can be <see langword="null"/>.</param>
        void ImportState(IBundle? state);

        /// <summary>
        /// Exports the state of the object to view's persistent storage.
        /// </summary>
        /// <returns>The state bundle instance if the object has a state; otherwise, <see langword="null"/>.</returns>
        IBundle? ExportState();
    }
}

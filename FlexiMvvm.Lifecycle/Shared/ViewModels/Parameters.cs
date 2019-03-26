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

using FlexiMvvm.Persistence;

namespace FlexiMvvm.ViewModels
{
    /// <summary>
    /// Represents a container for storing lifecycle-aware view model parameters.
    /// </summary>
    public abstract class Parameters
    {
        private IBundle? _bundle;

        /// <summary>
        /// Gets the bundle that stores lifecycle-aware view model parameters as a set of key/value pairs.
        /// </summary>
        protected IBundle Bundle => _bundle ?? (_bundle = BundleFactory.Create());

        internal void ImportBundle(IBundle bundle)
        {
            _bundle = bundle;
        }

        internal IBundle ExportBundle()
        {
            return Bundle;
        }
    }
}

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

using FlexiMvvm.Persistence.Core;

namespace FlexiMvvm.Persistence
{
    /// <summary>
    /// Represents a factory that creates a new bundle instance.
    /// </summary>
    public static class BundleFactory
    {
        /// <summary>
        /// Creates a new <see cref="IBundle"/> instance.
        /// </summary>
        /// <returns>The bundle instance.</returns>
        public static IBundle Create()
        {
#if __ANDROID__
            return new AndroidBundle(new Android.OS.Bundle());
#else
            return new InMemoryBundle(new System.Collections.Generic.Dictionary<string, object?>());
#endif
        }
    }
}

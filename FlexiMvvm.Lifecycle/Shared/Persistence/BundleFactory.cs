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
using JetBrains.Annotations;

namespace FlexiMvvm.Persistence
{
    public static class BundleFactory
    {
        [NotNull]
        public static IBundle Create()
        {
#if NETSTANDARD2_0
            return new InMemoryBundle(new System.Collections.Generic.Dictionary<string, object>());
#elif __ANDROID__
            return new AndroidBundle(new Android.OS.Bundle());
#elif __IOS__
            return new InMemoryBundle(new System.Collections.Generic.Dictionary<string, object>());
#else
            throw new System.NotImplementedException($"\"{nameof(IBundle)}\" is not implemented in the portable version of this assembly. " +
                "You should reference the NuGet package from your main application project in order " +
                "to reference the platform-specific implementation.");
#endif
        }
    }
}

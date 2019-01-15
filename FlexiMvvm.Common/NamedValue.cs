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

using JetBrains.Annotations;

namespace FlexiMvvm
{
    public class NamedValue
    {
        public NamedValue([CanBeNull] object value, [CanBeNull] string name)
        {
            Value = value;
            Name = name;
        }

        [CanBeNull]
        public object Value { get; }

        [CanBeNull]
        public string Name { get; }

        public override string ToString()
        {
            return Name ?? string.Empty;
        }
    }
}

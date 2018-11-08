// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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

using System.Reflection;
using System.Text;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core
{
    internal class NestedValueAccessor
    {
        [NotNull]
        private readonly MethodInfo _getter;
        [CanBeNull]
        private readonly MethodInfo _setter;
        [CanBeNull]
        [ItemCanBeNull]
        private readonly object[] _indexParameters;

        internal NestedValueAccessor([NotNull] PropertyInfo property, [CanBeNull] object[] indexParameters)
        {
            _getter = property.GetGetMethod().NotNull();
            _setter = property.GetSetMethod();
            _indexParameters = indexParameters;
            CanSetValue = _setter != null;
            PropertyName = property.Name;
            IsIndexer = _indexParameters != null;
        }

        internal bool CanSetValue { get; }

        [NotNull]
        internal string PropertyName { get; }

        internal bool IsIndexer { get; }

        [CanBeNull]
        internal object GetValue([NotNull] object item)
        {
            return _getter.Invoke(item, _indexParameters);
        }

        internal void SetValue([NotNull] object item, [CanBeNull] object value)
        {
            _setter?.Invoke(item, _indexParameters == null ? new[] { value } : new[] { _indexParameters, value });
        }

        public override string ToString()
        {
            var valuePathBuilder = new StringBuilder();

            if (_indexParameters == null)
            {
                valuePathBuilder.Append(PropertyName);
            }
            else
            {
                valuePathBuilder.Append("[");

                for (var i = 0; i < _indexParameters.Length; i++)
                {
                    var indexParameter = _indexParameters[i];

                    if (indexParameter is string)
                    {
                        valuePathBuilder.AppendFormat("\"{0}\"", indexParameter);
                    }
                    else
                    {
                        valuePathBuilder.Append(indexParameter);
                    }

                    if (i < _indexParameters.Length - 1)
                    {
                        valuePathBuilder.Append(", ");
                    }
                }

                valuePathBuilder.Append("]");
            }

            return valuePathBuilder.ToString();
        }
    }
}

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

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core
{
    internal class ItemValueAccessor<TItem, TValue>
    {
        [NotNull]
        [ItemNotNull]
        private readonly NestedValueAccessor[] _nestedValuesAccessors;
        [CanBeNull]
        private readonly NestedValueAccessor _targetNestedValueAccessor;

        internal ItemValueAccessor([CanBeNull] LambdaExpression itemValue)
        {
            _nestedValuesAccessors = ItemValueExpressionParser.Parse(itemValue);
            _targetNestedValueAccessor = _nestedValuesAccessors.LastOrDefault();
            CanSetValue = _targetNestedValueAccessor?.CanSetValue ?? false;
            PropertyName = _targetNestedValueAccessor?.PropertyName;
        }

        internal bool CanSetValue { get; }

        [CanBeNull]
        internal string PropertyName { get; }

        [ContractAnnotation("=> true, valueOwnerItem: notnull; => false, valueOwnerItem: null")]
        internal bool TryGetValueOwnerItem([NotNull] TItem item, out object valueOwnerItem)
        {
            valueOwnerItem = item;

            for (var i = 0; i < _nestedValuesAccessors.Length - 1; i++)
            {
                var nestedItemAccessor = _nestedValuesAccessors[i];
                valueOwnerItem = nestedItemAccessor.GetValue(valueOwnerItem);

                if (valueOwnerItem == null)
                {
                    return false;
                }
            }

            return _nestedValuesAccessors.Any();
        }

        [ContractAnnotation("=> true, value: notnull; => false, value: null")]
        internal bool TryGetValue([NotNull] TItem item, out TValue value)
        {
            if (TryGetValueOwnerItem(item, out var valueOwnerItem))
            {
                value = (TValue)_targetNestedValueAccessor.NotNull().GetValue(valueOwnerItem);

                return true;
            }

            value = default;

            return false;
        }

        internal void SetValue([NotNull] TItem item, [CanBeNull] TValue value)
        {
            if (CanSetValue && TryGetValueOwnerItem(item, out var valueOwnerItem))
            {
                _targetNestedValueAccessor.NotNull().SetValue(valueOwnerItem, value);
            }
        }

        public override string ToString()
        {
            var valuePathBuilder = new StringBuilder();

            for (var i = 0; i < _nestedValuesAccessors.Length; i++)
            {
                var nestedValueAccessor = _nestedValuesAccessors[i];

                if (i > 0 && !nestedValueAccessor.IsIndexer)
                {
                    valuePathBuilder.Append(".");
                }

                valuePathBuilder.Append(nestedValueAccessor);
            }

            return valuePathBuilder.ToString();
        }
    }
}

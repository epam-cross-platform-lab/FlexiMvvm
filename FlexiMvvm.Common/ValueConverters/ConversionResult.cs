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

namespace FlexiMvvm.ValueConverters
{
    /// <summary>
    /// Represents a value conversion result.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public sealed class ConversionResult<TValue>
    {
        private ConversionResult(object? value)
        {
            Value = value;
        }

        internal object? Value { get; }

        /// <summary>
        /// Sets <paramref name="value"/> as a conversion result and passes it through the binding engine.
        /// </summary>
        /// <param name="value">The converted value.</param>
        /// <returns>The conversion result instance.</returns>
        public static ConversionResult<TValue> SetValue(TValue value)
        {
            return new ConversionResult<TValue>(value);
        }

        /// <summary>
        /// Sets <see cref="BindingValue.UnsetValue"/> as a conversion result. It indicates that the value converter produced no value
        /// and that the binding engine will use the FallbackValue, if available, or the default value instead.
        /// </summary>
        /// <returns>The conversion result instance.</returns>
        public static ConversionResult<TValue> UnsetValue()
        {
            return new ConversionResult<TValue>(BindingValue.UnsetValue);
        }
    }
}

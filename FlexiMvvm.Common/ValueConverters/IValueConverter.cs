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

using System;
using System.Globalization;

namespace FlexiMvvm.ValueConverters
{
    /// <summary>
    /// Exposes methods that allow the value to be modified as it passes through the binding engine.
    /// </summary>
    public interface IValueConverter
    {
        /// <summary>
        /// Modifies the source value before passing it to the target for display in the UI.
        /// </summary>
        /// <param name="value">The source value being passed to the target. Can be <see langword="null"/>.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">The parameter to be used in the converter logic. Can be <see langword="null"/>.</param>
        /// <param name="culture">The culture to be used in the converter.</param>
        /// <returns>A converted value. If the method returns <see langword="null"/>, the valid <see langword="null"/> value is used.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="targetType"/> or <paramref name="culture"/> is <see langword="null"/>.</exception>
        object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture);

        /// <summary>
        /// Modifies the target value before passing it to the source object.
        /// </summary>
        /// <param name="value">The target value being passed to the source. Can be <see langword="null"/>.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">The parameter to be used in the converter logic. Can be <see langword="null"/>.</param>
        /// <param name="culture">The culture to be used in the converter.</param>
        /// <returns>A converted value. If the method returns <see langword="null"/>, the valid <see langword="null"/> value is used.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="targetType"/> or <paramref name="culture"/> is <see langword="null"/>.</exception>
        object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture);
    }
}

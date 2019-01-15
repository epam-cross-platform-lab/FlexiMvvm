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
using Android.Views;

namespace FlexiMvvm.ValueConverters
{
    public class VisibleInvisibleValueConverter : ValueConverter<bool, ViewStates>
    {
        protected override ConversionResult<ViewStates> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<ViewStates>.SetValue(value ? ViewStates.Visible : ViewStates.Invisible);
        }

        protected override ConversionResult<bool> ConvertBack(ViewStates value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<bool>.SetValue(value == ViewStates.Visible);
        }
    }
}

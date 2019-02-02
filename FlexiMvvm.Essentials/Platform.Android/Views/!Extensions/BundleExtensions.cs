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
using Android.OS;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public static class BundleExtensions
    {
        private const string Iso8601Format = "O";

        public static DateTime GetDateTime([NotNull] this Bundle bundle, [CanBeNull] string key)
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            return GetDateTime(bundle, key, default);
        }

        public static DateTime GetDateTime([NotNull] this Bundle bundle, [CanBeNull] string key, DateTime defaultValue)
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var dateTimeString = bundle.GetString(key);

            return dateTimeString == default
                ? defaultValue
                : DateTime.ParseExact(dateTimeString, Iso8601Format, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        }

        public static DateTimeOffset GetDateTimeOffset([NotNull] this Bundle bundle, [CanBeNull] string key)
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            return GetDateTimeOffset(bundle, key, default);
        }

        public static DateTimeOffset GetDateTimeOffset([NotNull] this Bundle bundle, [CanBeNull] string key, DateTimeOffset defaultValue)
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var dateTimeOffsetString = bundle.GetString(key);

            return dateTimeOffsetString == default
                ? defaultValue
                : DateTimeOffset.ParseExact(dateTimeOffsetString, Iso8601Format, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        }

        public static T GetEnum<T>([NotNull] this Bundle bundle, [CanBeNull] string key, T defaultValue)
            where T : Enum
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var enumString = bundle.GetString(key);

            return enumString == default
                ? defaultValue
                : (T)Enum.Parse(typeof(T), enumString);
        }

        public static void PutDateTime([NotNull] this Bundle bundle, [CanBeNull] string key, DateTime value)
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            bundle.PutString(key, value.ToString(Iso8601Format));
        }

        public static void PutDateTimeOffset([NotNull] this Bundle bundle, [CanBeNull] string key, DateTimeOffset value)
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            bundle.PutString(key, value.ToString(Iso8601Format));
        }

        public static void PutEnum<T>([NotNull] this Bundle bundle, [CanBeNull] string key, T value)
            where T : Enum
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            bundle.PutString(key, value.ToString());
        }
    }
}

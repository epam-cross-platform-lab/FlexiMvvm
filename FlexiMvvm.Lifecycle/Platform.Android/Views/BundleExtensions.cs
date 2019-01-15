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
using System.Runtime.Serialization;
using Android.OS;
using FlexiMvvm.Persistence;
using FlexiMvvm.Persistence.Core;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public static class BundleExtensions
    {
        private const string StateKey = "FlexiMvvm_ViewModel_State";
        private const string ParametersKey = "FlexiMvvm_ViewModel_Parameters";
        private const string ResultKey = "FlexiMvvm_ViewModel_Result";

        [CanBeNull]
        internal static IBundle GetState([NotNull] this Bundle bundle)
        {
            IBundle state = null;
            var stateNativeBundle = bundle.GetBundle(StateKey);

            if (stateNativeBundle != null && !stateNativeBundle.IsEmpty)
            {
                state = new AndroidBundle(stateNativeBundle);
            }

            return state;
        }

        internal static void PutState([NotNull] this Bundle bundle, [CanBeNull] IBundle state)
        {
            var stateNativeBundleOwner = (INativeBundleOwner)state;
            var stateNativeBundle = stateNativeBundleOwner?.ExportNativeBundle();

            if (stateNativeBundle != null && !stateNativeBundle.IsEmpty)
            {
                bundle.PutBundle(StateKey, stateNativeBundle);
            }
        }

        [CanBeNull]
        public static TParameters GetParameters<TParameters>([NotNull] this Bundle bundle)
            where TParameters : Parameters
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            TParameters parameters = null;
            var parametersNativeBundle = bundle.GetBundle(ParametersKey);

            if (parametersNativeBundle != null)
            {
                parameters = (TParameters)FormatterServices.GetUninitializedObject(typeof(TParameters)).NotNull();
                ((IBundleOwner)parameters).ImportBundle(new AndroidBundle(parametersNativeBundle));
            }

            return parameters;
        }

        public static void PutParameters<TParameters>([NotNull] this Bundle bundle, [CanBeNull] TParameters parameters)
            where TParameters : Parameters
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var parametersNativeBundleOwner = (INativeBundleOwner)((IBundleOwner)parameters)?.ExportBundle();
            var parametersNativeBundle = parametersNativeBundleOwner?.ExportNativeBundle();

            if (parametersNativeBundle != null)
            {
                bundle.PutBundle(ParametersKey, parametersNativeBundle);
            }
        }

        [CanBeNull]
        public static TResult GetResult<TResult>([NotNull] this Bundle bundle)
            where TResult : Result
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            TResult result = null;
            var resultNativeBundle = bundle.GetBundle(ResultKey);

            if (resultNativeBundle != null)
            {
                result = (TResult)FormatterServices.GetUninitializedObject(typeof(TResult)).NotNull();
                ((IBundleOwner)result).ImportBundle(new AndroidBundle(resultNativeBundle));
            }

            return result;
        }

        public static void PutResult<TResult>([NotNull] this Bundle bundle, [CanBeNull] TResult result)
            where TResult : Result
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var resultNativeBundleOwner = (INativeBundleOwner)((IBundleOwner)result)?.ExportBundle();
            var resultNativeBundle = resultNativeBundleOwner?.ExportNativeBundle();

            if (resultNativeBundle != null)
            {
                bundle.PutBundle(ResultKey, resultNativeBundle);
            }
        }
    }
}

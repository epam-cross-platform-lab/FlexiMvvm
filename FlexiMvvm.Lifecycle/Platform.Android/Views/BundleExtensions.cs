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

using System;
using System.Runtime.Serialization;
using Android.OS;
using FlexiMvvm.Persistence;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public static class BundleExtensions
    {
        private const string ViewModelStateKey = "FlexiMvvm_ViewModelState";
        private const string ViewModelParametersKey = "FlexiMvvm_ViewModelParameters";
        private const string ViewModelResultKey = "FlexiMvvm_ViewModelResult";

        [CanBeNull]
        internal static IBundle GetViewModelStateBundle([CanBeNull] this Bundle bundle)
        {
            var stateBundle = bundle?.GetBundle(ViewModelStateKey);

            if (stateBundle != null)
            {
                return new NativeBundle(stateBundle);
            }

            return default;
        }

        internal static void PutViewModelStateBundle([NotNull] this Bundle bundle, [CanBeNull] IBundle state)
        {
            var stateBundle = (Bundle)state?.ToNative();

            if (stateBundle != null)
            {
                bundle.PutBundle(ViewModelStateKey, stateBundle);
            }
        }

        [CanBeNull]
        public static TParameters GetViewModelParameters<TParameters>([CanBeNull] this Bundle bundle)
            where TParameters : ViewModelParametersBase
        {
            var parametersBundle = bundle?.GetBundle(ViewModelParametersKey);

            if (parametersBundle != null)
            {
                var viewModelParameters = (TParameters)FormatterServices.GetUninitializedObject(typeof(TParameters)).NotNull();
                viewModelParameters.ImportParametersBundle(new NativeBundle(parametersBundle));

                return viewModelParameters;
            }

            return default;
        }

        public static void PutViewModelParameters<TParameters>([NotNull] this Bundle bundle, [CanBeNull] TParameters parameters)
            where TParameters : ViewModelParametersBase
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var parametersBundle = (Bundle)parameters?.ExportParametersBundle()?.ToNative();

            if (parametersBundle != null)
            {
                bundle.PutBundle(ViewModelParametersKey, parametersBundle);
            }
        }

        [CanBeNull]
        public static TResult GetViewModelResult<TResult>([CanBeNull] this Bundle bundle)
            where TResult : ViewModelResultBase
        {
            var resultBundle = bundle?.GetBundle(ViewModelResultKey);

            if (resultBundle != null)
            {
                var viewModelResult = (TResult)FormatterServices.GetUninitializedObject(typeof(TResult)).NotNull();
                viewModelResult.ImportResultBundle(new NativeBundle(resultBundle));

                return viewModelResult;
            }

            return default;
        }

        public static void PutViewModelResult<TResult>([NotNull] this Bundle bundle, [CanBeNull] TResult result)
            where TResult : ViewModelResultBase
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var resultBundle = (Bundle)result?.ExportResultBundle()?.ToNative();

            if (resultBundle != null)
            {
                bundle.PutBundle(ViewModelResultKey, resultBundle);
            }
        }
    }
}

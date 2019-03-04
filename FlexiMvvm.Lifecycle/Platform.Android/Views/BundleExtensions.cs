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

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Provides a set of static methods for getting and putting custom data from/in the bundle.
    /// </summary>
    public static class BundleExtensions
    {
        private const string ParametersKey = "FlexiMvvm_ViewModel_Parameters";
        private const string ResultKey = "FlexiMvvm_ViewModel_Result";

        /// <summary>
        /// Extracts view model parameters from the bundle.
        /// </summary>
        /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
        /// <param name="bundle">The bundle from which to extract view model parameters.</param>
        /// <returns>View model parameters instance if the bundle contains parameters; otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bundle"/> is <c>null</c>.</exception>
        public static TParameters? GetParameters<TParameters>(this Bundle bundle)
            where TParameters : Parameters
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            TParameters? parameters = null;
            var parametersNativeBundle = bundle.GetBundle(ParametersKey);

            if (parametersNativeBundle != null)
            {
                parameters = (TParameters)FormatterServices.GetUninitializedObject(typeof(TParameters));
                parameters.ImportBundle(new AndroidBundle(parametersNativeBundle));
            }

            return parameters;
        }

        /// <summary>
        /// Puts view model parameters to the bundle.
        /// </summary>
        /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
        /// <param name="bundle">The bundle to put view model parameters.</param>
        /// <param name="parameters">The view model parameters. Can be <c>null</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="bundle"/> is <c>null</c>.</exception>
        public static void PutParameters<TParameters>(this Bundle bundle, TParameters? parameters)
            where TParameters : Parameters
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var parametersNativeBundleOwner = parameters?.ExportBundle() as INativeBundleOwner;
            var parametersNativeBundle = parametersNativeBundleOwner?.ExportNativeBundle();

            if (parametersNativeBundle != null)
            {
                bundle.PutBundle(ParametersKey, parametersNativeBundle);
            }
        }

        /// <summary>
        /// Extracts view model result from the bundle.
        /// </summary>
        /// <typeparam name="TResult">The type of the view model result.</typeparam>
        /// <param name="bundle">The bundle from which to extract view model result.</param>
        /// <returns>View model result instance if the bundle contains result; otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bundle"/> is <c>null</c>.</exception>
        public static TResult? GetResult<TResult>(this Bundle bundle)
            where TResult : Result
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            TResult? result = null;
            var resultNativeBundle = bundle.GetBundle(ResultKey);

            if (resultNativeBundle != null)
            {
                result = (TResult)FormatterServices.GetUninitializedObject(typeof(TResult));
                result.ImportBundle(new AndroidBundle(resultNativeBundle));
            }

            return result;
        }

        /// <summary>
        /// Puts view model result to the bundle.
        /// </summary>
        /// <typeparam name="TResult">The type of the view model result.</typeparam>
        /// <param name="bundle">The bundle to put view model result.</param>
        /// <param name="result">The view model result. Can be <c>null</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="bundle"/> is <c>null</c>.</exception>
        public static void PutResult<TResult>(this Bundle bundle, TResult? result)
            where TResult : Result
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var resultNativeBundleOwner = result?.ExportBundle() as INativeBundleOwner;
            var resultNativeBundle = resultNativeBundleOwner?.ExportNativeBundle();

            if (resultNativeBundle != null)
            {
                bundle.PutBundle(ResultKey, resultNativeBundle);
            }
        }

        internal static IBundle? GetState(this Bundle bundle, string key)
        {
            IBundle? state = null;
            var stateNativeBundle = bundle.GetBundle(key);

            if (stateNativeBundle != null)
            {
                state = new AndroidBundle(stateNativeBundle);
            }

            return state;
        }

        internal static void PutState(this Bundle bundle, string key, IBundle? state)
        {
            var stateNativeBundleOwner = state as INativeBundleOwner;
            var stateNativeBundle = stateNativeBundleOwner?.ExportNativeBundle();

            if (stateNativeBundle != null)
            {
                bundle.PutBundle(key, stateNativeBundle);
            }
        }
    }
}

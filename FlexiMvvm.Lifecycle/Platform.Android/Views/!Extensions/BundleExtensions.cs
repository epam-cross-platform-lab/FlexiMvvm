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
    /// Provides a set of static methods for the <see cref="Bundle"/>.
    /// </summary>
    public static class BundleExtensions
    {
        private const string ParametersKey = "FlexiMvvm_LifecycleViewModel_Parameters";
        private const string ResultKey = "FlexiMvvm_LifecycleViewModel_Result";

        /// <summary>
        /// Gets the lifecycle-aware view model parameters from the <paramref name="bundle"/>.
        /// </summary>
        /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
        /// <param name="bundle">The bundle to extract the view model parameters from.</param>
        /// <returns>The view model parameters instance if the <paramref name="bundle"/> contains the parameters; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bundle"/> is <see langword="null"/>.</exception>
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
        /// Puts the lifecycle-aware view model parameters to the <paramref name="bundle"/>.
        /// </summary>
        /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
        /// <param name="bundle">The bundle to put the view model parameters to.</param>
        /// <param name="parameters">The view model parameters. Can be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="bundle"/> is <see langword="null"/>.</exception>
        public static void PutParameters<TParameters>(this Bundle bundle, TParameters? parameters)
            where TParameters : Parameters
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var parametersNativeBundleOwner = (INativeBundleOwner?)parameters?.ExportBundle();
            var parametersNativeBundle = parametersNativeBundleOwner?.ExportNativeBundle();

            if (parametersNativeBundle != null)
            {
                bundle.PutBundle(ParametersKey, parametersNativeBundle);
            }
        }

        /// <summary>
        /// Gets the lifecycle-aware view model result from the <paramref name="bundle"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the view model result.</typeparam>
        /// <param name="bundle">The bundle to extract the view model result from.</param>
        /// <returns>The view model result instance if the <paramref name="bundle"/> contains the result; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="bundle"/> is <see langword="null"/>.</exception>
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
        /// Puts the lifecycle-aware view model result to the <paramref name="bundle"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the view model result.</typeparam>
        /// <param name="bundle">The bundle to put the view model result to.</param>
        /// <param name="result">The view model result. Can be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="bundle"/> is <see langword="null"/>.</exception>
        public static void PutResult<TResult>(this Bundle bundle, TResult? result)
            where TResult : Result
        {
            if (bundle == null)
                throw new ArgumentNullException(nameof(bundle));

            var resultNativeBundleOwner = (INativeBundleOwner?)result?.ExportBundle();
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
            var stateNativeBundleOwner = (INativeBundleOwner?)state;
            var stateNativeBundle = stateNativeBundleOwner?.ExportNativeBundle();

            if (stateNativeBundle != null)
            {
                bundle.PutBundle(key, stateNativeBundle);
            }
        }
    }
}

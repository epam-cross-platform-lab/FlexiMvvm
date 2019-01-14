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
using System.Collections.Generic;
using Android.Content;
using FlexiMvvm.Collections;
using FlexiMvvm.Navigation.Core;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;

namespace FlexiMvvm.Navigation
{
    public class RequestCode
    {
        [NotNull]
        private static readonly Dictionary<Type, RequestCodeItem[]> RequestCodes = new Dictionary<Type, RequestCodeItem[]>();

        public static int Get<TResult>([NotNull] Context context, [NotNull] Type targetViewType)
            where TResult : ViewModelResultBase
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (targetViewType == null)
                throw new ArgumentNullException(nameof(targetViewType));

            var requestCode = GetOrAddRequestCode(
                context.GetType(),
                targetViewType,
                typeof(HandleViewModelResultProxy<TResult>),
                () => new HandleViewModelResultProxy<TResult>());

            return requestCode.Value;
        }

        [CanBeNull]
        internal static IHandleViewModelResultProxy GetHandleViewModelResultProxy([NotNull] Type sourceViewType, int requestCodeValue)
        {
            var requestCode = GetRequestCode(sourceViewType, requestCodeValue);

            return requestCode?.HandleViewModelResultProxy;
        }

        [NotNull]
        private static RequestCodeItem GetOrAddRequestCode(
            [NotNull] Type sourceViewType,
            [NotNull] Type targetViewType,
            [NotNull] Type handleViewModelResultProxyType,
            [NotNull] Func<IHandleViewModelResultProxy> handleViewModelResultProxyFactory)
        {
            var targetViewsRequestCodes = RequestCodes.GetOrAdd(sourceViewType, _ => new RequestCodeItem[RequestCodeItem.MaxValue]).NotNull();
            var requestCodeValue = RequestCodeItem.DefaultValue;

            while (true)
            {
                if (TryAddRequestCode(targetViewsRequestCodes, requestCodeValue, targetViewType, handleViewModelResultProxyFactory))
                {
                    break;
                }

                var targetViewRequestCode = targetViewsRequestCodes[requestCodeValue].NotNull();
                var comparisonResult = CompareRequestCode(targetViewRequestCode, targetViewType, handleViewModelResultProxyType);

                if (comparisonResult == 0)
                {
                    break;
                }

                if (comparisonResult < 0 && TryAddRequestCode(
                        targetViewsRequestCodes,
                        --requestCodeValue,
                        targetViewType,
                        handleViewModelResultProxyFactory))
                {
                    break;
                }

                if (comparisonResult > 0 && TryAddRequestCode(
                        targetViewsRequestCodes,
                        ++requestCodeValue,
                        targetViewType,
                        handleViewModelResultProxyFactory))
                {
                    break;
                }
            }

            return targetViewsRequestCodes[requestCodeValue].NotNull();
        }

        [CanBeNull]
        private static RequestCodeItem GetRequestCode([NotNull] Type sourceViewType, int requestCodeValue)
        {
            if (RequestCodes.TryGetValue(sourceViewType, out var targetViewsRequestCodes))
            {
                if (requestCodeValue < targetViewsRequestCodes.Length)
                {
                    return targetViewsRequestCodes[requestCodeValue];
                }
            }

            return null;
        }

        private static bool TryAddRequestCode(
            [NotNull] RequestCodeItem[] targetViewsRequestCodes,
            int requestCodeValue,
            [NotNull] Type targetViewType,
            [NotNull] Func<IHandleViewModelResultProxy> handleViewModelResultProxyFactory)
        {
            if (targetViewsRequestCodes[requestCodeValue] == null)
            {
                targetViewsRequestCodes[requestCodeValue] = new RequestCodeItem(
                    requestCodeValue,
                    targetViewType,
                    handleViewModelResultProxyFactory().NotNull());

                return true;
            }

            return false;
        }

        private static int CompareRequestCode(
            [NotNull] RequestCodeItem targetViewRequestCode,
            [NotNull] Type targetViewType,
            [NotNull] Type proxyType)
        {
            var comparisonResult = string.CompareOrdinal(targetViewType.Name, targetViewRequestCode.TargetViewType.Name);

            if (comparisonResult == 0)
            {
                comparisonResult = string.CompareOrdinal(proxyType.Name, targetViewRequestCode.HandleViewModelResultProxy.GetType().Name);
            }

            return comparisonResult;
        }
    }
}

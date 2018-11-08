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
using Android.Content;
using Android.OS;
using FlexiMvvm.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Navigation.Generic
{
    public delegate void ForwardNavigationDelegate(IAndroidView fromView, int? requestCode, Intent intent);

    public class ForwardNavigationStrategy
    {
        [NotNull]
        public ForwardNavigationDelegate Combine([CanBeNull] params ForwardNavigationDelegate[] navigationStrategies)
        {
            return (fromView, requestCode, intent) =>
            {
                if (navigationStrategies != null)
                {
                    foreach (var navigationStrategy in navigationStrategies)
                    {
                        navigationStrategy(fromView, requestCode, intent);
                    }
                }
            };
        }

        [NotNull]
        public ForwardNavigationDelegate Default()
        {
            return (fromView, requestCode, intent) =>
            {
                if (requestCode != null)
                {
                    fromView.NotNull().StartActivityForResult(intent.NotNull(), requestCode.Value);
                }
                else
                {
                    fromView.NotNull().StartActivity(intent.NotNull());
                }
            };
        }

        [NotNull]
        public ForwardNavigationDelegate StartActivity()
        {
            return (fromView, requestCode, intent) =>
            {
                fromView.NotNull().StartActivity(intent.NotNull());
            };
        }

        [NotNull]
        public ForwardNavigationDelegate StartActivity([CanBeNull] Bundle options)
        {
            return (fromView, requestCode, intent) =>
            {
                fromView.NotNull().StartActivity(intent.NotNull(), options);
            };
        }

        [NotNull]
        public ForwardNavigationDelegate StartActivityForResult()
        {
            return (fromView, requestCode, intent) =>
            {
                if (requestCode == null)
                {
                    throw new InvalidOperationException(
                        $"\"{nameof(StartActivityForResult)}\" navigation strategy cannot be used for navigation to another activity " +
                        $"without expecting a result. Try to use \"{nameof(StartActivity)}\" strategy instead.");
                }

                fromView.NotNull().StartActivityForResult(intent.NotNull(), requestCode.Value);
            };
        }

        [NotNull]
        public ForwardNavigationDelegate StartActivityForResult([CanBeNull] Bundle options)
        {
            return (fromView, requestCode, intent) =>
            {
                if (requestCode == null)
                {
                    throw new InvalidOperationException(
                        $"\"{nameof(StartActivityForResult)}\" navigation strategy cannot be used for navigation to another activity " +
                        $"without expecting a result. Try to use \"{nameof(StartActivity)}\" strategy instead.");
                }

                fromView.NotNull().StartActivityForResult(intent.NotNull(), requestCode.Value, options);
            };
        }
    }
}

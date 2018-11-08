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

using FlexiMvvm.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Navigation.Generic
{
    public delegate void BackwardNavigationDelegate(IActivityView fromView);

    public class BackwardNavigationStrategy
    {
        [NotNull]
        public BackwardNavigationDelegate Combine([CanBeNull] params BackwardNavigationDelegate[] navigationStrategies)
        {
            return (fromView) =>
            {
                if (navigationStrategies != null)
                {
                    foreach (var navigationStrategy in navigationStrategies)
                    {
                        navigationStrategy(fromView);
                    }
                }
            };
        }

        [NotNull]
        public BackwardNavigationDelegate Default()
        {
            return fromView =>
            {
                fromView.NotNull().Finish();
            };
        }

        [NotNull]
        public BackwardNavigationDelegate Finish()
        {
            return fromView =>
            {
                fromView.NotNull().Finish();
            };
        }
    }
}

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
using System.Diagnostics.CodeAnalysis;
using FlexiMvvm.Views.Core;
using UIKit;

namespace FlexiMvvm.Views
{
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1648:InheritDocMustBeUsedWithInheritingClass",
        Justification = "This rule doesn't work properly with a partial class.")]
    public partial class NavigationController
    {
        /// <inheritdoc />
        public NavigationController(UIViewController rootViewController)
            : base(rootViewController)
        {
            LifecycleDelegate = new ViewLifecycleDelegate<NavigationController>(this);
        }

        /// <inheritdoc />
        public NavigationController(Type navigationBarType, Type toolbarType)
            : base(navigationBarType, toolbarType)
        {
            LifecycleDelegate = new ViewLifecycleDelegate<NavigationController>(this);
        }
    }

    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1648:InheritDocMustBeUsedWithInheritingClass",
        Justification = "This rule doesn't work properly with a partial class.")]
    public partial class NavigationController<TViewModel>
    {
        /// <inheritdoc />
        public NavigationController(UIViewController rootViewController)
            : base(rootViewController)
        {
            LifecycleDelegate = new ViewLifecycleDelegate<NavigationController<TViewModel>, TViewModel>(this);
        }

        /// <inheritdoc />
        public NavigationController(Type navigationBarType, Type toolbarType)
            : base(navigationBarType, toolbarType)
        {
            LifecycleDelegate = new ViewLifecycleDelegate<NavigationController<TViewModel>, TViewModel>(this);
        }
    }

    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1648:InheritDocMustBeUsedWithInheritingClass",
        Justification = "This rule doesn't work properly with a partial class.")]
    public partial class NavigationController<TViewModel, TParameters>
    {
        /// <inheritdoc />
        public NavigationController(UIViewController rootViewController)
            : base(rootViewController)
        {
            LifecycleDelegate = new ViewLifecycleDelegate<NavigationController<TViewModel, TParameters>, TViewModel>(this);
        }

        /// <inheritdoc />
        public NavigationController(Type navigationBarType, Type toolbarType)
            : base(navigationBarType, toolbarType)
        {
            LifecycleDelegate = new ViewLifecycleDelegate<NavigationController<TViewModel, TParameters>, TViewModel>(this);
        }
    }
}

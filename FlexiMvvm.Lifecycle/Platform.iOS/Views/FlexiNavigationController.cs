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
using UIKit;

namespace FlexiMvvm.Views
{
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1648:InheritDocMustBeUsedWithInheritingClass",
        Justification = "This rule doesn't work properly with a partial class.")]
    public partial class FlexiNavigationController
    {
        /// <inheritdoc />
        public FlexiNavigationController(UIViewController rootViewController)
            : base(rootViewController)
        {
            LifecycleDelegate.ForceInstanceCreation();
        }

        /// <inheritdoc />
        public FlexiNavigationController(Type navigationBarType, Type toolbarType)
            : base(navigationBarType, toolbarType)
        {
            LifecycleDelegate.ForceInstanceCreation();
        }
    }

    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1648:InheritDocMustBeUsedWithInheritingClass",
        Justification = "This rule doesn't work properly with a partial class.")]
    public partial class FlexiNavigationController<TViewModel>
    {
        /// <inheritdoc />
        public FlexiNavigationController(UIViewController rootViewController)
            : base(rootViewController)
        {
        }

        /// <inheritdoc />
        public FlexiNavigationController(Type navigationBarType, Type toolbarType)
            : base(navigationBarType, toolbarType)
        {
        }
    }

    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1648:InheritDocMustBeUsedWithInheritingClass",
        Justification = "This rule doesn't work properly with a partial class.")]
    public partial class FlexiNavigationController<TViewModel, TParameters>
    {
        /// <inheritdoc />
        public FlexiNavigationController(UIViewController rootViewController)
            : base(rootViewController)
        {
        }

        /// <inheritdoc />
        public FlexiNavigationController(Type navigationBarType, Type toolbarType)
            : base(navigationBarType, toolbarType)
        {
        }
    }
}

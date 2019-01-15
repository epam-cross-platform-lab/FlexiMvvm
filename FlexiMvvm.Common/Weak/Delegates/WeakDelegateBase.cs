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
using System.Reflection;
using JetBrains.Annotations;

namespace FlexiMvvm.Weak.Delegates
{
    public abstract class WeakDelegateBase
    {
        [NotNull]
        private readonly WeakReference<object> _targetWeakReference;
        [NotNull]
        private readonly MethodInfo _targetMethodInfo;

        protected WeakDelegateBase([NotNull] Delegate @delegate)
        {
            if (@delegate == null)
                throw new ArgumentNullException(nameof(@delegate));

            _targetWeakReference = new WeakReference<object>(@delegate.Target);
            _targetMethodInfo = @delegate.Method;
        }

        [ContractAnnotation("=> true, target: notnull; => false, target: null")]
        public bool TryGetTarget(out object target)
        {
            return _targetWeakReference.TryGetTarget(out target);
        }

        protected object Invoke([NotNull] object target, [CanBeNull] params object[] parameters)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            return _targetMethodInfo.Invoke(target, parameters);
        }
    }
}

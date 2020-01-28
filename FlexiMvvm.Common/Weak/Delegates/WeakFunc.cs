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

namespace FlexiMvvm.Weak.Delegates
{
    public sealed class WeakFunc<TResult> : WeakDelegate, IWeakFunc<TResult>
    {
        public WeakFunc(Func<TResult> func)
            : base(func)
        {
        }

        public TResult Invoke(object target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var result = base.Invoke(target!);

            return (TResult)result!;
        }
    }

    public sealed class WeakFunc<T, TResult> : WeakDelegate, IWeakFunc<T, TResult>
    {
        public WeakFunc(Func<T, TResult> func)
            : base(func)
        {
        }

        public TResult Invoke(object target, T arg)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var result = base.Invoke(target!, arg);

            return (TResult)result!;
        }
    }

    public sealed class WeakFunc<T1, T2, TResult> : WeakDelegate, IWeakFunc<T1, T2, TResult>
    {
        public WeakFunc(Func<T1, T2, TResult> func)
            : base(func)
        {
        }

        public TResult Invoke(object target, T1 arg1, T2 arg2)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var result = base.Invoke(target!, arg1, arg2);

            return (TResult)result!;
        }
    }

    public sealed class WeakFunc<T1, T2, T3, TResult> : WeakDelegate, IWeakFunc<T1, T2, T3, TResult>
    {
        public WeakFunc(Func<T1, T2, T3, TResult> func)
            : base(func)
        {
        }

        public TResult Invoke(object target, T1 arg1, T2 arg2, T3 arg3)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var result = base.Invoke(target!, arg1, arg2, arg3);

            return (TResult)result!;
        }
    }

    public sealed class WeakFunc<T1, T2, T3, T4, TResult> : WeakDelegate, IWeakFunc<T1, T2, T3, T4, TResult>
    {
        public WeakFunc(Func<T1, T2, T3, T4, TResult> func)
            : base(func)
        {
        }

        public TResult Invoke(object target, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var result = base.Invoke(target!, arg1, arg2, arg3, arg4);

            return (TResult)result!;
        }
    }

    public sealed class WeakFunc<T1, T2, T3, T4, T5, TResult> : WeakDelegate, IWeakFunc<T1, T2, T3, T4, T5, TResult>
    {
        public WeakFunc(Func<T1, T2, T3, T4, T5, TResult> func)
            : base(func)
        {
        }

        public TResult Invoke(object target, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var result = base.Invoke(target!, arg1, arg2, arg3, arg4, arg5);

            return (TResult)result!;
        }
    }
}

﻿// =========================================================================
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

using JetBrains.Annotations;

namespace FlexiMvvm.Weak.Delegates
{
    public interface IWeakFunc<out TResult>
    {
        [ContractAnnotation("=> true, target: notnull; => false, target: null")]
        bool TryGetTarget(out object target);

        [CanBeNull]
        TResult Invoke([NotNull] object target);
    }

    public interface IWeakFunc<in T, out TResult>
    {
        [ContractAnnotation("=> true, target: notnull; => false, target: null")]
        bool TryGetTarget(out object target);

        [CanBeNull]
        TResult Invoke([NotNull] object target, [CanBeNull] T arg);
    }

    public interface IWeakFunc<in T1, in T2, out TResult>
    {
        [ContractAnnotation("=> true, target: notnull; => false, target: null")]
        bool TryGetTarget(out object target);

        [CanBeNull]
        TResult Invoke([NotNull] object target, [CanBeNull] T1 arg1, [CanBeNull] T2 arg2);
    }

    public interface IWeakFunc<in T1, in T2, in T3, out TResult>
    {
        [ContractAnnotation("=> true, target: notnull; => false, target: null")]
        bool TryGetTarget(out object target);

        [CanBeNull]
        TResult Invoke([NotNull] object target, [CanBeNull] T1 arg1, [CanBeNull] T2 arg2, [CanBeNull] T3 arg3);
    }

    public interface IWeakFunc<in T1, in T2, in T3, in T4, out TResult>
    {
        [ContractAnnotation("=> true, target: notnull; => false, target: null")]
        bool TryGetTarget(out object target);

        [CanBeNull]
        TResult Invoke([NotNull] object target, [CanBeNull] T1 arg1, [CanBeNull] T2 arg2, [CanBeNull] T3 arg3, [CanBeNull] T4 arg4);
    }

    public interface IWeakFunc<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        [ContractAnnotation("=> true, target: notnull; => false, target: null")]
        bool TryGetTarget(out object target);

        [CanBeNull]
        TResult Invoke([NotNull] object target, [CanBeNull] T1 arg1, [CanBeNull] T2 arg2, [CanBeNull] T3 arg3, [CanBeNull] T4 arg4, [CanBeNull] T5 arg5);
    }
}

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

using System.Diagnostics.CodeAnalysis;

namespace FlexiMvvm.Weak.Delegates
{
    public interface IWeakAction
    {
        bool TryGetTarget([MaybeNullWhen(returnValue: false)] out object target);

        void Invoke(object target);

        void InvokeIfAlive();
    }

    public interface IWeakAction<in T>
    {
        bool TryGetTarget([MaybeNullWhen(returnValue: false)] out object target);

        void Invoke(object target, T arg);

        void InvokeIfAlive(T arg);
    }

    public interface IWeakAction<in T1, in T2>
    {
        bool TryGetTarget([MaybeNullWhen(returnValue: false)] out object target);

        void Invoke(object target, T1 arg1, T2 arg2);

        void InvokeIfAlive(T1 arg1, T2 arg2);
    }

    public interface IWeakAction<in T1, in T2, in T3>
    {
        bool TryGetTarget([MaybeNullWhen(returnValue: false)] out object target);

        void Invoke(object target, T1 arg1, T2 arg2, T3 arg3);

        void InvokeIfAlive(T1 arg1, T2 arg2, T3 arg3);
    }

    public interface IWeakAction<in T1, in T2, in T3, in T4>
    {
        bool TryGetTarget([MaybeNullWhen(returnValue: false)] out object target);

        void Invoke(object target, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        void InvokeIfAlive(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    public interface IWeakAction<in T1, in T2, in T3, in T4, in T5>
    {
        bool TryGetTarget([MaybeNullWhen(returnValue: false)] out object target);

        void Invoke(object target, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        void InvokeIfAlive(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }
}

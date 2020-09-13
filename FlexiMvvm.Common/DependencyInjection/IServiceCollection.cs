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

namespace FlexiMvvm.DependencyInjection
{
    public interface IServiceCollection
    {
        void Add<TInterface, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface : notnull
            where TImplementation : notnull, TInterface;

        void Add<TInterface1, TInterface2, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface1 : notnull
            where TInterface2 : notnull
            where TImplementation : notnull, TInterface1, TInterface2;

        void Add<TInterface1, TInterface2, TInterface3, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface1 : notnull
            where TInterface2 : notnull
            where TInterface3 : notnull
            where TImplementation : notnull, TInterface1, TInterface2, TInterface3;

        void Add<TInterface1, TInterface2, TInterface3, TInterface4, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface1 : notnull
            where TInterface2 : notnull
            where TInterface3 : notnull
            where TInterface4 : notnull
            where TImplementation : notnull, TInterface1, TInterface2, TInterface3, TInterface4;

        void Add<TInterface1, TInterface2, TInterface3, TInterface4, TInterface5, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface1 : notnull
            where TInterface2 : notnull
            where TInterface3 : notnull
            where TInterface4 : notnull
            where TInterface5 : notnull
            where TImplementation : notnull, TInterface1, TInterface2, TInterface3, TInterface4, TInterface5;

        IServiceProvider BuildServiceProvider();
    }
}

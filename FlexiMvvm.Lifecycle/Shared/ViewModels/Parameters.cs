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
using FlexiMvvm.Persistence;
using FlexiMvvm.Persistence.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public abstract class Parameters : IBundleOwner
    {
        [CanBeNull]
        private IBundle _bundle;

        [NotNull]
        protected IBundle Bundle => _bundle ?? (_bundle = BundleFactory.Create());

        void IBundleOwner.ImportBundle(IBundle bundle)
        {
            _bundle = bundle ?? throw new ArgumentNullException(nameof(bundle));
        }

        IBundle IBundleOwner.ExportBundle()
        {
            return Bundle;
        }
    }
}

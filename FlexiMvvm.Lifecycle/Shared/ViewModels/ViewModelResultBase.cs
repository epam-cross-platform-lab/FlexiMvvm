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

using FlexiMvvm.Persistence;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public abstract class ViewModelResultBase
    {
        [CanBeNull]
        private IBundle _bundle;

        [NotNull]
        protected IBundle Bundle => _bundle ?? (_bundle = BundleFactory.Create());

        internal void ImportResultBundle([NotNull] IBundle resultBundle)
        {
            _bundle = resultBundle;
        }

        [CanBeNull]
        internal IBundle ExportResultBundle()
        {
            return _bundle;
        }
    }
}

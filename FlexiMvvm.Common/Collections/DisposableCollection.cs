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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FlexiMvvm.Collections
{
    public class DisposableCollection<TDisposable> : Collection<TDisposable>, IDisposable
        where TDisposable : IDisposable
    {
        public DisposableCollection()
        {
        }

        public DisposableCollection(IList<TDisposable> disposables)
            : base(disposables)
        {
        }

        public DisposableCollection(params TDisposable[] disposables)
            : base(disposables)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var item in Items)
                {
                    item.Dispose();
                }

                Items.Clear();
            }
        }
    }

    public class DisposableCollection : DisposableCollection<IDisposable>
    {
        public DisposableCollection()
        {
        }

        public DisposableCollection(IList<IDisposable> disposables)
            : base(disposables)
        {
        }

        public DisposableCollection(params IDisposable[] disposables)
            : base(disposables)
        {
        }
    }
}

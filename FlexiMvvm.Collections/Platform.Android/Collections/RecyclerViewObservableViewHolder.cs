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

#if __ANDROID_29__
using AndroidX.RecyclerView.Widget;
#else
using Android.Support.V7.Widget;
#endif
using Android.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public class RecyclerViewObservableViewHolder : RecyclerView.ViewHolder
    {
        public RecyclerViewObservableViewHolder([NotNull] View itemView)
            : base(itemView)
        {
        }

        internal virtual void Bind([CanBeNull] object itemsContext, [CanBeNull] object value)
        {
        }
    }
}

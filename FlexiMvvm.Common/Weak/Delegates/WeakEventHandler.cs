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
    public sealed class WeakEventHandler : WeakDelegate
    {
        public WeakEventHandler(EventHandler eventHandler)
            : base(eventHandler)
        {
        }

        public void Invoke(object target, object sender, EventArgs args)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            base.Invoke(target, sender, args);
        }
    }

    public sealed class WeakEventHandler<TEventArgs> : WeakDelegate
    {
        public WeakEventHandler(EventHandler<TEventArgs> eventHandler)
            : base(eventHandler)
        {
        }

        public void Invoke(object target, object sender, TEventArgs args)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            base.Invoke(target, sender, args);
        }
    }
}

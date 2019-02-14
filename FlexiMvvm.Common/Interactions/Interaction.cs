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
using JetBrains.Annotations;

namespace FlexiMvvm.Interactions
{
    public class Interaction
    {
        public event EventHandler Requested;

        public void RaiseRequested()
        {
            Requested?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Interaction<T>
    {
        public event EventHandler<InteractionRequestEventArgs<T>> Requested;

        public void RaiseRequested([NotNull] T request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            Requested?.Invoke(this, new InteractionRequestEventArgs<T>(request));
        }
    }
}

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

namespace FlexiMvvm.Bootstrappers
{
    public class CompositeBootstrapper : IBootstrapper
    {
        [CanBeNull]
        private readonly IBootstrapper[] _bootstrappers;

        public CompositeBootstrapper([CanBeNull] params IBootstrapper[] bootstrappers)
        {
            _bootstrappers = bootstrappers;
        }

        public void Execute(BootstrapperConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (_bootstrappers != null)
            {
                foreach (var bootstrapper in _bootstrappers)
                {
                    bootstrapper.Execute(config);
                }
            }
        }
    }
}

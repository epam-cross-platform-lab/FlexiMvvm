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

namespace FlexiMvvm.Bootstrappers
{
    /// <summary>
    /// Represent a bootstrappers composition. Executes bootstrappers sequentially in the same order in which they are passed to the constructor.
    /// </summary>
    public sealed class CompositeBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper[] _bootstrappers;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeBootstrapper"/> class.
        /// </summary>
        /// <param name="bootstrappers">The collection of bootstrappers to be executed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="bootstrappers"/> is <see langword="null"/>.</exception>
        public CompositeBootstrapper(params IBootstrapper[] bootstrappers)
        {
            if (bootstrappers == null)
                throw new ArgumentNullException(nameof(bootstrappers));

            _bootstrappers = bootstrappers;
        }

        /// <inheritdoc />
        public void Execute(BootstrapperConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            foreach (var bootstrapper in _bootstrappers)
            {
                bootstrapper.Execute(config);
            }
        }
    }
}

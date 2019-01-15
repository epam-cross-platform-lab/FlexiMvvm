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

namespace FlexiMvvm.Diagnostics
{
    public class ConsoleLogger : ILogger
    {
        [CanBeNull]
        private readonly string _module;
        [CanBeNull]
        private readonly string _prefix;

        public ConsoleLogger()
        {
        }

        public ConsoleLogger(
            [NotNull] string module,
            [NotNull] string prefix)
        {
            if (module == null)
                throw new ArgumentNullException(nameof(module));
            if (string.IsNullOrWhiteSpace(module))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(module));
            if (prefix == null)
                throw new ArgumentNullException(nameof(prefix));
            if (string.IsNullOrWhiteSpace(prefix))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(prefix));

            _module = module;
            _prefix = prefix;
        }

        public void Log(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (string.IsNullOrWhiteSpace(_module) && string.IsNullOrWhiteSpace(_prefix))
                {
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine($"{_module}: {_prefix} - {message}");
                }
            }
        }
    }
}

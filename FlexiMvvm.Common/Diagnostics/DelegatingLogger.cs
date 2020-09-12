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
using System.Collections.ObjectModel;

namespace FlexiMvvm.Diagnostics
{
    [Obsolete]
    public class DelegatingLogger : ILogger
    {
        private Collection<string>? _messages;
        private ILogger? _logger;

        private Collection<string> Messages => _messages ?? (_messages = new Collection<string>());

        public ILogger? Logger
        {
            get => _logger;
            set
            {
                _logger = value;

                if (_logger != null && _messages != null)
                {
                    foreach (var message in _messages)
                    {
                        _logger.Log(message);
                    }

                    _messages.Clear();
                }
            }
        }

        public void Log(string? message)
        {
            if (Logger != null)
            {
                Logger.Log(message);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Messages.Add(message);
                }
            }
        }
    }
}

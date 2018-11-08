// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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
using System.Diagnostics;
using FlexiMvvm.Diagnostics;
using JetBrains.Annotations;

namespace FlexiMvvm.Commands
{
    public class RelayCommand : ICommand
    {
        [NotNull]
        private readonly Action _execute;
        [CanBeNull]
        private readonly Func<bool> _canExecute;
        [CanBeNull]
        private readonly string _name;
        [CanBeNull]
        private ILogger _logger;

        public RelayCommand([NotNull] Action execute, [CanBeNull] Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        internal RelayCommand([NotNull] Action execute, [CanBeNull] Func<bool> canExecute, [NotNull] string name)
            : this(execute, canExecute)
        {
            _name = name;
        }

        public event EventHandler CanExecuteChanged;

        [NotNull]
        private ILogger Logger => _logger ?? (_logger = new ConsoleLogger("FlexiMvvm.Lifecycle", GetCommandName()));

        public bool CanExecute([CanBeNull] object parameter)
        {
            if (parameter != null)
            {
                Log($"\"{GetCommandName()}.{nameof(CanExecute)}\" method doesn't handle any passed parameter. \"null\" value is only acceptable.");
            }

            return _canExecute?.Invoke() ?? true;
        }

        public bool CanExecute()
        {
            return CanExecute(null);
        }

        public void Execute([CanBeNull] object parameter)
        {
            if (CanExecute(parameter))
            {
                if (parameter != null)
                {
                    Log($"\"{GetCommandName()}.{nameof(Execute)}\" method doesn't handle any passed parameter. \"null\" value is only acceptable.");
                }

                _execute();
            }
        }

        public void Execute()
        {
            Execute(null);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        [NotNull]
        private string GetCommandName()
        {
            return !string.IsNullOrWhiteSpace(_name) ? _name : LogFormatter.FormatTypeName(this);
        }

        [Conditional("DEBUG")]
        private void Log([CanBeNull] string message)
        {
            Logger.Log(message);
        }
    }

    public class RelayCommand<T> : ICommand<T>
    {
        [NotNull]
        private readonly Action<T> _execute;
        [CanBeNull]
        private readonly Func<T, bool> _canExecute;
        [CanBeNull]
        private readonly string _name;
        [CanBeNull]
        private ILogger _logger;

        public RelayCommand([NotNull] Action<T> execute, [CanBeNull] Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        internal RelayCommand([NotNull] Action<T> execute, [CanBeNull] Func<T, bool> canExecute, [NotNull] string name)
            : this(execute, canExecute)
        {
            _name = name;
        }

        public event EventHandler CanExecuteChanged;

        [NotNull]
        private ILogger Logger => _logger ?? (_logger = new ConsoleLogger("FlexiMvvm.Lifecycle", GetCommandName()));

        public bool CanExecute([CanBeNull] object parameter)
        {
            if (parameter is T typedParameter)
            {
                return CanExecute(typedParameter);
            }
            else
            {
                if (Equals(parameter, default(T)))
                {
                    return CanExecute(default);
                }
                else
                {
                    Log($"\"{GetCommandName()}.{nameof(CanExecute)}\" method parameter is expected to be " +
                        $"\"{LogFormatter.FormatTypeName<T>()}\" type but it has \"{LogFormatter.FormatTypeName(parameter)}\" one. " +
                        $"This method won't be executed.");

                    return false;
                }
            }
        }

        public bool CanExecute(T parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute([CanBeNull] object parameter)
        {
            if (parameter is T typedParameter)
            {
                Execute(typedParameter);
            }
            else
            {
                if (Equals(parameter, default(T)))
                {
                    Execute(default);
                }
                else
                {
                    Log($"\"{GetCommandName()}.{nameof(Execute)}\" method parameter is expected to be " +
                        $"\"{LogFormatter.FormatTypeName<T>()}\" type but it has \"{LogFormatter.FormatTypeName(parameter)}\" one. " +
                        $"This method won't be executed.");
                }
            }
        }

        public void Execute(T parameter)
        {
            if (CanExecute(parameter))
            {
                _execute(parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        [NotNull]
        private string GetCommandName()
        {
            return !string.IsNullOrWhiteSpace(_name) ? _name : LogFormatter.FormatTypeName(this);
        }

        [Conditional("DEBUG")]
        private void Log([CanBeNull] string message)
        {
            Logger.Log(message);
        }
    }
}

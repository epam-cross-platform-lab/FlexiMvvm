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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FlexiMvvm.Collections;
using JetBrains.Annotations;

namespace FlexiMvvm.Commands
{
    public class CommandProvider
    {
        [NotNull]
        private readonly Dictionary<string, System.Windows.Input.ICommand> _commands = new Dictionary<string, System.Windows.Input.ICommand>();

        [NotNull]
        public ICommand Get(
            [NotNull] Action execute,
            [CanBeNull] Func<bool> canExecute = null,
            [CallerMemberName] string name = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            return (ICommand)_commands.GetOrAdd(
                name,
                _ => new RelayCommand(execute, canExecute, name)).NotNull();
        }

        [NotNull]
        public ICommand GetForAsync(
            [NotNull] Func<Task> execute,
            [CanBeNull] Func<bool> canExecute = null,
            [CallerMemberName] string name = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            return (ICommand)_commands.GetOrAdd(
                name,
                _ => new RelayCommand(async () => await execute().NotNull(), canExecute, name)).NotNull();
        }

        [NotNull]
        public ICommand<T> Get<T>(
            [NotNull] Action<T> execute,
            [CanBeNull] Func<T, bool> canExecute = null,
            [CallerMemberName] string name = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            return (ICommand<T>)_commands.GetOrAdd(
                name,
                _ => new RelayCommand<T>(execute, canExecute, name)).NotNull();
        }

        [NotNull]
        public ICommand<T> GetForAsync<T>(
            [NotNull] Func<T, Task> execute,
            [CanBeNull] Func<T, bool> canExecute = null,
            [CallerMemberName] string name = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            return (ICommand<T>)_commands.GetOrAdd(
                name,
                _ => new RelayCommand<T>(async parameter => await execute(parameter).NotNull(), canExecute, name)).NotNull();
        }
    }
}

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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlexiMvvm.Commands
{
    /// <summary>
    /// Represents a provider that returns an existing command instance by name or creates a new one.
    /// </summary>
    public sealed class CommandProvider
    {
        private readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        /// <summary>
        /// Returns an existing <see cref="Command"/> instance by <paramref name="name"/> or creates a new one. <paramref name="execute"/> is expected to be synchronous.
        /// </summary>
        /// <param name="execute">The synchronous <see cref="Action"/> to invoke when <see cref="Command.Execute"/> is called.</param>
        /// <param name="canExecute">The <see cref="Func{TResult}"/> to invoke when <see cref="Command.CanExecute"/> is called. Can be <see langword="null"/>.</param>
        /// <param name="name">A unique name that is used to get a command instance.</param>
        /// <returns>The command instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="execute"/> or <paramref name="name"/> is <see langword="null"/>.</exception>
        public Command Get(Action execute, Func<bool>? canExecute = null, [CallerMemberName] string? name = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return (Command)_commands.GetOrAdd(name, _ => new RelayCommand(execute, canExecute, name));
        }

        /// <summary>
        /// Returns an existing <see cref="Command{T}"/> instance by <paramref name="name"/> or creates a new one. <paramref name="execute"/> is expected to be synchronous.
        /// </summary>
        /// <typeparam name="T">The type of the command parameter.</typeparam>
        /// <param name="execute">The synchronous <see cref="Action{T}"/> to invoke when <see cref="Command{T}.Execute(T)"/> is called.</param>
        /// <param name="canExecute">The <see cref="Func{T, TResult}"/> to invoke when <see cref="Command{T}.CanExecute(T)"/> is called. Can be <see langword="null"/>.</param>
        /// <param name="name">A unique name that is used to get a command instance.</param>
        /// <returns>The command instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="execute"/> or <paramref name="name"/> is <see langword="null"/>.</exception>
        public Command<T> Get<T>(Action<T> execute, Func<T, bool>? canExecute = null, [CallerMemberName] string? name = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return (Command<T>)_commands.GetOrAdd(name, _ => new RelayCommand<T>(execute, canExecute, name));
        }

        /// <summary>
        /// Returns an existing <see cref="Command"/> instance by <paramref name="name"/> or creates a new one. <paramref name="execute"/> is expected to be asynchronous.
        /// </summary>
        /// <param name="execute">The asynchronous <see cref="Func{TResult}"/> to invoke when <see cref="Command.Execute"/> is called.</param>
        /// <param name="canExecute">The <see cref="Func{TResult}"/> to invoke when <see cref="Command.CanExecute"/> is called. Can be <see langword="null"/>.</param>
        /// <param name="name">A unique name that is used to get a command instance.</param>
        /// <returns>The command instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="execute"/> or <paramref name="name"/> is <see langword="null"/>.</exception>
        public Command GetForAsync(Func<Task> execute, Func<bool>? canExecute = null, [CallerMemberName] string? name = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return (Command)_commands.GetOrAdd(name, _ => new RelayCommand(async () => await execute(), canExecute, name));
        }

        /// <summary>
        /// Returns an existing <see cref="Command{T}"/> instance by <paramref name="name"/> or creates a new one. <paramref name="execute"/> is expected to be asynchronous.
        /// </summary>
        /// <typeparam name="T">The type of the command parameter.</typeparam>
        /// <param name="execute">The asynchronous <see cref="Func{T, TResult}"/> to invoke when <see cref="Command{T}.Execute(T)"/> is called.</param>
        /// <param name="canExecute">The <see cref="Func{T, TResult}"/> to invoke when <see cref="Command{T}.CanExecute(T)"/> is called. Can be <see langword="null"/>.</param>
        /// <param name="name">A unique name that is used to get a command instance.</param>
        /// <returns>The command instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="execute"/> or <paramref name="name"/> is <see langword="null"/>.</exception>
        public Command<T> GetForAsync<T>(Func<T, Task> execute, Func<T, bool>? canExecute = null, [CallerMemberName] string? name = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return (Command<T>)_commands.GetOrAdd(name, _ => new RelayCommand<T>(async parameter => await execute(parameter), canExecute, name));
        }
    }
}

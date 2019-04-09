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

namespace FlexiMvvm.Commands
{
    /// <summary>
    /// Represents a <see cref="Command"/> that delegates execution and execution check to its owner and takes no parameters.
    /// </summary>
    public sealed class RelayCommand : Command
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The <see cref="Action"/> to invoke when <see cref="Command.Execute"/> is called.</param>
        /// <param name="canExecute">
        /// The <see cref="Func{TResult}"/> to invoke when <see cref="Command.CanExecute"/> is called. Can be <see langword="null"/>.
        /// <para><see cref="Command.CanExecute"/> will return <see langword="true"/> if <paramref name="canExecute"/> is <see langword="null"/>.</para>
        /// </param>
        /// <param name="name">The diagnostic command name. Can be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="execute"/> is <see langword="null"/>.</exception>
        public RelayCommand(Action execute, Func<bool>? canExecute = null, string? name = null)
            : base(name)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Executes the command if <see cref="CanExecute"/> returns <see langword="true"/>.
        /// </summary>
        public override void Execute()
        {
            if (CanExecute())
            {
                _execute();
            }
        }

        /// <summary>
        /// Determines whether the command can be executed.
        /// </summary>
        /// <returns><see langword="true"/> if the command can be executed; otherwise, <see langword="false"/>.</returns>
        public override bool CanExecute()
        {
            return _canExecute?.Invoke() ?? true;
        }
    }

    /// <summary>
    /// Represents a <see cref="Command{T}"/> that delegates execution and execution check to its owner and takes a parameter.
    /// </summary>
    /// <typeparam name="T">The type of the command parameter.</typeparam>
    public sealed class RelayCommand<T> : Command<T>
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="execute">The <see cref="Action{T}"/> to invoke when <see cref="Command{T}.Execute(T)"/> is called.</param>
        /// <param name="canExecute">
        /// The <see cref="Func{T, TResult}"/> to invoke when <see cref="Command{T}.CanExecute(T)"/> is called. Can be <see langword="null"/>.
        /// <para><see cref="Command{T}.CanExecute(T)"/> will return <see langword="true"/> if <paramref name="canExecute"/> is <see langword="null"/>.</para>
        /// </param>
        /// <param name="name">The diagnostic command name. Can be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="execute"/> is <see langword="null"/>.</exception>
        public RelayCommand(Action<T> execute, Func<T, bool>? canExecute = null, string? name = null)
            : base(name)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Executes the command with the passed <paramref name="parameter"/> if <see cref="CanExecute(T)"/> returns <see langword="true"/>.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        public override void Execute(T parameter)
        {
            if (CanExecute(parameter))
            {
                _execute(parameter);
            }
        }

        /// <summary>
        /// Determines whether the command can be executed with the passed <paramref name="parameter"/>.
        /// </summary>
        /// <param name="parameter">The parameter used by the command to determine if it can be executed.</param>
        /// <returns><see langword="true"/> if the command can be executed; otherwise, <see langword="false"/>.</returns>
        public override bool CanExecute(T parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
    }
}

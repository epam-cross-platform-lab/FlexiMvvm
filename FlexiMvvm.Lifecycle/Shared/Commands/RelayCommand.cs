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

namespace FlexiMvvm.Commands
{
    public sealed class RelayCommand : Command
    {
        [NotNull]
        private readonly Action _execute;
        [CanBeNull]
        private readonly Func<bool> _canExecute;

        public RelayCommand([NotNull] Action execute, [CanBeNull] Func<bool> canExecute = null, [CanBeNull] string name = null)
            : base(name)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override bool CanExecute()
        {
            return _canExecute?.Invoke() ?? true;
        }

        public override void Execute()
        {
            if (CanExecute())
            {
                _execute();
            }
        }
    }

    public sealed class RelayCommand<T> : Command<T>
    {
        [NotNull]
        private readonly Action<T> _execute;
        [CanBeNull]
        private readonly Func<T, bool> _canExecute;

        public RelayCommand([NotNull] Action<T> execute, [CanBeNull] Func<T, bool> canExecute = null, [CanBeNull] string name = null)
            : base(name)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override bool CanExecute(T parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(T parameter)
        {
            if (CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
    }
}

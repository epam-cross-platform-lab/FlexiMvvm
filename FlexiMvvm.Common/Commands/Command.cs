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
using System.Windows.Input;
using FlexiMvvm.Formatters;
using JetBrains.Annotations;

namespace FlexiMvvm.Commands
{
    public abstract class Command : ICommand
    {
        [CanBeNull]
        private readonly string _name;

        protected Command([CanBeNull] string name = null)
        {
            _name = name;
        }

        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        public abstract bool CanExecute();

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        public abstract void Execute();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public abstract class Command<T> : ICommand
    {
        [CanBeNull]
        private readonly string _name;

        protected Command([CanBeNull] string name = null)
        {
            _name = name;
        }

        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute([CanBeNull] object parameter)
        {
            T typedParameter;

            try
            {
                typedParameter = (T)parameter;
            }
            catch (InvalidCastException ex)
            {
                throw new ArgumentException(
                    $"\"{_name.SelfOrDefaultIfNullOrWhiteSpace(TypeFormatter.FormatName(GetType()))}\" command expects value of \"{TypeFormatter.FormatName<T>()}\" type.",
                    nameof(parameter),
                    ex);
            }

            return CanExecute(typedParameter);
        }

        public abstract bool CanExecute(T parameter);

        void ICommand.Execute([CanBeNull] object parameter)
        {
            T typedParameter;

            try
            {
                typedParameter = (T)parameter;
            }
            catch (InvalidCastException ex)
            {
                throw new ArgumentException(
                    $"\"{_name.SelfOrDefaultIfNullOrWhiteSpace(TypeFormatter.FormatName(GetType()))}\" command expects value of \"{TypeFormatter.FormatName<T>()}\" type.",
                    nameof(parameter),
                    ex);
            }

            Execute(typedParameter);
        }

        public abstract void Execute(T parameter);

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

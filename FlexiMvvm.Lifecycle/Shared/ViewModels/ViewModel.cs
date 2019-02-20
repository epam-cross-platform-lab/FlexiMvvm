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

using System.ComponentModel;
using System.Threading.Tasks;
using FlexiMvvm.Commands;
using FlexiMvvm.Configuration;
using FlexiMvvm.Persistence;
using FlexiMvvm.Persistence.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public abstract class ViewModel : ObservableObject, IViewModelWithoutParameters, IStateOwner
    {
        [CanBeNull]
        private IBundle _state;
        [CanBeNull]
        private CommandProvider _commandProvider;

        [NotNull]
        protected IBundle State
        {
            get
            {
                if (_state == null)
                {
                    _state = BundleFactory.Create();

                    if (FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged())
                    {
                        _state.PropertyChangedWeakSubscribe(State_PropertyChanged);
                    }
                }

                return _state;
            }
        }

        [NotNull]
        protected CommandProvider CommandProvider => _commandProvider ?? (_commandProvider = new CommandProvider());

        public virtual Task InitializeAsync()
        {
            Initialize();

            return Task.CompletedTask;
        }

        public virtual void Initialize()
        {
        }

        void IStateOwner.ImportState(IBundle state)
        {
            _state = state;

            if (_state != null && FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged())
            {
                _state.PropertyChangedWeakSubscribe(State_PropertyChanged);
            }
        }

        IBundle IStateOwner.ExportState()
        {
            return _state;
        }

        private void State_PropertyChanged([NotNull] object sender, [NotNull] PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }
    }

    public abstract class ViewModel<TParameters> : ObservableObject, IViewModelWithParameters<TParameters>, IStateOwner
        where TParameters : Parameters
    {
        [CanBeNull]
        private IBundle _state;
        [CanBeNull]
        private CommandProvider _commandProvider;

        [NotNull]
        protected IBundle State
        {
            get
            {
                if (_state == null)
                {
                    _state = BundleFactory.Create();

                    if (FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged())
                    {
                        _state.PropertyChangedWeakSubscribe(State_PropertyChanged);
                    }
                }

                return _state;
            }
        }

        [NotNull]
        protected CommandProvider CommandProvider => _commandProvider ?? (_commandProvider = new CommandProvider());

        public virtual Task InitializeAsync(TParameters parameters)
        {
            Initialize(parameters);

            return Task.CompletedTask;
        }

        public virtual void Initialize(TParameters parameters)
        {
        }

        void IStateOwner.ImportState(IBundle state)
        {
            _state = state;

            if (_state != null && FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged())
            {
                _state.PropertyChangedWeakSubscribe(State_PropertyChanged);
            }
        }

        IBundle IStateOwner.ExportState()
        {
            return _state;
        }

        private void State_PropertyChanged([NotNull] object sender, [NotNull] PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }
    }
}

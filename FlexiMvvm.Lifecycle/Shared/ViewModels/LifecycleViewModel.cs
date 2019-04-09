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
using FlexiMvvm.Configuration;
using FlexiMvvm.Persistence;
using FlexiMvvm.Persistence.Core;

namespace FlexiMvvm.ViewModels
{
    /// <summary>
    /// Base class for a lifecycle-aware view model implementation that takes no parameters.
    /// </summary>
    public abstract class LifecycleViewModel : ViewModel, ILifecycleViewModelWithoutParameters, IStateOwner
    {
        private IBundle? _state;

        /// <summary>
        /// Gets the bundle that stores the lifecycle-aware view model state as a set of key/value pairs.
        /// </summary>
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

        /// <inheritdoc />
        public virtual Task InitializeAsync(bool recreated)
        {
            Initialize(recreated);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public virtual void Initialize(bool recreated)
        {
        }

        void IStateOwner.ImportState(IBundle? state)
        {
            _state = state;

            if (FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged())
            {
                _state?.PropertyChangedWeakSubscribe(State_PropertyChanged);
            }
        }

        IBundle? IStateOwner.ExportState()
        {
            return _state;
        }

        private void State_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }
    }

    /// <summary>
    /// Base class for a lifecycle-aware view model implementation that takes parameters.
    /// </summary>
    /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
    public abstract class LifecycleViewModel<TParameters> : ViewModel, ILifecycleViewModelWithParameters<TParameters>, IStateOwner
        where TParameters : Parameters
    {
        private IBundle? _state;

        /// <summary>
        /// Gets the bundle that stores the lifecycle-aware view model state as a set of key/value pairs.
        /// </summary>
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

        /// <inheritdoc />
        public virtual Task InitializeAsync(TParameters? parameters, bool recreated)
        {
            Initialize(parameters, recreated);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public virtual void Initialize(TParameters? parameters, bool recreated)
        {
        }

        void IStateOwner.ImportState(IBundle? state)
        {
            _state = state;

            if (FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged())
            {
                _state?.PropertyChangedWeakSubscribe(State_PropertyChanged);
            }
        }

        IBundle? IStateOwner.ExportState()
        {
            return _state;
        }

        private void State_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }
    }
}

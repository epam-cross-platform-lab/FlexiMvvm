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
using System.Threading.Tasks;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using FlexiMvvm.Persistence;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public abstract class ViewModelBase : ObservableObjectBase, IViewModelWithoutParameters, IViewModelWithState
    {
        [CanBeNull]
        private readonly IOperationFactory _operationFactory;
        [CanBeNull]
        private OperationContext _operationContext;
        [CanBeNull]
        private IBundle _stateBundle;
        [CanBeNull]
        private ViewModelState _state;
        [CanBeNull]
        private CommandProvider _commandProvider;

        protected ViewModelBase()
        {
        }

        protected ViewModelBase([NotNull] IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
        }

        public Task Initialization { get; private set; }

        [NotNull]
        protected IOperationFactory OperationFactory => _operationFactory ?? throw new InvalidOperationException(
            $"\"{nameof(OperationFactory)}\" property is \"null\". Make sure that operation factory is passed to \"{nameof(ViewModelBase)}\" constructor.");

        [NotNull]
        protected OperationContext OperationContext => _operationContext ?? (_operationContext = OperationFactory.CreateContext(this));

        [NotNull]
        private IBundle StateBundle => _stateBundle ?? (_stateBundle = BundleFactory.Create());

        [NotNull]
        protected ViewModelState State => _state ?? (_state = new ViewModelState(this, StateBundle));

        [NotNull]
        protected CommandProvider CommandProvider => _commandProvider ?? (_commandProvider = new CommandProvider());

        public virtual void Initialize()
        {
            Initialization = InitializeAsync();
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        void IViewModelWithState.ImportStateBundle(IBundle bundle)
        {
            _stateBundle = bundle;
        }

        public IBundle ExportStateBundle()
        {
            return _stateBundle;
        }
    }

    public abstract class ViewModelBase<TParameters> : ObservableObjectBase, IViewModelWithParameters<TParameters>, IViewModelWithState
        where TParameters : ViewModelParametersBase
    {
        [CanBeNull]
        private readonly IOperationFactory _operationFactory;
        [CanBeNull]
        private OperationContext _operationContext;
        [CanBeNull]
        private IBundle _stateBundle;
        [CanBeNull]
        private ViewModelState _state;
        [CanBeNull]
        private CommandProvider _commandProvider;

        protected ViewModelBase()
        {
        }

        protected ViewModelBase([NotNull] IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
        }

        public Task Initialization { get; private set; }

        [NotNull]
        protected IOperationFactory OperationFactory => _operationFactory ?? throw new InvalidOperationException(
            $"\"{nameof(OperationFactory)}\" property is \"null\". Make sure that operation factory is passed to \"{nameof(ViewModelBase)}\" constructor.");

        [NotNull]
        protected OperationContext OperationContext => _operationContext ?? (_operationContext = OperationFactory.CreateContext(this));

        [NotNull]
        private IBundle StateBundle => _stateBundle ?? (_stateBundle = BundleFactory.Create());

        [NotNull]
        protected ViewModelState State => _state ?? (_state = new ViewModelState(this, StateBundle));

        [NotNull]
        protected CommandProvider CommandProvider => _commandProvider ?? (_commandProvider = new CommandProvider());

        public virtual void Initialize(TParameters parameters)
        {
            Initialization = InitializeAsync(parameters);
        }

        public virtual Task InitializeAsync(TParameters parameters)
        {
            return Task.CompletedTask;
        }

        void IViewModelWithState.ImportStateBundle(IBundle bundle)
        {
            _stateBundle = bundle;
        }

        public IBundle ExportStateBundle()
        {
            return _stateBundle;
        }
    }
}

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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FlexiMvvm.Configuration;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected bool SetValue<T>([CanBeNull] ref T field, [CanBeNull] T value, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            if (!EqualityComparer<T>.Default.NotNull().Equals(field, value))
            {
                field = value;

                if (FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged())
                {
                    RaisePropertyChanged(propertyName);
                }

                return true;
            }

            return false;
        }

        [NotifyPropertyChangedInvocator]
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

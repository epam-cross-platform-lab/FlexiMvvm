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
using System.Diagnostics;
using FlexiMvvm.Bindings.Custom.Core.Source;
using FlexiMvvm.Diagnostics;
using FlexiMvvm.ValueConverters;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Composite
{
    internal abstract class CompositeItemBindingBase<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue> : ICompositeItemBinding<TSourceItem>
        where TSourceItem : class
        where TTargetItem : class
    {
        private BindingMode _compositeItemBindingMode;
        [CanBeNull]
        private ILogger _logger;

        protected CompositeItemBindingBase(
            [NotNull] SourceItemBinding<TSourceItem, TSourceItemValue> sourceItemBinding,
            [NotNull] TargetItemBinding<TTargetItem, TTargetItemValue> targetItemBinding,
            BindingMode requestedBindingMode,
            [NotNull] ICompositeItemBindingValueConverter valueConverter)
        {
            SourceItemBinding = sourceItemBinding;
            TargetItemBinding = targetItemBinding;
            RequestedBindingMode = requestedBindingMode;
            ValueConverter = valueConverter;

            SetLogger();
        }

        [NotNull]
        internal SourceItemBinding<TSourceItem, TSourceItemValue> SourceItemBinding { get; }

        [NotNull]
        internal TargetItemBinding<TTargetItem, TTargetItemValue> TargetItemBinding { get; }

        public BindingMode RequestedBindingMode { get; set; }

        public ICompositeItemBindingValueConverter ValueConverter { get; set; }

        [CanBeNull]
        internal CompositeItemBindingFallbackValue<TTargetItemValue> FallbackValue { get; set; }

        [NotNull]
        private ILogger Logger =>
            _logger ?? (_logger = new ConsoleLogger("FlexiMvvm.Bindings", $"{SourceItemBinding.GetName()} --> {TargetItemBinding.GetName()} binding"));

        public void SetSourceItemReference(IItemReference<TSourceItem> itemReference)
        {
            UnsubscribeFromSourceItemEvents();
            SourceItemBinding.SetItemReference(itemReference);
            SubscribeToSourceItemEvents();

            if (TargetItemBinding.TryGetItem(out var targetItem))
            {
                SetInitialValues(targetItem);
            }
        }

        public bool Apply()
        {
            if (TryResolveCompositeItemBindingMode(out _compositeItemBindingMode))
            {
                if (TargetItemBinding.TryGetItem(out var targetItem))
                {
                    SourceItemBinding.ValueChanged += SourceItemBinding_ValueChanged;
                    TargetItemBinding.ValueChanged += TargetItemBinding_ValueChanged;

                    SubscribeToSourceItemEvents();
                    SubscribeToTargetItemEvents();
                    SetInitialValues(targetItem);

                    return true;
                }

                Log("Composite binding target item is \"null\". Skip it.");
            }
            else
            {
                Log("Composite binding configured incorrectly. Skip it.");
            }

            return false;
        }

        private bool TryResolveCompositeItemBindingMode(out BindingMode compositeItemBindingMode)
        {
            if (SourceItemBinding.BindingMode.TryCombineWith(TargetItemBinding.BindingMode, out compositeItemBindingMode))
            {
                if (!compositeItemBindingMode.TryCombineWith(RequestedBindingMode, out compositeItemBindingMode))
                {
                    Log($"Ignore \"{RequestedBindingMode}\" requested binding mode because it is less strict or incompartible with " +
                        $"\"{compositeItemBindingMode}\" composite binding mode.");
                }

                return true;
            }

            Log($"Composite binding mode cannot be resolved due to \"{SourceItemBinding.BindingMode}\" source item binding mode " +
                $"and \"{TargetItemBinding.BindingMode}\" target item binding mode are not compatible.");

            return false;
        }

        protected abstract void SetInitialValues([NotNull] TTargetItem targetItem);

        protected abstract void SubscribeToSourceItemEvents();

        private void SubscribeToTargetItemEvents()
        {
            if (TargetItemBinding.TryGetItem(out var targetItem))
            {
                if (IsFromTargetToSourceBindingMode())
                {
                    try
                    {
                        TargetItemBinding.SubscribeToEvents(targetItem);
                    }
                    catch (Exception ex)
                    {
                        Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while executing " +
                            $"\"{LogFormatter.FormatTypeName(TargetItemBinding)}.{nameof(TargetItemBinding.SubscribeToEvents)}\" method.");
                    }
                }
            }
        }

        protected abstract void UnsubscribeFromSourceItemEvents();

        private void UnsubscribeFromTargetItemEvents()
        {
            if (TargetItemBinding.TryGetItem(out var targetItem))
            {
                if (IsFromTargetToSourceBindingMode())
                {
                    try
                    {
                        TargetItemBinding.UnsubscribeFromEvents(targetItem);
                    }
                    catch (Exception ex)
                    {
                        Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while executing " +
                            $"\"{LogFormatter.FormatTypeName(TargetItemBinding)}.{nameof(TargetItemBinding.UnsubscribeFromEvents)}\" method.");
                    }
                }
            }
        }

        protected bool TryGetSourceItemValue([NotNull] TSourceItem sourceItem, out TSourceItemValue sourceItemValue)
        {
            try
            {
                return SourceItemBinding.TryGetValue(sourceItem, out sourceItemValue);
            }
            catch (Exception ex)
            {
                Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while executing " +
                    $"\"{LogFormatter.FormatTypeName(SourceItemBinding)}.{nameof(SourceItemBinding.TryGetValue)}\" method.");

                sourceItemValue = default;

                return false;
            }
        }

        protected bool TryGetTargetItemValue([NotNull] TTargetItem targetItem, out TTargetItemValue targetItemValue)
        {
            try
            {
                return TargetItemBinding.TryGetValue(targetItem, out targetItemValue);
            }
            catch (Exception ex)
            {
                Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while executing " +
                    $"\"{LogFormatter.FormatTypeName(TargetItemBinding)}.{nameof(TargetItemBinding.TryGetValue)}\" method.");

                targetItemValue = default;

                return false;
            }
        }

        protected void SetSourceItemValue([NotNull] TSourceItem sourceItem, [CanBeNull] TTargetItemValue targetItemValue)
        {
            var sourceItemValue = ValueConverter.ConvertBack(targetItemValue, typeof(TSourceItemValue));

            if (sourceItemValue != BindingValue.UnsetValue)
            {
                try
                {
                    SourceItemBinding.SetValue(sourceItem, (TSourceItemValue)sourceItemValue, _compositeItemBindingMode == BindingMode.TwoWay);
                }
                catch (Exception ex)
                {
                    Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while executing " +
                        $"\"{LogFormatter.FormatTypeName(SourceItemBinding)}.{nameof(SourceItemBinding.SetValue)}\" method.");
                }
            }
        }

        protected void SetTargetItemValue([NotNull] TTargetItem targetItem, [NotNull] TSourceItem sourceItem, [CanBeNull] TSourceItemValue sourceItemValue)
        {
            var targetItemValue = ValueConverter.Convert(sourceItemValue, typeof(TTargetItemValue));

            SetTargetItemValue(targetItem, targetItemValue);
        }

        protected void SetTargetItemValue([NotNull] TTargetItem targetItem, [CanBeNull] object targetItemValue)
        {
            if (targetItemValue == BindingValue.UnsetValue)
            {
                if (FallbackValue != null)
                {
                    targetItemValue = FallbackValue.Value;
                }
                else
                {
                    if (!SourceItemBinding.TryGetItem(out _))
                    {
                        Log("Source item is null and fallback value is not set. " +
                            "This may lead to diplaying value from the previous source item. " +
                            "Set fallback value to override previous one.");
                    }
                }
            }

            if (targetItemValue != BindingValue.UnsetValue)
            {
                try
                {
                    TargetItemBinding.SetValue(targetItem, (TTargetItemValue)targetItemValue, _compositeItemBindingMode == BindingMode.TwoWay);
                }
                catch (Exception ex)
                {
                    Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while executing " +
                        $"\"{LogFormatter.FormatTypeName(TargetItemBinding)}.{nameof(TargetItemBinding.SetValue)}\" method.");
                }
            }
        }

        private void SourceItemBinding_ValueChanged([NotNull] object sender, [NotNull] ValueChangedEventArgs<TSourceItemValue> e)
        {
            if (TargetItemBinding.TryGetItem(out var targetItem) && SourceItemBinding.TryGetItem(out var sourceItem))
            {
                SetTargetItemValue(targetItem, sourceItem, e.Value);
            }
        }

        private void TargetItemBinding_ValueChanged([NotNull] object sender, [NotNull] ValueChangedEventArgs<TTargetItemValue> e)
        {
            if (SourceItemBinding.TryGetItem(out var sourceItem))
            {
                SetSourceItemValue(sourceItem, e.Value);
            }
        }

        protected bool IsFromSourceToTargetBindingMode(bool includingOneTimeBindingMode = true)
        {
            return _compositeItemBindingMode.IsFromSourceToTarget() && (includingOneTimeBindingMode || _compositeItemBindingMode != BindingMode.OneTime);
        }

        protected bool IsFromTargetToSourceBindingMode()
        {
            return _compositeItemBindingMode.IsFromTargetToSource();
        }

        public void Dispose()
        {
            UnsubscribeFromSourceItemEvents();
            UnsubscribeFromTargetItemEvents();

            SourceItemBinding.Dispose();
            TargetItemBinding.Dispose();
        }

        [Conditional("DEBUG")]
        private void SetLogger()
        {
            SourceItemBinding.SetLogger(Logger);
            TargetItemBinding.SetLogger(Logger);
            ValueConverter.SetLogger(Logger);
        }

        [Conditional("DEBUG")]
        protected void Log([CanBeNull] string message)
        {
            Logger.Log(message);
        }
    }
}

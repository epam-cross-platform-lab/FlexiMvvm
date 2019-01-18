using System;
using JetBrains.Annotations;

namespace FlexiMvvm.Weak.Subscriptions.Generation
{
    internal partial class WeakEventSubscriptionGenerator
    {
        internal WeakEventSubscriptionGenerator([NotNull] EventGenerationOptions typeEventGenerationOptions)
        {
            TypeEventGenerationOptions = typeEventGenerationOptions ?? throw new ArgumentNullException(nameof(typeEventGenerationOptions));
        }

        [NotNull]
        private EventGenerationOptions TypeEventGenerationOptions { get; }

        [NotNull]
        private string GetClassName()
        {
            var sanitizedClassName = TypeEventGenerationOptions.EventHandlerClassName.WithoutNamespace().WithoutGenericPart();

            return TypeEventGenerationOptions.IsGenericEventHandler
                ? $"{sanitizedClassName}WeakEventSubscription<TEventSource, TEventArgs>"
                : $"{sanitizedClassName}WeakEventSubscription<TEventSource>";
        }

        [NotNull]
        private string GetBaseClassName()
        {
            return TypeEventGenerationOptions.IsGenericEventHandler
                ? "WeakEventSubscription<TEventSource, TEventArgs>"
                : $"WeakEventSubscription<TEventSource, {TypeEventGenerationOptions.EventArgsClassName}>";
        }

        [NotNull]
        private string GetOriginEventHandlerDeclarationName()
        {
            return TypeEventGenerationOptions.IsGenericEventHandler
                ? $"{TypeEventGenerationOptions.EventHandlerClassName}<TEventArgs>"
                : TypeEventGenerationOptions.EventHandlerClassName;
        }

        [NotNull]
        private string GetPassedEventHandlerDeclarationName()
        {
            return TypeEventGenerationOptions.IsGenericEventHandler
                ? $"{nameof(EventHandler)}<TEventArgs>"
                : $"{nameof(EventHandler)}<{TypeEventGenerationOptions.EventArgsClassName}>";
        }
    }
}

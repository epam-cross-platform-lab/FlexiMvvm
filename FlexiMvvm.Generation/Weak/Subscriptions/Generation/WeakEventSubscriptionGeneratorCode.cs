using System;
using JetBrains.Annotations;

namespace FlexiMvvm.Weak.Subscriptions.Generation
{
    internal partial class WeakEventSubscriptionGenerator
    {
        internal WeakEventSubscriptionGenerator(
            [NotNull] string typeClassName,
            [NotNull] EventGenerationOptions typeEventGenerationOptions)
        {
            if (string.IsNullOrWhiteSpace(typeClassName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(typeClassName));
            if (typeEventGenerationOptions == null)
                throw new ArgumentNullException(nameof(typeEventGenerationOptions));

            TypeClassName = typeClassName;
            TypeEventGenerationOptions = typeEventGenerationOptions;
        }

        [NotNull]
        private string TypeClassName { get; }

        [NotNull]
        private EventGenerationOptions TypeEventGenerationOptions { get; }

        public static bool ShouldGenerateCustom([NotNull] EventGenerationOptions typeEventGenerationOptions)
        {
            if (typeEventGenerationOptions == null)
                throw new ArgumentNullException(nameof(typeEventGenerationOptions));

            return !string.IsNullOrWhiteSpace(typeEventGenerationOptions.EventHandlerClassName) &&
                !typeEventGenerationOptions.EventHandlerClassName.Equals("EventHandler") &&
                !typeEventGenerationOptions.EventHandlerClassName.EndsWith(".EventHandler");
        }

        [NotNull]
        public static string GetWeakEventSubscriptionClassName([NotNull] string typeClassName, [NotNull] EventGenerationOptions typeEventGenerationOptions)
        {
            if (string.IsNullOrWhiteSpace(typeClassName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(typeClassName));
            if (typeEventGenerationOptions == null)
                throw new ArgumentNullException(nameof(typeEventGenerationOptions));

            var weakEventSubscriptionClassName = $"{typeEventGenerationOptions.EventName}WeakEventSubscription";

            if (string.IsNullOrWhiteSpace(typeEventGenerationOptions.EventHandlerClassName))
            {
                weakEventSubscriptionClassName = string.IsNullOrWhiteSpace(typeEventGenerationOptions.EventArgsClassName)
                    ? $"WeakEventSubscription<{typeClassName}>"
                    : $"WeakEventSubscription<{typeClassName}, {typeEventGenerationOptions.EventArgsClassName}>";
            }

            return weakEventSubscriptionClassName;
        }
    }
}

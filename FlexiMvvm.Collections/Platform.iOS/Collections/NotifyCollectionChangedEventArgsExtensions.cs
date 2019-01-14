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
using System.Collections;
using System.Collections.Specialized;
using Foundation;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    internal static class NotifyCollectionChangedEventArgsExtensions
    {
        [NotNull]
        internal static NSIndexPath[] ToOldIndexPaths([NotNull] this NotifyCollectionChangedEventArgs args, nint section)
        {
            return ToIndexPaths(args.OldStartingIndex, args.OldItems.NotNull(), section);
        }

        [NotNull]
        internal static NSIndexPath ToOldIndexPath([NotNull] this NotifyCollectionChangedEventArgs args, nint section)
        {
            return NSIndexPath.FromRowSection(args.OldStartingIndex, section).NotNull();
        }

        [NotNull]
        internal static NSIndexSet ToOldIndexSet([NotNull] this NotifyCollectionChangedEventArgs args)
        {
            return NSIndexSet.FromNSRange(new NSRange(args.OldStartingIndex, args.OldItems.NotNull().Count)).NotNull();
        }

        [NotNull]
        internal static NSIndexPath[] ToNewIndexPaths([NotNull] this NotifyCollectionChangedEventArgs args, nint section)
        {
            return ToIndexPaths(args.NewStartingIndex, args.NewItems.NotNull(), section);
        }

        [NotNull]
        internal static NSIndexPath ToNewIndexPath([NotNull] this NotifyCollectionChangedEventArgs args, nint section)
        {
            return NSIndexPath.FromRowSection(args.NewStartingIndex, section).NotNull();
        }

        [NotNull]
        internal static NSIndexSet ToNewIndexSet([NotNull] this NotifyCollectionChangedEventArgs args)
        {
            return NSIndexSet.FromNSRange(new NSRange(args.NewStartingIndex, args.NewItems.NotNull().Count)).NotNull();
        }

        [NotNull]
        private static NSIndexPath[] ToIndexPaths(int startingIndex, [NotNull] ICollection items, nint section)
        {
            var indexPaths = new NSIndexPath[items.Count];

            for (var index = 0; index < indexPaths.Length; index++)
            {
                indexPaths[index] = NSIndexPath.FromRowSection(startingIndex + index, section);
            }

            return indexPaths;
        }
    }
}

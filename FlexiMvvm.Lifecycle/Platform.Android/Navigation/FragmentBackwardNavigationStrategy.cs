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

namespace FlexiMvvm.Navigation
{
    using Android.Support.V4.App;

    /// <summary>
    /// Defines the contract for backward navigation from the <see cref="Fragment"/>.
    /// </summary>
    /// <param name="sourceView">The <see cref="Fragment"/> from which navigation is performed from.</param>
    public delegate void FragmentBackwardNavigationDelegate(Fragment sourceView);

    /// <summary>
    /// Provides a set of backward navigation strategies for the <see cref="Fragment"/>.
    /// </summary>
    public sealed class FragmentBackwardNavigationStrategy
    {
        /// <summary>
        /// Backward navigation using the <see cref="FragmentManager.PopBackStack()"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        public FragmentBackwardNavigationDelegate PopBackStack()
        {
            return sourceView =>
            {
                sourceView.FragmentManager.PopBackStack();
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="FragmentManager.PopBackStack(int, int)"/> method.
        /// </summary>
        /// <param name="id">
        /// Identifier of the stated to be popped. If no identifier exists, false is returned. The identifier is the number returned by <see cref="FragmentTransaction.Commit()"/>.
        /// The <see cref="FragmentManager.PopBackStackInclusive"/> flag can be used to control whether the named state itself is popped.
        /// </param>
        /// <param name="flags">Either 0 or <see cref="FragmentManager.PopBackStackInclusive"/>.</param>
        /// <returns>The backward navigation delegate.</returns>
        public FragmentBackwardNavigationDelegate PopBackStack(int id, int flags)
        {
            return sourceView =>
            {
                sourceView.FragmentManager.PopBackStack(id, flags);
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="FragmentManager.PopBackStack(string?, int)"/> method.
        /// </summary>
        /// <param name="name">
        /// If non-<see langword="null"/>, this is the name of a previous back state to look for; if found, all states up to that state will be popped.
        /// The <see cref="FragmentManager.PopBackStackInclusive"/> flag can be used to control whether the named state itself is popped. If <see langword="null"/>, only the top state is popped.
        /// </param>
        /// <param name="flags">Either 0 or <see cref="FragmentManager.PopBackStackInclusive"/>.</param>
        /// <returns>The backward navigation delegate.</returns>
        public FragmentBackwardNavigationDelegate PopBackStack(string? name, int flags)
        {
            return sourceView =>
            {
                sourceView.FragmentManager.PopBackStack(name, flags);
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="FragmentManager.PopBackStackImmediate()"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        public FragmentBackwardNavigationDelegate PopBackStackImmediate()
        {
            return sourceView =>
            {
                sourceView.FragmentManager.PopBackStackImmediate();
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="FragmentManager.PopBackStackImmediate(int, int)"/> method.
        /// </summary>
        /// <param name="id">
        /// Identifier of the stated to be popped. If no identifier exists, false is returned. The identifier is the number returned by <see cref="FragmentTransaction.Commit()"/>.
        /// The <see cref="FragmentManager.PopBackStackInclusive"/> flag can be used to control whether the named state itself is popped.
        /// </param>
        /// <param name="flags">Either 0 or <see cref="FragmentManager.PopBackStackInclusive"/>.</param>
        /// <returns>The backward navigation delegate.</returns>
        public FragmentBackwardNavigationDelegate PopBackStackImmediate(int id, int flags)
        {
            return sourceView =>
            {
                sourceView.FragmentManager.PopBackStackImmediate(id, flags);
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="FragmentManager.PopBackStackImmediate(string?, int)"/> method.
        /// </summary>
        /// <param name="name">
        /// If non-<see langword="null"/>, this is the name of a previous back state to look for; if found, all states up to that state will be popped.
        /// The <see cref="FragmentManager.PopBackStackInclusive"/> flag can be used to control whether the named state itself is popped. If <see langword="null"/>, only the top state is popped.
        /// </param>
        /// <param name="flags">Either 0 or <see cref="FragmentManager.PopBackStackInclusive"/>.</param>
        /// <returns>The backward navigation delegate.</returns>
        public FragmentBackwardNavigationDelegate PopBackStackImmediate(string? name, int flags)
        {
            return sourceView =>
            {
                sourceView.FragmentManager.PopBackStackImmediate(name, flags);
            };
        }
    }
}

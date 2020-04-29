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
using Android.Text;
using Android.Text.Method;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;

namespace FlexiMvvm.Bindings
{
    public static class EditTextExtensions
    {
        public static TargetItemBinding<EditText, InputTypes> InputTypeBinding(
            this IItemReference<EditText> editTextReference)
        {
            if (editTextReference == null)
                throw new ArgumentNullException(nameof(editTextReference));

            return new TargetItemOneWayCustomBinding<EditText, InputTypes>(
                editTextReference,
                (editText, inputType) => editText.InputType = inputType,
                () => nameof(EditText.InputType));
        }

        public static TargetItemBinding<EditText, IInputFilter[]> SetFiltersBinding(
            this IItemReference<EditText> editTextReference)
        {
            if (editTextReference == null)
                throw new ArgumentNullException(nameof(editTextReference));

            return new TargetItemOneWayCustomBinding<EditText, IInputFilter[]>(
                editTextReference,
                (editText, filters) => editText.SetFilters(filters),
                () => nameof(EditText.SetFilters));
        }

        public static TargetItemBinding<EditText, ITransformationMethod> TransformationMethodBinding(
            this IItemReference<EditText> editTextReference)
        {
            if (editTextReference == null)
                throw new ArgumentNullException(nameof(editTextReference));

            return new TargetItemOneWayCustomBinding<EditText, ITransformationMethod>(
                editTextReference,
                (editText, transformationMethod) => editText.TransformationMethod = transformationMethod,
                () => nameof(EditText.TransformationMethod));
        }
    }
}

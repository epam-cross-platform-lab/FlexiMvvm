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
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace FlexiMvvm.ObjCRuntime
{
    public static class NSObjectExtensions
    {
#pragma warning disable SA1300, SA1400
        [DllImport("/usr/lib/libobjc.dylib")]
        static extern IntPtr objc_getAssociatedObject(IntPtr pointer, IntPtr key);

        [DllImport("/usr/lib/libobjc.dylib")]
        static extern void objc_setAssociatedObject(IntPtr pointer, IntPtr key, IntPtr value, AssociationPolicy policy);
#pragma warning restore SA1300, SA1400

        public static T GetAssociatedObject<T>(this NSObject obj, NSString key)
            where T : NSObject
        {
            var valuePtr = objc_getAssociatedObject(obj.Handle, key.Handle);

            return valuePtr != IntPtr.Zero ? Runtime.GetNSObject<T>(valuePtr) : null;
        }

        public static void SetAssociatedObject<T>(this NSObject obj, NSString key, T value, AssociationPolicy policy)
            where T : NSObject
        {
            objc_setAssociatedObject(obj.Handle, key.Handle, value?.Handle ?? IntPtr.Zero, policy);
        }
    }
}

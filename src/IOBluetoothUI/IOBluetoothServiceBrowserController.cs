//
// IOBluetoothServiceBrowserController.cs
//
// Author:
//       David Lechner <david@lechnology.com>
//
// Copyright (c) 2013 David Lechner
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Runtime.InteropServices;
using MonoMac.AppKit;
using MonoMac.Foundation;
using MonoMac.IOBluetooth;
using MonoMac.IOKit;
using MonoMac.ObjCRuntime;

namespace MonoMac.IOBluetoothUI
{
	public partial class IOBluetoothServiceBrowserController
	{
		public void BeginSheetModalForWindow (NSWindow sheetWindow,
		                                      NSObject modalDelegate,
		                                      Selector didEndSelector,
		                                      IntPtr contextInfo = default(IntPtr))
		{
			var result = beginSheetModalForWindow (sheetWindow, modalDelegate,
			                                       didEndSelector, contextInfo);
			IOObject.ThrowIfError (result);
		}

		public IOBluetoothDeviceSearchAttributes SearchAttributes {
			get {
				return (IOBluetoothDeviceSearchAttributes)Marshal.PtrToStructure (searchAttributes, typeof(IOBluetoothDeviceSearchAttributes));
			}
			set {
				if (value == null) {
					searchAttributes = IntPtr.Zero;
					return;
				}
				var valuePtr = Marshal.AllocHGlobal (Marshal.SizeOf (value));
				Marshal.StructureToPtr (value, valuePtr, false);
				try {
					searchAttributes = valuePtr;
				} finally {
					Marshal.FreeHGlobal (valuePtr);
				}
			}
		}
	}
}


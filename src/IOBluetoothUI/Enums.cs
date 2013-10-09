//
// Enums.cs
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
using MonoMac.ObjCRuntime;

namespace MonoMac.IOBluetoothUI
{
	[Since (2,0)]
	[Flags]
	public enum IOBluetoothServiceBrowserControllerOptions : uint
	{
		None               = 0,

		[Obsolete ("this has been deprecated in 10.5, all panels will AutoStart")]
		AutoStartInquiry   = 1 << 0,

		[Since (6,0)]
		DisconnectWhenDone = 1 << 1
	}

	public enum BluetoothKeyboardReturnType
	{
		ANSI,
		ISO,
		JIS
	}

	public enum IOBluetoothUIPanelResult
	{
		Success         = -1000,
		UserCanceledErr = -1001
	}
}
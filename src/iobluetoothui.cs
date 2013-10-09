//
// iobluetoothui.cs
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
using MonoMac.AppKit;
using MonoMac.Foundation;
using MonoMac.IOBluetooth;
using MonoMac.IOKit;
using MonoMac.ObjCRuntime;

namespace MonoMac.IOBluetoothUI
{
	[BaseType (typeof (NSWindowController))]
	interface IOBluetoothDeviceSelectorController {
		[Static]
		[Export ("deviceSelector")]
		IOBluetoothDeviceSelectorController CreateDeviceSelector ();

//		[Static]
//		[Obsolete ("Depretiated in Mac OS X version 10.7 and later")]
//		[Export ("withDeviceSelectorControllerRef:")]
//		IOBluetoothDeviceSelectorController WithDeviceSelectorControllerRef (IOBluetoothDeviceSelectorControllerRef deviceSelectorControllerRef, );
//
//		[Export ("getDeviceSelectorControllerRef")]
//		[Obsolete ("Depretiated in Mac OS X version 10.7 and later")]
//		IOBluetoothDeviceSelectorControllerRef GetDeviceSelectorControllerRef ();

		[Export ("runModal")]
		IOBluetoothUIPanelResult RunModal ();

		[Export ("beginSheetModalForWindow:modalDelegate:didEndSelector:contextInfo:"), Internal]
		IOReturn beginSheetModalForWindow (NSWindow sheetWindow, NSObject modalDelegate, Selector didEndSelector, IntPtr contextInfo);

		[Export ("getResults")]
		IOBluetoothDevice[] Results { get; }

		[Export ("options")]
		IOBluetoothServiceBrowserControllerOptions Options {
			[Bind ("getOptions")] get; set;
		}

		[Export ("searchAttributes"), Internal]
		/*IOBluetoothDeviceSearchAttributes*/ IntPtr searchAttributes {
			[Bind ("getSearchAttributes")] get; set;
		}

		[Export ("addAllowedUUID:")]
		void AddAllowedUUID (IOBluetoothSDPUUID allowedUUID);

		[Export ("addAllowedUUIDArray:")]
		void AddAllowedUUIDs (IOBluetoothSDPUUID[] allowedUUIDs);

		[Export ("clearAllowedUUIDs")]
		void ClearAllowedUUIDs ();

		[Export ("title")]
		string GetTitle { [Bind ("getTitle")] get; set; }

		[Export ("descriptionText")]
		string GetDescriptionText { [Bind ("getDescriptionText")] get; set; }

		[Export ("prompt")]
		string GetPrompt { [Bind ("getPrompt")] get; set; }
	}

	[Internal]
	[BaseType (typeof (IOBluetoothDeviceSelectorController))]
	interface IOBluetoothConcreteDeviceSelectorController {
	}

	[BaseType (typeof (NSWindowController))]
	interface IOBluetoothObjectPushUIController {
		[Export ("initObjectPushWithBluetoothDevice:withFiles:delegate:")]
		IOBluetoothObjectPushUIController Constructor (IOBluetoothDevice inDevice, string[] inFiles, [NullAllowed] NSObject inDelegate);

		[Export ("runModal")]
		void RunModal ();

		[Export ("runPanel")]
		void RunPanel ();

		[Export ("beginSheetModalForWindow:modalDelegate:didEndSelector:contextInfo:"), Internal]
		IOReturn beginSheetModalForWindow (NSWindow sheetWindow, NSObject modalDelegate, Selector didEndSelector, IntPtr contextInfo);

		[Export ("stop")]
		void Stop ();

		[Export ("title")]
		string Title { [Bind ("getTitle")] get; set; }

		[Export ("setIconImage:")]
		void SetIconImage (NSImage image);

		[Export ("getDevice")]
		IOBluetoothDevice Device { get; }

		[Export ("isTransferInProgress")]
		bool IsTransferInProgress { get; }
	}

	[Internal]
	[BaseType (typeof (IOBluetoothObjectPushUIController))]
	interface IOBluetoothConcreteObjectPushUIController {
	}

	[BaseType (typeof (NSWindowController))]
	interface IOBluetoothPairingController {
		[Static]
		[Export ("pairingController")]
		IOBluetoothPairingController CreateParingController ();

//		[Static]
//		[Obsolete ("Depretiated in Mac OS X version 10.7 and later")]
//		[Export ("withPairingControllerRef:")]
//		IOBluetoothPairingController WithPairingControllerRef (IOBluetoothPairingControllerRef pairingControllerRef, );
//
//		[Export ("getPairingControllerRef")]
//		[Obsolete ("Depretiated in Mac OS X version 10.7 and later")]
//		IOBluetoothPairingControllerRef GetPairingControllerRef ();

		[Export ("runModal")]
		IOBluetoothUIPanelResult RunModal ();

		[Export ("getResults")]
		IOBluetoothDevice[] Results { get; }

		[Export ("options")]
		IOBluetoothServiceBrowserControllerOptions Options {
			[Bind ("getOptions")] get; set;
		}

		[Export ("searchAttributes"), Internal]
		/*IOBluetoothDeviceSearchAttributes*/ IntPtr searchAttributes {
			[Bind ("getSearchAttributes")] get; set;
		}

		[Export ("addAllowedUUID:")]
		void AddAllowedUUID (IOBluetoothSDPUUID allowedUUID);

		[Export ("addAllowedUUIDArray:")]
		void AddAllowedUUIDs (IOBluetoothSDPUUID[] allowedUUIDs);

		[Export ("clearAllowedUUIDs")]
		void ClearAllowedUUIDs ();

		[Export ("title")]
		string Title { [Bind ("getTitle")] get; set; }

		[Export ("descriptionText")]
		string DescriptionText { [Bind ("getDescriptionText")] get; set; }

		[Export ("prompt")]
		string Prompt { [Bind ("getPrompt")] get; set; }
	}

	[Internal]
	[BaseType (typeof (IOBluetoothPairingController))]
	interface IOBluetoothConcretePairingController {
	}

	[BaseType (typeof (NSView))]
	interface IOBluetoothPasskeyDisplay {
		[Export ("returnImage")]
		NSImage ReturnImage { get; set; }

		[Export ("returnHighlightImage")]
		NSImage ReturnHighlightImage { get; set; }

		[Export ("returnType")]
		BluetoothKeyboardReturnType ReturnType { get; set; }

		[Static]
		[Export ("sharedDisplayView")]
		IOBluetoothPasskeyDisplay SharedDisplayView { get; }

		[Export ("setPasskeyString:")]
		void SetPasskeyString (string inString);

		[Export ("advancePasskeyIndicator")]
		void AdvancePasskeyIndicator ();

		[Export ("retreatPasskeyIndicator")]
		void RetreatPasskeyIndicator ();

		[Export ("resetAll")]
		void ResetAll ();

		[Export ("resetPasskeyIndicator")]
		void ResetPasskeyIndicator ();

		[Export ("setPasskeyIndicatorEnabled:")]
		void SetPasskeyIndicatorEnabled (bool inEnabled);

		[Export ("setupUIForDevice:")]
		void SetupUIForDevice (IOBluetoothDevice device);

		[Export ("setupUIForSSPDevice:")]
		void SetupUIForSSPDevice (IOBluetoothDevice device);
	}

	[Internal]
	[BaseType (typeof (IOBluetoothPasskeyDisplay))]
	interface IOBluetoothConcretePasskeyDisplay {
	}

	[BaseType (typeof (NSTextFieldCell))]
	interface IOBluetoothAccessibilityIgnoredTextFieldCell {
	}

	[BaseType (typeof (NSWindowController))]
	interface IOBluetoothServiceBrowserController {
		[Static]
		[Export ("serviceBrowserController:")]
		IOBluetoothServiceBrowserController CreateServiceBrowserController (IOBluetoothServiceBrowserControllerOptions inOptions);

		//DEPRECATED_IN_MAC_OS_X_VERSION_10_5_AND_LATER
//		[Static]
//		[Export ("browseDevices:options:")]
//		IOReturn BrowseDevices (IOBluetoothSDPServiceRecord outRecord, IOBluetoothServiceBrowserControllerOptions inOptions);

		//DEPRECATED_IN_MAC_OS_X_VERSION_10_5_AND_LATER
//		[Static]
//		[Export ("browseDevicesAsSheetForWindow:options:window:")]
//		IOReturn BrowseDevicesAsSheetForWindow (out IOBluetoothSDPServiceRecord outRecord, IOBluetoothServiceBrowserControllerOptions inOptions, NSWindow inWindow);

//		[Static]
//		[Export ("withServiceBrowserControllerRef:")]
//		IOBluetoothServiceBrowserController WithServiceBrowserControllerRef (IOBluetoothServiceBrowserControllerRef serviceBrowserControllerRef);
//
//		[Export ("getServiceBrowserControllerRef")]
//		IOBluetoothServiceBrowserControllerRef GetServiceBrowserControllerRef ();

		//DEPRECATED_IN_MAC_OS_X_VERSION_10_5_AND_LATER
//		[Export ("discover:")]
//		IOReturn Discover (out IOBluetoothSDPServiceRecord outRecord);

		//DEPRECATED_IN_MAC_OS_X_VERSION_10_5_AND_LATER
//		[Export ("discoverAsSheetForWindow:withRecord:")]
//		IOReturn DiscoverAsSheetForWindow (NSWindow sheetWindow, IOBluetoothSDPServiceRecord outRecord);

		//DEPRECATED_IN_MAC_OS_X_VERSION_10_5_AND_LATER
//		[Export ("discoverWithDeviceAttributes:serviceList:serviceRecord:")]
//		IOReturn DiscoverWithDeviceAttributes (IOBluetoothDeviceSearchAttributes deviceAttributes, NSArray serviceArray, out IOBluetoothSDPServiceRecord outRecord);

		[Export ("runModal")]
		int RunModal ();

		[Export ("beginSheetModalForWindow:modalDelegate:didEndSelector:contextInfo:"), Internal]
		IOReturn beginSheetModalForWindow (NSWindow sheetWindow, NSObject modalDelegate, Selector didEndSelector, IntPtr contextInfo);

		[Export ("getResults")]
		IOBluetoothSDPServiceRecord[] Results { get; }

		[Export ("options")]
		IOBluetoothServiceBrowserControllerOptions Options {
			[Bind ("getOptions")] get; set;
		}

		[Export ("searchAttributes"), Internal]
		/*IOBluetoothDeviceSearchAttributes*/ IntPtr searchAttributes {
			[Bind ("getSearchAttributes")] get; set;
		}

		[Export ("addAllowedUUID:")]
		void AddAllowedUUID (IOBluetoothSDPUUID allowedUUID);

		[Export ("addAllowedUUIDArray:")]
		void AddAllowedUUIDs (IOBluetoothSDPUUID[] allowedUUIDs);

		[Export ("clearAllowedUUIDs")]
		void ClearAllowedUUIDs ();

		[Export ("title")]
		string Title { [Bind ("getTitle")] get; set; }

		[Export ("descriptionText")]
		string DescriptionText { [Bind ("getDescriptionText")] get; set; }

		[Export ("prompt")]
		string Prompt { [Bind ("getPrompt")] get; set; }
	}

	[Internal]
	[BaseType (typeof (IOBluetoothServiceBrowserController))]
	interface IOBluetoothConcreteServiceBrowserController {
	}
}
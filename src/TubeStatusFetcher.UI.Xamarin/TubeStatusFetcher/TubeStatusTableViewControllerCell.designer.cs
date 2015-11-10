// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TubeStatusFetcher
{
	[Register ("TubeStatusTableViewControllerCell")]
	partial class TubeStatusTableViewControllerCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel statusLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel tubeNameLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (statusLabel != null) {
				statusLabel.Dispose ();
				statusLabel = null;
			}
			if (tubeNameLabel != null) {
				tubeNameLabel.Dispose ();
				tubeNameLabel = null;
			}
		}
	}
}

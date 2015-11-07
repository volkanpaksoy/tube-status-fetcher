
using System;

using Foundation;
using UIKit;

namespace TubeStatusFetcher
{
	public class TubeStatusTableViewControllerCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("TubeStatusTableViewControllerCell");

		public TubeStatusTableViewControllerCell () : base (UITableViewCellStyle.Value1, Key)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			TextLabel.Text = "TextLabel";
		}
	}
}


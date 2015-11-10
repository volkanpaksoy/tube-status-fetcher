using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TubeStatusFetcher
{
	public partial class TubeStatusTableViewControllerCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("TubeCell");
	
		public UILabel StatusLabel 
		{
			get
			{
				return statusLabel;	
			}
		}

		public UILabel TubeNameLabel 
		{
			get
			{
				return tubeNameLabel;	
			}
		}

		public TubeStatusTableViewControllerCell (IntPtr handle) : base (handle)
		{
			
		}
			
	}
}

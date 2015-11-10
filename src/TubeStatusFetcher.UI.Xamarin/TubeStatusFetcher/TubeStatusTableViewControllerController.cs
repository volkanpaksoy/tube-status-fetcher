using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

using TubeStatusFetcher.Core;
using System.Collections.Generic;

namespace TubeStatusFetcher
{
	partial class TubeStatusTableViewControllerController : UITableViewController
	{
		public TubeStatusTableViewControllerController (IntPtr handle) : base (handle)
		{


		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var fetcher = new Fetcher ();
			var lineInfoList = fetcher.GetTubeInfo();
			TableView.Source = new TubeStatusTableViewControllerSource(lineInfoList.ToArray());
			TableView.ReloadData();
		}
	}
}

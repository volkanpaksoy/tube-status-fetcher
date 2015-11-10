
using System;
using TubeStatusFetcher.Core;


using Foundation;
using UIKit;


namespace TubeStatusFetcher
{
	public class TubeStatusTableViewControllerSource : UITableViewSource
	{
		LineInfo[] _lineInfoList;

		public TubeStatusTableViewControllerSource (LineInfo[] lineInfoList)
		{
			_lineInfoList = lineInfoList;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return _lineInfoList.Length;
		}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return "Tube Status";
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (TubeStatusTableViewControllerCell.Key) as TubeStatusTableViewControllerCell;
			
			var lineInfo = _lineInfoList [indexPath.Row];

			var rgb = new RGB(){ R = 137, G = 38, B = 0};
			try 
			{
				rgb = TubeColourHelper.GetRGBColour(lineInfo.Id);	
			} 
			catch (ArgumentException ex) 
			{
				Console.WriteLine (ex.Message);
			}

			cell.TubeNameLabel.Text = lineInfo.Name;
			cell.TubeNameLabel.TextColor = UIColor.White;

			cell.StatusLabel.Text = lineInfo.StatusSeverityDescription;
			cell.StatusLabel.TextColor = UIColor.White;

			cell.BackgroundColor = new UIColor (red: rgb.R / 255.0f, green: rgb.G / 255.0f, blue: rgb.B / 255.0f, alpha: 1);


			return cell;
		}
	}
}


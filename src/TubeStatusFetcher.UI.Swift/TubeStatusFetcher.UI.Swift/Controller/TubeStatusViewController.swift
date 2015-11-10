//
//  TubeStatusViewController.swift
//  TubeStatusFetcher.UI.Swift
//
//  Created by VOLKAN PAKSOY on 07/11/2015.
//  Copyright © 2015 VOLKAN PAKSOY. All rights reserved.
//

import UIKit

class TubeStatusViewController: UITableViewController {

    var lineInfoList = [LineInfo]()
    var colourHelper = TubeColourHelper()
    
    override func viewWillAppear(animated: Bool) {
        super.viewWillAppear(animated)
        
        TFLClient.sharedInstance().getTubeStatus { lineStatus, error in
            
            if let lineStatus = lineStatus {
                self.lineInfoList = lineStatus
                dispatch_async(dispatch_get_main_queue()) {
                    self.tableView!.reloadData()
                }
            } else {
                print(error)
            }
        }
    }


    override func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return lineInfoList.count
    }
    
    override func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCellWithIdentifier("TubeInfoCell", forIndexPath: indexPath) as! TubeInfoTableViewCell
        let lineStatus = lineInfoList[indexPath.row]
        
        cell.backgroundColor = colourHelper.getTubeColor(lineStatus.Id)
        
        cell.lineName?.text = lineStatus.Name
        cell.lineName?.textColor = UIColor.whiteColor()
        
        cell.severityDescription?.text = lineStatus.StatusSeverityDescription
        cell.severityDescription?.textColor = UIColor.whiteColor()
        
        cell.reason?.text = lineStatus.Reason
        cell.reason?.textColor = UIColor.whiteColor()

        return cell
    }
    
    // Used to hide the status bar, otherwise the share and cancel buttons collide with the status bar
    override func prefersStatusBarHidden() -> Bool {
        return true
    }
}

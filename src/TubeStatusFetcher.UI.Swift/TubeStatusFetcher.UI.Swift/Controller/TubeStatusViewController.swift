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
    
    override func viewDidLoad() {
        super.viewDidLoad()
    
        
    }
    
    override func viewWillAppear(animated: Bool) {
        super.viewWillAppear(animated)
        
        
        /*
        let line = LineInfo(Id: "bakerloo", Name: "Bakerloo", LineColour: RGB(R: 137/255, G: 78/255, B: 36/255), StatusSeverity: 10, StatusSeverityDescription: "Good Service", Reason: "" )
        
        lineInfoList.append(line)
        */
        
        var t = TubeColourHelper()
        t.loadColourData()

        
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

       

        // tableView!.reloadData()
    }


    override func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return lineInfoList.count
    }
    
    override func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCellWithIdentifier("TubeInfoCell", forIndexPath: indexPath) as! TubeInfoTableViewCell
        let lineStatus = lineInfoList[indexPath.row]
        
        cell.backgroundColor = UIColor(
            red: CGFloat(lineStatus.LineColour.R),
            green: CGFloat(lineStatus.LineColour.G),
            blue: CGFloat(lineStatus.LineColour.B),
            alpha: CGFloat(1.0))

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

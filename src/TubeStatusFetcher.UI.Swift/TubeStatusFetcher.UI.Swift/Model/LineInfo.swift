//
//  LineInfo.swift
//  TubeStatusFetcher.UI.Swift
//
//  Created by VOLKAN PAKSOY on 07/11/2015.
//  Copyright © 2015 VOLKAN PAKSOY. All rights reserved.
//

import UIKit

struct LineInfo {

    var Id : String
    var Name : String
    var LineColour : RGB
    var StatusSeverity : Int
    var StatusSeverityDescription : String
    var Reason : String
    
    
    init(status: AnyObject) {

        Id = status["id"] as! String
        Name = status["name"] as! String
        StatusSeverity = status["lineStatuses"]!![0]!["statusSeverity"] as! Int
        StatusSeverityDescription = status["lineStatuses"]!![0]!["statusSeverityDescription"] as! String
        Reason = ""
        
        LineColour = RGB(R: 0, G: 0, B: 0)
        
        
    }
    
    
    static func lineStatusFromResults(results: [AnyObject]) -> [LineInfo] {
        var lineStatus = [LineInfo]()
        
        for result in results {
            
            lineStatus.append(LineInfo(status: result))
        }
        
        return lineStatus
    }
    
}

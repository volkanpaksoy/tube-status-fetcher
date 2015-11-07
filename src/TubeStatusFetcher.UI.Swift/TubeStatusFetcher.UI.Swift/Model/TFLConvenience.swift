//
//  TFLConvenience.swift
//  TubeStatusFetcher.UI.Swift
//
//  Created by VOLKAN PAKSOY on 07/11/2015.
//  Copyright © 2015 VOLKAN PAKSOY. All rights reserved.
//

import UIKit

extension TFLClient {

    func getTubeStatus(completionHandler: (result: [LineInfo]?, error: NSError?) -> Void) {
        
        // var parameters = [String : AnyObject]()
        // parameters["detail"] = true
        
        let parameters = ["detail" : "true"]
        
        let mutableMethod : String = Methods.TubeStatus
        
        taskForGETMethod(mutableMethod, parameters: parameters) { JSONResult, error in
            
            if let error = error {
                completionHandler(result: nil, error: error)
            } else {
                
                if let results = JSONResult as? [AnyObject] {
                    //print(results[0])
    
                    let lineStatus = LineInfo.lineStatusFromResults(results)
                    
                    completionHandler(result: lineStatus, error: nil)
                }
           }
        }
    }
}

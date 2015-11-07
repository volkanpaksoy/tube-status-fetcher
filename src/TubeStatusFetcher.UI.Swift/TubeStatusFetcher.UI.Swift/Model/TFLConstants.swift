//
//  TFLConstants.swift
//  TubeStatusFetcher.UI.Swift
//
//  Created by VOLKAN PAKSOY on 02/11/2015.
//  Copyright © 2015 VOLKAN PAKSOY. All rights reserved.
//

import UIKit

extension TFLClient {

    struct Constants {
        static let BaseURL : String = "https://api.tfl.gov.uk"
        // static let ApiEndPoint = "https://api.tfl.gov.uk/line/mode/tube/status?detail=true"
   
    }
    
    
    struct Methods {
        static let TubeStatus = "/line/mode/tube/status"
        
    }
    
    
    
}

//
//  TubeColourHelper.swift
//  TubeStatusFetcher.UI.Swift
//
//  Created by VOLKAN PAKSOY on 07/11/2015.
//  Copyright © 2015 VOLKAN PAKSOY. All rights reserved.
//

import UIKit

class TubeColourHelper: NSObject {

    func loadColourData() {
        
        if let filePath = NSBundle.mainBundle().pathForResource("Assets/colour.json", ofType: "json"), data = NSData(contentsOfFile: filePath) {
            print (filePath)
            
            do {
                let json = try NSJSONSerialization.JSONObjectWithData(data, options: NSJSONReadingOptions.AllowFragments)
                print(json)
            }
            catch {
                
            }
        }
        
        
    }
    
}

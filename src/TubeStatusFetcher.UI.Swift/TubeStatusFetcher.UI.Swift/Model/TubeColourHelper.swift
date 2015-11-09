//
//  TubeColourHelper.swift
//  TubeStatusFetcher.UI.Swift
//
//  Created by VOLKAN PAKSOY on 07/11/2015.
//  Copyright © 2015 VOLKAN PAKSOY. All rights reserved.
//

import UIKit

class TubeColourHelper: NSObject {

    var tubeColourDictionary : [String : AnyObject]
    
    
    override init() {
        tubeColourDictionary = [String : AnyObject]()
        
        let asset = NSDataAsset(name: "Colours", bundle: NSBundle.mainBundle())
        let json = try? NSJSONSerialization.JSONObjectWithData(asset!.data, options: NSJSONReadingOptions.AllowFragments)
        
        
        // print (json![0]!["id"] as! String)
        
        
        
        for colour in json! as! [AnyObject] {
            
            let tubeId = colour["id"] as! String
            print(tubeId)
            
            let rgb = colour["RGB"]!! as AnyObject
            
            /*
            var tubeColor = RGB(
                R: rgb["R"]!!.doubleValue,
                G: "0".doubleValue,
                B: "0".doubleValue)
            

            print (tubeColor)
            */

            //tubeColourDictionary.append()
            
            
        }
        

        
    }
    
    func loadColourData() {
        
       
        
        
        
    }
    
}

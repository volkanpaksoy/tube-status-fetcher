//
//  TubeColourHelper.swift
//  TubeStatusFetcher.UI.Swift
//
//  Created by VOLKAN PAKSOY on 07/11/2015.
//  Copyright © 2015 VOLKAN PAKSOY. All rights reserved.
//

import UIKit

class TubeColourHelper: NSObject {

    var tubeColourDictionary = [String : RGB]()
    
    override init() {
        
        let asset = NSDataAsset(name: "Colours", bundle: NSBundle.mainBundle())
        let json = try? NSJSONSerialization.JSONObjectWithData(asset!.data, options: NSJSONReadingOptions.AllowFragments)
        
        for colour in json! as! [AnyObject] {
            
            let tubeId = colour["id"] as! String
            let rgb = colour["RGB"]!! as AnyObject
            let tubeColor = RGB(
                R: rgb["R"]!!.doubleValue,
                G: rgb["G"]!!.doubleValue,
                B: rgb["B"]!!.doubleValue)
            
            tubeColourDictionary[tubeId] = tubeColor
        }
    }
    
    func getTubeColor(tubeId : String) -> UIColor {
        
        let rgb : RGB = tubeColourDictionary[tubeId]!
        
        return UIColor(red: CGFloat(rgb.R/255.0), green: CGFloat(rgb.G/255.0), blue: CGFloat(rgb.B/255.0), alpha: 1.0)
    }
    
}

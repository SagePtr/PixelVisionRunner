﻿//  
// Copyright (c) Jesse Freeman. All rights reserved.  
// 
// Licensed under the Microsoft Public License (MS-PL) License. 
// See LICENSE file in the project root for full license information. 
// 
// Contributors
// --------------------------------------------------------
// This is the official list of Pixel Vision 8 contributors:
//  
// Jesse Freeman - @JesseFreeman
// Christer Kaitila - @McFunkypants
// Pedro Medeiros - @saint11
// Shawn Rakowski - @shwany
// 

using System.Collections.Generic;

namespace PixelVisionSDK.Services
{
    public interface IService
    {
        void RegisterService(IServiceLocator locator);
        T GetInstance<T>() where T : IService;
        bool Execute(string command, Dictionary<string, object> data);
    }
}
﻿#pragma checksum "C:\Users\mctiernan\documents\visual studio 2012\Projects\InstrumentExplorer\InstrumentExplorer\MainPivotPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "185870474280DDD2999C82F9C5C4AE69"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace InstrumentExplorer {
    
    
    public partial class MainPivotPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock classification;
        
        internal System.Windows.Controls.Image imageImage;
        
        internal Microsoft.Phone.Controls.LongListSelector ResultsList;
        
        internal System.Windows.Controls.TextBlock noInternetWarning;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/InstrumentExplorer;component/MainPivotPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.classification = ((System.Windows.Controls.TextBlock)(this.FindName("classification")));
            this.imageImage = ((System.Windows.Controls.Image)(this.FindName("imageImage")));
            this.ResultsList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("ResultsList")));
            this.noInternetWarning = ((System.Windows.Controls.TextBlock)(this.FindName("noInternetWarning")));
        }
    }
}


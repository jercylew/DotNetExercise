﻿#pragma checksum "..\..\..\View\HeatMapView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6C4FB5FA4A56315B6B02AF835AB96E25CECD97FCC3B7CF01AD3C22C8DE8E6907"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HRIS_UI.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HRIS_UI.View {
    
    
    /// <summary>
    /// HeatMapView
    /// </summary>
    public partial class HeatMapView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\View\HeatMapView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox m_cmbCampus;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\HeatMapView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox m_cmbClassType;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\View\HeatMapView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox m_cmbColor;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HRIS-UI;component/view/heatmapview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\HeatMapView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.m_cmbCampus = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\View\HeatMapView.xaml"
            this.m_cmbCampus.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.m_cmbCampus_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.m_cmbClassType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 31 "..\..\..\View\HeatMapView.xaml"
            this.m_cmbClassType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.m_cmbClassType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.m_cmbColor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\View\HeatMapView.xaml"
            this.m_cmbColor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.m_cmbColor_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\UpdateWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D56E0E6147AEACD14D19911B6918FA0BCEC10BD3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WPF_Project;


namespace WPF_Project {
    
    
    /// <summary>
    /// UpdateWindow
    /// </summary>
    public partial class UpdateWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtCarName;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbModelNames;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtColour;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbColours;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtEngine;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbEngine;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtBodyType2;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBodyType2;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtBodyType4;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBodyType4;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF Project;component/updatewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UpdateWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtCarName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.cmbModelNames = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\UpdateWindow.xaml"
            this.cmbModelNames.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbModelNames_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtColour = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.cmbColours = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\..\UpdateWindow.xaml"
            this.cmbColours.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbColours_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtEngine = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.cmbEngine = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.txtBodyType2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.cmbBodyType2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.txtBodyType4 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.cmbBodyType4 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 92 "..\..\..\UpdateWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSelectCar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

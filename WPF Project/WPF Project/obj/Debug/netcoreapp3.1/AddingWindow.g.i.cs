﻿#pragma checksum "..\..\..\AddingWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39BC76C9882D9C2D53FA14A1EB3FB9AAFE16EEEE"
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
    /// AddingWindow
    /// </summary>
    public partial class AddingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\AddingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbModelNames;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\AddingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtColour;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\AddingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbEngine;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\AddingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBodyType;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF Project;V1.0.0.0;component/addingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddingWindow.xaml"
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
            this.cmbModelNames = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\AddingWindow.xaml"
            this.cmbModelNames.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbModelNames_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtColour = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cmbEngine = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cmbBodyType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            
            #line 66 "..\..\..\AddingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddCar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 71 "..\..\..\AddingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


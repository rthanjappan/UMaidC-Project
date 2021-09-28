﻿#pragma checksum "..\..\CustomerMainMenuWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74D7F935049A831E4CD599191EB7223F136A9716"
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
using UMaid_Window;


namespace UMaid_Window {
    
    
    /// <summary>
    /// CustomerMainMenuWindow
    /// </summary>
    public partial class CustomerMainMenuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\CustomerMainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spMain;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CustomerMainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\CustomerMainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spButtons;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\CustomerMainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnProfile;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\CustomerMainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnManageProperty;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\CustomerMainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnManageListing;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\CustomerMainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewActiveBids;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\CustomerMainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spInfo;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\CustomerMainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbUserType;
        
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
            System.Uri resourceLocater = new System.Uri("/UMaid_Window;component/customermainmenuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomerMainMenuWindow.xaml"
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
            this.spMain = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.btnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\CustomerMainMenuWindow.xaml"
            this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.BtnLogout_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.spButtons = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.btnProfile = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\CustomerMainMenuWindow.xaml"
            this.btnProfile.Click += new System.Windows.RoutedEventHandler(this.BtnCustomerProfileWindow_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnManageProperty = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\CustomerMainMenuWindow.xaml"
            this.btnManageProperty.Click += new System.Windows.RoutedEventHandler(this.BtnManagePropertyWindow_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnManageListing = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\CustomerMainMenuWindow.xaml"
            this.btnManageListing.Click += new System.Windows.RoutedEventHandler(this.BtnManageListingWindow_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnViewActiveBids = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\CustomerMainMenuWindow.xaml"
            this.btnViewActiveBids.Click += new System.Windows.RoutedEventHandler(this.BtnViewBidWindow_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.spInfo = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.tbUserType = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

﻿#pragma checksum "..\..\..\..\Functions\EditStudent.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "687F6A9CD3F9B505DC0E8E122E97EE0919E250D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectCSharp_SchoolGradingSystem;
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


namespace ProjectCSharp_SchoolGradingSystem {
    
    
    /// <summary>
    /// EditStudent
    /// </summary>
    public partial class EditStudent : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Functions\EditStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListboxStudents;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Functions\EditStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Functions\EditStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Functions\EditStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Functions\EditStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Functions\EditStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordVerifyBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Functions\EditStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock infoblock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectCSharp_SchoolGradingSystem;component/functions/editstudent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Functions\EditStudent.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ListboxStudents = ((System.Windows.Controls.ListBox)(target));
            
            #line 15 "..\..\..\..\Functions\EditStudent.xaml"
            this.ListboxStudents.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListboxStudent_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.SurnameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.EmailBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.PasswordVerifyBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            
            #line 26 "..\..\..\..\Functions\EditStudent.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.infoblock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 28 "..\..\..\..\Functions\EditStudent.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


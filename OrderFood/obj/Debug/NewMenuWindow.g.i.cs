﻿#pragma checksum "..\..\NewMenuWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "323F4D6ABF1CF52A6A2D3A408C0EF295D08EB574AC50DEFCDA4B1FFAC3FBFEA9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using OrderFood;
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


namespace OrderFood {
    
    
    /// <summary>
    /// NewMenuWindow
    /// </summary>
    public partial class NewMenuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 88 "..\..\NewMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\NewMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\NewMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\NewMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SortTextBox;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\NewMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\NewMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxOrder;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\NewMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridAllMenues;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\NewMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update;
        
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
            System.Uri resourceLocater = new System.Uri("/OrderFood;component/newmenuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewMenuWindow.xaml"
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
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\NewMenuWindow.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.AddNewProduct);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Edit = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\NewMenuWindow.xaml"
            this.Edit.Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Delete = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\NewMenuWindow.xaml"
            this.Delete.Click += new System.Windows.RoutedEventHandler(this.DeleteProduct);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SortTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 123 "..\..\NewMenuWindow.xaml"
            this.SortTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SortTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 135 "..\..\NewMenuWindow.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ListBoxOrder = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.DataGridAllMenues = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.Update = ((System.Windows.Controls.Button)(target));
            
            #line 172 "..\..\NewMenuWindow.xaml"
            this.Update.Click += new System.Windows.RoutedEventHandler(this.FillDataGrid);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

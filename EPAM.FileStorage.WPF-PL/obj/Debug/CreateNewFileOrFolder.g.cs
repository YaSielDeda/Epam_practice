﻿#pragma checksum "..\..\CreateNewFileOrFolder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "557E10E9D84F08ED776FA9B34D614424F5D234A65E632FC4474986A8A1DD3380"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using EPAM.FileStorage.WPF_PL;
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


namespace EPAM.FileStorage.WPF_PL {
    
    
    /// <summary>
    /// CreateNewFileOrFolder
    /// </summary>
    public partial class CreateNewFileOrFolder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\CreateNewFileOrFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxName;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\CreateNewFileOrFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelCreateButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\CreateNewFileOrFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton FileRadioButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CreateNewFileOrFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton FolderRadioButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\CreateNewFileOrFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmCreateButton;
        
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
            System.Uri resourceLocater = new System.Uri("/EPAM.FileStorage.WPF-PL;component/createnewfileorfolder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateNewFileOrFolder.xaml"
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
            this.TextBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.CancelCreateButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\CreateNewFileOrFolder.xaml"
            this.CancelCreateButton.Click += new System.Windows.RoutedEventHandler(this.CancelCreateButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FileRadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.FolderRadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.ConfirmCreateButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\CreateNewFileOrFolder.xaml"
            this.ConfirmCreateButton.Click += new System.Windows.RoutedEventHandler(this.ConfirmCreateButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\Forms\Windows\LoginWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E5184531A1838D320390188F0781B128638FFFDB51930DA76D11D1CB53B9C59B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using FixItYourselfHospital;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace FixItYourselfHospital {
    
    
    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FixItYourselfHospital.LoginWindow window_LoginWindow;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_LoginInterface;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_Login;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox textBox_Password;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Login;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_ForgotPassword;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_Label_ForgotPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/FixItYourselfHospital;component/forms/windows/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
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
            this.window_LoginWindow = ((FixItYourselfHospital.LoginWindow)(target));
            return;
            case 2:
            this.image_LoginInterface = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.textBox_Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBox_Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.button_Login = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
            this.button_Login.Click += new System.Windows.RoutedEventHandler(this.button_Login_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.label_ForgotPassword = ((System.Windows.Controls.Label)(target));
            
            #line 20 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
            this.label_ForgotPassword.MouseEnter += new System.Windows.Input.MouseEventHandler(this.label_ForgotPassword_MouseEnter);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
            this.label_ForgotPassword.MouseLeave += new System.Windows.Input.MouseEventHandler(this.label_ForgotPassword_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textBlock_Label_ForgotPassword = ((System.Windows.Controls.TextBlock)(target));
            
            #line 22 "..\..\..\..\Forms\Windows\LoginWindow.xaml"
            this.textBlock_Label_ForgotPassword.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBlock_Label_ForgotPassword_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


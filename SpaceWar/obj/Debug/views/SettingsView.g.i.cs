﻿#pragma checksum "..\..\..\views\SettingsView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "92FB6398513907BEECEE612A3AD210DA96BD7E22AD09E2A5CC9E814FC9C28777"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SpaceWar.views;
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


namespace SpaceWar.views {
    
    
    /// <summary>
    /// SettingsView
    /// </summary>
    public partial class SettingsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\views\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox playerName;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\views\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox sound;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\views\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox music;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\views\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox attack;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\views\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox move;
        
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
            System.Uri resourceLocater = new System.Uri("/SpaceWar;component/views/settingsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\views\SettingsView.xaml"
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
            this.playerName = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\views\SettingsView.xaml"
            this.playerName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.nameChange);
            
            #line default
            #line hidden
            return;
            case 2:
            this.sound = ((System.Windows.Controls.CheckBox)(target));
            
            #line 39 "..\..\..\views\SettingsView.xaml"
            this.sound.Checked += new System.Windows.RoutedEventHandler(this.SoundOn);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\views\SettingsView.xaml"
            this.sound.Unchecked += new System.Windows.RoutedEventHandler(this.SoundOff);
            
            #line default
            #line hidden
            return;
            case 3:
            this.music = ((System.Windows.Controls.CheckBox)(target));
            
            #line 43 "..\..\..\views\SettingsView.xaml"
            this.music.Checked += new System.Windows.RoutedEventHandler(this.MusicOn);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\views\SettingsView.xaml"
            this.music.Unchecked += new System.Windows.RoutedEventHandler(this.MusicOff);
            
            #line default
            #line hidden
            return;
            case 4:
            this.attack = ((System.Windows.Controls.CheckBox)(target));
            
            #line 57 "..\..\..\views\SettingsView.xaml"
            this.attack.Checked += new System.Windows.RoutedEventHandler(this.AttackWithMouse);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\views\SettingsView.xaml"
            this.attack.Unchecked += new System.Windows.RoutedEventHandler(this.AttackWithKeyboard);
            
            #line default
            #line hidden
            return;
            case 5:
            this.move = ((System.Windows.Controls.CheckBox)(target));
            
            #line 64 "..\..\..\views\SettingsView.xaml"
            this.move.Checked += new System.Windows.RoutedEventHandler(this.MoveWithMouse);
            
            #line default
            #line hidden
            
            #line 65 "..\..\..\views\SettingsView.xaml"
            this.move.Unchecked += new System.Windows.RoutedEventHandler(this.MoveWithKeyboard);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

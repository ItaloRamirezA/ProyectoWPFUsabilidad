﻿#pragma checksum "..\..\InformacionProducto.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1AF0208EF8B6531321BA6EA72BD9ED1AC12673CD831C30ACEC012A1C5221D7E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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


namespace ProyectoWPF {
    
    
    /// <summary>
    /// InformacionProducto
    /// </summary>
    public partial class InformacionProducto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\InformacionProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImagenProducto;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\InformacionProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NombreProducto;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\InformacionProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TamanoProducto;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\InformacionProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DescripcionProducto;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\InformacionProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PrecioProducto;
        
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
            System.Uri resourceLocater = new System.Uri("/ProyectoWPF;component/informacionproducto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InformacionProducto.xaml"
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
            
            #line 18 "..\..\InformacionProducto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AbrirVentanaHome);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 22 "..\..\InformacionProducto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AbrirVentanaHome);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 24 "..\..\InformacionProducto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AbrirVentanaNews);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 26 "..\..\InformacionProducto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AbrirVentanaError);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 28 "..\..\InformacionProducto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AbrirVentanaError);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 31 "..\..\InformacionProducto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CerrarSesion_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ImagenProducto = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.NombreProducto = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.TamanoProducto = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.DescripcionProducto = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.PrecioProducto = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            
            #line 42 "..\..\InformacionProducto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SalirButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


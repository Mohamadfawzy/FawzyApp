//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("FawzyApp.Views.NotepadPages.NotepadMainPage.xaml", "Views/NotepadPages/NotepadMainPage.xaml", typeof(global::FawzyApp.Views.NotepadPages.NotepadMainPage))]

namespace FawzyApp.Views.NotepadPages {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\NotepadPages\\NotepadMainPage.xaml")]
    public partial class NotepadMainPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label label;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::FawzyApp.Controllers.CustomEntry MyCustomEntry;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(NotepadMainPage));
            label = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "label");
            MyCustomEntry = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::FawzyApp.Controllers.CustomEntry>(this, "MyCustomEntry");
        }
    }
}

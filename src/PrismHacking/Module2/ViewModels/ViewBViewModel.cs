using Prism.Mvvm;
using System.ComponentModel.Composition;

namespace Module2.ViewModels
{
    [Export(typeof(ViewBViewModel))]
    public class ViewBViewModel : BindableBase
    {
        private string _moduleName = "Module 2 is the second module";
        public string ModuleName
        {
            get { return _moduleName; }
            set { SetProperty(ref _moduleName, value); }
        }
    }
}

using Prism.Mvvm;
using System.ComponentModel.Composition;

namespace Module2.ViewModels
{
    [Export(typeof(ViewBViewModel))]
    public class ViewBViewModel : BindableBase
    {
        private string _moduleName = "Module 2";
        public string ModuleName
        {
            get { return _moduleName; }
            set { SetProperty(ref _moduleName, value); }
        }
    }
}

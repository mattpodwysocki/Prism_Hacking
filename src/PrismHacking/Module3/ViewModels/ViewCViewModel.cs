using Prism.Mvvm;
using System.ComponentModel.Composition;

namespace Module3.ViewModels
{
    [Export(typeof(ViewCViewModel))]
    public class ViewCViewModel : BindableBase
    {
        private string _moduleName = "Module 3";
        public string ModuleName
        {
            get { return _moduleName; }
            set { SetProperty(ref _moduleName, value); }
        }
    }
}

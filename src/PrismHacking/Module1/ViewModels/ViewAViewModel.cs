using Prism.Mvvm;
using System.ComponentModel.Composition;

namespace Module1.ViewModels
{
    [Export(typeof(ViewAViewModel))]
    public class ViewAViewModel : BindableBase
    {
        private string _moduleName = "Module 1";

        public string ModuleName
        {
            get { return _moduleName; }
            set { SetProperty(ref _moduleName, value); }
        }
    }
}

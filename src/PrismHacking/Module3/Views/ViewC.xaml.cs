using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Module3.Views
{
    /// <summary>
    /// Interaction logic for ViewC
    /// </summary>
    [Export(typeof(ViewC))]
    public partial class ViewC : UserControl
    {
        public ViewC()
        {
            InitializeComponent();
        }
    }
}

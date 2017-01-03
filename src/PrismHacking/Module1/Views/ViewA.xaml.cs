using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Module1.Views
{
    /// <summary>
    /// Interaction logic for ViewA
    /// </summary>
    [Export(typeof(ViewA))]
    public partial class ViewA : UserControl
    {
        public ViewA()
        {
            InitializeComponent();
        }
    }
}

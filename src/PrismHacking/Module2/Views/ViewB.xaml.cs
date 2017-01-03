using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Module2.Views
{
    /// <summary>
    /// Interaction logic for ViewB
    /// </summary>
    [Export(typeof(ViewB))]
    public partial class ViewB : UserControl
    {
        public ViewB()
        {
            InitializeComponent();
        }
    }
}

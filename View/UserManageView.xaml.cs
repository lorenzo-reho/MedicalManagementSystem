using System.Windows.Controls;

namespace MedicalManagementSystem.View
{
    /// <summary>
    /// Logica di interazione per UserManageView.xaml
    /// </summary>
    public partial class UserManageView : UserControl
    {
        public UserManageView()
        {
            InitializeComponent();

            SearchToggleButton.Target = LateralPanel;

        }




    }
}

using System.Windows;

namespace MedicalManagementSystem.View
{
    /// <summary>
    /// Logica di interazione per HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();

            MenuToggleButton.Target = LateralPanel1;

        }
    }
}

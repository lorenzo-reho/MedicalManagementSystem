using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalManagementSystem.View
{
    /// <summary>
    /// Logica di interazione per CreateNewUserView.xaml
    /// </summary>
    public partial class CreateNewUserView : UserControl
    {
        public CreateNewUserView()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

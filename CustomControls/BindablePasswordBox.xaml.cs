using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalManagementSystem.CustomControls
{
    /// <summary>
    /// Logica di interazione per BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        // SecurePassword è un campo di BindablePassword
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox));

        // Abbiamo accesso diretto a questo campo dalla View sottoforma di proprietà
        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set {
                SetValue(PasswordProperty, value); 
            }
        }


        public BindablePasswordBox()
        {
            InitializeComponent();
            // aggiunta del metodo che deve essere eseguito quando la password cambia
            txtPassword.PasswordChanged += OnPasswordChanged;
        }

        // scatta al momento della modifica del valore
        public void OnPasswordChanged(object sender, RoutedEventArgs args)
        {
            // SecurePassword è la proprietà binded

            Password = txtPassword.SecurePassword;
        }
    }
}

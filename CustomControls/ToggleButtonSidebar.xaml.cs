using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logica di interazione per ToggleButtonSidebar.xaml
    /// </summary>
    public partial class ToggleButtonSidebar : UserControl
    {

        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(Grid), typeof(ToggleButtonSidebar), new UIPropertyMetadata(null));

        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(ImageSource), typeof(ToggleButtonSidebar), new UIPropertyMetadata(null));

        public Grid Target
        {
            get { return (Grid)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public ImageSource ImagePath
        {
            get { return (ImageSource)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public ToggleButtonSidebar()
        {
            InitializeComponent();
        }
    }
}

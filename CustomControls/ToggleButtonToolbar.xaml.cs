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
    /// Logica di interazione per ToggleButtonToolbar.xaml
    /// </summary>
    public partial class ToggleButtonToolbar : UserControl
    {

        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(ContentPresenter), typeof(ToggleButtonToolbar), new UIPropertyMetadata(null));

        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(ImageSource), typeof(ToggleButtonToolbar), new UIPropertyMetadata(null));

        public static readonly DependencyProperty IsCheckedButtonProperty=
            DependencyProperty.Register("IsCheckedButton", typeof(bool), typeof(ToggleButtonToolbar), new UIPropertyMetadata(null));

        public static readonly DependencyProperty IsEnabledButtonProperty =
            DependencyProperty.Register("IsEnabledButton", typeof(bool), typeof(ToggleButtonToolbar), new UIPropertyMetadata(null));

        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(ToggleButtonToolbar), new UIPropertyMetadata(null));

        public ContentPresenter Target
        {
            get { return (ContentPresenter)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public ImageSource ImagePath
        {
            get { return (ImageSource)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public bool IsEnabledButton
        {
            get { return (bool)GetValue(IsEnabledButtonProperty); }
            set { SetValue(IsEnabledButtonProperty, value); }
        }

        public bool IsCheckedButton
        {
            get { return (bool)GetValue(IsCheckedButtonProperty); }
            set { SetValue(IsCheckedButtonProperty, value); }
        }

        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public ToggleButtonToolbar()
        {
            InitializeComponent();

        }
    }
}

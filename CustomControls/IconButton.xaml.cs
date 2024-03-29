﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalManagementSystem.CustomControls
{
    /// <summary>
    /// Logica di interazione per IconButton.xaml
    /// </summary>
    public partial class IconButton : UserControl
    {

        public static readonly DependencyProperty TextButtonProperty =
            DependencyProperty.Register("TextButton", typeof(string), typeof(IconButton), new UIPropertyMetadata(null));

        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(ImageSource), typeof(IconButton), new UIPropertyMetadata(null));

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(IconButton), new UIPropertyMetadata(null));

        public string TextButton
        {
            get { return (string)GetValue(TextButtonProperty); }
            set { SetValue(TextButtonProperty, value); }
        }

        public ImageSource ImagePath
        {
            get { return (ImageSource)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public IconButton()
        {

            InitializeComponent();
        }
    }
}

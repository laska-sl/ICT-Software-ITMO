using System.Windows.Controls;
using System.Windows;
using System;

namespace WpfUserControl
{
    /// <summary>
    /// Interaction logic for ShowNumberControl.xaml
    /// </summary>
    public partial class ShowNumberControl : UserControl
    {
        private int currNumber = 0;

        public int CurrentNumber
        {
            get { return (int)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register(
                "CurrentNumber", 
                typeof(int), 
                typeof(ShowNumberControl),
                new UIPropertyMetadata(100, new PropertyChangedCallback(CurrentNumberChanged)),
                new ValidateValueCallback(ValidateCurrentNumber));

        public ShowNumberControl()
        {
            InitializeComponent();
        }

        public static bool ValidateCurrentNumber(object value)
        {
            if (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CurrentNumberChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ShowNumberControl s = (ShowNumberControl)depObj;
            Label theLabel = s.numberDisplay;
            theLabel.Content = args.NewValue.ToString();
        }
    }
}

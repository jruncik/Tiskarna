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

namespace TV.TiskarnaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddUser_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddUser_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("The New command was invoked");
        }
    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand AddUser = new RoutedUICommand
            (
                "AddUser",
                "AddUser",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F1, ModifierKeys.Alt)
                }
            );
    }

}

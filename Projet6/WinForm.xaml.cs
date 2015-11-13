using System;
using System.Windows;
namespace Projet6
{
    /// <summary>
    /// Logique d'interaction pour WinForm.xaml
    /// </summary>
    public partial class WinForm : Window
    {
        public WinForm()
        {
            InitializeComponent();
        }

        public WinForm(string msg)
        {
            InitializeComponent();
            this.label1.Content = msg;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
using System.Windows;

namespace Projet6
{
    /// <summary>
    /// Logique d'interaction pour AboutForm.xaml
    /// </summary>
    public partial class AboutForm : Window
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.everaldo.com");
        }

        private void linkLabel2_LinkClicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.freesound.org/usersViewSingle.php?id=4948");
        }

        private void linkLabel3_LinkClicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mattrich.deviantart.com/");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
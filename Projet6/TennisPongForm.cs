using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Projet6
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Pong PongGame { get; private set; }
        public Manette ManetteController { get; private set; }
        public Ai AiController { get; private set; }
        internal Canvas Canvas1 { get { return this.canvas1; } }
        internal MenuItem NouvellePartieMenuItem { get { return (MenuItem)((MenuItem)this.menu1.Items.GetItemAt(0)).Items.GetItemAt(0); } }
        internal MenuItem TerminerLaPartieMenuItem { get { return (MenuItem)((MenuItem)this.menu1.Items.GetItemAt(0)).Items.GetItemAt(1); } }
        internal MenuItem JoueursMenuItem { get { return (MenuItem)this.menu1.Items.GetItemAt(1); } }
        internal MenuItem ClavierMenuItem { get { return (MenuItem)((MenuItem)this.JoueursMenuItem.Items.GetItemAt(0)).Items.GetItemAt(0); } }
        internal MenuItem ClavierMenuItem1 { get { return (MenuItem)((MenuItem)this.JoueursMenuItem.Items.GetItemAt(1)).Items.GetItemAt(0); } }
        internal MenuItem SourisMenuItem { get { return (MenuItem)((MenuItem)this.JoueursMenuItem.Items.GetItemAt(0)).Items.GetItemAt(1); } }
        internal MenuItem SourisMenuItem1 { get { return (MenuItem)((MenuItem)this.JoueursMenuItem.Items.GetItemAt(1)).Items.GetItemAt(1); } }
        internal MenuItem ManetteMenuItem { get { return (MenuItem)((MenuItem)this.JoueursMenuItem.Items.GetItemAt(0)).Items.GetItemAt(2); } }
        internal MenuItem ManetteMenuItem1 { get { return (MenuItem)((MenuItem)this.JoueursMenuItem.Items.GetItemAt(1)).Items.GetItemAt(2); } }
        internal MenuItem IntelligenceArtificielleMenuItem { get { return (MenuItem)((MenuItem)this.JoueursMenuItem.Items.GetItemAt(0)).Items.GetItemAt(3); } }
        internal MenuItem IntelligenceArtificielleMenuItem1 { get { return (MenuItem)((MenuItem)this.JoueursMenuItem.Items.GetItemAt(1)).Items.GetItemAt(3); } }
        internal MenuItem DifficultéMenuItem { get { return (MenuItem)this.menu1.Items.GetItemAt(2); } }
        internal MenuItem FacileMenuItem { get { return (MenuItem)this.DifficultéMenuItem.Items.GetItemAt(0); } }
        internal MenuItem MoyenMenuItem { get { return (MenuItem)this.DifficultéMenuItem.Items.GetItemAt(1); } }
        internal MenuItem DifficileMenuItem { get { return (MenuItem)this.DifficultéMenuItem.Items.GetItemAt(2); } }
        internal MenuItem ScoreMenuItem { get { return (MenuItem)this.menu1.Items.GetItemAt(3); } }
        internal MenuItem OptionsMenuItem { get { return (MenuItem)this.menu1.Items.GetItemAt(4); } }
        internal MenuItem VibrationsManette1MenuItem { get { return (MenuItem)this.OptionsMenuItem.Items.GetItemAt(0); } }
        internal MenuItem VibrationsManette2MenuItem { get { return (MenuItem)this.OptionsMenuItem.Items.GetItemAt(1); } }
        internal MenuItem SonsMenuItem { get { return (MenuItem)this.OptionsMenuItem.Items.GetItemAt(3); } }

        public MainWindow()
        {
            InitializeComponent();
            this.PongGame = new Pong(this);
            this.ManetteController = new Manette(this);
            this.AiController = new Ai(this);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            this.PongGame.Terrain.Draw();
            this.PongGame.Filet.Draw();
            this.PongGame.Joueur1.Draw();
            this.PongGame.Joueur2.Draw();
            this.PongGame.Balle.Draw();
            this.PongGame.ScoreTexteJoueur1.Draw();
            this.PongGame.ScoreTexteJoueur2.Draw();
        }

        internal void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.SourisMenuItem.IsChecked)
            {
                if ((e.GetPosition(this.Canvas1).Y > 25) && (e.GetPosition(this.Canvas1).Y < this.Canvas1.Height - 25))
                {
                    this.PongGame.Joueur1.Centre = new Point(this.PongGame.Joueur1.Centre.X, e.GetPosition(this.Canvas1).Y);
                    if (this.PongGame.ServiceJoueur1)
                        this.PongGame.Balle.Centre = new Point(this.PongGame.Balle.Centre.X, e.GetPosition(this.Canvas1).Y);
                }
            }
            if (this.SourisMenuItem1.IsChecked)
            {
                if ((e.GetPosition(this.Canvas1).Y > 25) && (e.GetPosition(this.Canvas1).Y < this.Canvas1.Height - 25))
                {
                    this.PongGame.Joueur2.Centre = new Point(this.PongGame.Joueur2.Centre.X, e.GetPosition(this.Canvas1).Y);
                    if (this.PongGame.ServiceJoueur2)
                        this.PongGame.Balle.Centre = new Point(this.PongGame.Balle.Centre.X, e.GetPosition(this.Canvas1).Y);
                }
            }
            this.InvalidateVisual();
        }

        internal void canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (this.SourisMenuItem.IsChecked)
                {
                    if (this.PongGame.UpButtonPressedJoueur1 < 3)
                    {
                        this.PongGame.AngleJoueur1 -= 1;
                        this.PongGame.UpButtonPressedJoueur1++;
                    }
                }
                if (this.SourisMenuItem1.IsChecked)
                {
                    if (this.PongGame.UpButtonPressedJoueur2 < 3)
                    {
                        this.PongGame.AngleJoueur2 -= 1;
                        this.PongGame.UpButtonPressedJoueur2++;
                    }
                }
            }
            if (e.ChangedButton == MouseButton.Middle)
            {
                if (this.SourisMenuItem.IsChecked)
                {
                    if (this.PongGame.ServiceJoueur1)
                    {
                        this.PongGame.AngleBalle += this.PongGame.AngleJoueur1;
                        this.PongGame.ServiceJoueur1 = false;
                        this.PongGame.TimerBalle.Enabled = true;
                        this.PongGame.TimerBalle.Start();
                    }
                }
                if (this.SourisMenuItem1.IsChecked)
                {
                    if (this.PongGame.ServiceJoueur2)
                    {
                        this.PongGame.AngleBalle += this.PongGame.AngleJoueur2;
                        this.PongGame.ServiceJoueur2 = false;
                        this.PongGame.TimerBalle.Enabled = true;
                        this.PongGame.TimerBalle.Start();
                    }
                }
            }
            if (e.ChangedButton == MouseButton.Right)
            {
                if (this.SourisMenuItem.IsChecked)
                {
                    if (this.PongGame.DownButtonPressedJoueur1 < 3)
                    {
                        this.PongGame.AngleJoueur1 += 1;
                        this.PongGame.DownButtonPressedJoueur1++;
                    }
                }
                if (this.SourisMenuItem1.IsChecked)
                {
                    if (this.PongGame.DownButtonPressedJoueur2 < 3)
                    {
                        this.PongGame.AngleJoueur2 += 1;
                        this.PongGame.DownButtonPressedJoueur2++;
                    }
                }
            }
        }

        internal void canvas1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ClavierMenuItem.IsChecked)
            {
                switch (e.Key)
                {
                    case Key.Up:
                        e.Handled = true;
                        if (this.PongGame.Joueur1.Centre.Y > 25)
                        {
                            this.PongGame.Joueur1.Centre = new Point(this.PongGame.Joueur1.Centre.X, this.PongGame.Joueur1.Centre.Y - 25);
                            if (this.PongGame.ServiceJoueur1)
                                this.PongGame.Balle.Centre = new Point(this.PongGame.Balle.Centre.X, this.PongGame.Balle.Centre.Y - 25);
                            this.InvalidateVisual();
                        }
                        break;
                    case Key.Down:
                        e.Handled = true;
                        if (this.PongGame.Joueur1.Centre.Y < this.Canvas1.Height - 25)
                        {
                            this.PongGame.Joueur1.Centre = new Point(this.PongGame.Joueur1.Centre.X, this.PongGame.Joueur1.Centre.Y + 25);
                            if (this.PongGame.ServiceJoueur1)
                                this.PongGame.Balle.Centre = new Point(this.PongGame.Balle.Centre.X, this.PongGame.Balle.Centre.Y + 25);
                            this.InvalidateVisual();
                        }
                        break;
                    case Key.Space:
                        e.Handled = true;
                        if (this.PongGame.ServiceJoueur1)
                        {
                            this.PongGame.AngleBalle += this.PongGame.AngleJoueur1;
                            this.PongGame.ServiceJoueur1 = false;
                            this.PongGame.TimerBalle.Enabled = true;
                            this.PongGame.TimerBalle.Start();
                        }
                        break;
                    case Key.A:
                        e.Handled = true;
                        if (this.PongGame.UpButtonPressedJoueur1 < 3)
                        {
                            this.PongGame.AngleJoueur1 -= 1;
                            this.PongGame.UpButtonPressedJoueur1++;
                        }
                        break;
                    case Key.Q:
                        e.Handled = true;
                        if (this.PongGame.DownButtonPressedJoueur1 < 3)
                        {
                            this.PongGame.AngleJoueur1 += 1;
                            this.PongGame.DownButtonPressedJoueur1++;
                        }
                        break;
                }
            }
            if (this.ClavierMenuItem1.IsChecked)
            {
                switch (e.Key)
                {
                    case Key.Up:
                        e.Handled = true;
                        if (this.PongGame.Joueur2.Centre.Y > 25)
                        {
                            this.PongGame.Joueur2.Centre = new Point(this.PongGame.Joueur2.Centre.X, this.PongGame.Joueur2.Centre.Y - 25);
                            if (this.PongGame.ServiceJoueur2)
                                this.PongGame.Balle.Centre = new Point(this.PongGame.Balle.Centre.X, this.PongGame.Balle.Centre.Y - 25);
                            this.InvalidateVisual();
                        }
                        break;
                    case Key.Down:
                        e.Handled = true;
                        if (this.PongGame.Joueur2.Centre.Y < this.Canvas1.Height - 25)
                        {
                            this.PongGame.Joueur2.Centre = new Point(this.PongGame.Joueur2.Centre.X, this.PongGame.Joueur2.Centre.Y + 25);
                            if (this.PongGame.ServiceJoueur2)
                                this.PongGame.Balle.Centre = new Point(this.PongGame.Balle.Centre.X, this.PongGame.Balle.Centre.Y + 25);
                            this.InvalidateVisual();
                        }
                        break;
                    case Key.Space:
                        e.Handled = true;
                        if (this.PongGame.ServiceJoueur2)
                        {
                            this.PongGame.AngleBalle += this.PongGame.AngleJoueur2;
                            this.PongGame.ServiceJoueur2 = false;
                            this.PongGame.TimerBalle.Enabled = true;
                            this.PongGame.TimerBalle.Start();
                        }
                        break;
                    case Key.A:
                        e.Handled = true;
                        if (this.PongGame.UpButtonPressedJoueur2 < 3)
                        {
                            this.PongGame.AngleJoueur2 -= 1;
                            this.PongGame.UpButtonPressedJoueur2++;
                        }
                        break;
                    case Key.Q:
                        e.Handled = true;
                        if (this.PongGame.DownButtonPressedJoueur2 < 3)
                        {
                            this.PongGame.AngleJoueur2 += 1;
                            this.PongGame.DownButtonPressedJoueur2++;
                        }
                        break;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.ManetteController.ManetteController.IsAlive)
                this.ManetteController.ManetteController.Abort();
            if (this.ManetteController.Manette1Controller.IsAlive)
                this.ManetteController.Manette1Controller.Abort();
            if (this.ManetteController.Manette2Controller.IsAlive)
                this.ManetteController.Manette2Controller.Abort();
            if (this.AiController.Ai1Controller.IsAlive)
                this.AiController.Ai1Controller.Abort();
            if (this.AiController.Ai2Controller.IsAlive)
                this.AiController.Ai2Controller.Abort();
        }

        private void quitterMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clavierMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            this.ClavierMenuItem1.IsEnabled = false;
            if (this.ClavierMenuItem1.IsChecked)
                this.ClavierMenuItem1.IsChecked = false;
            if (this.SourisMenuItem.IsChecked)
                this.SourisMenuItem.IsChecked = false;
            if (this.ManetteMenuItem.IsChecked)
                this.ManetteMenuItem.IsChecked = false;
            if (this.IntelligenceArtificielleMenuItem.IsChecked)
                this.IntelligenceArtificielleMenuItem.IsChecked = false;
        }

        private void clavierMenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            this.ClavierMenuItem1.IsEnabled = true;
        }

        private void clavierMenuItem1_Checked(object sender, RoutedEventArgs e)
        {
            this.ClavierMenuItem.IsEnabled = false;
            if (this.ClavierMenuItem.IsChecked)
                this.ClavierMenuItem.IsChecked = false;
            if (this.SourisMenuItem1.IsChecked)
                this.SourisMenuItem1.IsChecked = false;
            if (this.ManetteMenuItem1.IsChecked)
                this.ManetteMenuItem1.IsChecked = false;
            if (this.IntelligenceArtificielleMenuItem1.IsChecked)
                this.IntelligenceArtificielleMenuItem1.IsChecked = false;
        }

        private void clavierMenuItem1_Unchecked(object sender, RoutedEventArgs e)
        {
            this.ClavierMenuItem.IsEnabled = true;
        }

        private void sourisMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            this.SourisMenuItem1.IsEnabled = false;
            if (this.SourisMenuItem1.IsChecked)
                this.SourisMenuItem1.IsChecked = false;
            if (this.ClavierMenuItem.IsChecked)
                this.ClavierMenuItem.IsChecked = false;
            if (this.ManetteMenuItem.IsChecked)
                this.ManetteMenuItem.IsChecked = false;
            if (this.IntelligenceArtificielleMenuItem.IsChecked)
                this.IntelligenceArtificielleMenuItem.IsChecked = false;
        }

        private void sourisMenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            this.SourisMenuItem1.IsEnabled = true;
        }

        private void sourisMenuItem1_Checked(object sender, RoutedEventArgs e)
        {
            this.SourisMenuItem.IsEnabled = false;
            if (this.SourisMenuItem.IsChecked)
                this.SourisMenuItem.IsChecked = false;
            if (this.ClavierMenuItem1.IsChecked)
                this.ClavierMenuItem1.IsChecked = false;
            if (this.ManetteMenuItem1.IsChecked)
                this.ManetteMenuItem1.IsChecked = false;
            if (this.IntelligenceArtificielleMenuItem1.IsChecked)
                this.IntelligenceArtificielleMenuItem1.IsChecked = false;
        }

        private void sourisMenuItem1_Unchecked(object sender, RoutedEventArgs e)
        {
            this.SourisMenuItem.IsEnabled = true;
        }

        private void manetteMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            this.VibrationsManette1MenuItem.IsEnabled = true;
            if (this.ClavierMenuItem.IsChecked)
                this.ClavierMenuItem.IsChecked = false;
            if (this.SourisMenuItem.IsChecked)
                this.SourisMenuItem.IsChecked = false;
            if (this.IntelligenceArtificielleMenuItem.IsChecked)
                this.IntelligenceArtificielleMenuItem.IsChecked = false;
        }

        private void manetteMenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            this.VibrationsManette1MenuItem.IsEnabled = false;
        }

        private void manetteMenuItem1_Checked(object sender, RoutedEventArgs e)
        {
            this.VibrationsManette2MenuItem.IsEnabled = true;
            if (this.ClavierMenuItem1.IsChecked)
                this.ClavierMenuItem1.IsChecked = false;
            if (this.SourisMenuItem1.IsChecked)
                this.SourisMenuItem1.IsChecked = false;
            if (this.IntelligenceArtificielleMenuItem1.IsChecked)
                this.IntelligenceArtificielleMenuItem1.IsChecked = false;
        }

        private void manetteMenuItem1_Unchecked(object sender, RoutedEventArgs e)
        {
            this.VibrationsManette2MenuItem.IsEnabled = false;
        }

        private void intelligenceArtificielleMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            this.DifficultéMenuItem.IsEnabled = true;
            if (this.ClavierMenuItem.IsChecked)
                this.ClavierMenuItem.IsChecked = false;
            if (this.SourisMenuItem.IsChecked)
                this.SourisMenuItem.IsChecked = false;
            if (this.ManetteMenuItem.IsChecked)
                this.ManetteMenuItem.IsChecked = false;
        }

        private void intelligenceArtificielleMenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!this.IntelligenceArtificielleMenuItem1.IsChecked)
                this.DifficultéMenuItem.IsEnabled = false;
        }

        private void intelligenceArtificielleMenuItem1_Checked(object sender, RoutedEventArgs e)
        {
            this.DifficultéMenuItem.IsEnabled = true;
            if (this.ClavierMenuItem1.IsChecked)
                this.ClavierMenuItem1.IsChecked = false;
            if (this.SourisMenuItem1.IsChecked)
                this.SourisMenuItem1.IsChecked = false;
            if (this.ManetteMenuItem1.IsChecked)
                this.ManetteMenuItem1.IsChecked = false;
        }

        private void intelligenceArtificielleMenuItem1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!this.IntelligenceArtificielleMenuItem.IsChecked)
                this.DifficultéMenuItem.IsEnabled = false;
        }

        private void facileMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            if (this.MoyenMenuItem.IsChecked)
                this.MoyenMenuItem.IsChecked = false;
            if (this.DifficileMenuItem.IsChecked)
                this.DifficileMenuItem.IsChecked = false;
            this.AiController.AiSkill = 150; // ms
        }

        private void moyenMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            if (this.FacileMenuItem.IsChecked)
                this.FacileMenuItem.IsChecked = false;
            if (this.DifficileMenuItem.IsChecked)
                this.DifficileMenuItem.IsChecked = false;
            this.AiController.AiSkill = 75; // ms
        }

        private void difficileMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            if (this.FacileMenuItem.IsChecked)
                this.FacileMenuItem.IsChecked = false;
            if (this.MoyenMenuItem.IsChecked)
                this.MoyenMenuItem.IsChecked = false;
            this.AiController.AiSkill = 38; // ms
        }

        private void nouvellePartieMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.NouvellePartieMenuItem.IsEnabled = false;
            this.TerminerLaPartieMenuItem.IsEnabled = true;
            this.JoueursMenuItem.IsEnabled = false;
            this.DifficultéMenuItem.IsEnabled = false;
            this.PongGame.Partie = true;
            if (new Random().Next() % 2 == 0)
            {
                this.PongGame.ServiceJoueur1 = true;
                this.PongGame.ServiceJoueur2 = false;
                this.PongGame.AllerBalle = true;
                this.PongGame.Balle.Centre = new Point(this.PongGame.Joueur1.Centre.X + 5, this.PongGame.Joueur1.Centre.Y + 20);
            }
            else
            {
                this.PongGame.ServiceJoueur1 = false;
                this.PongGame.ServiceJoueur2 = true;
                this.PongGame.AllerBalle = false;
                this.PongGame.Balle.Centre = new Point(this.PongGame.Joueur2.Centre.X - 10, this.PongGame.Joueur2.Centre.Y + 20);
            }
            this.InvalidateVisual();
            if (this.ManetteController.ManetteController.IsAlive)
                this.ManetteController.ManetteController.Abort();
            if (this.ClavierMenuItem.IsChecked || this.ClavierMenuItem1.IsChecked)
                this.KeyDown += new KeyEventHandler(this.canvas1_KeyDown);
            if (this.SourisMenuItem.IsChecked || this.SourisMenuItem1.IsChecked)
            {
                this.Canvas1.MouseDown += new MouseButtonEventHandler(this.canvas1_MouseDown);
                this.Canvas1.MouseMove += new MouseEventHandler(this.canvas1_MouseMove);
            }
            if (this.ManetteMenuItem.IsChecked)
            {
                this.ManetteController.Manette1Controller = new Thread(this.ManetteController.Manette1Thread);
                this.ManetteController.Manette1Controller.Start();
            }
            if (this.ManetteMenuItem1.IsChecked)
            {
                this.ManetteController.Manette2Controller = new Thread(this.ManetteController.Manette2Thread);
                this.ManetteController.Manette2Controller.Start();
            }
            if (this.IntelligenceArtificielleMenuItem.IsChecked)
            {
                this.AiController.Ai1Controller = new Thread(this.AiController.Ai1Thread);
                this.AiController.Ai1Controller.Start();
            }
            if (this.IntelligenceArtificielleMenuItem1.IsChecked)
            {
                this.AiController.Ai2Controller = new Thread(this.AiController.Ai2Thread);
                this.AiController.Ai2Controller.Start();
            }
        }

        private void terminerLaPartieMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.NouvellePartieMenuItem.IsEnabled = true;
            this.TerminerLaPartieMenuItem.IsEnabled = false;
            this.JoueursMenuItem.IsEnabled = true;
            this.DifficultéMenuItem.IsEnabled = true;
            this.PongGame.Partie = false;
            this.PongGame.TimerBalle.Stop();
            this.PongGame.TimerBalle.Close();
            this.PongGame.ScoreJoueur1 = new Score();
            this.PongGame.ScoreJoueur2 = new Score();
            this.PongGame.Jeu = new Jeu();
            this.PongGame.Set = new Set();
            this.PongGame.Match = new Match();
            this.PongGame.CreateEnvironment();
            if (!this.ManetteController.ManetteController.IsAlive)
            {
                this.ManetteController.ManetteController = new Thread(this.ManetteController.ManetteThread);
                this.ManetteController.ManetteController.Start();
            }
            if (this.ClavierMenuItem.IsChecked || this.ClavierMenuItem1.IsChecked)
                this.KeyDown -= new KeyEventHandler(this.canvas1_KeyDown);
            if (this.SourisMenuItem.IsChecked || this.SourisMenuItem1.IsChecked)
            {
                this.Canvas1.MouseDown -= new MouseButtonEventHandler(this.canvas1_MouseDown);
                this.Canvas1.MouseMove -= new MouseEventHandler(this.canvas1_MouseMove);
            }
            if (this.ManetteController.Manette1Controller.IsAlive)
                this.ManetteController.Manette1Controller.Abort();
            if (this.ManetteController.Manette2Controller.IsAlive)
                this.ManetteController.Manette2Controller.Abort();
            if (this.AiController.Ai1Controller.IsAlive)
                this.AiController.Ai1Controller.Abort();
            if (this.AiController.Ai2Controller.IsAlive)
                this.AiController.Ai2Controller.Abort();
        }

        private void testMenuItem_Click(object sender, RoutedEventArgs e)
        {
            new TestForm().Show();
        }

        private void vibrationsManette1MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            this.PongGame.VibrationsJoueur1 = true;
        }

        private void vibrationsManette1MenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            this.PongGame.VibrationsJoueur1 = false;
        }

        private void vibrationsManette2MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            this.PongGame.VibrationsJoueur2 = true;
        }

        private void vibrationsManette2MenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            this.PongGame.VibrationsJoueur2 = false;
        }

        private void sonsMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            this.PongGame.Sons = true;
        }

        private void sonsMenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            this.PongGame.Sons = false;
        }

        private void aProposDeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            new AboutForm().ShowDialog();
        }
    }
}
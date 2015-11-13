using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Projet6
{
    public class Texte : Figure
    {
        private static Action EmptyDelegate = delegate() { };
        private Canvas Parent { get; set; }
        private TextBlock MyTextBlock { get; set; }
        public string Texto { get; set; }
        public Typeface Police { get; set; }
        public SolidColorBrush Brush { get; set; }
        public double PoliceSize { get; set; }

        public Texte(Canvas parent)
            : this(parent, "Hello World !")
        {
        }

        public Texte(Canvas parent, string texte)
            : this(parent, texte, new Point(150, 150))
        {
        }

        public Texte(Canvas parent, string texte, Point centre)
            : this(parent, texte, centre, Brushes.Black)
        {
        }

        public Texte(Canvas parent, string texte, Point centre, Brush couleur)
            : this(parent, texte, centre, couleur, new Typeface("Arial"))
        {
        }

        public Texte(Canvas parent, string texte, Point centre, Brush couleur, Typeface police)
            : this(parent, texte, centre, couleur, police, 16)
        {
        }

        public Texte(Canvas parent, string texte, Point centre, Brush couleur, Typeface police, double policeSize)
            : this(parent, texte, centre, couleur, police, policeSize, new SolidColorBrush(Color.FromArgb(50, 255, 255, 255)))
        {
        }

        public Texte(Canvas parent, string texte, Point centre, Brush couleur, Typeface police, double policeSize, SolidColorBrush brush)
            : base(centre, couleur, new Point(0, 0), 1)
        {
            this.Parent = parent;
            this.Texto = texte;
            this.Police = police;
            this.PoliceSize = policeSize;
            this.Brush = brush;
            this.MyTextBlock = new TextBlock();
            this.MyTextBlock.Foreground = this.Brush;
            this.MyTextBlock.FontFamily = this.Police.FontFamily;
            this.MyTextBlock.FontSize = this.PoliceSize;
            this.Parent.Children.Add(this.MyTextBlock);
        }

        public override void Draw()
        {
            this.MyTextBlock.Text = this.Texto;
            Canvas.SetLeft(this.MyTextBlock, this.Centre.X);
            Canvas.SetTop(this.MyTextBlock, this.Centre.Y);
        }

        public void Refresh()
        {
            this.MyTextBlock.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
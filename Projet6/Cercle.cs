using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System;

namespace Projet6
{
    public class Cercle : Figure
    {
        private static Action EmptyDelegate = delegate() { };
        private Canvas Parent { get; set; }
        private Ellipse MyEllipse { get; set; }
        public int Rayon { get; set; }
        public Brush CouleurFond { get; set; }

        public Cercle(Canvas parent)
            : this(parent, 25, new Point(100, 100))
        {
        }

        public Cercle(Canvas parent, int rayon, Point centre)
            : this(parent, rayon, centre, Brushes.Black)
        {
        }

        public Cercle(Canvas parent, int rayon, Point centre, Brush couleur) :
            this(parent, rayon, centre, couleur, 1)
        {
        }

        public Cercle(Canvas parent, int rayon, Point centre, Brush couleur, float epaisseurTrait) :
            this(parent, rayon, centre, couleur, epaisseurTrait, Brushes.White)
        {
        }

        public Cercle(Canvas parent, int rayon, Point centre, Brush couleur, float epaisseurTrait, Brush couleurFond) :
            base(centre, couleur, new Point(0, 0), epaisseurTrait)
        {
            this.Parent = parent;
            this.Rayon = rayon;
            this.CouleurFond = couleurFond;
            this.MyEllipse = new Ellipse();
            this.MyEllipse.Width = 2 * this.Rayon;
            this.MyEllipse.Height = 2 * this.Rayon;
            this.MyEllipse.Fill = this.CouleurFond;
            this.MyEllipse.StrokeThickness = this.Epaisseur;
            this.MyEllipse.Stroke = this.Couleur;
            this.Parent.Children.Add(this.MyEllipse);
        }

        public override void Draw()
        {
            Canvas.SetLeft(this.MyEllipse, this.Centre.X);
            Canvas.SetTop(this.MyEllipse, this.Centre.Y);
        }

        public void Refresh()
        {
            this.MyEllipse.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
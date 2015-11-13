using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System;

namespace Projet6
{
    public class MonRectangle : Figure
    {
        private static Action EmptyDelegate = delegate() { };
        private Canvas Parent { get; set; }
        private Rectangle MyRectangle { get; set; }
        public int Longueur { get; set; }
        public int Largeur { get; set; }
        public Brush CouleurFond { get; set; }

        public MonRectangle(Canvas parent)
            : this(parent, 100, 50, new Point(100, 100))
        {
        }

        public MonRectangle(Canvas parent, int longueur, int largeur, Point centre) :
            this(parent, longueur, largeur, centre, Brushes.Black)
        {
        }

        public MonRectangle(Canvas parent, int longueur, int largeur, Point centre, Brush couleur) :
            this(parent, longueur, largeur, centre, couleur, new Point(0, 0))
        {
        }

        public MonRectangle(Canvas parent, int longueur, int largeur, Point centre, Brush couleur, Point position) :
            this(parent, longueur, largeur, centre, couleur, position, 1)
        {
        }

        public MonRectangle(Canvas parent, int longueur, int largeur, Point centre, Brush couleur, Point position, float epaisseur) :
            this(parent, longueur, largeur, centre, couleur, position, epaisseur, Brushes.Black)
        {
        }

        public MonRectangle(Canvas parent, int longueur, int largeur, Point centre, Brush couleur, Point position, float epaisseur, Brush couleurFond)
            : base(centre, couleur, position, epaisseur)
        {
            this.Parent = parent;
            this.Longueur = longueur;
            this.Largeur = largeur;
            this.CouleurFond = couleurFond;
            this.MyRectangle = new Rectangle();
            this.MyRectangle.Width = this.Longueur;
            this.MyRectangle.Height = this.Largeur;
            this.MyRectangle.Stroke = this.Couleur;
            this.MyRectangle.StrokeThickness = this.Epaisseur;
            this.MyRectangle.Fill = this.CouleurFond;
            this.Parent.Children.Add(this.MyRectangle);
        }

        public override void Draw()
        {
            Canvas.SetLeft(this.MyRectangle, this.Centre.X);
            Canvas.SetTop(this.MyRectangle, this.Centre.Y);
        }

        public void Refresh()
        {
            this.MyRectangle.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
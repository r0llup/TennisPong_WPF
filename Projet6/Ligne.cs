using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Projet6
{
    public class Ligne : Figure
    {
        private static Action EmptyDelegate = delegate() { };
        private Canvas Parent { get; set; }
        private Line MyLine { get; set; }
        public int Longueur { get; set; }

        public Ligne(Canvas parent)
            : this(parent, 100, new Point(100, 100))
        {
        }

        public Ligne(Canvas parent, int longueur, Point centre)
            : this(parent, longueur, centre, Brushes.Black)
        {
        }

        public Ligne(Canvas parent, int longueur, Point centre, Brush couleur) :
            this(parent, longueur, centre, couleur, new Point(0, 0))
        {
        }

        public Ligne(Canvas parent, int longueur, Point centre, Brush couleur, Point position) :
            this(parent, longueur, centre, couleur, position, 1)
        {
        }

        public Ligne(Canvas parent, int longueur, Point centre, Brush couleur, Point position, float epaisseur) :
            base(centre, couleur, position, epaisseur)
        {
            this.Parent = parent;
            this.Longueur = longueur;
            this.MyLine = new Line();
            this.MyLine.Stroke = this.Couleur;
            this.MyLine.StrokeThickness = this.Epaisseur;
            this.Parent.Children.Add(this.MyLine);
        }

        public override void Draw()
        {
            this.MyLine.X1 = this.Centre.X;
            this.MyLine.Y1 = this.Centre.Y;
            this.MyLine.X2 = this.Position.X;
            this.MyLine.Y2 = this.Position.Y;
        }

        public void Refresh()
        {
            this.MyLine.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
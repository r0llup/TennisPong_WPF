using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Projet6
{
    public abstract class Figure : IDrawable
    {
        public Point Centre { get; set; }
        public Brush Couleur { get; set; }
        public Point Position { get; set; }
        public float Epaisseur { get; set; }

        public Figure(Point centre, Brush couleur, Point position, float epaisseur)
        {
            this.Centre = centre;
            this.Couleur = couleur;
            this.Position = position;
            this.Epaisseur = epaisseur;
        }

        public abstract void Draw();
    }
}
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Projet6
{
    public interface IDrawable
    {
        void Draw();
        Point Centre { get; set; }
        Brush Couleur { get; set; }
        Point Position { get; set; }
        float Epaisseur { get; set; }
    }
}
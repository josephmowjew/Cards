using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
namespace Drawing
{
    class Square: IDraw,IColor
    {
        private int sideLength;
        private Rectangle rect = null;
        private int locX = 0, locY = 0;

        public Square(int sideLength)
        {
            this.sideLength = sideLength;
        }

        void IDraw.Draw(Canvas canvas)
        {
            if(this.rect != null)
            {
                canvas.Children.Remove(rect);
;            }
            else
            {
                this.rect = new Rectangle();
            }

            this.rect.Height = this.sideLength;
            this.rect.Width = this.sideLength;

            Canvas.SetTop(this.rect, this.locY);
            Canvas.SetLeft(this.rect, this.locX);

            canvas.Children.Add(this.rect);
        }

        void IColor.setColor(Color color)
        {
            if(this.rect != null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);

                this.rect.Fill = brush;
            }
        }

        void IDraw.SetLocation(int xCoord, int yCood)
        {
            this.locY = yCood;
            this.locX = xCoord;
        }
    }
}

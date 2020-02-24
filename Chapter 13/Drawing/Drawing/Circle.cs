using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace Drawing
{
    class Circle: IDraw, IColor
    {
        private int diameter = 0;
        private int locY = 0, locX = 0;
        private Ellipse circle = null;


        public Circle(int diameter)
        {
            //initializing the circle with a diametre
            this.diameter = diameter;
        }

        void IDraw.Draw(Canvas canvas)
        {
            //check if a circle has been displayed on the canvas
            if(this.circle != null)
            {
                //remove the previous circle from the canvas
                canvas.Children.Remove(this.circle);
            }
            else
            {
                //create a new circle object
                this.circle = new Ellipse();
            }

            this.circle.Height = this.diameter; 
            this.circle.Width = this.diameter;

            Canvas.SetTop(this.circle, this.locY);
            Canvas.SetLeft(this.circle, this.locX);

            canvas.Children.Add(this.circle);
        }

        void IColor.setColor(Color color)
        {
            if (this.circle != null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);

                this.circle.Fill = brush;
            }
        }

        void IDraw.SetLocation(int xCoord, int yCood)
        {
            this.locY = yCood;
            this.locX = xCoord;
        }
    }
}

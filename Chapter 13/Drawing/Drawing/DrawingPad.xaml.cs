using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Drawing
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DrawingPad : Page
    {

        public DrawingPad()
        {
            this.InitializeComponent();
        }


        private void drawingCanvas_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            //get the coordinates of the postion where the user right clicked on the canvas (drawingCanvas control) 

            Point mousePosition = e.GetPosition(this.drawingCanvas);

            //creating a new Circle object passing it a diametre

            Circle myCircle = new Circle(100);

            //check if the circle implements the IDraw interface to draw one

            if (myCircle is IDraw)
            {
                //box the cicle to the interface

                IDraw drawCircle = myCircle;

                //set the location to draw the circle using X and Y coordinates

                drawCircle.SetLocation((int)mousePosition.X, (int)mousePosition.Y);

                //draw the circle on the canvas 

                drawCircle.Draw(drawingCanvas);
            }

            //check if the circle drawn implements the color interface

            if (myCircle is IColor)
            {
                //if the circle implements the IColor inteface then box the circle to the interface

                IColor circleColor = myCircle;

                //set the color of the circle
                circleColor.setColor(Colors.Red);
            }

        }

        private void drawingCanvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //get the current position of the mouse
            Point mousePosition = e.GetPosition(this.drawingCanvas);

            //create a square at the current positon

            Square mySquare = new Square(100);

            //check if the squre implements IDraw interface

            if (mySquare is IDraw)
            {
                //box the square to the interface to call the interface methods

                IDraw drawSquare = mySquare;

                drawSquare.SetLocation((int)mousePosition.X, (int)mousePosition.Y);
                drawSquare.Draw(drawingCanvas);
            }

            //set the color of the square drawn

            if(mySquare is IColor)
            {
                IColor squareColor = mySquare;

                squareColor.setColor(Colors.BlueViolet);
            }
        }
    }
}

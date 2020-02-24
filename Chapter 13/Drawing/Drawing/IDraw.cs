﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Drawing
{
    interface IDraw
    {
        void SetLocation(int xCoord, int yCood);
        void Draw(Canvas canvas);
    }
}
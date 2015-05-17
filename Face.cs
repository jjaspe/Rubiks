﻿using Canvas_Window_Template.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RubikCubeUI
{

    public class Face : IDrawable
    {
        public Cubie[] Cubies;
        public Face()
        {
            Cubies = new Cubie[9];
        }

        public void colorFace(FaceNames faceName, Color color)
        {
            foreach (Cubie cubie in Cubies)
            {
                cubie.setFaceColor(faceName, color);
            }
        }

        public bool Visible
        {
            get { return true; }
            set { return; }
        }

        public void draw()
        {
            foreach (Cubie cubie in Cubies)
                cubie.draw();
        }

        public int getId()
        {
            return 0;
        }

        public double[] getPosition()
        {
            return new double[3];
        }

        public void setPosition(IPoint newPosition)
        {
            return;
        }

        public void Rotate(Axis axis,int degrees)
        {
            foreach (Cubie cubie in Cubies)
                cubie.Rotate(AxisBuilder.GetAxis()[(int)axis],degrees);
        }
    }
}

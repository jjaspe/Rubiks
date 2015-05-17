using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RubikCubeUI
{
    public enum Axis { X,Y,Z};
    public enum FacePosition { First,Second,Third};
    public enum RotationSteps { One, Two, Three};
    public static class Constants
    {
        public static int CubeSize = 40;
        public static int CubiesPerSide = 3;
        public static int StepsPerRotation = 6;
        public static int AxisLength = 300;

        public static Color FrontColor = Color.Yellow,
            RightColor = Color.Orange,
            BackColor = Color.Red,
            LeftColor = Color.Blue,
            TopColor = Color.White,
            BottomColor = Color.Green;

        public static double GetMiddle()
        {
            return CubeSize * CubiesPerSide / 2;
        }
    }
}

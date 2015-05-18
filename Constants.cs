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
        public const int CubeSize = 40;
        public const int CubiesPerSide = 3;
        public const int StepsPerRotation =4 ;
        public const int AxisLength = 300;
        public const int ScrambleMoves=5;

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

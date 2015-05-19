using Canvas_Window_Template.Basic_Drawing_Functions;
using Canvas_Window_Template.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RubikCubeUI
{
    public class AxisBuilder
    {
        public static List<lineObj> GetAxis()
        {
            double middle = Constants.GetMiddle();
            lineObj zAxis = new lineObj(new pointObj(middle, middle, -Constants.AxisLength/2), 
                new pointObj(middle, middle, Constants.AxisLength/2), 
                Cubie.getFloatColor(Color.Red));
            lineObj xAxis = new lineObj(new pointObj(-Constants.AxisLength / 2,middle,middle),
               new pointObj(Constants.AxisLength / 2,middle,middle),
               Cubie.getFloatColor(Color.Green));
            lineObj yAxis = new lineObj(new pointObj(middle,-Constants.AxisLength / 2, middle),
               new pointObj(middle,Constants.AxisLength / 2,middle),
               Cubie.getFloatColor(Color.Blue));
            return new List<lineObj>() { xAxis,zAxis ,yAxis};
        }
    }
}

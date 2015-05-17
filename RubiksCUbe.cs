using Canvas_Window_Template.Basic_Drawing_Functions;
using Canvas_Window_Template.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RubikCubeUI
{
    public enum FaceNames { Front,Right,Back,Left,Top,Bottom} ;

    public class RubiksCube:IDrawable
    {
        public Face FaceFront = new Face(),
            FaceRight = new Face(),
            FaceBack = new Face(),
            FaceLeft = new Face(),
            FaceTop = new Face(),
            FaceBottom = new Face(),
            FaceMiddleX = new Face(),
            FaceMiddleY = new Face(),
            FaceMiddleZ = new Face();

        public RubiksCube()
        {
            
        }
        public bool Visible
        {
            get { return true; }
            set { return; }
        }

        public void draw()
        {
            FaceFront.draw();
            FaceRight.draw();
            FaceBack.draw();
            FaceLeft.draw();
            FaceTop.draw();
            FaceBottom.draw();
        }

        public int getId()
        {
            throw new NotImplementedException();
        }

        public double[] getPosition()
        {
            throw new NotImplementedException();
        }

        public void setPosition(IPoint newPosition)
        {
            throw new NotImplementedException();
        }

        public Face GetShitFaced(FaceNames faceName)
        {
            switch (faceName)
            {
                case FaceNames.Front:
                    return FaceFront;
                case FaceNames.Right:
                    return FaceRight;
                case FaceNames.Back:
                    return FaceBack;
                case FaceNames.Left:
                    return FaceLeft;
                case FaceNames.Top:
                    return FaceTop;
                case FaceNames.Bottom:
                    return FaceBottom;
            }
            return new Face();
        }

        public void Rotate(Axis axis,FacePosition position,RotationSteps steps)
        {
            Face chosenFace=getFace(axis,position);
            chosenFace.Rotate(axis, (int)(steps+1) * 90);
        }

        private Face getFace(Axis axis, FacePosition position)
        {
            switch (axis)
            {
                case Axis.X:
                    switch (position)
                    {
                        case FacePosition.First:
                            return FaceLeft;
                        case FacePosition.Second:
                            return FaceMiddleX;
                        case FacePosition.Third:
                            return FaceRight;
                    }
                    break;
                case Axis.Y:
                    switch (position)
                    {
                        case FacePosition.First:
                            return FaceFront;
                        case FacePosition.Second:
                            return FaceMiddleY;
                        case FacePosition.Third:
                            return FaceBack;
                    }
                    break;
                case Axis.Z:
                    switch (position)
                    {
                        case FacePosition.First:
                            return FaceBottom;
                        case FacePosition.Second:
                            return FaceMiddleZ;
                        case FacePosition.Third:
                            return FaceTop;
                    }
                    break;
            }
            return new Face();
        }
    }

}

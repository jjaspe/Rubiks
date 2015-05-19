using Canvas_Window_Template.Basic_Drawing_Functions;
using Canvas_Window_Template.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RubikCubeUI
{
    public enum FaceNames { Front, Right, Back, Left, Top, Bottom, MiddleX, MiddleY, MiddleZ } ;

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
            Rotate(axis, position, (int)(steps + 1) * 90);
        }

        public void Rotate(Axis axis, FacePosition position, double degrees)
        {
            Face chosenFace = getFace(axis, position);
            List<Face> surroundingFaces = getSurroundingFaces(axis);
            List<List<Cubie>> SharedLists = getSharedLists(chosenFace, surroundingFaces);
            cycleCubies(surroundingFaces,SharedLists);
            chosenFace.Rotate(axis, degrees);
        }

        private void cycleCubies(List<Face> faces,List<List<Cubie>> SharedLists)
        {
            faces[0].Cubies.AddRange(SharedLists[SharedLists.Count - 1]);
            faces[0].Cubies.RemoveAll(n => SharedLists[0].Contains(n) == true);

            for(int i=1;i<SharedLists.Count;i++)
            {
                //Add previous,remove current
                faces[i].Cubies.AddRange(SharedLists[i-1]);
                faces[i].Cubies.RemoveAll(n=>SharedLists[i].Contains(n)==true);
            }
        }

        private List<List<Cubie>> getSharedLists(Face chosenFace, List<Face> surroundingFaces)
        {
            List<List<Cubie>> sharedLists = new List<List<Cubie>>();
            foreach(Face face in surroundingFaces)
            {
                sharedLists.Add(chosenFace.getShared(face));
            }
            return sharedLists;
        }

        private List<Face> getSurroundingFaces(Axis axis)
        {
            switch(axis)
            {
                case Axis.X:
                    return new List<Face> { FaceTop, FaceBack, FaceBottom, FaceFront };
                case Axis.Y:
                    return new List<Face> { FaceTop, FaceRight, FaceBottom, FaceLeft };
                case Axis.Z:
                    return new List<Face> { FaceFront, FaceRight, FaceBack, FaceLeft };
            }
            return null;
        }

        private FaceNames getFaceName(Axis axis, FacePosition position)
        {
            FaceNames[,] faces = new FaceNames[,]
            {
                {FaceNames.Left,FaceNames.MiddleX,FaceNames.Right},
                {FaceNames.Front,FaceNames.MiddleY,FaceNames.Back},
                {FaceNames.Bottom,FaceNames.MiddleZ,FaceNames.Top}
            };
            return faces[(int)axis,(int)position];
        }

        public void Rotate(FaceRotation rotation)
        {
            Rotate(rotation.Axis, rotation.FacePosition, rotation.Degrees);
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

        public Stack<FaceRotation> Scramble(int movements=Constants.ScrambleMoves)
        {
            Stack<FaceRotation> rotations = new Stack<FaceRotation>();
            Random r = new Random();
            Axis axis;
            FacePosition face;
            RotationSteps steps;
            for(int i=0;i<movements;i++)
            {
                axis = (Axis)r.Next(3);
                face = (FacePosition)r.Next(3);
                steps = (RotationSteps)r.Next(3);
                rotations.Push(new FaceRotation() { 
                    Axis = axis, 
                    FacePosition = face, 
                    Degrees = ((int)steps+1)*90 
                });
            }
            return rotations;
        }
    }

}

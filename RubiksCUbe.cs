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
        CoolRotator rotator = new CoolRotator();
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
            return 0;
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
            for (int i = 0; i < degrees / 90;i++ )
                reassignCubies(chosenFace, axis, position, degrees);
            chosenFace.Rotate(axis, degrees);
        }

        private void reassignCubies(Face chosenFace,Axis axis, FacePosition position, double degrees)
        {
            List<Face> surroundingFaces = getSurroundingFaces(axis);
            List<Face> surroundingMiddles = getSurroundingMiddles(axis);
            List<List<Cubie>> SharedLists = getSharedSideCubies(chosenFace, surroundingFaces);
            List<List<Cubie>> SharedMiddles = getSharedMiddleCubies(chosenFace, surroundingMiddles);
            cycleSideCubies(surroundingFaces, SharedLists);
            cycleMiddleCubies(surroundingMiddles, SharedMiddles);
        }

        private void cycleMiddleCubies(List<Face> faces, List<List<Cubie>> SharedMiddles)
        {            
            //Remove current, add previous. Needs to be done in this order
            //because otherwise you'd lose the cubie the previous surrounding face
            //and the current surrounding face share
            faces[0].Cubies.RemoveAll(n => SharedMiddles[0].Contains(n) == true);
            faces[0].Cubies.AddRange(SharedMiddles[SharedMiddles.Count - 1]);

            faces[1].Cubies.RemoveAll(n => SharedMiddles[SharedMiddles.Count - 1].Contains(n) == true);
            faces[1].Cubies.AddRange(SharedMiddles[0]);
        }

        private List<List<Cubie>> getSharedMiddleCubies(Face chosenFace, List<Face> surroundingMiddles)
        {
            List<List<Cubie>> sharedLists = new List<List<Cubie>>();
            foreach (Face face in surroundingMiddles)
            {
                sharedLists.Add(chosenFace.getShared(face));
            }
            return sharedLists;
        }

        private List<Face> getSurroundingMiddles(Axis axis)
        {
            switch (axis)
            {
                case Axis.X:
                    return new List<Face> { FaceMiddleY,FaceMiddleZ};
                case Axis.Y:
                    return new List<Face> { FaceMiddleX,FaceMiddleZ };
                case Axis.Z:
                    return new List<Face> { FaceMiddleX,FaceMiddleY };
            }
            return null;
        }

        private void cycleSideCubies(List<Face> faces,List<List<Cubie>> SharedLists)
        {
            faces[0].Cubies.RemoveAll(n => SharedLists[0].Contains(n) == true);
            faces[0].Cubies.AddRange(SharedLists[SharedLists.Count - 1]);
            
            for(int i=1;i<SharedLists.Count;i++)
            {
                //Remove current, add previous. Needs to be done in this order
                //because otherwise you'd lose the cubie the previous surrounding face
                //and the current surrounding face share
                faces[i].Cubies.RemoveAll(n => SharedLists[i].Contains(n) == true);
                faces[i].Cubies.AddRange(SharedLists[i-1]);
            }
        }

        private List<List<Cubie>> getSharedSideCubies(Face chosenFace, List<Face> surroundingFaces)
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
                    return new List<Face> { FaceTop, FaceFront, FaceBottom, FaceBack };
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
            //return debugScramble();//DEBUG
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

        //DEBUG
        public Stack<FaceRotation> debugScramble()
        {
            Stack<FaceRotation> rotations = new Stack<FaceRotation>();
            rotations.Push(new FaceRotation()
            { 
                Axis=Axis.Y, 
                FacePosition=FacePosition.Second, 
                Degrees = 90 
            });
            rotations.Push(new FaceRotation()
            {
                Axis = Axis.X,
                FacePosition = FacePosition.Second,
                Degrees = 90
            });
            //rotations.Push(new FaceRotation()
            //{
            //    Axis = Axis.Z,
            //    FacePosition = FacePosition.Third,
            //    Degrees = 90
            //});
            //rotations.Push(new FaceRotation()
            //{
            //    Axis = Axis.X,
            //    FacePosition = FacePosition.Second,
            //    Degrees = 180
            //});
            return rotations;
        }

        /// <summary>
        /// Rotates but doesn't reassign cubies since it is breaking up a bigger rotation
        /// and you dont want to reassign on every small rotations.
        /// </summary>
        /// <returns></returns>
        public bool CoolRotate()
        {
            FaceRotation rotation = rotator.GetNext();
            if (rotation == null)
                return false;
            Face chosenFace = getFace(rotation.Axis, rotation.FacePosition);            
            chosenFace.Rotate(rotation.Axis, rotation.Degrees);
            return true;
        }

        /// <summary>
        /// This method is called once per rotation, so this one reassingns cubies
        /// </summary>
        /// <param name="rotation"></param>
        internal void SetCoolRotation(FaceRotation rotation)
        {
            Face chosenFace = getFace(rotation.Axis, rotation.FacePosition);
            rotator.CreateRotations(rotation);
            for (int i = 0; i < rotation.Degrees / 90; i++)
                reassignCubies(chosenFace, rotation.Axis, rotation.FacePosition, rotation.Degrees);
        }
    }

}

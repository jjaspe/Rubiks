using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubikCubeUI
{
    /// <summary>
    /// Use this to make rotations take more steps instead of just jumping 90 degrees.
    /// Call CreateRotations, then call getNextRotation until it returns null.
    /// </summary>
    public class CoolRotator
    {
        Stack<FaceRotation> rotations = new Stack<FaceRotation>();

        public void CreateRotations(FaceRotation rotation)
        {
            for(int i=0;i<Constants.StepsPerRotation;i++)
            {
                rotations.Push(new FaceRotation()
                {
                    Axis = rotation.Axis,
                    FacePosition = rotation.FacePosition,
                    Degrees = rotation.Degrees / Constants.StepsPerRotation
                });
            }
        }

        public FaceRotation GetNext()
        {
            if (rotations.Count>0)
                return rotations.Pop();
            else
                return null;
        }
    }
}

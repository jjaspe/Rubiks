using Canvas_Window_Template.Basic_Drawing_Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RubikCubeUI
{

    public class CubeBuilder
    {
        public static RubiksCube BuildCube()
        {
            RubiksCube cube = new RubiksCube();

            Cubie[, ,] cubies = createCubies();
            giveCubiesToFaces(cubies, cube);

            cube.FaceFront.colorFace(FaceNames.Front, Constants.FrontColor);
            cube.FaceRight.colorFace(FaceNames.Right, Constants.RightColor);
            cube.FaceBack.colorFace(FaceNames.Back, Constants.BackColor);
            cube.FaceLeft.colorFace(FaceNames.Left, Constants.LeftColor);
            cube.FaceTop.colorFace(FaceNames.Top, Constants.TopColor);
            cube.FaceBottom.colorFace(FaceNames.Bottom, Constants.BottomColor);
            return cube;
        }

        /// <summary>
        /// cubies should use coordinates x,y,z
        /// </summary>
        /// <param name="cubies"></param>
        /// <param name="cube"></param>
        private static void giveCubiesToFaces(Cubie[, ,] cubies, RubiksCube cube)
        {
            List<Cubie> FrontCubies = new List<Cubie>(),
                RightCubies = new List<Cubie>(),
                BackCubies = new List<Cubie>(),
                LeftCubies = new List<Cubie>(),
                TopCubies = new List<Cubie>(),
                BottomCubies = new List<Cubie>(),
                MiddleXCubies = new List<Cubie>(),
                MiddleYCubies = new List<Cubie>(),
                MiddleZCubies = new List<Cubie>();

            int lowValue = 0, midValue=1,highValue = (Constants.CubiesPerSide - 1);

            for (int i = 0; i < Constants.CubiesPerSide; i++)
            {
                for (int j = 0; j < Constants.CubiesPerSide; j++)
                {
                    //Left face gets cubies with low x
                    LeftCubies.Add(cubies[lowValue, i, j]);
                    //Back face gets cubies with high Y
                    BackCubies.Add(cubies[i, highValue, j]);
                    //Right face gets cubies with high x
                    RightCubies.Add(cubies[highValue, i, j]);
                    //Front face gets cubies with low y
                    FrontCubies.Add(cubies[i, lowValue, j]);
                    //top face gets cubies with high z
                    TopCubies.Add(cubies[i, j, highValue]);
                    //botoom face gets cubies with low z
                    BottomCubies.Add(cubies[i, j, lowValue]);
                    //Middle X face gets cubies with middle x
                    MiddleXCubies.Add(cubies[midValue, i, j]);
                    //Middle Y face gets cubies with middle Y
                    MiddleYCubies.Add(cubies[i,midValue, j]);
                    //Middle Z face gets cubies with middle Z
                    MiddleZCubies.Add(cubies[i, j, midValue]);
                }
            }

            cube.FaceFront.Cubies = FrontCubies;
            cube.FaceRight.Cubies = RightCubies;
            cube.FaceBack.Cubies = BackCubies;
            cube.FaceLeft.Cubies = LeftCubies;
            cube.FaceTop.Cubies = TopCubies;
            cube.FaceBottom.Cubies = BottomCubies;
            cube.FaceMiddleX.Cubies = MiddleXCubies;
            cube.FaceMiddleY.Cubies = MiddleYCubies;
            cube.FaceMiddleZ.Cubies = MiddleZCubies;
        }

        public static Cubie[, ,] createCubies()
        {
            int x = 0, y = 0, z = 0;
            Cubie[, ,] cubies = new Cubie[Constants.CubiesPerSide, Constants.CubiesPerSide, Constants.CubiesPerSide];
            for (int i = 0; i < Constants.CubiesPerSide; i++)
            {
                y = 0;
                for (int j = 0; j < Constants.CubiesPerSide; j++)
                {
                    z = 0;
                    for (int k = 0; k < Constants.CubiesPerSide; k++)
                    {
                        cubies[i, j, k] = new Cubie()
                        {
                            MyOrigin = new pointObj(x, y, z),
                            CubeSize = Constants.CubeSize,
                            Color = Color.Black,
                            OutlineColor = Cubie.getFloatColor(Color.Black)
                        };
                        cubies[i, j, k].createCubeTiles();
                        z += Constants.CubeSize;
                    }
                    y += Constants.CubeSize;
                }
                x += Constants.CubeSize;
            }

            return cubies;
        }
    }
}

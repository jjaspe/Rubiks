using Canvas_Window_Template.Basic_Drawing_Functions;
using Canvas_Window_Template.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RubikCubeUI
{
    /// <summary>
    /// Tile order (Front, Right,Back,Left,Top,Down)
    /// </summary>
    public class Cubie : cubeObj
    {
        static int id = 0;
        int myID;

        public static Cubie getCubieByPosition(IPoint origin, Cubie[] cubies)
        {
            foreach (Cubie cubie in cubies)
            {
                if (cubie.MyOrigin.equals(origin))
                    return cubie;
            }
            return null;
        }

        public Color Color
        {
            set
            {
                base.Color = getFloatColor(value);
            }
        }

        public Cubie()
        {
            myID = id++;
            Color = Color.Black;
            TileFront = new tileObj();
            TileRight = new tileObj();
            TileBack = new tileObj();
            TileLeft = new tileObj();
            TileTop = new tileObj();
            TileBottom = new tileObj();
        }

        public void setTiles(tileObj[] tiles)
        {
            TileFront = tiles[0];
            TileRight = tiles[1];
            TileBack = tiles[2];
            TileLeft = tiles[3];
            TileTop = tiles[4];
            TileBottom = tiles[5];
        }

        public void setFaceColor(FaceNames faceName, float[] color)
        {
            tileObj tile = getCorrectFace(faceName);
            tile.setColor(color);
        }

        public void setFaceColor(FaceNames faceName, Color color)
        {
            tileObj tile = getCorrectFace(faceName);
            tile.setColor(getFloatColor(color));
        }

        public tileObj getCorrectFace(FaceNames faceName)
        {
            switch (faceName)
            {
                case FaceNames.Front:
                    return TileFront;
                case FaceNames.Right:
                    return TileRight;
                case FaceNames.Back:
                    return TileBack;
                case FaceNames.Left:
                    return TileLeft;
                case FaceNames.Top:
                    return TileTop;
                case FaceNames.Bottom:
                    return TileBottom;
            }
            return new tileObj();
        }

        public static float[] getFloatColor(Color color)
        {
            return new float[] { color.R / 255, (float)color.G / 255, (float)color.B / 255 };
        }
    }
}

using Canvas_Window_Template;
using Canvas_Window_Template.Basic_Drawing_Functions;
using Canvas_Window_Template.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RubikCubeUI
{
    public partial class CubikView : ReadyOpenGlTemplate
    {
        RubiksCube MyCube;
        public CubikView()
        {
            InitializeComponent();
        }

        private void setupCube()
        {
            MyCube = CubeBuilder.BuildCube();
            MyWorld.add(MyCube);
            List<lineObj> Axii = AxisBuilder.GetAxis();
            foreach(IDrawable axis in Axii)
                MyWorld.add(axis);
        }
        public void Start()
        {
            this.Show();
            setupCube();
            drawingLoop();
        }

        public new void drawingLoop()
        {
            Common myDrawer = new Common();
            MyView.setCameraView(simpleOpenGlView.VIEWS.FrontUp);
            Stack<FaceRotation> rotations = MyCube.Scramble();
            CoolRotator rotator = new CoolRotator();
            FaceRotation currentRotation;

            while (!MyView.isDisposed() && !this.IsDisposed)
            {
                MyView.setupScene();
                //DRAW SCENE HERE
                if (rotations.Count > 0)
                {
                    currentRotation = rotator.GetNext();
                    if (currentRotation != null)
                        MyCube.Rotate(currentRotation);
                    else
                        rotator.CreateRotations(rotations.Pop());
                }

                myDrawer.drawWorld(MyWorld);
                //END DRAW SCENE HERE
                MyView.flushScene();
                this.Refresh();
                Thread.Sleep(300);
                Application.DoEvents();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyCube.Rotate(Axis.X, FacePosition.First, RotationSteps.Two);
        }




    }
}

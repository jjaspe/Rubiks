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
        Stack<FaceRotation> rotations;
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
            MyView.setCameraView(simpleOpenGlView.VIEWS.Iso);
            rotations = MyCube.Scramble();
            bool hasNextRotation = false;

            while (!MyView.isDisposed() && !this.IsDisposed)
            {
                MyView.setupScene();
                //DRAW SCENE HERE
                if(!hasNextRotation)
                {
                    if(rotations.Count>0)
                    {
                        MyCube.SetCoolRotation(rotations.Pop());
                        hasNextRotation = MyCube.CoolRotate();
                    }
                }
                else
                    hasNextRotation=MyCube.CoolRotate();

                myDrawer.drawWorld(MyWorld);
                //END DRAW SCENE HERE
                MyView.flushScene();
                this.Refresh();
                Thread.Sleep(Constants.pauseTime);
                Application.DoEvents();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rotations = MyCube.Scramble(20);
        }
    }
}

namespace RubikCubeUI
{
    partial class CubikView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.bottomButton = new System.Windows.Forms.Button();
            this.topButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.frontButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // simpleOpenGlView1
            // 
            this.simpleOpenGlView1.EyeCustom = new double[] {
        -300D,
        0D,
        0D};
            this.simpleOpenGlView1.Size = new System.Drawing.Size(733, 497);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(771, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bottomButton
            // 
            this.bottomButton.Location = new System.Drawing.Point(776, 256);
            this.bottomButton.Name = "bottomButton";
            this.bottomButton.Size = new System.Drawing.Size(75, 23);
            this.bottomButton.TabIndex = 18;
            this.bottomButton.Text = "Bottom";
            this.bottomButton.UseVisualStyleBackColor = true;
            this.bottomButton.Click += new System.EventHandler(this.bottomButton_Click);
            // 
            // topButton
            // 
            this.topButton.Location = new System.Drawing.Point(776, 226);
            this.topButton.Name = "topButton";
            this.topButton.Size = new System.Drawing.Size(75, 23);
            this.topButton.TabIndex = 20;
            this.topButton.Text = "Top";
            this.topButton.UseVisualStyleBackColor = true;
            this.topButton.Click += new System.EventHandler(this.topButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(776, 168);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 21;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // frontButton
            // 
            this.frontButton.Location = new System.Drawing.Point(776, 109);
            this.frontButton.Name = "frontButton";
            this.frontButton.Size = new System.Drawing.Size(75, 23);
            this.frontButton.TabIndex = 22;
            this.frontButton.Text = "Front";
            this.frontButton.UseVisualStyleBackColor = true;
            this.frontButton.Click += new System.EventHandler(this.frontButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(776, 197);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(75, 23);
            this.leftButton.TabIndex = 23;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(776, 138);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(75, 22);
            this.rightButton.TabIndex = 24;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // CubikView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 735);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.frontButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.topButton);
            this.Controls.Add(this.bottomButton);
            this.Controls.Add(this.button1);
            this.Name = "CubikView";
            this.Text = "CubikView";
            this.Controls.SetChildIndex(this.simpleOpenGlView1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.bottomButton, 0);
            this.Controls.SetChildIndex(this.topButton, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.frontButton, 0);
            this.Controls.SetChildIndex(this.leftButton, 0);
            this.Controls.SetChildIndex(this.rightButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bottomButton;
        private System.Windows.Forms.Button topButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button frontButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
    }
}
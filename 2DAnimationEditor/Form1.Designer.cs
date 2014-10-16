namespace _2DAnimationEditor
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SceneView = new System.Windows.Forms.PictureBox();
            this.checkBoxVertex = new System.Windows.Forms.CheckBox();
            this.checkBoxEdge = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxMoveMode = new System.Windows.Forms.CheckBox();
            this.dataGridAnimation = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSetFramesCount = new System.Windows.Forms.Button();
            this.textBoxFramesCount = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxCurrentFrame = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSaveAnimation = new System.Windows.Forms.Button();
            this.buttonLoadAnimation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SceneView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnimation)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SceneView
            // 
            this.SceneView.Location = new System.Drawing.Point(12, 12);
            this.SceneView.Name = "SceneView";
            this.SceneView.Size = new System.Drawing.Size(727, 254);
            this.SceneView.TabIndex = 0;
            this.SceneView.TabStop = false;
            this.SceneView.Paint += new System.Windows.Forms.PaintEventHandler(this.SceneView_Paint);
            this.SceneView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SceneView_MouseDown);
            this.SceneView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SceneView_MouseMove);
            // 
            // checkBoxVertex
            // 
            this.checkBoxVertex.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxVertex.Location = new System.Drawing.Point(6, 19);
            this.checkBoxVertex.Name = "checkBoxVertex";
            this.checkBoxVertex.Size = new System.Drawing.Size(88, 34);
            this.checkBoxVertex.TabIndex = 3;
            this.checkBoxVertex.Text = "Vertex";
            this.checkBoxVertex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxVertex.UseVisualStyleBackColor = true;
            this.checkBoxVertex.CheckedChanged += new System.EventHandler(this.checkBoxVertex_CheckedChanged);
            // 
            // checkBoxEdge
            // 
            this.checkBoxEdge.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxEdge.Location = new System.Drawing.Point(6, 59);
            this.checkBoxEdge.Name = "checkBoxEdge";
            this.checkBoxEdge.Size = new System.Drawing.Size(88, 34);
            this.checkBoxEdge.TabIndex = 4;
            this.checkBoxEdge.Text = "Edge";
            this.checkBoxEdge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEdge.UseVisualStyleBackColor = true;
            this.checkBoxEdge.CheckedChanged += new System.EventHandler(this.checkBoxEdge_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxMoveMode);
            this.groupBox1.Controls.Add(this.checkBoxVertex);
            this.groupBox1.Controls.Add(this.checkBoxEdge);
            this.groupBox1.Location = new System.Drawing.Point(745, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // checkBoxMoveMode
            // 
            this.checkBoxMoveMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxMoveMode.BackgroundImage = global::_2DAnimationEditor.Properties.Resources.move;
            this.checkBoxMoveMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBoxMoveMode.Location = new System.Drawing.Point(101, 20);
            this.checkBoxMoveMode.Name = "checkBoxMoveMode";
            this.checkBoxMoveMode.Size = new System.Drawing.Size(34, 33);
            this.checkBoxMoveMode.TabIndex = 5;
            this.checkBoxMoveMode.UseVisualStyleBackColor = true;
            this.checkBoxMoveMode.CheckedChanged += new System.EventHandler(this.checkBoxMoveMode_CheckedChanged);
            // 
            // dataGridAnimation
            // 
            this.dataGridAnimation.AllowUserToAddRows = false;
            this.dataGridAnimation.AllowUserToDeleteRows = false;
            this.dataGridAnimation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridAnimation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridAnimation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAnimation.ColumnHeadersVisible = false;
            this.dataGridAnimation.Location = new System.Drawing.Point(12, 278);
            this.dataGridAnimation.Name = "dataGridAnimation";
            this.dataGridAnimation.ReadOnly = true;
            this.dataGridAnimation.RowHeadersVisible = false;
            this.dataGridAnimation.Size = new System.Drawing.Size(727, 45);
            this.dataGridAnimation.TabIndex = 6;
            this.dataGridAnimation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAnimation_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSetFramesCount);
            this.groupBox2.Controls.Add(this.textBoxFramesCount);
            this.groupBox2.Location = new System.Drawing.Point(745, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 57);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Frames count";
            // 
            // buttonSetFramesCount
            // 
            this.buttonSetFramesCount.Location = new System.Drawing.Point(95, 20);
            this.buttonSetFramesCount.Name = "buttonSetFramesCount";
            this.buttonSetFramesCount.Size = new System.Drawing.Size(34, 25);
            this.buttonSetFramesCount.TabIndex = 1;
            this.buttonSetFramesCount.Text = "OK";
            this.buttonSetFramesCount.UseVisualStyleBackColor = true;
            this.buttonSetFramesCount.Click += new System.EventHandler(this.buttonSetFramesCount_Click);
            // 
            // textBoxFramesCount
            // 
            this.textBoxFramesCount.Location = new System.Drawing.Point(7, 20);
            this.textBoxFramesCount.Multiline = true;
            this.textBoxFramesCount.Name = "textBoxFramesCount";
            this.textBoxFramesCount.Size = new System.Drawing.Size(81, 25);
            this.textBoxFramesCount.TabIndex = 0;
            this.textBoxFramesCount.Text = "5";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxCurrentFrame);
            this.groupBox3.Location = new System.Drawing.Point(745, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(142, 57);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Frame";
            // 
            // textBoxCurrentFrame
            // 
            this.textBoxCurrentFrame.Location = new System.Drawing.Point(7, 20);
            this.textBoxCurrentFrame.Multiline = true;
            this.textBoxCurrentFrame.Name = "textBoxCurrentFrame";
            this.textBoxCurrentFrame.Size = new System.Drawing.Size(81, 25);
            this.textBoxCurrentFrame.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonLoadAnimation);
            this.groupBox4.Controls.Add(this.buttonSaveAnimation);
            this.groupBox4.Location = new System.Drawing.Point(746, 119);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(141, 84);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Animation";
            // 
            // buttonSaveAnimation
            // 
            this.buttonSaveAnimation.Location = new System.Drawing.Point(7, 20);
            this.buttonSaveAnimation.Name = "buttonSaveAnimation";
            this.buttonSaveAnimation.Size = new System.Drawing.Size(127, 24);
            this.buttonSaveAnimation.TabIndex = 0;
            this.buttonSaveAnimation.Text = "Save";
            this.buttonSaveAnimation.UseVisualStyleBackColor = true;
            this.buttonSaveAnimation.Click += new System.EventHandler(this.buttonSaveAnimation_Click);
            // 
            // buttonLoadAnimation
            // 
            this.buttonLoadAnimation.Location = new System.Drawing.Point(7, 50);
            this.buttonLoadAnimation.Name = "buttonLoadAnimation";
            this.buttonLoadAnimation.Size = new System.Drawing.Size(127, 24);
            this.buttonLoadAnimation.TabIndex = 1;
            this.buttonLoadAnimation.Text = "Load";
            this.buttonLoadAnimation.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 335);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridAnimation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SceneView);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "2D Animation Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.SceneView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnimation)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SceneView;
        private System.Windows.Forms.CheckBox checkBoxVertex;
        private System.Windows.Forms.CheckBox checkBoxEdge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxMoveMode;
        private System.Windows.Forms.DataGridView dataGridAnimation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSetFramesCount;
        private System.Windows.Forms.TextBox textBoxFramesCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxCurrentFrame;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonLoadAnimation;
        private System.Windows.Forms.Button buttonSaveAnimation;
    }
}


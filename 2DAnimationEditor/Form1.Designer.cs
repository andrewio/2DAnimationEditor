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
            ((System.ComponentModel.ISupportInitialize)(this.SceneView)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.SceneView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SceneView_MouseUp);
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 296);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SceneView);
            this.Name = "Form1";
            this.Text = "2D Animation Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SceneView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SceneView;
        private System.Windows.Forms.CheckBox checkBoxVertex;
        private System.Windows.Forms.CheckBox checkBoxEdge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxMoveMode;
    }
}


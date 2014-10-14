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
            ((System.ComponentModel.ISupportInitialize)(this.SceneView)).BeginInit();
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
            this.checkBoxVertex.Location = new System.Drawing.Point(745, 12);
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
            this.checkBoxEdge.Location = new System.Drawing.Point(745, 52);
            this.checkBoxEdge.Name = "checkBoxEdge";
            this.checkBoxEdge.Size = new System.Drawing.Size(88, 34);
            this.checkBoxEdge.TabIndex = 4;
            this.checkBoxEdge.Text = "Edge";
            this.checkBoxEdge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEdge.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 296);
            this.Controls.Add(this.checkBoxEdge);
            this.Controls.Add(this.checkBoxVertex);
            this.Controls.Add(this.SceneView);
            this.Name = "Form1";
            this.Text = "2D Animation Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SceneView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SceneView;
        private System.Windows.Forms.CheckBox checkBoxVertex;
        private System.Windows.Forms.CheckBox checkBoxEdge;
    }
}


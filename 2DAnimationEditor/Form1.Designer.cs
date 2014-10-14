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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 296);
            this.Controls.Add(this.SceneView);
            this.Name = "Form1";
            this.Text = "2D Animation Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SceneView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SceneView;
    }
}


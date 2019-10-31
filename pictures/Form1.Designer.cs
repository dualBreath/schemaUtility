namespace pictures
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileSchema = new System.Windows.Forms.OpenFileDialog();
            this.openFileReal = new System.Windows.Forms.OpenFileDialog();
            this.schemaImage = new System.Windows.Forms.PictureBox();
            this.realImage = new System.Windows.Forms.PictureBox();
            this.buttonSelectShema = new System.Windows.Forms.Button();
            this.buttonSelectReal = new System.Windows.Forms.Button();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.schemaImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realImage)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileSchema
            // 
            this.openFileSchema.FileName = "Select an image file";
            this.openFileSchema.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            // 
            // openFileReal
            // 
            this.openFileReal.FileName = "Select an image file";
            this.openFileReal.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            // 
            // schemaImage
            // 
            this.schemaImage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.schemaImage.Location = new System.Drawing.Point(12, 12);
            this.schemaImage.Name = "schemaImage";
            this.schemaImage.Size = new System.Drawing.Size(380, 407);
            this.schemaImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.schemaImage.TabIndex = 0;
            this.schemaImage.TabStop = false;
            // 
            // realImage
            // 
            this.realImage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.realImage.Location = new System.Drawing.Point(408, 12);
            this.realImage.Name = "realImage";
            this.realImage.Size = new System.Drawing.Size(380, 407);
            this.realImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.realImage.TabIndex = 1;
            this.realImage.TabStop = false;
            // 
            // buttonSelectShema
            // 
            this.buttonSelectShema.Location = new System.Drawing.Point(12, 425);
            this.buttonSelectShema.Name = "buttonSelectShema";
            this.buttonSelectShema.Size = new System.Drawing.Size(380, 49);
            this.buttonSelectShema.TabIndex = 2;
            this.buttonSelectShema.Text = "Выберите схему платы";
            this.buttonSelectShema.UseVisualStyleBackColor = true;
            this.buttonSelectShema.Click += new System.EventHandler(this.buttonSelectShema_Click);
            // 
            // buttonSelectReal
            // 
            this.buttonSelectReal.Location = new System.Drawing.Point(408, 425);
            this.buttonSelectReal.Name = "buttonSelectReal";
            this.buttonSelectReal.Size = new System.Drawing.Size(380, 49);
            this.buttonSelectReal.TabIndex = 3;
            this.buttonSelectReal.Text = "Выберите изображение платы";
            this.buttonSelectReal.UseVisualStyleBackColor = true;
            this.buttonSelectReal.Click += new System.EventHandler(this.buttonSelectReal_Click);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(178, 501);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(63, 20);
            this.textBoxWidth.TabIndex = 4;
            this.textBoxWidth.Tag = "";
            this.textBoxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxWidth_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите ширину изображения:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Введите высоту изображения:";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(510, 501);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(63, 20);
            this.textBoxHeight.TabIndex = 6;
            this.textBoxHeight.Tag = "";
            this.textBoxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHeight_KeyPress);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(713, 498);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 8;
            this.buttonNext.Text = "Готово";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.buttonSelectReal);
            this.Controls.Add(this.buttonSelectShema);
            this.Controls.Add(this.realImage);
            this.Controls.Add(this.schemaImage);
            this.Name = "Form1";
            this.Text = "Сличитель 2000";
            ((System.ComponentModel.ISupportInitialize)(this.schemaImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileSchema;
        private System.Windows.Forms.OpenFileDialog openFileReal;
        private System.Windows.Forms.PictureBox schemaImage;
        private System.Windows.Forms.PictureBox realImage;
        private System.Windows.Forms.Button buttonSelectShema;
        private System.Windows.Forms.Button buttonSelectReal;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Button buttonNext;
    }
}


namespace docpdf
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
            this.LogintextBox = new System.Windows.Forms.TextBox();
            this.PastextBox = new System.Windows.Forms.TextBox();
            this.Loginbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogintextBox
            // 
            this.LogintextBox.Location = new System.Drawing.Point(88, 112);
            this.LogintextBox.Multiline = true;
            this.LogintextBox.Name = "LogintextBox";
            this.LogintextBox.Size = new System.Drawing.Size(236, 39);
            this.LogintextBox.TabIndex = 0;
            this.LogintextBox.TextChanged += new System.EventHandler(this.LogintextBox_TextChanged);
            // 
            // PastextBox
            // 
            this.PastextBox.Location = new System.Drawing.Point(88, 181);
            this.PastextBox.Multiline = true;
            this.PastextBox.Name = "PastextBox";
            this.PastextBox.PasswordChar = '*';
            this.PastextBox.Size = new System.Drawing.Size(236, 39);
            this.PastextBox.TabIndex = 1;
            this.PastextBox.TextChanged += new System.EventHandler(this.PastextBox_TextChanged);
            // 
            // Loginbutton
            // 
            this.Loginbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Loginbutton.Location = new System.Drawing.Point(138, 246);
            this.Loginbutton.Name = "Loginbutton";
            this.Loginbutton.Size = new System.Drawing.Size(138, 47);
            this.Loginbutton.TabIndex = 2;
            this.Loginbutton.Text = "Вход";
            this.Loginbutton.UseVisualStyleBackColor = false;
            this.Loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(106, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Войдите в систему";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пароль";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 346);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Loginbutton);
            this.Controls.Add(this.PastextBox);
            this.Controls.Add(this.LogintextBox);
            this.Name = "Form1";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogintextBox;
        private System.Windows.Forms.TextBox PastextBox;
        private System.Windows.Forms.Button Loginbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


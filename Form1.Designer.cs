namespace Калькулятор_СЛАУ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton1.Location = new System.Drawing.Point(112, 49);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(118, 30);
            this.materialRadioButton1.TabIndex = 2;
            this.materialRadioButton1.Text = "Метод Гаусса";
            this.materialRadioButton1.UseVisualStyleBackColor = false;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 56);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(623, 30);
            this.materialTabSelector1.TabIndex = 3;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 92);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(624, 308);
            this.materialTabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.materialRadioButton2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.materialFlatButton1);
            this.tabPage1.Controls.Add(this.materialRadioButton1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 290);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Главное окно";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(-4, -11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 417);
            this.panel1.TabIndex = 6;
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton2.Location = new System.Drawing.Point(112, 79);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(183, 30);
            this.materialRadioButton2.TabIndex = 5;
            this.materialRadioButton2.Text = "Метод Жордана-Гаусса";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(109, 0);
            this.label1.MaximumSize = new System.Drawing.Size(400, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберите один из предложенных методов решения для начала работы:";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Location = new System.Drawing.Point(311, 177);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(74, 36);
            this.materialFlatButton1.TabIndex = 3;
            this.materialFlatButton1.Text = "Перейти";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.materialLabel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Теоретическая справка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(8, 8);
            this.materialLabel3.MaximumSize = new System.Drawing.Size(595, 800);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(108, 19);
            this.materialLabel3.TabIndex = 0;
            this.materialLabel3.Text = "materialLabel3";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.materialLabel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(616, 282);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "О программе";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(8, 8);
            this.materialLabel1.MaximumSize = new System.Drawing.Size(605, 800);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(108, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "materialLabel1";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.materialLabel4);
            this.tabPage4.Controls.Add(this.materialLabel2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(616, 290);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Об авторах";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(240, 256);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(115, 19);
            this.materialLabel4.TabIndex = 5;
            this.materialLabel4.Text = "Кострома 2020";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(24, 88);
            this.materialLabel2.MaximumSize = new System.Drawing.Size(600, 50);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(571, 38);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Данная программа разработана студентами ОГБПОУ \"Костромской политехнический колле" +
    "дж\" гр. 2-2П9 Павловой Элиной и Летуновым Сергеем";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(623, 407);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Решение квадратных СЛАУ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
    }
}


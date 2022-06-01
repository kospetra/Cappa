
namespace AnimalHotelSystem.Application
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(25, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj novu rezervaciju";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.newReservation_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(25, 71);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Pogledaj sve rezervacije";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.allReservation_clicked);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(383, 146);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "Otvori popis hrana";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.allFoods_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(383, 113);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 29);
            this.button4.TabIndex = 4;
            this.button4.Text = "Dodaj novu hranu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.addNewFood_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(398, 180);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 29);
            this.button5.TabIndex = 5;
            this.button5.Text = "Dodaj novu igračku";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.addNewToy_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button6.AutoSize = true;
            this.button6.Location = new System.Drawing.Point(378, 216);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 29);
            this.button6.TabIndex = 6;
            this.button6.Text = "Pogledaj popis igračaka";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.listOfAllToys_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button8.AutoSize = true;
            this.button8.Location = new System.Drawing.Point(398, 251);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(110, 29);
            this.button8.TabIndex = 8;
            this.button8.Text = "Dodaj novu sobu";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.newRoom_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Cappa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
    }
}
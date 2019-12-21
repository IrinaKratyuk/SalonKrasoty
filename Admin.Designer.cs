namespace Salon
{
    partial class Admin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.заказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.мастераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьМастераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подтверждениеЗапросовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закупкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button5 = new System.Windows.Forms.Button();
            this.продлитьНа30ДнейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заказыToolStripMenuItem,
            this.мастераToolStripMenuItem,
            this.материалыToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.продлитьНа30ДнейToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(493, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // заказыToolStripMenuItem
            // 
            this.заказыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.просмотрToolStripMenuItem2});
            this.заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            this.заказыToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.заказыToolStripMenuItem.Text = "Заказы";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // просмотрToolStripMenuItem2
            // 
            this.просмотрToolStripMenuItem2.Name = "просмотрToolStripMenuItem2";
            this.просмотрToolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
            this.просмотрToolStripMenuItem2.Text = "Просмотр";
            this.просмотрToolStripMenuItem2.Click += new System.EventHandler(this.просмотрToolStripMenuItem2_Click);
            // 
            // мастераToolStripMenuItem
            // 
            this.мастераToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрToolStripMenuItem,
            this.добавитьМастераToolStripMenuItem,
            this.подтверждениеЗапросовToolStripMenuItem});
            this.мастераToolStripMenuItem.Name = "мастераToolStripMenuItem";
            this.мастераToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.мастераToolStripMenuItem.Text = "Мастера";
            // 
            // просмотрToolStripMenuItem
            // 
            this.просмотрToolStripMenuItem.Name = "просмотрToolStripMenuItem";
            this.просмотрToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.просмотрToolStripMenuItem.Text = "Просмотр";
            this.просмотрToolStripMenuItem.Click += new System.EventHandler(this.просмотрToolStripMenuItem_Click);
            // 
            // добавитьМастераToolStripMenuItem
            // 
            this.добавитьМастераToolStripMenuItem.Name = "добавитьМастераToolStripMenuItem";
            this.добавитьМастераToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.добавитьМастераToolStripMenuItem.Text = "Добавить мастера";
            this.добавитьМастераToolStripMenuItem.Click += new System.EventHandler(this.добавитьМастераToolStripMenuItem_Click);
            // 
            // подтверждениеЗапросовToolStripMenuItem
            // 
            this.подтверждениеЗапросовToolStripMenuItem.Name = "подтверждениеЗапросовToolStripMenuItem";
            this.подтверждениеЗапросовToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.подтверждениеЗапросовToolStripMenuItem.Text = "Подтверждение запросов";
            this.подтверждениеЗапросовToolStripMenuItem.Click += new System.EventHandler(this.подтверждениеЗапросовToolStripMenuItem_Click);
            // 
            // материалыToolStripMenuItem
            // 
            this.материалыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списаниеToolStripMenuItem,
            this.закупкаToolStripMenuItem,
            this.просмотрToolStripMenuItem1});
            this.материалыToolStripMenuItem.Name = "материалыToolStripMenuItem";
            this.материалыToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.материалыToolStripMenuItem.Text = "Материалы";
            // 
            // списаниеToolStripMenuItem
            // 
            this.списаниеToolStripMenuItem.Name = "списаниеToolStripMenuItem";
            this.списаниеToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.списаниеToolStripMenuItem.Text = "Списание ";
            this.списаниеToolStripMenuItem.Click += new System.EventHandler(this.списаниеToolStripMenuItem_Click);
            // 
            // закупкаToolStripMenuItem
            // 
            this.закупкаToolStripMenuItem.Name = "закупкаToolStripMenuItem";
            this.закупкаToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.закупкаToolStripMenuItem.Text = "Закупка";
            this.закупкаToolStripMenuItem.Click += new System.EventHandler(this.закупкаToolStripMenuItem_Click);
            // 
            // просмотрToolStripMenuItem1
            // 
            this.просмотрToolStripMenuItem1.Name = "просмотрToolStripMenuItem1";
            this.просмотрToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.просмотрToolStripMenuItem1.Text = "Просмотр";
            this.просмотрToolStripMenuItem1.Click += new System.EventHandler(this.просмотрToolStripMenuItem1_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заказыToolStripMenuItem1});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // заказыToolStripMenuItem1
            // 
            this.заказыToolStripMenuItem1.Name = "заказыToolStripMenuItem1";
            this.заказыToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.заказыToolStripMenuItem1.Text = "Заказы за период";
            this.заказыToolStripMenuItem1.Click += new System.EventHandler(this.заказыToolStripMenuItem1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(493, 248);
            this.dataGridView1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(283, 281);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 28);
            this.button3.TabIndex = 4;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(393, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(341, 281);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 28);
            this.button4.TabIndex = 5;
            this.button4.Text = "Печать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(147, 281);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 28);
            this.button5.TabIndex = 6;
            this.button5.Text = "Подтвердить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // продлитьНа30ДнейToolStripMenuItem
            // 
            this.продлитьНа30ДнейToolStripMenuItem.Name = "продлитьНа30ДнейToolStripMenuItem";
            this.продлитьНа30ДнейToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.продлитьНа30ДнейToolStripMenuItem.Text = "Продлить на 30 дней";
            this.продлитьНа30ДнейToolStripMenuItem.Click += new System.EventHandler(this.продлитьНа30ДнейToolStripMenuItem_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 321);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Admin";
            this.Text = "Admin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мастераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьМастераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подтверждениеЗапросовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem материалыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закупкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem1;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem продлитьНа30ДнейToolStripMenuItem;
    }
}
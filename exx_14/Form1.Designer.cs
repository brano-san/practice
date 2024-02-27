namespace exx_14
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.on_off_btn = new System.Windows.Forms.Button();
            this.settings_btn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.interval = new System.Windows.Forms.NumericUpDown();
            this.size = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // on_off_btn
            // 
            this.on_off_btn.Location = new System.Drawing.Point(659, 12);
            this.on_off_btn.Name = "on_off_btn";
            this.on_off_btn.Size = new System.Drawing.Size(75, 23);
            this.on_off_btn.TabIndex = 0;
            this.on_off_btn.Text = "Вкл/Выкл";
            this.on_off_btn.UseVisualStyleBackColor = true;
            this.on_off_btn.Click += new System.EventHandler(this.on_off_btn_Click);
            // 
            // settings_btn
            // 
            this.settings_btn.Location = new System.Drawing.Point(740, 12);
            this.settings_btn.Name = "settings_btn";
            this.settings_btn.Size = new System.Drawing.Size(132, 23);
            this.settings_btn.TabIndex = 1;
            this.settings_btn.Text = "Настройки";
            this.settings_btn.UseVisualStyleBackColor = true;
            this.settings_btn.Click += new System.EventHandler(this.settings_btn_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Enabled = false;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(605, 38);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(267, 12);
            this.label.TabIndex = 2;
            this.label.Text = "Чтобы изменения вступили в силу нужно перезапустить игру";
            this.label.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(620, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Интервал времени (мс)";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(620, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Размер поля N";
            this.label1.Visible = false;
            // 
            // interval
            // 
            this.interval.Enabled = false;
            this.interval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.interval.Location = new System.Drawing.Point(752, 110);
            this.interval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.interval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.interval.Name = "interval";
            this.interval.Size = new System.Drawing.Size(120, 20);
            this.interval.TabIndex = 5;
            this.interval.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.interval.Visible = false;
            // 
            // size
            // 
            this.size.Enabled = false;
            this.size.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.size.Location = new System.Drawing.Point(752, 67);
            this.size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(120, 20);
            this.size.TabIndex = 6;
            this.size.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.size.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 530);
            this.Controls.Add(this.size);
            this.Controls.Add(this.interval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.settings_btn);
            this.Controls.Add(this.on_off_btn);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Game My Life";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button on_off_btn;
        private System.Windows.Forms.Button settings_btn;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown interval;
        private System.Windows.Forms.NumericUpDown size;
    }
}


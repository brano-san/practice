namespace exx_16
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
            this.count = new System.Windows.Forms.NumericUpDown();
            this.length = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.settings_btn = new System.Windows.Forms.Button();
            this.on_off_btn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.settings = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.length)).BeginInit();
            this.settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // count
            // 
            this.count.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.count.Location = new System.Drawing.Point(161, 33);
            this.count.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.count.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(120, 20);
            this.count.TabIndex = 13;
            this.count.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // length
            // 
            this.length.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.length.Location = new System.Drawing.Point(161, 59);
            this.length.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.length.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(120, 20);
            this.length.TabIndex = 12;
            this.length.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Количество точек";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Максимальная длина линии";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(6, 14);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(267, 12);
            this.label.TabIndex = 9;
            this.label.Text = "Чтобы изменения вступили в силу нужно перезапустить игру";
            // 
            // settings_btn
            // 
            this.settings_btn.Location = new System.Drawing.Point(656, 12);
            this.settings_btn.Name = "settings_btn";
            this.settings_btn.Size = new System.Drawing.Size(132, 23);
            this.settings_btn.TabIndex = 8;
            this.settings_btn.Text = "Настройки";
            this.settings_btn.UseVisualStyleBackColor = true;
            this.settings_btn.Click += new System.EventHandler(this.settings_btn_Click);
            // 
            // on_off_btn
            // 
            this.on_off_btn.Location = new System.Drawing.Point(575, 12);
            this.on_off_btn.Name = "on_off_btn";
            this.on_off_btn.Size = new System.Drawing.Size(75, 23);
            this.on_off_btn.TabIndex = 7;
            this.on_off_btn.Text = "Вкл/Выкл";
            this.on_off_btn.UseVisualStyleBackColor = true;
            this.on_off_btn.Click += new System.EventHandler(this.on_off_btn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // settings
            // 
            this.settings.Controls.Add(this.label);
            this.settings.Controls.Add(this.count);
            this.settings.Controls.Add(this.label2);
            this.settings.Controls.Add(this.length);
            this.settings.Controls.Add(this.label1);
            this.settings.Location = new System.Drawing.Point(510, 41);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(288, 86);
            this.settings.TabIndex = 14;
            this.settings.TabStop = false;
            this.settings.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 777);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.settings_btn);
            this.Controls.Add(this.on_off_btn);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dots";
            ((System.ComponentModel.ISupportInitialize)(this.count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.length)).EndInit();
            this.settings.ResumeLayout(false);
            this.settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown count;
        private System.Windows.Forms.NumericUpDown length;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button settings_btn;
        private System.Windows.Forms.Button on_off_btn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox settings;
    }
}


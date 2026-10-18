namespace project2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            checkBox1 = new CheckBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox5 = new TextBox();
            labelResult = new Label();
            listViewPlan = new ListView();
            colNum = new ColumnHeader();
            colStep = new ColumnHeader();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(203, 9);
            label1.Name = "label1";
            label1.Size = new Size(368, 37);
            label1.TabIndex = 0;
            label1.Text = "Менеджер Обновлений ";
            label1.Click += label1_Click;

            // label2
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 99);
            label2.Name = "label2";
            label2.Size = new Size(132, 21);
            label2.TabIndex = 1;
            label2.Text = "Текущая  версия ";
            label2.Click += label2_Click;

            // textBox1
            textBox1.Location = new Point(3, 139);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;

            // textBox2
            textBox2.Location = new Point(3, 246);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(199, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;

            // textBox3
            textBox3.Location = new Point(532, 246);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(199, 23);
            textBox3.TabIndex = 8;

            // label4
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(560, 211);
            label4.Name = "label4";
            label4.Size = new Size(156, 21);
            label4.TabIndex = 7;
            label4.Text = "Окно обслуживания";
            label4.Click += label4_Click;

            // textBox4
            textBox4.Location = new Point(532, 139);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(199, 23);
            textBox4.TabIndex = 6;

            // label5
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(560, 99);
            label5.Name = "label5";
            label5.Size = new Size(158, 21);
            label5.TabIndex = 5;
            label5.Text = "Размер Базы данных";
            label5.Click += label5_Click;

            // label6
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(5, 298);
            label6.Name = "label6";
            label6.Size = new Size(159, 21);
            label6.TabIndex = 10;
            label6.Text = "Количество модулей";
            label6.Click += label6_Click;

            // checkBox1
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(560, 335);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(82, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Миграция";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            // label3
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(3, 211);
            label3.Name = "label3";
            label3.Size = new Size(107, 21);
            label3.TabIndex = 12;
            label3.Text = "Новая версия";

            // button1 — Очистить
            button1.Location = new Point(5, 415);
            button1.Name = "button1";
            button1.Size = new Size(98, 46);
            button1.TabIndex = 13;
            button1.Text = "Очистить ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // button2 — Рассчитать
            button2.Location = new Point(633, 415);
            button2.Name = "button2";
            button2.Size = new Size(98, 46);
            button2.TabIndex = 14;
            button2.Text = "Расчитать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            // textBox5
            textBox5.Location = new Point(3, 335);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(199, 23);
            textBox5.TabIndex = 15;

            // labelResult — НОВЫЙ: вывод результата
            labelResult.BorderStyle = BorderStyle.FixedSingle;
            labelResult.Font = new Font("Consolas", 9F);
            labelResult.Location = new Point(203, 298);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(348, 99);
            labelResult.TabIndex = 16;
            labelResult.Text = "Результат появится здесь.";

            // listViewPlan — НОВЫЙ: план этапов
            listViewPlan.Columns.AddRange(new ColumnHeader[] { colNum, colStep });
            listViewPlan.FullRowSelect = true;
            listViewPlan.GridLines = true;
            listViewPlan.Location = new Point(203, 415);
            listViewPlan.Name = "listViewPlan";
            listViewPlan.Size = new Size(348, 150);
            listViewPlan.TabIndex = 17;
            listViewPlan.UseCompatibleStateImageBehavior = false;
            listViewPlan.View = View.Details;

            colNum.Text = "№";
            colNum.Width = 40;
            colStep.Text = "Этап";
            colStep.Width = 290;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 590);
            Controls.Add(listViewPlan);
            Controls.Add(labelResult);
            Controls.Add(textBox5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Менеджер обновлений";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private Label label6;
        private CheckBox checkBox1;
        private Label label3;
        private Button button1;
        private Button button2;
        private TextBox textBox5;
        private Label labelResult;      // НОВЫЙ
        private ListView listViewPlan;  // НОВЫЙ
        private ColumnHeader colNum;
        private ColumnHeader colStep;
    }
}
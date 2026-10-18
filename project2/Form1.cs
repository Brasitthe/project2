using System;
using System.Windows.Forms;

namespace project2
{
    public partial class Form1 : Form
    {
        // <<< поле объявляется здесь, в начале класса, а не внутри метода
        private readonly UpdateManager _manager = new UpdateManager();

        public Form1()
        {
            InitializeComponent();
        }

        // ---- пустые обработчики, привязанные в вашем дизайнере ----
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        // ============ ОЧИСТКА (button1) ============
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            checkBox1.Checked = false;
            labelResult.Text = "Результат появится здесь.";
            listViewPlan.Items.Clear();
        }

        // ============ РАСЧЁТ (button2) ============
        private void button2_Click(object sender, EventArgs e)
        {
            var result = _manager.Calculate(
                currentVersion: textBox1.Text,
                newVersion: textBox2.Text,
                modulesText: textBox5.Text,
                dbSizeText: textBox4.Text,
                windowText: textBox3.Text,
                migrationRequired: checkBox1.Checked);

            listViewPlan.Items.Clear();

            if (!result.IsValid)
            {
                labelResult.Text = "ОШИБКИ ВВОДА:\r\n - " +
                                   string.Join("\r\n - ", result.Errors);
                return;
            }

            string kindText = result.Kind == UpdateKind.Modernization
                ? "Модернизация"
                : "Обновление";

            string proceedText = result.CanProceed
                ? "Переход возможен"
                : $"Окно недостаточно (требуется {result.TransitionMinutes} мин)";

            string riskText = result.Risk == RiskLevel.Low ? "Низкий"
                            : result.Risk == RiskLevel.Medium ? "Средний"
                            : "Высокий";

            labelResult.Text =
                $"Версии: {result.CurrentVersion} → {result.NewVersion}\r\n" +
                $"Тип операции: {kindText}\r\n" +
                $"Расчётное время: {result.TransitionMinutes} мин\r\n" +
                $"Окно обслуживания: {result.WindowMinutes} мин\r\n" +
                $"Результат: {proceedText}\r\n" +
                $"Риск: {riskText}";

            if (result.CanProceed)
            {
                int n = 1;
                foreach (var step in result.Steps)
                {
                    var item = new ListViewItem(n.ToString());
                    item.SubItems.Add(step);
                    listViewPlan.Items.Add(item);
                    n++;
                }
            }
            else
            {
                var item = new ListViewItem("-");
                item.SubItems.Add("План не сформирован — недостаточно окна");
                listViewPlan.Items.Add(item);
            }
        }
    }
}
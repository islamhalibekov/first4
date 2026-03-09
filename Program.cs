using System;
using System.Windows.Forms;
using System.Drawing;

namespace SimpleGreetingApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GreetingForm());
        }
    }

    public class GreetingForm : Form
    {
        private Label instructionLabel;  
        private TextBox nameTextBox;      
        private Button greetButton;        
        private Label resultLabel;       

        public GreetingForm()
        {

            this.Text = "Программа-приветствие";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;


            CreateControls();
        }

        private void CreateControls()
        {

            instructionLabel = new Label
            {
                Text = "Введите ваше имя и нажмите кнопку:",
                Location = new Point(20, 20),
                Size = new Size(350, 25),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };


            nameTextBox = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(200, 25),
                Font = new Font("Arial", 10)
            };


            greetButton = new Button
            {
                Text = "Поздороваться!",
                Location = new Point(230, 48),
                Size = new Size(130, 30),
                BackColor = Color.LightGreen,
                Font = new Font("Arial", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            resultLabel = new Label
            {
                Text = "",
                Location = new Point(20, 100),
                Size = new Size(350, 50),
                Font = new Font("Arial", 12, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightYellow
            };

            greetButton.Click += GreetButton_Click;

            this.Controls.AddRange(new Control[] {
                instructionLabel,
                nameTextBox,
                greetButton,
                resultLabel
            });
        }

        private void GreetButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(
                    "Пожалуйста, введите ваше имя!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                nameTextBox.Focus();
                return;
            }

            resultLabel.Text = $"Привет, {name}! Рады познакомиться!";
            resultLabel.Visible = true;
            greetButton.Enabled = false;

            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += (s, args) =>
            {
                greetButton.Enabled = true;
                timer.Stop();
            };
            timer.Start();
        }
    }
}
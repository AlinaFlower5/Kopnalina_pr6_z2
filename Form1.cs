using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kopnalina_pr6_z2
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int rocketPositionY;
        private const int rocketSpeed = 5;

        public Form1()
        {
            InitializeComponent();
            rocketPositionY = this.Height; // начальная позиция ракеты - внизу формы

            // Создаем и настраиваем таймер
            timer = new Timer();
            timer.Interval = 50; // частота обновления - 50 мс
            timer.Tick += timer1_Tick;

            // Создаем и настраиваем кнопку
            Button startButton = new Button();
            startButton.Text = "Start";
            startButton.BackColor = Color.Red;
            startButton.ForeColor = Color.White;
            startButton.Size = new Size(70, 30);
            startButton.Location = new Point((this.Width - startButton.Width) / 2, this.Height - 50);
            startButton.Click += StartButton_Click;
            this.Controls.Add(startButton); // добавляем кнопку на форму
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            timer.Start(); // запускаем таймер при нажатии кнопки Start
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    

        private void timer1_Tick(object sender, EventArgs e)
        {
            rocketPositionY -= rocketSpeed; // обновляем позицию ракеты
            if (rocketPositionY < -100) // если ракета вышла за пределы формы
            {
                rocketPositionY = this.Height; // возвращаем ракету внизу формы
                timer.Stop(); // останавливаем таймер
            }
            this.Invalidate(); // вызываем перерисовку формы
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // создаем объект Graphics
            Graphics g = e.Graphics;
            // рисуем ракету на текущей позиции
            g.FillRectangle(Brushes.Gray, (this.Width - 20) / 2, rocketPositionY, 20, 80);
        }
    }

      

      
}

using System;
using System.Threading;

namespace Ball
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<Label> labels = new List<Label>();
        List<Thread> threads = new List<Thread>();
        int i = 1;
        bool isStarted = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            if (!isStarted)
            {
                isStarted = true;
                AddThread();
            }
            button1.Enabled = false;
        }

        private void AddThread()
        {
            foreach (Label label in labels)
            {
                Thread thread = new Thread(() => MoveLabel(label));
                thread.IsBackground = true;
                threads.Add(thread);
                thread.Start();
            }
        }

        private void MoveLabel(Label label)
        {
            while (isStarted)
            {
                int x = rnd.Next(50, panel1.ClientSize.Width - 15);  // Позиция x в пределах панели
                int y = rnd.Next(50, panel1.ClientSize.Height - 15); // Позиция y в пределах панели
                Thread.Sleep(rnd.Next(500, 900));

                label.Location = new Point(x, y);

                // Проверка, если метка выходит за пределы клиентской области панели
                if (!panel1.ClientRectangle.Contains(label.Bounds))
                {
                    // Необходимо выполнить удаление, если метка выходит за пределы панели
                    labels.Remove(label);
                    label.Dispose();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateLabel();
            if (isStarted)
            {
                StopThreads();
                button1_Click(sender, e);
            }

        }

        private void CreateLabel()
        {
            Label buffer = new Label();
            buffer.Text = $"Шар {i}";
            buffer.AutoSize = true;
            buffer.Location = new Point(50, 50 + 20 * i);
            i += 1;
            panel1.Controls.Add(buffer);
            buffer.BringToFront();
            labels.Add(buffer);
        }

        private void StopThreads()
        {
            isStarted = false;
            foreach (Thread t in threads)
            {
                t.Join();
            }
            threads.Clear();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = false;
            StopThreads();
        }
    }
}
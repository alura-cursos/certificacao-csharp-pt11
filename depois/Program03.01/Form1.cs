using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program03._01
{
    public partial class Form1 : Form
    {
        Stopwatch relogio;

        public Form1()
        {
            InitializeComponent();
            relogio = new Stopwatch();
            relogio.Start();
        }

        private async void btnRelogio_Click(object sender, EventArgs e)
        {
            await VisualizaRelogio3();
        }

        private void VisualizaRelogio()
        {
            Thread threadSecundaria =
                new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(100);
                        TimeSpan tempo = relogio.Elapsed;
                        int minutos = tempo.Minutes;
                        int segundos = tempo.Seconds;
                        int milissegundos = tempo.Milliseconds;

                        this.Invoke((Action)delegate
                        {
                            txtRelogio.Text = $"{minutos:00}:{segundos:00}:{milissegundos:000}";
                        });
                        //this.Refresh();
                    }
                });
            threadSecundaria.Start();
        }

        void VisualizaRelogio2()
        {
            Task taskSecundaria =
            new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    TimeSpan tempo = relogio.Elapsed;
                    int minutos = tempo.Minutes;
                    int segundos = tempo.Seconds;
                    int milissegundos = tempo.Milliseconds;

                    this.Invoke((Action)delegate
                    {
                        txtRelogio.Text = $"{minutos:00}:{segundos:00}:{milissegundos:000}";
                    });
                    //this.Refresh();
                }
            });
            taskSecundaria.Start();
        }

        async Task VisualizaRelogio3()
        {
            while (true)
            {
                await Task.Delay(100);
                TimeSpan tempo = relogio.Elapsed;
                int minutos = tempo.Minutes;
                int segundos = tempo.Seconds;
                int milissegundos = tempo.Milliseconds;
                txtRelogio.Text = $"{minutos:00}:{segundos:00}:{milissegundos:000}";
            }
        }
    }
}

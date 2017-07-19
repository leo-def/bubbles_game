
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bubbles.Forms.tools;
using BubblesVisualComponenets;
using System.Threading;
using Bubbles.Forms.Tools;
namespace Bubbles.Forms
{
    public partial class Panel : Form
    {

        private int escape_move_number = 80;
        private long start_sleep_time = 0;
        private long sleep_increment = 20;

        public int BubbleCount { get; set; }
        public double UseArea { get; set; }
        public PanelFill Fill { get; set; }
        //public Dictionary<Bubble, List<Task<Boolean>>> Childs { get; set; }
        public List<Bubble> Childs { get; set; }

        public Panel()
        {
            InitializeComponent();
            UseArea = (75/100);
            Childs = new List<Bubble>();
           // Childs = new Dictionary<Bubble, List<Task<Boolean>>>();
            AskForBubbleNumber();
            UseFill();
            Console.WriteLine();
        }

        public void AskForBubbleNumber()
        {
            bool valid = false;
            while (!valid)
            {
                InputBox ib = new InputBox("ALERTA", "Informe o numero e o tamanho das bolhas", "20");
                ib.ShowDialog();
                /*try
                {*/
                    BubbleCount = ib.Qtd;
                    UseArea = ib.UseArea;   
                    valid = true;
               /* }
                catch (Exception ex) { MessageBox.Show("INFORME APENAS CARACTERES NUMERICOS", "ALERTA", MessageBoxButtons.OK); }*/
            }
        }

        public void InformBubblePosition(Bubble _b)
        {
            foreach(Bubble bubble in Childs)
            {
                if(_b != bubble)
                {
                    Task<Boolean> escape = new TaskFactory().StartNew<Boolean>(() => { 
                            if(!bubble.InMargin(_b)){return false;}

                            BubbleMover mover = new BubbleMover(bubble, bubble.GetEscapeDirection(_b.CentralPoint), escape_move_number, start_sleep_time, sleep_increment);
                                while(mover.Move())
                                {
                                    InformBubblePosition(bubble);
                                   //Task t = new TaskFactory().StartNew(() => InformBubblePosition(bubble));
                                }
                                return true;

                            /*
                            bool will_run = bubble.WillRun(_b);
                            if (will_run) {
                                //StopTasks(bubble); 
                            bubble.EscapeWithOutCheck(_b);
                            };

                            return will_run; */
                        });
                   /* escape.ContinueWith((antecedent) => { if (antecedent.Result) { InformBubblePosition(bubble); } });*/
                   // Childs[bubble].Add(escape);
                }
            }
        }

        public void InformMousePosition(Point _p)
        {
            foreach (Bubble bubble in Childs)
            {                 
                Task<Boolean> escape = new TaskFactory().StartNew<Boolean>(() => {
                    if (!bubble.InMargin(_p)) { return false; } 
                    BubbleMover mover = new BubbleMover(bubble,bubble.GetEscapeDirection(_p),escape_move_number,start_sleep_time,sleep_increment);
                    while(mover.Move())
                    {
                        InformBubblePosition(bubble);
                        //Task t = new TaskFactory().StartNew(() => { InformBubblePosition(bubble); });
                    }
                    return true;
                    /*if (will_run) 
                    { 
                       StopTasks(bubble);
                       bubble.EscapeWithOutCheck(_p);
                   };
                    return will_run;*/


                });
                /*escape.ContinueWith((antecedent) => { if (antecedent.Result) { InformBubblePosition(bubble); } });*/
                //Childs[bubble].Add(escape);
            }
        }




        public void UseFill()
        {
            Fill = new PanelFill(this, BubbleCount, UseArea);
            Fill.FillPanel();

        }

        public void AddBubble(Bubble _b)
        {
            Childs.Add(_b);
            this.Controls.Add(_b);

        }

        public string GetBubbleName()
        {
            return "Bubble_" + (Childs.Count - 1).ToString();
        }
        protected void OnMouseMove(object sender, MouseEventArgs e)
        {
            InformMousePosition(new Point(e.X, e.Y));
        }

        public void LoseGame()
        {
            MessageBox.Show("VOCÊ PERDEU", "AVISO", MessageBoxButtons.OK);
            this.Dispose();
        }
    }
}

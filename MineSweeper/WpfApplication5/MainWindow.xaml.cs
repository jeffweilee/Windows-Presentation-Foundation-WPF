using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfApplication5
{

    public partial class MainWindow : Window, IComponentConnector
    {
        private int contx = 10;
        private int conty = 10;
        private int minecont = 10;
        private Random randObj = new Random();
        private int temptime = 0;
        private bool gaming = false;
        private int timecont = 0;
  
        private sqrs[,] sqrsarray;
    
        private DispatcherTimer timer;
       

        public MainWindow()
        {
            this.InitializeComponent();
            this.dp01.Background = (Brush)Brushes.Gray;
            this.startgm();
        }

        public void startgm()
        {
            this.resetall();
            this.viewsqrs();
            this.havemine();
            this.sqrsnum();
            this.gmtimer();
            this.gaming = true;
        }

        public void resetall()
        {
            this.ugbox01.Children.Clear();
            this.textBox1.Text = this.minecont.ToString();
        }

        public void endall()
        {
            for (int index1 = 0; index1 < this.conty; ++index1)
            {
                for (int index2 = 0; index2 < this.contx; ++index2)
                {
                    if (this.sqrsarray[index1, index2].minein)
                        this.sqrsarray[index1, index2].sqrsstyle("bomb");
                }
            }
            this.timer.Stop();
            this.gaming = false;
        }

        private void youwin()
        {
            int num1 = 0;
            for (int index1 = 0; index1 < this.conty; ++index1)
            {
                for (int index2 = 0; index2 < this.contx; ++index2)
                {
                    if (this.sqrsarray[index1, index2].openin)
                        ++num1;
                    if (num1 == this.contx * this.conty - this.minecont)
                    {
                        this.endall();
                        int num2 = (int)MessageBox.Show("資管三/100306039/李維哲:\n恭喜你在" + this.timebox.Text + "秒內完成踩地雷^_^");
                        num1 = 0;
                        break;
                    }
                }
            }
        }

        public void gmtimer()
        {
            if (this.timecont == 0)
            {
                this.timer = new DispatcherTimer();
                this.timer.Interval = TimeSpan.FromSeconds(1.0);
                this.timer.Tick += new EventHandler(this.timer_Tick);
                ++this.timecont;
            }
            this.timer.Start();
            this.timebox.Text = "0";
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.timebox.Text) >= 999)
                return;
            this.temptime = Convert.ToInt32(this.timebox.Text) + 1;
            this.timebox.Text = this.temptime.ToString();
        }

        private void viewsqrs()
        {
            sqrs sqrs1 = new sqrs();
            this.sqrsarray = new sqrs[this.conty, this.contx];
            if (this.contx < 20 || this.conty < 10)
            {
                this.Width = (double)(this.contx * 60);
                this.Height = (double)(this.conty * 60 + 22);
            }
            else
            {
                this.Width = (double)(this.contx * 40);
                this.Height = (double)(this.conty * 40 + 22);
            }
            this.ugbox01.Rows = this.conty;
            for (int index1 = 0; index1 < this.conty; ++index1)
            {
                for (int index2 = 0; index2 < this.contx; ++index2)
                {
                    sqrs sqrs2 = new sqrs();
                    sqrs2.X = index2;
                    sqrs2.Y = index1;
                    sqrs2.sqrsstyle("unopen");
                    sqrs2.Focusable = false;
                    this.sqrsarray[index1, index2] = sqrs2;
                    this.ugbox01.Children.Add((UIElement)sqrs2);
                }
            }
        }

        private void havemine()
        {
            int num = 0;
            while (num < this.minecont)
            {
                int index1 = this.randObj.Next(0, this.contx);
                int index2 = this.randObj.Next(0, this.conty);
                if (!this.sqrsarray[index2, index1].minein)
                {
                    this.sqrsarray[index2, index1].minein = true;
                    ++num;
                }
            }
        }

        private void sqrsnum()
        {
            for (int index1 = 0; index1 < this.conty; ++index1)
            {
                for (int index2 = 0; index2 < this.contx; ++index2)
                {
                    int num = 0;
                    if (!this.sqrsarray[index1, index2].minein)
                    {
                        if (index2 == 0 && index1 == 0)
                        {
                            if (this.sqrsarray[index1, index2 + 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2 + 1].minein)
                                ++num;
                        }
                        else if (index2 == this.contx - 1 && index1 == 0)
                        {
                            if (this.sqrsarray[index1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2].minein)
                                ++num;
                        }
                        else if (index2 == 0 && index1 == this.conty - 1)
                        {
                            if (this.sqrsarray[index1 - 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1 - 1, index2 + 1].minein)
                                ++num;
                            if (this.sqrsarray[index1, index2 + 1].minein)
                                ++num;
                        }
                        else if (index2 == this.contx - 1 && index1 == this.conty - 1)
                        {
                            if (this.sqrsarray[index1 - 1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 - 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1, index2 - 1].minein)
                                ++num;
                        }
                        else if (index1 == 0)
                        {
                            if (this.sqrsarray[index1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1, index2 + 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2 + 1].minein)
                                ++num;
                        }
                        else if (index2 == 0)
                        {
                            if (this.sqrsarray[index1 - 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1 - 1, index2 + 1].minein)
                                ++num;
                            if (this.sqrsarray[index1, index2 + 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2 + 1].minein)
                                ++num;
                        }
                        else if (index1 == this.conty - 1)
                        {
                            if (this.sqrsarray[index1 - 1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 - 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1 - 1, index2 + 1].minein)
                                ++num;
                            if (this.sqrsarray[index1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1, index2 + 1].minein)
                                ++num;
                        }
                        else if (index2 == this.contx - 1)
                        {
                            if (this.sqrsarray[index1 - 1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 - 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2].minein)
                                ++num;
                        }
                        else
                        {
                            if (this.sqrsarray[index1 - 1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 - 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1 - 1, index2 + 1].minein)
                                ++num;
                            if (this.sqrsarray[index1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1, index2 + 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2 - 1].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2].minein)
                                ++num;
                            if (this.sqrsarray[index1 + 1, index2 + 1].minein)
                                ++num;
                        }
                        this.sqrsarray[index1, index2].numis = num;
                    }
                }
            }
        }

        private void showmine()
        {
            for (int index1 = 0; index1 < this.conty; ++index1)
            {
                for (int index2 = 0; index2 < this.contx; ++index2)
                {
                    if (this.sqrsarray[index1, index2].minein)
                        this.sqrsarray[index1, index2].Background = (Brush)Brushes.Pink;
                }
            }
        }

        private void shownum(sqrs s)
        {
            for (int index1 = 0; index1 < this.conty; ++index1)
            {
                for (int index2 = 0; index2 < this.contx; ++index2)
                {
                    if (!this.sqrsarray[index1, index2].minein && this.sqrsarray[index1, index2].numis != 0)
                        this.sqrsarray[index1, index2].Content = (object)this.sqrsarray[index1, index2].numis.ToString();
                }
            }
        }

        public void opensqrs(sqrs s)
        {
            if (s.openin || s.flagin || s.surein)
                return;
            if (s.minein)
            {
                this.endall();
                s.sqrsstyle("minebomb");
                int num = (int)MessageBox.Show("爆炸拉!");
            }
            else if (s.numis > 0)
                s.sqrsstyle("opennum");
            else if (s.numis == 0)
            {
                s.sqrsstyle("openspace");
                this.openspot(s.Y - 1, s.X - 1);
                this.openspot(s.Y - 1, s.X);
                this.openspot(s.Y - 1, s.X + 1);
                this.openspot(s.Y, s.X - 1);
                this.openspot(s.Y, s.X + 1);
                this.openspot(s.Y + 1, s.X - 1);
                this.openspot(s.Y + 1, s.X);
                this.openspot(s.Y + 1, s.X + 1);
            }
        }

        private void openspot(int tempy, int tempx)
        {
            if (tempy < 0 || tempy >= this.conty || (tempx < 0 || tempx >= this.contx))
                return;
            this.opensqrs(this.sqrsarray[tempy, tempx]);
        }

        public void mistakeflag(int tempy, int tempx)
        {
            if (tempy < 0 || tempy >= this.conty || (tempx < 0 || tempx >= this.contx))
                return;
            if (!this.sqrsarray[tempy, tempx].minein && this.sqrsarray[tempy, tempx].flagin)
                this.sqrsarray[tempy, tempx].sqrsstyle("mistakeflag");
            else if (this.sqrsarray[tempy, tempx].minein && !this.sqrsarray[tempy, tempx].flagin)
                this.sqrsarray[tempy, tempx].sqrsstyle("minebomb");
        }


        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.gaming || !(e.Source.GetType() == typeof(sqrs)))
                return;
            sqrs s = (sqrs)e.Source;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    if (this.gaming)
                        this.youwin();
                }
                else if (!s.flagin)
                {
                    this.opensqrs(s);
                    if (this.gaming)
                        this.youwin();
                }
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                if (!s.openin && !s.flagin && !s.surein)
                {
                    this.textBox1.Text = (Convert.ToInt32(this.textBox1.Text) - 1).ToString();
                    s.sqrsstyle("flag");
                }
                else if (!s.openin && s.flagin && !s.surein)
                {
                    this.textBox1.Text = (Convert.ToInt32(this.textBox1.Text) + 1).ToString();
                    s.sqrsstyle("sure");
                }
                else if (s.surein)
                {
                    s.sqrsstyle("unopen");
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.menu1.Height > 0.0)
            {
                this.menu1.Height = 0.0;
                MainWindow window1 = this;
               
                double num = (window1.Height) - 24.0;
             
               (window1.Height) = num;
            }
            else
            {
                this.menu1.Height = 24.0;
                MainWindow window1 = this;
          
                double num = (window1.Height) + 24.0;
     
                (window1.Height) = num;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.startgm();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.startgm();
        }


        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("-關於踩地雷-\n\n遊戲開始時，玩家可看到一堆整齊排列的空白方塊，方塊數可由玩家自行選擇。\n\n如果玩家點開方塊後沒有地雷，會有一個數字顯現其上，這個數字代表著鄰近方塊有多少顆地雷，玩家須運用邏輯來推斷哪些方塊含或不含地雷。\n\n玩家可在推測有地雷的方塊上點滑鼠右鍵，以放置旗幟來標明地雷的位置；若再次點擊右鍵，旗幟會變成問號，代表不確定是否有地雷存在；第三次點擊右鍵後會使問號消失，成為空白的方塊。\n\n若在已標明旗幟的方塊點擊左鍵，方塊不會有任何的變動，若是點擊標明問號的方塊，則與點擊空白的方塊相同。若在遊戲進行中錯置旗幟或問號，可用右鍵來改變方塊狀態。");
        }

        
    }
}

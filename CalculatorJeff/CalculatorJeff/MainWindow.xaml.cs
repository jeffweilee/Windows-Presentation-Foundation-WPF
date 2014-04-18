using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shapes;

namespace CalculatorJeff
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        /*public MainWindow()
        {
            InitializeComponent();
        }*/
        private double prenum = 0.0;
        private double nextnum = 0.0;
        private int digitcont = 0;
        private string preop = null;
        private string op = null;
        private int startnext = 0;
        private int cont = 0;
        private char tempchar;
        private int digitinclose = 0;
        private double testnum = 0.0;
        private string tempanswerstring = null;
        private int shifton = 0;
        private void digitin(int i, string keyword)
        {
            if (this.digitinclose == 0)
            {
                switch (keyword)
                {
                    case "num":
                        this.digithandle(i, keyword);
                        break;
                    case "point":
                        this.digithandle(0, keyword);
                        break;
                    case "op":
                        this.prenumcal(this.cont);
                        this.preophandle(i);
                        this.startnext = 1;
                        break;
                    case "ac":
                        this.digithandle(0, keyword);
                        break;
                    case "cancel":
                        this.answerbar.Text = "0.";
                        this.showbar.Text = null;
                        this.reset();
                        break;
                    case "equ":
                        this.mynameshow();
                        break;
                    case "nv":
                        this.digithandle(0, keyword);
                        break;
                    case "back":
                        this.digithandle(0, keyword);
                        break;
                }
            }
        }
        private void prenumcal(int n)
        {
            if (this.startnext == 0)
            {
                if (this.preop == null)
                {
                    this.prenum = double.Parse(this.answerbar.Text);
                }
                else
                {
                    this.nextnum = double.Parse(this.answerbar.Text);
                    this.prenum = this.ophandle(this.prenum, this.nextnum, this.preop);
                }
            }
        }
        private void preophandle(int i)
        {
            switch (i)
            {
                case 1:
                    this.op = "add";
                    this.showbar.Text = this.prenum + "+";
                    break;
                case 2:
                    this.op = "cut";
                    this.showbar.Text = this.prenum + "-";
                    break;
                case 3:
                    this.op = "mut";
                    this.showbar.Text = this.prenum + "×";
                    break;
                case 4:
                    this.op = "div";
                    this.showbar.Text = this.prenum + "÷";
                    break;
            }
        }
        private void digithandle(int i, string keyword)
        {
            if (this.startnext == 1)
            {
                this.answerbar.Text = "0.";
                this.startnext = 0;
                this.preop = this.op;
                this.cont = 0;
                this.digitcont = 0;
            }
            if (keyword == "num")
            {
                if (this.answerbar.Text.Length < 10)
                {
                    switch (this.digitcont)
                    {
                        case 0:
                            this.answerbar.Text = i.ToString() + ".";
                            if (i != 0)
                            {
                                this.digitcont++;
                            }
                            break;
                        case 1:
                            this.answerbar.Text = this.answerbar.Text.Substring(0, this.answerbar.Text.Length - 1) + i.ToString() + ".";
                            break;
                        case 2:
                            this.answerbar.Text = this.answerbar.Text + i.ToString();
                            break;
                    }
                }
            }
            else
            {
                if (keyword == "point")
                {
                    this.digitcont = 2;
                }
                else
                {
                    if (keyword == "ac")
                    {
                        this.answerbar.Text = "0.";
                        this.digitcont = 0;
                    }
                    else
                    {
                        if (keyword == "nv")
                        {
                            if (this.answerbar.Text[0] == '-')
                            {
                                this.answerbar.Text = this.answerbar.Text.Substring(1);
                            }
                            else
                            {
                                this.answerbar.Text = '-' + this.answerbar.Text;
                            }
                        }
                        else
                        {
                            if (keyword == "back")
                            {
                                this.tempchar = this.answerbar.Text[this.answerbar.Text.Length - 1];
                                if (this.digitcont == 2)
                                {
                                    if (this.tempchar == '.')
                                    {
                                        this.digitcont = 1;
                                    }
                                    else
                                    {
                                        this.answerbar.Text = this.answerbar.Text.Substring(0, this.answerbar.Text.Length - 1);
                                    }
                                }
                                else
                                {
                                    if (this.digitcont == 1)
                                    {
                                        if (this.answerbar.Text[1] == '.')
                                        {
                                            this.answerbar.Text = "0.";
                                            this.digitcont = 0;
                                        }
                                        else
                                        {
                                            if (this.answerbar.Text[2] == '.')
                                            {
                                                if (this.answerbar.Text[0] == '-')
                                                {
                                                    this.answerbar.Text = "0.";
                                                    this.digitcont = 0;
                                                }
                                                else
                                                {
                                                    this.answerbar.Text = this.answerbar.Text[0] + ".";
                                                }
                                            }
                                            else
                                            {
                                                this.answerbar.Text = this.answerbar.Text.Substring(0, this.answerbar.Text.Length - 2) + ".";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private double ophandle(double i, double j, string keyop)
        {
            if (keyop != null)
            {
                if (!(keyop == "add"))
                {
                    if (!(keyop == "cut"))
                    {
                        if (!(keyop == "mut"))
                        {
                            if (keyop == "div")
                            {
                                i /= j;
                            }
                        }
                        else
                        {
                            i *= j;
                        }
                    }
                    else
                    {
                        i -= j;
                    }
                }
                else
                {
                    i += j;
                }
            }
            return i;
        }
        private void reset()
        {
            this.prenum = 0.0;
            this.nextnum = 0.0;
            this.digitcont = 0;
            this.preop = null;
            this.op = null;
            this.startnext = 0;
            this.cont = 0;
        }
        private void exphandle(string cutstate, int exppoint)
        {
            int pointtime = 0;
            for (int tempanscont2 = 0; tempanscont2 < this.tempanswerstring.Length; tempanscont2++)
            {
                string text = cutstate;
                if (text != null)
                {
                    if (!(text == "start"))
                    {
                        if (!(text == "point"))
                        {
                            if (!(text == "exp"))
                            {
                                if (text == "last")
                                {
                                    TextBlock expr_130 = this.answerbar;
                                    expr_130.Text += this.tempanswerstring[tempanscont2];
                                }
                            }
                            else
                            {
                                tempanscont2 = exppoint;
                                TextBlock expr_FF = this.answerbar;
                                expr_FF.Text += this.tempanswerstring[tempanscont2];
                                cutstate = "last";
                            }
                        }
                        else
                        {
                            TextBlock expr_A5 = this.answerbar;
                            expr_A5.Text += this.tempanswerstring[tempanscont2];
                            pointtime++;
                            if (this.tempanswerstring[tempanscont2 + 1] == 'E' || pointtime == 10)
                            {
                                cutstate = "exp";
                            }
                        }
                    }
                    else
                    {
                        TextBlock expr_58 = this.answerbar;
                        expr_58.Text += this.tempanswerstring[tempanscont2];
                        if (this.tempanswerstring[tempanscont2] == '.')
                        {
                            cutstate = "point";
                        }
                    }
                }
            }
        }
        private void mynameshow()
        {
            if (this.prenum == 100306039.0 || this.answerbar.Text == "100306039.")
            {
                this.showbar.Text = "Jeff Lee";
                this.answerbar.Text = "李維哲";
                MessageBox.Show("資管三 100306039 李維哲");
                this.testnum = this.prenum;
                this.reset();
            }
            else
            {
                this.equmode();
            }
        }
        private void equmode()
        {
            this.prenumcal(this.cont);
            int haveexp = 0;
            string cutstate = "start";
            int exppoint = 0;
            this.tempanswerstring = this.prenum.ToString();
            for (int tempanscont = 0; tempanscont < this.tempanswerstring.Length; tempanscont++)
            {
                if (this.tempanswerstring[tempanscont] == 'E' && this.tempanswerstring[tempanscont + 1] == '+')
                {
                    haveexp = 1;
                    exppoint = tempanscont;
                    this.answerbar.Text = null;
                }
            }
            if (haveexp == 1)
            {
                this.exphandle(cutstate, exppoint);
                this.showbar.Text = null;
                this.reset();
            }
            else
            {
                if (this.prenum == Math.Ceiling(this.prenum))
                {
                    this.testnum = this.prenum;
                    this.answerbar.Text = this.prenum.ToString() + ".";
                    this.showbar.Text = null;
                    this.reset();
                }
                else
                {
                    if (this.prenum != Math.Ceiling(this.prenum))
                    {
                        this.testnum = this.prenum;
                        this.answerbar.Text = this.prenum.ToString();
                        this.showbar.Text = null;
                        this.reset();
                    }
                }
            }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(1, "num");            
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(2, "num");
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(3, "num");
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(4, "num");
        }
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(5, "num");
        }
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(6, "num");
        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(7, "num");
        }
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(8, "num");
        }
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(9, "num");
        }
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(0, "num");
        }
        private void btnpoint_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(0, "point");
        }
        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(1, "op");
        }
        private void btncut_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(2, "op");
        }
        private void btnmut_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(3, "op");
        }
        private void btndiv_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(4, "op");
        }
        private void btnac_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(0, "ac");
        }
        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(0, "cancel");
        }
        private void btnequ_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(0, "equ");
        }
        private void btnnv_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(0, "nv");
        }
        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            this.digitin(0, "back");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit Easy Calculator?", "Calculator", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Key key = e.Key;

            if (key == Key.Enter) {
                this.digitin(1, "equ");
            }
            if (key <= Key.Escape)
            {
                if (key != Key.Back)
                {
                    if (key != Key.Return)
                    {
                        if (key == Key.Escape)
                        {
                            this.digitin(0, "cancel");
                        }
                    }
                    else
                    {
                        this.digitin(1, "equ");
                    }
                }
                else
                {
                    this.digitin(0, "back");
                }
            }
            else
            {
                if (key <= Key.F4)
                {
                    switch (key)
                    {
                        case Key.Delete:
                            this.digitin(0, "ac");
                            goto IL_324;
                        case Key.Help:
                            goto IL_324;
                        case Key.D0:
                            break;
                        case Key.D1:
                            if (this.shifton == 0)
                            {
                                this.digitin(1, "num");
                            }
                            else
                            {
                                if (this.shifton == 1)
                                {
                                    this.digitin(0, "nv");
                                }
                            }
                            goto IL_324;
                        case Key.D2:
                            goto IL_166;
                        case Key.D3:
                            goto IL_178;
                        case Key.D4:
                            goto IL_18A;
                        case Key.D5:
                            goto IL_19C;
                        case Key.D6:
                            goto IL_1AE;
                        case Key.D7:
                            goto IL_1C0;
                        case Key.D8:
                            if (this.shifton == 0)
                            {
                                this.digitin(8, "num");
                            }
                            else
                            {
                                this.digitin(3, "op");
                            }
                            goto IL_324;
                        case Key.D9:
                            goto IL_219;
                        default:
                            switch (key)
                            {
                                case Key.NumPad0:
                                    break;
                                case Key.NumPad1:
                                    this.digitin(1, "num");
                                    goto IL_324;
                                case Key.NumPad2:
                                    goto IL_166;
                                case Key.NumPad3:
                                    goto IL_178;
                                case Key.NumPad4:
                                    goto IL_18A;
                                case Key.NumPad5:
                                    goto IL_19C;
                                case Key.NumPad6:
                                    goto IL_1AE;
                                case Key.NumPad7:
                                    goto IL_1C0;
                                case Key.NumPad8:
                                    this.digitin(8, "num");
                                    goto IL_324;
                                case Key.NumPad9:
                                    goto IL_219;
                                case Key.Multiply:
                                    this.digitin(3, "op");
                                    goto IL_324;
                                case Key.Add:
                                    this.digitin(1, "op");
                                    goto IL_324;
                                case Key.Separator:
                                case Key.F1:
                                case Key.F2:
                                case Key.F3:
                                    goto IL_324;
                                case Key.Subtract:
                                    this.digitin(2, "op");
                                    goto IL_324;
                                case Key.Decimal:
                                    goto IL_298;
                                case Key.Divide:
                                    goto IL_262;
                                case Key.F4:
                                    //MessageBox.Show(this.testnum.ToString());
                                    goto IL_324;
                                default:
                                    goto IL_324;
                            }
                            break;
                    }
                    this.digitin(0, "num");
                    goto IL_324;
                IL_166:
                    this.digitin(2, "num");
                    goto IL_324;
                IL_178:
                    this.digitin(3, "num");
                    goto IL_324;
                IL_18A:
                    this.digitin(4, "num");
                    goto IL_324;
                IL_19C:
                    this.digitin(5, "num");
                    goto IL_324;
                IL_1AE:
                    this.digitin(6, "num");
                    goto IL_324;
                IL_1C0:
                    this.digitin(7, "num");
                    goto IL_324;
                IL_219:
                    this.digitin(9, "num");
                    goto IL_324;
                }
                switch (key)
                {
                    case Key.LeftShift:
                    case Key.RightShift:
                        this.shifton = 1;
                        goto IL_324;
                    default:
                        switch (key)
                        {
                            case Key.OemPlus:
                                if (this.shifton == 1)
                                {
                                    this.digitin(1, "op");
                                }
                                else
                                {
                                    this.digitin(0, "equ");
                                }
                                goto IL_324;
                            case Key.OemComma:
                                goto IL_324;
                            case Key.OemMinus:
                                this.digitin(2, "op");
                                goto IL_324;
                            case Key.OemPeriod:
                                goto IL_298;
                            case Key.Oem2:
                                break;
                            default:
                                goto IL_324;
                        }
                        break;
                }
            IL_262:
                this.digitin(4, "op");
                goto IL_324;
            IL_298:
                this.digitin(0, "point");
            }
        IL_324:
            e.Handled = false;
        }
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                this.shifton = 1;
            }
            else
            {
                this.shifton = 0;
            }
        }
        private void MenuItem_Click_exit(object sender, RoutedEventArgs e)
        {
            base.Close();
        }
        private void MenuItem_Click_aboutme(object sender, RoutedEventArgs e)
        {
            AboutBox2 about = new AboutBox2();
            about.Show();
        }
    }
}

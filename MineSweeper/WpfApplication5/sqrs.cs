using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApplication5
{
    public class sqrs : Button
    {
        private int xptr = 0;
        private int yptr = 0;
        private int numptr = 0;
        private bool flagptr = false;
        private bool sureptr = false;
        private bool mineptr = false;
        private bool openptr = false;

        public bool flagin
        {
            get
            {
                return this.flagptr;
            }
            set
            {
                this.flagptr = value;
            }
        }

        public bool surein
        {
            get
            {
                return this.sureptr;
            }
            set
            {
                this.sureptr = value;
            }
        }

        public bool minein
        {
            get
            {
                return this.mineptr;
            }
            set
            {
                this.mineptr = value;
            }
        }

        public bool openin
        {
            get
            {
                return this.openptr;
            }
            set
            {
                this.openptr = value;
            }
        }

        public int X
        {
            get
            {
                return this.xptr;
            }
            set
            {
                this.xptr = value;
            }
        }

        public int Y
        {
            get
            {
                return this.yptr;
            }
            set
            {
                this.yptr = value;
            }
        }

        public int numis
        {
            get
            {
                return this.numptr;
            }
            set
            {
                this.numptr = value;
            }
        }

        public sqrs()
        {
            this.flagptr = false;
            this.sureptr = false;
            this.openptr = false;
        }

        public void sqrsstyle(string styleid)
        {
            switch (styleid)
            {
                case "unopen":
                    this.openin = false;
                    this.flagin = false;
                    this.surein = false;
                    break;
                case "openspace":
                    this.openin = true;
                    this.flagin = false;
                    this.surein = false;
                    this.Background = (Brush)Brushes.White;
                    this.Opacity = 0.5;
                    break;
                case "opennum":
                    this.openin = true;
                    this.flagin = false;
                    this.surein = false;
                    ImageBrush imageBrush1 = new ImageBrush();
                    imageBrush1.Stretch = Stretch.Uniform;
                    switch (this.numis)
                    {
                        case 1:
                            imageBrush1.ImageSource = (ImageSource)new BitmapImage(new Uri("img/num1", UriKind.Relative));
                            imageBrush1.Stretch = Stretch.Uniform;
                            this.Background = (Brush)imageBrush1;
                            return;
                        case 2:
                            imageBrush1.ImageSource = (ImageSource)new BitmapImage(new Uri("img/num2", UriKind.Relative));
                            imageBrush1.Stretch = Stretch.Uniform;
                            this.Background = (Brush)imageBrush1;
                            return;
                        case 3:
                            imageBrush1.ImageSource = (ImageSource)new BitmapImage(new Uri("img/num3", UriKind.Relative));
                            imageBrush1.Stretch = Stretch.Uniform;
                            this.Background = (Brush)imageBrush1;
                            return;
                        case 4:
                            imageBrush1.ImageSource = (ImageSource)new BitmapImage(new Uri("img/num4", UriKind.Relative));
                            imageBrush1.Stretch = Stretch.Uniform;
                            this.Background = (Brush)imageBrush1;
                            return;
                        case 5:
                            imageBrush1.ImageSource = (ImageSource)new BitmapImage(new Uri("img/num5", UriKind.Relative));
                            imageBrush1.Stretch = Stretch.Uniform;
                            this.Background = (Brush)imageBrush1;
                            return;
                        case 6:
                            imageBrush1.ImageSource = (ImageSource)new BitmapImage(new Uri("img/num6", UriKind.Relative));
                            imageBrush1.Stretch = Stretch.Uniform;
                            this.Background = (Brush)imageBrush1;
                            return;
                        case 7:
                            imageBrush1.ImageSource = (ImageSource)new BitmapImage(new Uri("img/num7", UriKind.Relative));
                            imageBrush1.Stretch = Stretch.Uniform;
                            this.Background = (Brush)imageBrush1;
                            return;
                        case 8:
                            imageBrush1.ImageSource = (ImageSource)new BitmapImage(new Uri("img/num8", UriKind.Relative));
                            imageBrush1.Stretch = Stretch.Uniform;
                            this.Background = (Brush)imageBrush1;
                            return;
                        default:
                            return;
                    }
                case "bomb":
                    ImageBrush imageBrush2 = new ImageBrush();
                    imageBrush2.ImageSource = (ImageSource)new BitmapImage(new Uri("img/mine", UriKind.Relative));
                    imageBrush2.Stretch = Stretch.Uniform;
                    this.Background = (Brush)imageBrush2;
                    break;
                case "flag":
                    ImageBrush imageBrush3 = new ImageBrush();
                    imageBrush3.ImageSource = (ImageSource)new BitmapImage(new Uri("img/flag8", UriKind.Relative));
                    imageBrush3.Stretch = Stretch.Uniform;
                    this.Background = (Brush)imageBrush3;
                    this.openin = false;
                    this.flagin = true;
                    this.surein = false;
                    break;
                case "sure":
                    ImageBrush imageBrush4 = new ImageBrush();
                    imageBrush4.ImageSource = (ImageSource)new BitmapImage(new Uri("img/sure", UriKind.Relative));
                    imageBrush4.Stretch = Stretch.Uniform;
                    this.Background = (Brush)imageBrush4;
                    this.openin = false;
                    this.flagin = false;
                    this.surein = true;
                    break;
                case "mistakeflag":
                    ImageBrush imageBrush5 = new ImageBrush();
                    imageBrush5.ImageSource = (ImageSource)new BitmapImage(new Uri("img/msflag", UriKind.Relative));
                    imageBrush5.Stretch = Stretch.Uniform;
                    this.Background = (Brush)imageBrush5;
                    break;
                case "minebomb":
                    ImageBrush imageBrush6 = new ImageBrush();
                    imageBrush6.ImageSource = (ImageSource)new BitmapImage(new Uri("img/mineboom", UriKind.Relative));
                    imageBrush6.Stretch = Stretch.Uniform;
                    this.Background = (Brush)imageBrush6;
                    break;
            }
        }
    }
}

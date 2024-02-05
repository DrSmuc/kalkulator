using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace kalkulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int _outnum = 0;
        int active_base = 10;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private bool calc(char op)
        {
            int a, b;
            try
            {
                int n;
                if (active_base == 2)
                {
                    int n1 = 0;
                    int n2 = 0;
                    int t = 0;
                    for (int i = op1.Text.Length - 1; i >= 0; i--)
                    {
                        char c = op1.Text[i];
                        if (i == 0 && c == '-')
                        {
                            n1 *= -1;
                            break;
                        }
                        else if (c != '0' && c != '1')
                        {
                            _out.Text = "Cannot convert into numebr.";
                            return false;
                        }
                        n = c - '0';
                        n1 = (int)(n1 + (n * Math.Pow(2, t++)));
                    }
                    t = 0;
                    for (int i = op2.Text.Length - 1; i >= 0; i--)
                    {
                        char c = op2.Text[i];
                        if (i == 0 && c == '-')
                        {
                            n2 *= -1;
                            break;
                        }
                        else if (c != '0' && c != '1')
                        {
                            _out.Text = "Cannot convert into numebr.";
                            return false;
                        }
                        n = c - '0';
                        n2 = (int)(n2 + (n * Math.Pow(2, t++)));
                    }
                    a = n1;
                    b = n2;
                }
                else if (active_base == 8)
                {
                    int n1 = 0;
                    int n2 = 0;
                    int t = 0;
                    for (int i = op1.Text.Length - 1; i >= 0; i--)
                    {
                        char c = op1.Text[i];
                        if (i == 0 && c == '-')
                        {
                            n1 *= -1;
                            break;
                        }
                        else if (c < '0' || c > '8')
                        {
                            _out.Text = "Cannot convert into numebr.";
                            return false;
                        }
                        n = c - '0';
                        n1 = (int)(n1 + (n * Math.Pow(8, t++)));
                    }
                    t = 0;
                    for (int i = op2.Text.Length - 1; i >= 0; i--)
                    {
                        char c = op2.Text[i];
                        if (i == 0 && c == '-')
                        {
                            n2 *= -1;
                            break;
                        }
                        else if (c < '0' || c > '8')
                        {
                            _out.Text = "Cannot convert into numebr.";
                            return false;
                        }
                        n = c - '0';
                        n2 = (int)(n2 + (n * Math.Pow(8, t++)));
                    }
                    a = n1;
                    b = n2;
                }
                else if (active_base == 16)
                {
                    int n1 = 0;
                    int n2 = 0;
                    int t = 0;
                    for (int i = op1.Text.Length - 1; i >= 0; i--)
                    {
                        char c = op1.Text[i];
                        if (i == 0 && c == '-')
                        {
                            n1*= -1;
                            break;
                        }
                        else if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
                        {
                            _out.Text = "Cannot convert into numebr.";
                            return false;
                        }

                        if (c == 'A' || c == 'a') n = 10;
                        else if (c == 'B' || c == 'b') n = 11;
                        else if (c == 'C' || c == 'c') n = 12;
                        else if (c == 'D' || c == 'd') n = 13;
                        else if (c == 'E' || c == 'e') n = 14;
                        else if (c == 'F' || c == 'f') n = 15;
                        else n = c - '0';


                        n1 = (int)(n1 + (n * Math.Pow(16, t++)));
                    }
                    t = 0;
                    for (int i = op2.Text.Length - 1; i >= 0; i--)
                    {
                        char c = op2.Text[i];
                        if (i == 0 && c == '-')
                        {
                            n2 *= -1;
                            break;
                        }
                        else if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
                        {
                            _out.Text = "Cannot convert into numebr.";
                            return false;
                        }

                        if ( c == 'A' || c == 'a')  n = 10;
                        else if (c == 'B' || c == 'b')  n = 11;
                        else if (c == 'C' || c == 'c')  n = 12;
                        else if (c == 'D' || c == 'd')  n = 13;
                        else if (c == 'E' || c == 'e')  n = 14;
                        else if (c == 'F' || c == 'f')  n = 15;
                        else n = c - '0';


                        n2 = (int)(n2 + (n * Math.Pow(16, t++)));
                    }
                    a = n1;
                    b = n2;
                }
                else
                {
                    a = Convert.ToInt32(op1.Text);
                    b = Convert.ToInt32(op2.Text);
                }
            }
            catch
            {
                _out.Text = "Cannot convert into numebr.";
                return false;
            }
            switch (op)
            {
                case '+':
                    _outnum = a + b;
                    break;
                case '-':
                    _outnum = a - b;
                    break;
                case '*':
                    _outnum = a * b;
                    break;
                case '/':
                    _outnum = a / b;
                    break;
                default:
                    break;
            }
            return true;
        }

        private void output()
        {
            if (op1.Text != null && op2.Text != null)
            {
                switch (active_base)
                {
                    case 2:
                        _out.Text = Convert.ToString(_outnum, 2);
                        break;
                    case 8:
                        _out.Text = Convert.ToString(_outnum, 8);
                        break;
                    case 16:
                        _out.Text = Convert.ToString(_outnum, 16);
                        break;
                    default:
                        _out.Text = Convert.ToString(_outnum);
                        break;
                }
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            
            if (calc('+'))
                output();
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            if (calc('-'))
                output();
        }

        private void mul_Click(object sender, RoutedEventArgs e)
        {
            if (calc('*'))
                output();
        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            if (calc('/'))
                output();
        }

        private void _base_Checked(object sender, RoutedEventArgs e)
        {
            active_base = 10;
            output();
        }

        private void _base1_Checked(object sender, RoutedEventArgs e)
        {
            active_base = 2;
            output();
        }

        private void _base2_Checked(object sender, RoutedEventArgs e)
        {
            active_base = 8;
            output();
        }

        private void _base3_Checked(object sender, RoutedEventArgs e)
        {
            active_base = 16;
            output();
        }
    }
}

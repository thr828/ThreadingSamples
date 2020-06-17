using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace UIDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Thread.Sleep(5000);//UI阻塞
            TxtMessage.Text = "HELLO";

        }

        private void Btn2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new Thread(() =>
            {
                Thread.Sleep(5000);
                TxtMessage.Text = "HELLO";//异常，不能访问主线程上的ui（调用线程无法访问此对象，因为另一个线程拥有该对象。”
                    
            }).Start();
        }

        private void Btn3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new Thread(() =>
            {
                Thread.Sleep(5000);
                UpdateMessage("hello");
            }).Start();
        }

        private void UpdateMessage(string msg)
        {
            Action action = new Action(() => TxtMessage.Text = msg);
            Dispatcher.BeginInvoke(action);//将这个委托发送到ui主线程的消息队列中，等待操作
        }

    }
}
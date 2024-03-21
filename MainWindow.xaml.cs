using System;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Input;

namespace ImageConversion
{
    public partial class MainWindow : Window
    {
        private OpenFileDialog ofd = new OpenFileDialog();
        private SaveFileDialog sfd = new SaveFileDialog();
        byte[] dataI;

        public MainWindow()
        {
            InitializeComponent();
            ofd.Filter = "Image Files (.png, .jpg, .bmp)|*.png;*.jpg;*.bmp";
            sfd.Filter = "Image Files (.png, .jpg, .bmp)|*.png;*.jpg;*.bmp";
        }

        private void ButtonLoadImage_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.ShowDialog() == true)
            {
                byte[] dataUpload = File.ReadAllBytes(ofd.FileName);
                ListBoxItem lbi = new ListBoxItem();
                lbi.Tag = dataUpload; // Сохранение массива байтов в Tag
                lbi.Content = "Image " + lb.Items.Count; // Отображение текста
                lb.Items.Add(lbi);
            }
        }

        private void lb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lb.SelectedItem != null)
            {
                if (sfd.ShowDialog() == true)
                {
                    byte[] dataDownload = (byte[])((lb.SelectedItem as ListBoxItem).Tag); // Извлечение массива байтов из Tag
                    File.WriteAllBytes(sfd.FileName, dataDownload);
                }
            }
        }
    }
}

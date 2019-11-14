using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaveImagesToDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog Op = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new DbEntities();
            tbl_Images im = new tbl_Images();

            im.Image = File.ReadAllBytes(Op.FileName);

            db.tbl_Images.Add(im);
            db.SaveChanges();
            MessageBox.Show("image has been saved");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Op.Title = "image selection";
            Op.Filter = "JPG(.jpg)|*.jpg|PNG(.png)|*.png|JPEG(.jpeg)|*.jpeg";

            if (Op.ShowDialog() == true)
            {
                img.Source = new BitmapImage(new Uri(Op.FileName));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var db = new DbEntities();
            var f1 = db.tbl_Images.SingleOrDefault(t => t.ID == 1);

            img.Source = LoadImage(f1.Image);
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}

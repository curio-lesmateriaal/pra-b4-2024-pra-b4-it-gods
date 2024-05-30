using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PRA_B4_FOTOKIOSK.magie
{
    public class PictureManager
    {
        public static Home Instance { get; set; }

        public static void UpdatePictures(List<KioskPhoto> PicturesToDisplay)
        {
            Instance.spPictures.Children.Clear();

            // Group photos into pairs
            List<List<KioskPhoto>> photoPairs = GroupPhotosIntoPairs(PicturesToDisplay);

            // Display each pair of photos side by side
            foreach (var pair in photoPairs)
            {
                DisplayPhotoPair(pair);
            }
        }

        // Group photos into pairs
        private static List<List<KioskPhoto>> GroupPhotosIntoPairs(List<KioskPhoto> photos)
        {
            List<List<KioskPhoto>> photoPairs = new List<List<KioskPhoto>>();
            List<KioskPhoto> currentPair = new List<KioskPhoto>();

            foreach (var photo in photos)
            {
                currentPair.Add(photo);

                // If current pair is complete (contains two photos), add it to the list of pairs and reset the current pair
                if (currentPair.Count == 2)
                {
                    photoPairs.Add(currentPair);
                    currentPair = new List<KioskPhoto>();
                }
            }

          

            return photoPairs;
        }

        // Display a pair of photos side by side
        private static void DisplayPhotoPair(List<KioskPhoto> pair)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            foreach (var photo in pair)
            {
                Image image = new Image();
                BitmapImage bitmap = PathToImage(photo.Source);
                image.Source = bitmap;
                image.Width = 1920 / 3.5;
                image.Height = 1080 / 3.5;
                stackPanel.Children.Add(image);
            }

            Instance.spPictures.Children.Add(stackPanel);
        }

        // Convert file path to BitmapImage
        private static BitmapImage PathToImage(string path)
        {
            var stream = new MemoryStream(File.ReadAllBytes(path));
            var img = new BitmapImage();

            img.BeginInit();
            img.StreamSource = stream;
            img.EndInit();

            return img;
        }
    }
}
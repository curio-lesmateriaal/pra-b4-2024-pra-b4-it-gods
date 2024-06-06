using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace PRA_B4_FOTOKIOSK.controller
{
   
    public class PictureController
    {
        // De window die we laten zien op het scherm
        public static Home Window { get; set; }

        // De lijst met fotos die we laten zien
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        // Start methode die wordt aangeroepen wanneer de foto pagina opent.
        public void Start()
        {
            var now = DateTime.Now;

            int nowTime = now.Hour * 10000 + now.Minute * 100 + now.Second;
            int startTime = now.AddMinutes(-30).Hour * 10000 + now.AddMinutes(-30).Minute * 100 + now.Second;
            int endTime = now.AddMinutes(-2).Hour * 10000 + now.AddMinutes(-2).Minute * 100 + now.Second;

            int currentDay = (int)now.DayOfWeek;

            foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            {
                // Extract the day number from the directory name (e.g., "0_Zondag")
                string dirName = new DirectoryInfo(dir).Name;
                if (int.TryParse(dirName.Split('_')[0], out int dirDay) && dirDay == currentDay)
                {
                    foreach (string file in Directory.GetFiles(dir, "*.jpg"))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        string[] parts = fileName.Split('_');

                        if (parts.Length >= 3)
                        {
                            string hourPart = parts[0];
                            string minutePart = parts[1];
                            string secondPart = parts[2];

                            if (int.TryParse(hourPart, out int hour) &&
                                int.TryParse(minutePart, out int minute) &&
                                int.TryParse(secondPart, out int second))
                            {
                                // Combine the time parts into a single integer (HHmmss format)
                                int pictureTime = hour * 10000 + minute * 100 + second;

                                if (pictureTime >= startTime && pictureTime <= endTime)
                                {
                                    PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
                                }
                            }
                        }
                    }
                }
            }
        

        // Update de fotos
        PictureManager.UpdatePictures(PicturesToDisplay);
        }

        

        // Wordt uitgevoerd wanneer er op de Refresh knop is geklikt
        public void RefreshButtonClick()
        {
            // Refresh logic can be implemented here
        }
    } 
}

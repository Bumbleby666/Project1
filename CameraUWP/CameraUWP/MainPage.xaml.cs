using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace CameraUWP
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void CaptureBtn_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
            // Öffne Kamera erstelle ein Image
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
            // Wenn das Image vom Anwender nicht gewüscht ist, lächle und winke 
            if (photo == null)
            {
                // Anwender löscht Foto
                return;
            }
            // Sonst, Display nimmt das Foto in den Platzhalter
            else
            {
                BitmapImage bitmapImage = new BitmapImage();
                using (IRandomAccessStream photoStream = await photo.OpenAsync(FileAccessMode.Read))
                {
                    bitmapImage.SetSource(photoStream);
                }
                CapturedImage.Source = bitmapImage;

            // Mit F5 wird die App gestartet und Freigabe der App über die Entwicklertools freischalten
            }
        }
    }
}

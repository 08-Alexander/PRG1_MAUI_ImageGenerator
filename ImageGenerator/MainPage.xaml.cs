using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ImageGenerator
{
    public class Gallery
    {
        public string Picture { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
    }

    
    public partial class MainPage : ContentPage
    {
        Gallery _currentPicture;

        private List<Gallery> ImageList = new List<Gallery>()
            {
                new Gallery() { Picture = "image1", Description = "Man", IsFavorite = false },
                new Gallery() { Picture = "image2", Description = "Bird", IsFavorite = false },
                new Gallery() { Picture = "image3",Description = "Big cat", IsFavorite = false},
                new Gallery(){ Picture = "image4", Description = "Autumn road", IsFavorite = false},
                new Gallery(){ Picture = "image5", Description = "Flowergirl", IsFavorite = false},
                new Gallery(){ Picture = "image6", Description = "En ko", IsFavorite = false},
                new Gallery(){ Picture = "image7", Description = "En vacker stig med en vacker utsikt", IsFavorite =false},
                new Gallery(){ Picture = "image8", Description = "Ett stort och fint slott", IsFavorite = false},
                new Gallery(){ Picture = "image9", Description = "En liten pojke som gör sin läxa", IsFavorite =false},
                new Gallery(){ Picture = "image10", Description = "Mmmm, god fika", IsFavorite =false},
            };

        
        private Random random = new();

        public MainPage()
        {
            InitializeComponent();
            int a = 23;
        }

        private void ImageOnClicked(object? sender, EventArgs e)
        {
            ShowImageAndText();
        }

        private void ShowImageAndText()
        {

            //var singleKeys = ImageList.Keys.ToList(); // en lokal lista av det första paret i en Dictionary

            var pairs = ImageList.ElementAt(random.Next(ImageList.Count));

            Debug.WriteLine(pairs.Picture + ": " + pairs.Description); // för testning i Output

            string showKey = GetImageFileEnding(pairs.Picture); // detta då enbart Windows kräver filändelse

            ShowGallery.Source = showKey;

            ImageText.Text = pairs.Description;
        }

        private string GetImageFileEnding(string imageKey)
        {
            #if WINDOWS
            return imageKey + ".jpg";
            #else
            return imageKey;
            #endif
        }


        private void OnFavoriteClicked(object sender, EventArgs e)
        {

            _currentPicture.IsFavorite = !_currentPicture.IsFavorite;   

            if (_currentPicture.IsFavorite)
            {
                FavoriteButton.Source = new FontImageSource
                {
                    Glyph = "\ue87d",
                    FontFamily = "MaterialIcons",
                    Size = 32,
                    Color = Colors.Red
                };
            }
            else
            {
                FavoriteButton.Source = new FontImageSource
                {
                    Glyph = "\ue87e",
                    FontFamily = "MaterialIcons",
                    Size = 32,
                    Color = Colors.Gray
                };
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        //    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}

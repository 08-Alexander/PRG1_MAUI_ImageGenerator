using System.Diagnostics;

namespace ImageGenerator
{
    public class Gallery
    {
        public string PathToFolderWithImages { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
    }


    public partial class MainPage : ContentPage
    {
        Gallery _currentItemInImageList;

        private List<Gallery> ImageList = new List<Gallery>()
            {
                new Gallery() { PathToFolderWithImages = "image1", Description = "Man", IsFavorite = false },
                new Gallery() { PathToFolderWithImages = "image2", Description = "Bird", IsFavorite = false },
                new Gallery() { PathToFolderWithImages = "image3",Description = "Big cat", IsFavorite = false},
                new Gallery(){ PathToFolderWithImages = "image4", Description = "Autumn road", IsFavorite = false},
                new Gallery(){ PathToFolderWithImages = "image5", Description = "Flowergirl", IsFavorite = false},
                new Gallery(){ PathToFolderWithImages = "image6", Description = "En ko", IsFavorite = false},
                new Gallery(){ PathToFolderWithImages = "image7", Description = "En vacker stig med en vacker utsikt", IsFavorite =false},
                new Gallery(){ PathToFolderWithImages = "image8", Description = "Ett stort och fint slott", IsFavorite = false},
                new Gallery(){ PathToFolderWithImages = "image9", Description = "En liten pojke som gör sin läxa", IsFavorite =false},
                new Gallery(){ PathToFolderWithImages = "image10", Description = "Mmmm, god fika", IsFavorite =false},
            };


        private Random random = new Random();


        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageOnClicked(object? sender, EventArgs e)
        {
            ShowImageAndText();
        }

        private void ShowImageAndText()
        {
            _currentItemInImageList = ImageList.ElementAt(random.Next(1, ImageList.Count));

            Debug.WriteLine(_currentItemInImageList.PathToFolderWithImages + " " + _currentItemInImageList.IsFavorite); // för testning i Output

            string singleItem = GetImageFileEnding(_currentItemInImageList.PathToFolderWithImages); // detta då enbart Windows kräver filändelse         

            ShowGallery.Source = singleItem;

            ImageText.Text = _currentItemInImageList.Description;
            FavoriteHeart();
        }

        private string GetImageFileEnding(string imageURL)
        {
#if WINDOWS
            return imageURL + ".jpg";
#else
            return imageURL;
#endif
        }




        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            if (_currentItemInImageList == null) return;

            _currentItemInImageList.IsFavorite = !_currentItemInImageList.IsFavorite;
            FavoriteHeart();
        }


        private void FavoriteHeart()
        {

            if (_currentItemInImageList.IsFavorite)
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

    }
}

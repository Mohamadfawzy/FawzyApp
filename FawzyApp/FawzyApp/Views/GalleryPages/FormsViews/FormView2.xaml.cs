using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;

namespace FawzyApp.Views.GalleryPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormView2 : StackLayout
    {
        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        Dictionary<int, ImageSource> ImagesValues = new Dictionary<int, ImageSource>();
        public FormView2()
        {
            InitializeComponent();


            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            ImageFlexLaout.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await FilePicker.PickAsync(new PickOptions { FileTypes = FilePickerFileType.Images, PickerTitle = "pick an image" });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                image.Source = ImageSource.FromStream(() => stream);
            }
        }
        Image ImageFlexLaout = new Image();
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var result = await FilePicker.PickMultipleAsync(new PickOptions { FileTypes = FilePickerFileType.Images, PickerTitle = "pick images" });
            var imageSource = new List<ImageSource>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    // "/storage/emulated/0/Android/data/com.companyname.fawzyapp/cache/2203693cc04e0be7f4f024d5f9499e13/0e642369375e4b8d9e700811ed24ba75/images.jpeg"
                    var fullPath = item.FullPath;
                    ImageFlexLaout = new Image() { Source = ImageSource.FromFile(fullPath), Margin = new Thickness(5, 0, 0, 0), Aspect = Aspect.AspectFill, HeightRequest = 100, WidthRequest = 100, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start };

                    ImageFlexLaout.GestureRecognizers.Add(tapGestureRecognizer);

                    flextLayout.Children.Add(ImageFlexLaout);
                }

                //collectionView.ItemsSource = imageSource;
            }
        }
        Rectangle crruntRec = new Rectangle();
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send<FormView2, bool>(this, "Hi", true);

            stackBackground.IsVisible = true;
            var image = sender as Image;
            var fromBounds = image.Bounds;

            imageAbsolute.IsVisible = false;

            AbsoluteLayout.SetLayoutBounds(imageAbsolute, fromBounds);

            imageAbsolute.Source = image.Source;
            imageAbsolute.IsVisible = true;
           // var rectangle = new Rectangle(stackAbsolute.Bounds.X, stackAbsolute.Bounds.Y,image.Width, image.Height);
            await imageAbsolute.LayoutTo(stackAbsolute.Bounds, 400, Easing.SinOut);
            crruntRec = image.Bounds;
        }

        private async void TapimageAbsolute(object sender, EventArgs e)
        {
            await imageAbsolute.LayoutTo(crruntRec, 400, Easing.SinOut);

            stackBackground.IsVisible = false;
            imageAbsolute.IsVisible = false;
            MessagingCenter.Send<FormView2, bool>(this, "Hi", false);
        }
    }
}
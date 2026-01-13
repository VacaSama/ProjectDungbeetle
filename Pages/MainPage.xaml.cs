using ProjectDungbeetle.Models;
using ProjectDungbeetle.PageModels;

namespace ProjectDungbeetle.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}
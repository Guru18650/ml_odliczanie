namespace ml_odliczanie
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            list.ItemsSource = event_handler.events;
        }
        private async void eventBtn_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ViewCell viewCell = (ViewCell)button.Parent.Parent;
            eventClass selectedItem = (eventClass)viewCell.BindingContext;
            await Navigation.PushAsync(new Event(selectedItem));
        }
        private async void eventBtn_Delete(object sender, EventArgs e)
        {
            if(await DisplayAlert("Uwaga", "Czy na pewno chcesz to zrobić?", "TAK", "NIE"))
            {
                Button button = (Button)sender;
                ViewCell viewCell = (ViewCell)button.Parent.Parent;
                eventClass selectedItem = (eventClass)viewCell.BindingContext;
                event_handler.removeEvent(selectedItem);
            }
            
        }

        private void new_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventCreator());
        }
    }
}
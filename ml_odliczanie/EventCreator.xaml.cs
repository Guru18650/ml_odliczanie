using System.Text.RegularExpressions;

namespace ml_odliczanie;

public partial class EventCreator : ContentPage
{
	public EventCreator()
	{
		InitializeComponent();
		var today = DateTime.Now;
		Datepick.MinimumDate = today.AddDays(1);
		
	}

    private async void dodajBtn_Clicked(object sender, EventArgs e)
    {
		if (string.IsNullOrEmpty(nameEntry.Text))
		{
			await DisplayAlert("B³¹d", "Uzupe³nij wszystkie dane", "OK");
			return;
		}
		eventClass eventClass = new eventClass();
		eventClass.Name = nameEntry.Text;
		DateTime tempDT = new DateTime(year: Datepick.Date.Year, month: Datepick.Date.Month, day: Datepick.Date.Day, hour: Timepick.Time.Hours, minute: Timepick.Time.Minutes, second: Timepick.Time.Seconds);
		eventClass.DateTime = tempDT;

		event_handler.addEvent(eventClass);
	}
}
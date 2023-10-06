using System.Timers;
using Timer = System.Timers.Timer;

namespace ml_odliczanie;

public partial class Event : ContentPage
{
    private DateTime mainDT;
    private Timer timer;

    public Event(eventClass e)
    {
        InitializeComponent();

        name.Text = e.Name;

        mainDT = e.DateTime;
        TimeSpan df = mainDT.Subtract(DateTime.Now);

        day.Text = df.Days.ToString() + " dni";
        hour.Text = df.Hours.ToString() + " godzin";
        minute.Text = df.Minutes.ToString() + " minut";
        second.Text = df.Seconds.ToString("00") + " sekund";
        timer = new Timer(1000); 
        timer.Elapsed += TimerElapsed;
        timer.Start();
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        TimeSpan df = mainDT.Subtract(DateTime.Now);

        Device.BeginInvokeOnMainThread(() =>
        {
            day.Text = $"{df.Days.ToString()} dni";
            hour.Text = $"{df.Hours.ToString()} godzin";
            minute.Text = $"{df.Minutes.ToString()} minut";
            second.Text = df.Seconds.ToString("00") + " sekund";
        });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Stop the timer when the page disappears (e.g., when navigating away)
        timer.Stop();
        timer.Elapsed -= TimerElapsed;
    }

}
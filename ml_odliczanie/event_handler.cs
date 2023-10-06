using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ml_odliczanie
{
    public static class event_handler
    { 
        public static ObservableCollection<eventClass> events = new ObservableCollection<eventClass>();

        static event_handler()
        {
            events = JsonConvert.DeserializeObject<ObservableCollection<eventClass>>(Preferences.Get("events","[]"));
        }
        public static void addEvent(eventClass e)
        {
            events.Add(e);
            Preferences.Set("events",JsonConvert.SerializeObject(events));
        }

        public static async void removeEvent(eventClass e)
        {
            events.Remove(e);
            Preferences.Set("events", JsonConvert.SerializeObject(events));
        }

    }

    public class eventClass {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}

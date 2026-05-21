using Microsoft.Maui.Devices;
using System.Collections.ObjectModel;
using static CampusAttendanceSystem.FileManager;

namespace CampusAttendanceSystem.Pages;

public partial class CheckPage : ContentPage
{
    public ObservableCollection<AttendanceRecord> Records { get; set; } = new();

    public CheckPage()
    {
        InitializeComponent();
        BindingContext = this;
        LoadSavedRecords();
        StartClock();
    }

    private void LoadSavedRecords()
    {
        var list = LoadRecords();
        Records.Clear();
        foreach (var item in list) Records.Add(item);
    }

    private async void OnCheckInClicked(object sender, EventArgs e)
    {
        var location = await GetLocationAsync();
        var record = new AttendanceRecord
        {
            Type = "Check In",
            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Location = location
        };

        Records.Add(record);
        SaveRecords(Records.ToList());
        await DisplayAlert("Success", "Checked In", "OK");
    }

    private async void OnCheckOutClicked(object sender, EventArgs e)
    {
        var location = await GetLocationAsync();
        var record = new AttendanceRecord
        {
            Type = "Check Out",
            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Location = location
        };

        Records.Add(record);
        SaveRecords(Records.ToList());
        await DisplayAlert("Success", "Checked Out", "OK");
    }

    private void OnViewRecordsClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RecordPage());
    }

    private async Task<string> GetLocationAsync()
    {
        try
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);
            if (location != null)
                return $"{location.Latitude:F4}, {location.Longitude:F4}";
        }
        catch { }
        return "No GPS";
    }

    private void StartClock()
    {
        Dispatcher.DispatchAsync(async () =>
        {
            while (true)
            {
                TimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                await Task.Delay(1000);
            }
        });
    }
}
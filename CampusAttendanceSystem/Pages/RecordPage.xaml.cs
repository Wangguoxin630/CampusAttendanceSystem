using static CampusAttendanceSystem.FileManager;

namespace CampusAttendanceSystem.Pages;

public partial class RecordPage : ContentPage
{
    public RecordPage()
    {
        InitializeComponent();
        attendanceListView.ItemsSource = LoadRecords();
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
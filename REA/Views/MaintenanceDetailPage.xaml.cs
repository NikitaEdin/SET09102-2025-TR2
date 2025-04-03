using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REA.Views.Maintenance;

public partial class MaintenanceDetailPage : ContentPage {
    private Models.Maintenance _maintenance;

    public MaintenanceDetailPage(Models.Maintenance maintenance) {
        _maintenance = maintenance;
        this.BindingContext = _maintenance;

        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e) {
        await Navigation.PopAsync();
    }
}
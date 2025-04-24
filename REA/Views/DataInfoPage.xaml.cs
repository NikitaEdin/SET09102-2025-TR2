using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.Models;

namespace REA.Views;

public partial class DataInfoPage : ContentPage {
    public DataInfoPage() {
        InitializeComponent();
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        await ViewModel.LoadUserRoleCounts();
    }

    /// <summary>
    /// Handles the event when a user role is selected from the list and forwards the selected role to the ViewModel.
    /// </summary>
    private async void OnUserRoleSelected(object sender, SelectedItemChangedEventArgs e) {
        if (e.SelectedItem != null) {
            var selectedField = (Tuple<Role, int>)e.SelectedItem;

            ViewModel.NavigateToEditRoleCommand.Execute(selectedField.Item1);
        }
    }
}
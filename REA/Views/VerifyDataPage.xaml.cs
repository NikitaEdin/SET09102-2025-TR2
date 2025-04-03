using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Maui.Controls;

namespace REA.Views;

public partial class VerifyDataPage : ContentPage {
    // Dummy data
    private List<Data> data;
    // Dummy status
    private List<string> status;
    // Current selected data
    private Data selectedData;
    // Hold user's input 
    private string typedDescription = string.Empty;

    public VerifyDataPage() {
        InitializeComponent();
        LoadDummyData();
    }

    private void LoadDummyData()
    {
        // Create dummy for UI prototype
        data = new List<Data>
        {
            new Data
            {
                ID = 1,
                Type = "Water",
                Description = "No issues",
                Status = "Approved",
                DateCreated = DateTime.Now.AddDays(-3)
            },
            new Data
            {
                ID = 2,
                Type = "Air",
                Description = "Input Out of Bounds",
                Status = "Unapproved",
                DateCreated = DateTime.Now.AddDays(-7)
            },
            new Data
            {
                ID = 3,
                Type = "Weather",
                Description = "Invalid Input",
                Status = "Unapproved",
                DateCreated = DateTime.Now.AddDays(-5)
            }
        };

        // Status options
        status = new List<string> { "Approved", "Unapproved"};

        // Connect data to StatusPicker
        DataListView.ItemsSource = data;
        StatusPicker.ItemsSource = status;
    }

    private void OnDataSelected(object sender, SelectedItemChangedEventArgs e) 
    {
        // Store selected data item
        selectedData = (Data)e.SelectedItem;

        if (selectedData != null) {
            // Set picker to current status
            StatusPicker.SelectedItem = selectedData.Status;

            // Store the current description separately
            typedDescription = selectedData.Description;

            // Show description as a placeholder
            DescriptionEntry.Text = string.Empty;
            DescriptionEntry.Placeholder = selectedData.Description;

            
            SaveButton.IsEnabled = true;
        }
    }

    private void OnStatusSelected(object sender, EventArgs e)
    {
        if (selectedData != null)
        {
            selectedData.Status = StatusPicker.SelectedItem?.ToString();
        }
    }

    private void OnDescriptionChanged(object sender, TextChangedEventArgs e)
    {
        if (selectedData != null)
        {
            // Store new value in temp variable
            typedDescription = e.NewTextValue;

            // Enable save button if description OR status has changed
            bool descriptionChanged = !string.IsNullOrWhiteSpace(typedDescription) && typedDescription != selectedData.Description;
            bool statusChanged = StatusPicker.SelectedItem?.ToString() != selectedData.Status;

            SaveButton.IsEnabled = descriptionChanged || statusChanged;
        }
    }


    private void OnSaveClicked(object sender, EventArgs e)
    {
        if (selectedData != null)
        {
            // Check if description has been changed
            bool descriptionChanged = !string.IsNullOrWhiteSpace(typedDescription) &&
                                      typedDescription != selectedData.Description;

            // Store description if changed
            if (descriptionChanged)
            {
                selectedData.Description = typedDescription;
            }

            // Show user a message to say it has changed
            string message = $"Data ID:{selectedData.ID} is {selectedData.Status} and description is '{selectedData.Description}'";
            DisplayAlert("Success", message, "OK");
        }
        else
        {
            // Show message to users that no item has been selected error
            DisplayAlert("Error", "Please select a data item first.", "OK");
        }
    }

}

// Dummy Data object for prototyping purposes
public class Data
{
    public int ID { get; set; }
    public required string Type { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public required DateTime DateCreated { get; set; }
}
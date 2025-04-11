using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace REA.Views;

public partial class ManageSensorPage : ContentPage {
    // Dummy Sensor
    private List<Sensor> sensor;
    // Dummy type and frequency for pickers
    private List<string> type;
    private List<string> frequency;
    // Current selected sensor
    private Sensor selectedSensor;
    // Hold user's input for URL
    private string typedUrl = string.Empty;

    public ManageSensorPage() {
        InitializeComponent();
        LoadDummyData();
    }

    private void LoadDummyData() {
        // Create dummy for UI prototype
        sensor = new List<Sensor> {

            new Sensor {
                ID = 1,
                Type = "Water quality",
                Url = "https://airly.org/en/features/air-quality-sensors/",
                Frequency = "Hourly"
            },
            new Sensor {
                ID = 2,
                Type = "Weather",
                Url = "https://airly.org/en/features/air-quality-sensors/",
                Frequency = "Hourly"
            },
            new Sensor {
                ID = 3,
                Type = "Air quality",
                Url = "https://airly.org/en/features/air-quality-sensors/",
                Frequency = "Hourly"
            }
        };

        // Type options
        type = new List<string> { "Water quality", "Air quality", "Weather" };
        // Measurement frequency options
        frequency = new List<string> { "Hourly", "Daily" };

        // Connect sensor to TypePicker and FrequencyPicker
        SensorListView.ItemsSource = sensor;
        TypePicker.ItemsSource = type;
        FrequencyPicker.ItemsSource = frequency;
    }

    private void OnSensorSelected(object sender, SelectedItemChangedEventArgs e) {
        // Store selected sensor item
        selectedSensor = (Sensor)e.SelectedItem;

        if (selectedSensor != null) {
            // Set pickers to current type and frequency
            TypePicker.SelectedItem = selectedSensor.Type;
            FrequencyPicker.SelectedItem = selectedSensor.Frequency;

            // Store the current URL separately
            typedUrl = selectedSensor.Url;

            // Show Url as a placeholder
            UrlEntry.Text = string.Empty;
            UrlEntry.Placeholder = selectedSensor.Url;

            SaveButton.IsEnabled = true;
        }
    }

    private void OnTypeSelected(object sender, EventArgs e) {
        if (selectedSensor != null) {
            selectedSensor.Type = TypePicker.SelectedItem?.ToString();
        }
    }

    private void OnFrequencySelected(object sender, EventArgs e) {
        if (selectedSensor != null) {
            selectedSensor.Frequency = FrequencyPicker.SelectedItem?.ToString();
        }
    }

    private void OnUrlChanged(object sender, TextChangedEventArgs e) {
        if (selectedSensor != null) {
            typedUrl = e.NewTextValue;

            // Enable save button if URL OR type has changed
            bool urlChanged = !string.IsNullOrWhiteSpace(typedUrl) && typedUrl != selectedSensor.Url;
            bool typeChanged = TypePicker.SelectedItem?.ToString() != selectedSensor.Type;

            SaveButton.IsEnabled = urlChanged || typeChanged;
        }
    }


    private void OnSaveClicked(object sender, EventArgs e) {
        if (selectedSensor != null) {
            // Check if url has been changed
            bool urlChanged = !string.IsNullOrWhiteSpace(typedUrl) &&
                                      typedUrl != selectedSensor.Url;

            // Store url if changed
            if (urlChanged) {
                selectedSensor.Url = typedUrl;
            }

            // Show user a message to say it has changed
            string message = $"Sensor ID: {selectedSensor.ID} \n- Type: {selectedSensor.Type} \n- Url: {selectedSensor.Url} \n- Measurement Frequency: {selectedSensor.Frequency}";
            DisplayAlert("Success", message, "OK");
        }
        else {
            // Show message to users that no item has been selected error
            DisplayAlert("Error", "Please select a sensor and edit details.", "OK");
        }
    }
}

// Dummy Sensor object for UI prototyping purposes
public class Sensor {
    public int ID { get; set; }
    public required string Type { get; set; }
    public required string Url { get; set; }
    public required string Frequency { get; set; }
}
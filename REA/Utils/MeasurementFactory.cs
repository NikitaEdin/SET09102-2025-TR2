using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.DB;
using REA.Models;
using System.Collections.ObjectModel;

namespace REA.Utils
{
    internal class MeasurementFactory<T>
    {
        private ObservableCollection<T> collection;

        private MeasurementFactory(ObservableCollection<T> genericCollection) 
        { 
            collection = genericCollection;
        }

        private static async Task<MeasurementFactory<AirMeasurement>> CreateAsyncAirCollection()
        {
            var airMessurement = await SQLiteDatabaseService.Instance.GetItemsAsync<AirMeasurement>();
            var airCollection = new ObservableCollection<AirMeasurement>(airMessurement);
            return new MeasurementFactory<AirMeasurement>(airCollection);
        }

        private static async Task<MeasurementFactory<WaterMeasurement>> CreateAsyncWaterCollection()
        {
            var waterMessurement = await SQLiteDatabaseService.Instance.GetItemsAsync<WaterMeasurement>();
            var waterCollection = new ObservableCollection<WaterMeasurement>(waterMessurement);
            return new MeasurementFactory<WaterMeasurement>(waterCollection);
        }

        private static async Task<MeasurementFactory<WeatherMeasurement>> CreateAsyncWeatherCollection()
        {
            var weatherMessurement = await SQLiteDatabaseService.Instance.GetItemsAsync<WeatherMeasurement>();
            var weatherCollection = new ObservableCollection<WeatherMeasurement>(weatherMessurement);
            return new MeasurementFactory<WeatherMeasurement>(weatherCollection);
        }

        /// <summary>
        /// Public method to get the collection
        /// </summary>
        /// <returns>The collection with the configs</returns>
        public ObservableCollection<T> GetConfigurations()
        {
            return collection;
        }
    }
}

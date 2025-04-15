using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.DB;
using REA.Models;

namespace REA.Utils
{
    internal class ConfigFactory
    { 
        private ObservableCollection<Configuration> collection;
        /// <summary>
        /// Constructor that takes in the collection
        /// </summary>
        /// <param name="configCollection"> Collection of the sensor configs</param>
        private ConfigFactory(ObservableCollection<Configuration> configCollection)
        {
            collection = configCollection;
        }
        /// <summary>
        /// Method that takes the data from the database and puts them into a collection
        /// </summary>
        /// <returns>Collection to the constructor to be later used.</returns>
        public static async Task<ConfigFactory> CreateAsync()
        {
            var configs = await SQLiteDatabaseService.Instance.GetItemsAsync<Configuration>();
            var configCollection = new ObservableCollection<Configuration>(configs);
            return new ConfigFactory(configCollection); // Send the collection to the constructor

        }
        /// <summary>
        /// Public method to get the collection
        /// </summary>
        /// <returns>The collection with the configs</returns>
        public ObservableCollection<Configuration> GetConfigurations()
        {
            return collection;
        }
    }
}

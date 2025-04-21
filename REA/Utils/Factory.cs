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
    internal class Factory<T>
    {
        private ObservableCollection<T> collection;

        /// <summary>
        /// Initialises the constructor with the provided generic collection
        /// </summary>
        /// <param name="genericCollection"> This is the collection that gets passed in from the different methods in the factory</param>
        private Factory(ObservableCollection<T> genericCollection) 
        { 
            collection = genericCollection;
        }

        /// <summary>
        /// Populates database data into a collection from the database
        /// </summary>
        /// <returns> Factory that has generic collection </returns>
        internal static async Task<Factory<T>> CreateAsync<T>(IDatabaseService dbService) where T : new() 
        {
            var items = await dbService.GetItemsAsync<T>();
            var collection = new ObservableCollection<T>(items);
            return new Factory<T>(collection);
        }


        /// <summary>
        /// Public method to get the collection
        /// </summary>
        /// <returns>The collection</returns>
        public ObservableCollection<T> GetMeasurements()
        {
            return collection;
        }
    }
}

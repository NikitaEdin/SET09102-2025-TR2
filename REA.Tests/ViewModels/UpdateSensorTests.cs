﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.DB;
using REA.Models;
using REA.ViewModels;
using REA.Tests.Services;
using REA.Utils;

namespace REA.Tests.ViewModels
{
    /// <summary>
    /// Unit tests for the UpdateSensorViewModel
    /// Author: Thomas Smith
    /// </summary>
    public class UpdateSensorTests
    {
        private readonly IDatabaseService fakeDb;
        private UpdateSensorViewModel viewModel;

        public UpdateSensorTests() 
        { 
            viewModel = new UpdateSensorViewModel();
            fakeDb = new FakeDatabaseService();
        }

        [Fact]
        public async Task LoadConfigsTest()
        {
            // Act
            await viewModel.LoadConfigs();

            // Assert
            Assert.NotNull(viewModel.SensorTypes);


        }

        /// <summary>
        /// Test the normal case of converting a string to a float
        /// </summary>
        [Fact]
        public void ConvertStringToFloatTest_Valid()
        {
            // Arrange
            float convertedFloat;
            string input = "0.2";

            // Act
            convertedFloat = viewModel.ConvertStringToFloat(input);

            // Assert
            Assert.IsType<float>(convertedFloat); 
        }

        /// <summary>
        /// Test the case if the method can handle incorrect formats for the input and handle the error with the try catch.
        /// </summary>
        [Fact]
        public void ConvertStringToFloatTest_Invalid() 
        {
            // Arrange
            float convertedFloat;
            string input = "Hello World";

            // Act
            convertedFloat = viewModel.ConvertStringToFloat(input);

            // Assert
            Assert.IsType<float>(convertedFloat);
            Assert.Equal(0,convertedFloat); 
        }

        /// <summary>
        /// Test case to check if the method can handle null values 
        /// </summary>
        [Fact]
        public void ConvertStringToFloatTest_Null()
        {
            float convertedFloat;
            string input = null;

            // Act
            convertedFloat = viewModel.ConvertStringToFloat(input);

            // Assert
            Assert.NotNull(convertedFloat);
            Assert.Equal(0, convertedFloat); 
        }

    }
}

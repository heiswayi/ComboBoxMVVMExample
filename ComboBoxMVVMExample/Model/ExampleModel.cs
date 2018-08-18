using ComboBoxMVVMExample.ViewModel; // ViewModelBase.cs
using System;
using System.Collections.Generic; // List<Country>
//using System.ComponentModel; // [Description("")]

namespace ComboBoxMVVMExample.Model
{
    public class ExampleModel
    {
    }

    /// <summary>
    /// Enum-type object
    /// </summary>
    public enum EnumItem
    {
        Enum01,
        Enum02,
        Enum03
    }

    /// <summary>
    /// Country object
    /// </summary>
    public class Country
    {
        public string CountryName { get; set; }
        public string CountryTwoLetterCode { get; set; }

        public List<Country> getCountries()
        {
            List<Country> returnCountries = new List<Country>();
            returnCountries.Add(new Country() { CountryName = "United States", CountryTwoLetterCode = "US" });
            returnCountries.Add(new Country() { CountryName = "Malaysia", CountryTwoLetterCode = "MY" });
            returnCountries.Add(new Country() { CountryName = "India", CountryTwoLetterCode = "IN" });
            return returnCountries;
        }
    }

    /// <summary>
    /// State object
    /// </summary>
    public class State
    {
        public string CountryTwoLetterCode { get; set; }
        public string StateName { get; set; }

        public List<State> getStatesCollection()
        {
            List<State> returnStates = new List<State>();
            returnStates.Add(new State() { CountryTwoLetterCode = "US", StateName = "New York" });
            returnStates.Add(new State() { CountryTwoLetterCode = "US", StateName = "Alaska" });
            returnStates.Add(new State() { CountryTwoLetterCode = "US", StateName = "West Virginia" });
            returnStates.Add(new State() { CountryTwoLetterCode = "MY", StateName = "Kelantan" });
            returnStates.Add(new State() { CountryTwoLetterCode = "MY", StateName = "Pulau Pinang" });
            returnStates.Add(new State() { CountryTwoLetterCode = "MY", StateName = "Selangor" });
            returnStates.Add(new State() { CountryTwoLetterCode = "IN", StateName = "Mumbai" });
            return returnStates;
        }

        public List<State> getStateByCountryCode(string countryCode)
        {
            List<State> stateList = new List<State>();
            foreach (State currentState in getStatesCollection())
            {
                if (currentState.CountryTwoLetterCode == countryCode)
                {
                    stateList.Add(new State() { CountryTwoLetterCode = currentState.CountryTwoLetterCode, StateName = currentState.StateName });
                }
            }
            return stateList;
        }
    }
}

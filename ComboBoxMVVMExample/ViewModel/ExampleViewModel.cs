using ComboBoxMVVMExample.Model; // ExampleEnum
using System;
using System.Collections.Generic; // IEnumerable
using System.Windows; // MessageBox
using System.Windows.Input; // ICommand
using System.Collections.ObjectModel; // ObservableCollection<Country>


namespace ComboBoxMVVMExample.ViewModel
{
    /// <summary>
    /// This class inherits from ViewModelBase class
    /// </summary>
    public class ExampleViewModel : ViewModelBase
    {
        #region ComboBox using enum type

        #region Fields
        private IEnumerable<EnumItem> _EnumItems;
        private string _EnumSelectedItem;
        private ICommand _ShowEnumItemCommand;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get or set a list of enum items
        /// </summary>
        public IEnumerable<EnumItem> EnumItems
        {
            get {
                return (EnumItem[])Enum.GetValues(typeof(EnumItem));
            }
            set
            {
                if (value != _EnumItems)
                {
                    _EnumItems = value;
                    OnPropertyChanged("EnumItems");
                }
            }
        }

        /// <summary>
        /// Get or set enum selected item
        /// </summary>
        public string EnumSelectedItem
        {
            get { return _EnumSelectedItem; }
            set
            {
                _EnumSelectedItem = value;
                OnPropertyChanged("EnumSelectedItem");
            }
        }

        /// <summary>
        /// Trigger command to show enum item
        /// </summary>
        public ICommand ShowEnumItemCommand
        {
            get
            {
                _ShowEnumItemCommand = new RelayCommand(
                    param => ShowEnumItemMethod()
                );
                return _ShowEnumItemCommand;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Show enum selected item
        /// </summary>
        private void ShowEnumItemMethod()
        {
            // Get combobox current selected value
            MessageBox.Show(EnumSelectedItem);
        }
        #endregion

        #endregion

        #region Cascaded ComboBox using List<T> class

        #region Private Fields
        private List<Country> _CountryList;
        private string _SelectedCountryCode;
        private List<State> _StateList;
        private string _SelectedState;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get or set a list of countries
        /// </summary>
        public List<Country> CountryList {
            get { return _CountryList; }
            set
            {
                _CountryList = value;
                OnPropertyChanged("CountryList");
            }
        }

        /// <summary>
        /// Get or set selected country two-letter code
        /// </summary>
        public string SelectedCountryCode
        {
            get { return _SelectedCountryCode; }
            set
            {
                _SelectedCountryCode = value;
                OnPropertyChanged("SelectedCountryCode");

                // Trigger Enable/Disable UI element when a particular country is selected
                OnPropertyChanged("AllowStateSelection");

                // Generate a new list of states based on a selected country (two-letter code)
                getStateList();
            }
        }

        /// <summary>
        /// Get or set a list of states
        /// </summary>
        public List<State> StateList
        {
            get { return _StateList; }
            set
            {
                _StateList = value;
                OnPropertyChanged("StateList");
            }
        }
        
        /// <summary>
        /// Get or set a selected state
        /// </summary>
        public string SelectedState
        {
            get { return _SelectedState; }
            set
            {
                _SelectedState = value;
                OnPropertyChanged("SelectedState");
            }
        }

        /// <summary>
        /// Return TRUE when user selected a particular country
        /// </summary>
        public bool AllowStateSelection
        {
            get { return (SelectedCountryCode != null); }
        }
        #endregion

        #region Constructors
        public ExampleViewModel()
        {
            // Instantiate, get a list of countries from the Model
            Country _Country = new Country();
            CountryList = _Country.getCountries();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Populate a list of states based on a selected country
        /// </summary>
        private void getStateList()
        {
            // Instantiate, get a list of states based on selected country two-letter code from the Model
            State _State = new State();
            StateList = _State.getStateByCountryCode(SelectedCountryCode);
        }
        #endregion

        #endregion
    }
}

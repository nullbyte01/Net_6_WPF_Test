using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.WPF.Services;
using System.Collections.ObjectModel;
using TestApp.Shared.Models;

namespace TestApp.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Property

        private string _operationMode;
        public string OperationMode
        {
            get { return _operationMode; }
            set
            {
                _operationMode = value;
                OnPropertyChanged(nameof(OperationMode));
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                OnPropertyChanged(nameof(Header));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        private ObservableCollection<Information> _informationCollection;

        public ObservableCollection<Information> InformationCollection
        {
            get
            {
                return _informationCollection;
            }
            set
            {
                _informationCollection = value;
                OnPropertyChanged(nameof(InformationCollection));
            }
        }

        private Information _selectedInformation;

        public Information SelectedInformation
        {
            get { return _selectedInformation; }
            set
            {
                _selectedInformation = value;
                OnPropertyChanged(nameof(_selectedInformation));
            }
        }

        private readonly ITestService _testService;

        private int _NewIdToInsert;

        #endregion

        #region Constructor
        public MainViewModel(ITestService testService)
        {
            _testService = testService;
        }

        private async Task LoadGrid()
        {
            var informations = (await _testService.GetAllInformations()).ToList();
            InformationCollection = new ObservableCollection<Information>(informations);
        }

        #endregion
        private RelayCommand _windowLoadedCommand;
        public RelayCommand WindowLoadedCommand
        {
            get
            {
                return _windowLoadedCommand = new RelayCommand(async () =>
                {
                    Title = "Demo App";
                    await LoadGrid();
                    _NewIdToInsert = InformationCollection.Count;
                    OperationMode = "Add";
                });
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand = new RelayCommand(async () =>
                {
                    Information information = new Information();
                    information.Id = _NewIdToInsert;
                    information.Header = Header;
                    information.Description = Description;

                    if (OperationMode == "Add")
                    {
                        var response = await _testService.AddInformation(information);
                        if (response != null)
                        {
                            await LoadGrid();
                            _NewIdToInsert++;
                        }
                    }
                    else
                    {
                        if (SelectedInformation != null)
                        {
                            var response = await _testService.UpdateInformation(SelectedInformation.Id, information);
                            if (response != null)
                                await LoadGrid();
                        }
                    }

                    ClearCommand.Execute(null);

                });
            }
        }

        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand
        {
            get
            {
                return _clearCommand = new RelayCommand(() =>
                {
                    Id = -1;
                    Header = String.Empty;
                    Description = String.Empty;
                    OperationMode = "Add";
                });
            }
        }

        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand = new RelayCommand(() =>
                {
                    if (SelectedInformation != null)
                    {
                        Id = SelectedInformation.Id;
                        Header = SelectedInformation.Header;
                        Description = SelectedInformation.Description;
                        OperationMode = "Update";
                    }
                });
            }
        }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand = new RelayCommand(async () =>
                {
                    if (SelectedInformation != null)
                    {
                        var msgBxResult = System.Windows.MessageBox.Show("Do you want to delete?", "Confirm", System.Windows.MessageBoxButton.YesNo);
                        if (msgBxResult == System.Windows.MessageBoxResult.Yes)
                        {
                            bool isDeleted = await _testService.DeleteInformation(SelectedInformation.Id);
                            if (isDeleted)
                            {
                                await LoadGrid();
                            }
                        }
                    }
                });
            }
        }
    }
}

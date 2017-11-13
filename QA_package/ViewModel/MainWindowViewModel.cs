using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using XBOXValidator.HelperClasses;
using XBOXValidator.Model;

namespace XBOXValidator.classes
{
    class MainWindowViewModel
    {
        private ICommand _pickFolderCommand;
        private ICommand _readSnapshotsCommand;
        private ICommand _generateSnapshotsCommand;
        private ICommand _clearSnapshotsCommand;
        private ICommand _removeBreakOnRootCommand;
        private FolderBrowserDialog openFolder = new FolderBrowserDialog();
        private FolderPathModel folderPathModel;
        private FileSeeker snapshotFileSeeker;
        public SnapshotsListModel snapshotListModel { get; }

        public MainWindowViewModel()
        {
            this.folderPathModel = new FolderPathModel();
            this.snapshotListModel = new SnapshotsListModel();
        }

        

        //command ktery vola vybirani formulare
        public ICommand PickFolderCommand
        {

            get
            {
                if (_pickFolderCommand == null)
                {
                    _pickFolderCommand = new RelayCommand(
                        param => this.CanPickFolder(),
                        param => this.PickFolder()
                        );

                }
                return _pickFolderCommand;
            }

        }


        public ICommand ReadSnapsotsCommand {
            get {
                if (_readSnapshotsCommand == null)
                {
                    _readSnapshotsCommand = new RelayCommand(
                        param => this.CanReadSnapshots(),
                        param => this.ReadSnapshots()
                        );
                }
                return _readSnapshotsCommand;

            }

        }

        public ICommand GenerateSnapshotsCommand {
            get
            {
                if (_generateSnapshotsCommand == null) {

                    _generateSnapshotsCommand = new RelayCommand(
                        param => this.CanGenerateSnapshots(),
                        param => this.GenerateSnapshots()                        
                        );
                }

                return _generateSnapshotsCommand;

            }
        }

        public ICommand ClearSnapshotsCommand {
            get
            {
                if (_clearSnapshotsCommand == null)
                {

                    _clearSnapshotsCommand = new RelayCommand(
                        param => this.CanClearSnapshots(),
                        param => this.ClearSnapshots()
                        );
                }

                return _clearSnapshotsCommand;

            }
        }

        public ICommand RemoveBreakOnRootCommand {
            get {
                if (_removeBreakOnRootCommand == null) {

                    _removeBreakOnRootCommand = new RelayCommand(
                        param => this.CanRemoveBreakOnRoot(),
                        param => this.RemoveBreakOnRoot()
                        
                        );
                }
                return _removeBreakOnRootCommand;
            }
        }

        private void RemoveBreakOnRoot() {
            

            this.snapshotListModel.RemoveBreakOnRoot();
        }

        private bool CanRemoveBreakOnRoot() {
            return true;
        }

        private void ClearSnapshots() {
            this.snapshotListModel.RemoveAllItems();
        }

        public bool CanClearSnapshots() {
            return true;
        }

        private void GenerateSnapshots() {
            this.snapshotListModel.GenerateSnapshotOutput();
        }

        private bool CanGenerateSnapshots() {
            return true;
        }

        private void ReadSnapshots() {
            
            snapshotFileSeeker = new FileSeeker(this.FolderPathModel.FolderPath,this.snapshotListModel);
        }

        private bool CanReadSnapshots() {
            return true;
        }

        // nastaveni setteru a geretu pro FolderPathModel, ktery uchovava adresar ktery se bude zpracovavat
        public FolderPathModel FolderPathModel
        {
            get
            {
                return folderPathModel;
            }
            set
            {
                folderPathModel = value;
            }
        }

        //metoda vytvarejici folder picker a zaroven nastavuje adresar modelu
        private void PickFolder()
        {
            FolderBrowserDialog folderPicker = new FolderBrowserDialog();
            openFolder.SelectedPath = "C:\\";
            DialogResult result = openFolder.ShowDialog();
            if (result.ToString() == "OK")
            {
                folderPathModel.FolderPath = openFolder.SelectedPath;
            }

        }

        // funkce v ktere je mozne overovat, zda je mozne vybirat adresar
        private bool CanPickFolder()
        {
            return true;
        }


    }
}

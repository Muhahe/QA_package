using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using XBOXValidator.Classes;
using XBOXValidator.Model;

namespace XBOXValidator.classes
{
    class FolderPicker
    {
        private ICommand _pickFolderCommand;
        private FolderBrowserDialog openFolder = new FolderBrowserDialog();
        private FolderPathModel folderPathModel;

        public FolderPicker() {
            folderPathModel = new FolderPathModel();
        }

        public ICommand PickFolderCommand {

            get {
                if (_pickFolderCommand == null) {
                    _pickFolderCommand = new RelayCommand(
                        param => this.CanPickFolder(),
                        param => this.PickFolder()                        
                        );

                }
                return _pickFolderCommand;
            }

        }

        public FolderPathModel FolderPathModel {
            get {
                return folderPathModel;
            }
            set {
                folderPathModel = value;
            }                
        }


        private void PickFolder() {
            FolderBrowserDialog folderPicker = new FolderBrowserDialog();
            openFolder.SelectedPath = "C:\\";
            DialogResult result = openFolder.ShowDialog();
            if (result.ToString() == "OK") {
                folderPathModel.FolderPath = openFolder.SelectedPath;               
            }

        }

        private bool CanPickFolder() {
            return true;
        }


    }
}

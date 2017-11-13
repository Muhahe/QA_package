using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XBOXValidator.Model
{
    class FolderPathModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String _folderPath = "c:\\Users\\lubos\\OneDrive\\Dokumenty\\!snapshots\\";



        public String FolderPath
        {
            get
            {
                return _folderPath;
            }
            set
            {
                if (_folderPath != value)
                {
                    _folderPath = value;
                    OnPropertyChanged("FolderPath");
                }
            }
        }

        private void validateFolder()
        { 
            //todo chec
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

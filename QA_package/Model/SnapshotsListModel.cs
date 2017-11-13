using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBOXValidator.Model
{
    class SnapshotsListModel
    {
        private ObservableCollection<SingleSnapshotModel> _SnapshotItems = new ObservableCollection<SingleSnapshotModel>();
        public ObservableCollection<SingleSnapshotModel> SnapshotItems { get { return _SnapshotItems; } set { _SnapshotItems = value; } }

        private ObservableCollection<SingleSnapshotModel> _BackupSnapshotItems = new ObservableCollection<SingleSnapshotModel>();
        private String SnapshotOutputString = "";
        private String SnapshotOutputFileName;

        public void AddItem(String pathToSnapshot) {

            SingleSnapshotModel snapshot = new SingleSnapshotModel(pathToSnapshot);
            this.SnapshotItems.Add(snapshot);
            this._BackupSnapshotItems.Add(snapshot);
            
        }

        public void GenerateSnapshotOutput() {
            this.SnapshotOutputFileName = "snapshots.txt";
            this.SnapshotOutputString = "";
            foreach (var snapshot in _SnapshotItems) {
                if (snapshot.Included == true) {
                    this.SnapshotOutputString += "wh_ai_OpenReplayLog " + snapshot.SnapshotPath + "; ";
                }
            }

            File.WriteAllText(this.SnapshotOutputFileName,this.SnapshotOutputString);
        }

        public void RemoveAllItems() {
            this.SnapshotItems.Clear();
            this._BackupSnapshotItems.Clear();
        }

        public void RemoveBreakOnRoot() {

            for (int i = _SnapshotItems.Count - 1; i >= 0; i--) {
                if (_SnapshotItems[i].ErrorMessage == "OnInit branch in root has failed. Reporting due to the BreakOnRootFail compatibility mode") {
                    _SnapshotItems.RemoveAt(i);
                }else if(_SnapshotItems[i].ErrorMessage == "Root has failed. Reporting due to the BreakOnRootFail compatibility mode")
                {
                    _SnapshotItems.RemoveAt(i);
                }

            }
         
        }

        public void UniqItemsInCollection() {
          


        }

        private void BackupSnapshots() {
            this._BackupSnapshotItems = this.SnapshotItems;
        }

        private void RestoreBackupSnapshots() {
            this.SnapshotItems = this._BackupSnapshotItems;
        }

      
    }
}

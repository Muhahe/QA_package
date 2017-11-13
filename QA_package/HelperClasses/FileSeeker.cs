using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WHSQA.Model;

namespace WHSQA.HelperClasses
{
    class FileSeeker
    {
        private String FolderPath;
        private String[] Folders { get; set; }
        private SnapshotsListModel snapshotListModel;
        private Regex folderPattern = new Regex("[0000-9999]_[0000-9999]");
        private String[] SnapshotSubfolders;
        private String[] SnapshotFiles;

        public FileSeeker(String FolderPath,SnapshotsListModel snapshotListModel) {
            this.FolderPath = FolderPath;
            this.snapshotListModel = snapshotListModel;
            ListDirectories();
        }
        //dodelat at nacita pouze adresare ktere odpovidaji regexpu, NNNN_NNNN a da je nekam do listu a pak je zpracovat separe. 
        // vytahnout xmlko, z cesty urcit nazev a cislo entity a chyby a celkove naplnit snapshot model. A upravit 
        // view at to spravne zobrazuje v tabulce. Dale zvetsit okno atp atp atp
        private void ListDirectories() {
            this.Folders = System.IO.Directory.GetDirectories(this.FolderPath, "*", System.IO.SearchOption.TopDirectoryOnly);

            foreach(var dirName in this.Folders){
                if (folderPattern.IsMatch(dirName)) {
                    this.SnapshotSubfolders = System.IO.Directory.GetDirectories(dirName, "*", System.IO.SearchOption.TopDirectoryOnly);
                    foreach(var entityDirName in this.SnapshotSubfolders) {
                        this.SnapshotFiles = System.IO.Directory.GetFiles(entityDirName, "*.xml");
                        foreach (var snapshotFileName in this.SnapshotFiles) {
                            this.snapshotListModel.AddItem(snapshotFileName);
                        }
                        
                    }
                }
                // Console.WriteLine(dir);
            }
        }

        

    }
}

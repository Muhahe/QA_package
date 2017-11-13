using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHSQA.HelperClasses;

namespace WHSQA.Model
{
    class SingleSnapshotModel
    {
        public String SnapshotPath { get; }
        public String EntityNumber { get; }
        public String ErrorNumber { get; }
        public String SnapshotId { get; }
        public String EntityName { get; }
        public String ErrorNode { get; }
        public String ErrorMessage {get;}
        public bool Included { get; set; }

        public SingleSnapshotModel(String path) {
            this.SnapshotPath = path;
            this.Included = true;
            String[] splitedPath = path.Split(new string[] { Path.DirectorySeparatorChar.ToString() }, StringSplitOptions.None);
            int pathCount = splitedPath.Count();

            this.EntityName = splitedPath[pathCount - 2];
            this.SnapshotId = splitedPath[pathCount - 3];
            this.EntityNumber = this.SnapshotId.Split('_').First();
            this.ErrorNumber = this.SnapshotId.Split('_').Last();
            XmlFileReader xmlFileReader = new XmlFileReader(path);

            this.ErrorMessage = xmlFileReader.GetErrorNodeText();
        }

        private void SetEntityNumber() {

        }

        




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBOXValidator.Model
{
    class SingleSnapshotModel
    {
        private String SnapshotPath { get; }
        private String EntityName { get; }
        private String ErrorNode { get; }
        private String ErrorMessage {get;}


        public SingleSnapshotModel(String path) {
            this.SnapshotPath = path;
        }

        
    }
}

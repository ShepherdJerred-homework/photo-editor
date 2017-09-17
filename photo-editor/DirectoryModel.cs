using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photo_editor {
    class DirectoryModel {
        public DirectoryInfo directory { get; set; }
        FileInfo[] getImagesInDirectory() {
            FileInfo[] files = directory.GetFiles("*.jpg");
            return files;
        }
    }
}

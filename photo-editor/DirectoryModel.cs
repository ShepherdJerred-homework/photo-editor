using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photo_editor {
    class DirectoryModel {
        public DirectoryInfo directory { get; set; }

        public DirectoryModel() {
            directory = new DirectoryInfo("/");
        }

        public DirectoryModel(string path) {
            directory = new DirectoryInfo(path);
        }

        public FileInfo[] getImagesInDirectory() {
            FileInfo[] files = directory.GetFiles("*.jpg");
            return files;
        }
    }
}

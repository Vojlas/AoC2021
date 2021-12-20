using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC2021
{
    public abstract class Day
    {
        public string path = "";
        public abstract string completed();
        public abstract string name();


        public Day()
        {
        }
        
        public void GetPath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (DialogResult.OK == dialog.ShowDialog())
            {
                path = dialog.FileName;
            }
        }

        public string[] ReadFile()
        {
            string[] lines = File.ReadAllLines(this.path);
            return lines;
        }
    }
}

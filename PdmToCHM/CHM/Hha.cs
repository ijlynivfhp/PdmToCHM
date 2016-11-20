using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;

namespace CHMUtil
{
    public  class Hha
    {
        string log1;
        string log2;

        delegate bool GetInfo(string log);

        //编译信息
        public bool GetInfo1(string log)
        {
            log1 = log;
            return true;
        }

        //进度信息
        public bool GetInfo2(string log)
        {
            log2 = log;
            return true;
        }

        [DllImport(@"hha.dll")]
        private extern static void HHA_CompileHHP(string hhpFile, GetInfo g1, GetInfo g2, int stack);

        public void Compile(string hhpfile)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "hha.dll");
            //if (!File.Exists(path))
            //{
                String projectName = Assembly.GetExecutingAssembly().GetName().Name.ToString();
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(projectName + ".DllImport." + "hha.dll");
                byte[] bs = new byte[stream.Length];
                stream.Read(bs, 0, (int)stream.Length);
                stream.Close();
                File.WriteAllBytes(path, bs);
            //}
                 
            HHA_CompileHHP(hhpfile, GetInfo1, GetInfo2, 0);
        }
    }
}

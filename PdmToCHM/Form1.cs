using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PdmModels;
using System.IO;
using PdmUtil;
using CHMUtil;
using System.Threading;

namespace PDMToCHM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void BtnBrow_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                FileName = "",
                Filter = "(*.pdm)|*.pdm",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtMulItem.Text = string.Join("\r\n", openFileDialog.FileNames);
            }
        }

        static HashSet<string> lstPhs = new HashSet<string>();
        static string title = string.Empty;


        static IList<TableInfo> lstTabs = new List<TableInfo>();       
        private void BtnBuild_Click(object sender, EventArgs e)
        {   
            string[] paths = txtMulItem.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ph in paths)
            {
                string extName = Path.GetExtension(ph).ToLower();
                if (File.Exists(ph) && extName == ".pdm")
                {
                    lstPhs.Add(ph);
                }
            }
            txtMulItem.Text = string.Join("\r\n", lstPhs);
            title = txtChmName.Text.TrimEnd('.','c', 'h', 'm', 'C', 'H', 'M');

            Thread thread = new Thread(CrateCHM);
            thread.IsBackground = true;          
            thread.Start(lstPhs.ToArray());

        }

        static IList<TableInfo> GetTables(params string[] pdmPaths)
        {
            List<TableInfo> lstTables = new List<TableInfo>();
            var pdmReader = new PdmReader();
            foreach (string path in pdmPaths)
            {
                if (File.Exists(path))
                {
                    var models = pdmReader.ReadFromFile(path);
                    lstTables.AddRange(models.Tables);
                }
            }
            lstTables = lstTables.OrderBy(t => t.Code).ToList();
            return lstTables;
        }

        void CrateCHM(object phs)
        {
            
            try
            {
                string[] pdmPaths = phs as string[];

                lstTabs = GetTables(pdmPaths);

                string defaultHtml = "数据库表目录.html";
                string tempPath = Path.GetFullPath("tmp");
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                else
                {
                    Directory.Delete(tempPath, true);
                    Directory.CreateDirectory(tempPath);
                }
                ChmHtmlHelper.CreateDirHtml("数据库表目录", lstTabs, Path.Combine(tempPath, defaultHtml));

                //创建表结构的html
                tempPath = Path.GetFullPath("tmp\\表结构");
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                ChmHtmlHelper.CreateHtml(lstTabs, tempPath);


                //编译CHM文档
                ChmHelp c3 = new ChmHelp();
                c3.DefaultPage = defaultHtml;
                c3.Title = title;
                c3.ChmFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), c3.Title + ".chm");
                c3.SourcePath = "tmp";
                c3.Compile();

                SetMsg("生成成功！文件路径：" + c3.ChmFileName, true);

            }
            catch (Exception ex)
            {
                SetMsg(ex.Message, false);
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void SetMsg(string msg, bool isok)
        {
            labMsg.Text = msg;
            if (isok)
            {
                labMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                labMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}

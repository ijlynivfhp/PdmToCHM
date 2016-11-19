using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using PdmModels;

namespace System
{
    public static class StringExt
    {
        public static string FormatString(this string s, params object[] args)
        {
            return string.Format(s, args);
        }
    }
}




namespace CHMUtil
{
    /// <summary>
    /// 常用功能类
    /// </summary>
    public class ChmHtmlHelper
    {


        public static void CreateDirHtml(string tabDirName, IList<TableInfo> lstTabs, string path)
        {
            var code = new StringBuilder();
            code.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            code.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            code.AppendLine("<head>");
            code.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />");
            code.AppendLine("    <title>{0}</title>".FormatString(tabDirName));
            code.AppendLine("    <style type=\"text/css\">");
            code.AppendLine("        *");
            code.AppendLine("        {");
            code.AppendLine("            font-family:'微软雅黑';");
            code.AppendLine("        }");
            code.AppendLine("        body");
            code.AppendLine("        {");
            code.AppendLine("            font-size: 9pt;");
            code.AppendLine("            font-family:'lucida console';");
            code.AppendLine("        }");
            code.AppendLine("        .styledb");
            code.AppendLine("        {");
            code.AppendLine("            font-size: 14px;");
            code.AppendLine("        }");
            code.AppendLine("        .styletab");
            code.AppendLine("        {");
            code.AppendLine("            font-size: 14px;");
            code.AppendLine("            padding-top: 15px;");
            code.AppendLine("        }");
            code.AppendLine("        a");
            code.AppendLine("        {");
            code.AppendLine("            color: #015FB6;");
            code.AppendLine("        }");
            code.AppendLine("        a:link, a:visited, a:active");
            code.AppendLine("        {");
            code.AppendLine("            color: #015FB6;");
            code.AppendLine("            text-decoration: none;");
            code.AppendLine("        }");
            code.AppendLine("        a:hover");
            code.AppendLine("        {");
            code.AppendLine("            color: #E33E06;");
            code.AppendLine("        }");
            code.AppendLine("    </style>");
            code.AppendLine("</head>");
            code.AppendLine("<body>");
            code.AppendLine("    <div style=\"text-align: center\">");
            code.AppendLine("        <div>");
            code.AppendLine("            <table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" width=\"90%\">");
            code.AppendLine("                <tr>");
            code.AppendLine("                    <td bgcolor=\"#FBFBFB\">");
            code.AppendLine("                        <table cellspacing=\"0\" cellpadding=\"5\" border=\"1\" width=\"100%\" bordercolorlight=\"#D7D7E5\" bordercolordark=\"#D3D8E0\">");
            code.AppendLine("                        <caption>");
            code.AppendLine("        <div class=\"styletab\">{0}</div>".FormatString("<b>" + tabDirName + "</b>"));
            code.AppendLine("                        </caption>");
            code.AppendLine("                          <tr bgcolor=\"#F0F0F0\"><td>序号</td><td>表名</td><td>表说明</td></tr>");


            //构建表头
            int j = 1;          
            //构建数据行
            foreach (TableInfo tab in lstTabs)
            {
                code.AppendLine("            <tr>");
                code.AppendLine("            <td>{0}</td>".FormatString(j));
                code.AppendLine("            <td>{0}</td>".FormatString("<a href=\"表结构\\" + tab.Code + " " + tab.Name.Replace("/", "▪").Replace("\\","▪") + ".html\">" + tab.Code + "</a>"));
                code.AppendLine("            <td>{0}</td>".FormatString(tab.Name));
                code.AppendLine("            </tr>");
                j++;
            }
            code.AppendLine("                        </table>");
            code.AppendLine("                    </td>");
            code.AppendLine("                </tr>");
            code.AppendLine("            </table>");
            code.AppendLine("        </div>");
            code.AppendLine("    </div>");
            code.AppendLine("</body>");
            code.AppendLine("</html>");
            File.WriteAllText(path, code.ToString(), Encoding.GetEncoding("gb2312"));
        }


        public static void CreateHtml(IList<TableInfo> lstTabs, string tabsdir)
        {
            
            foreach (var tab in lstTabs)
            {
                string tabPath = tabsdir + "\\" + tab.Code + " " + tab.Name.Replace("/", "▪").Replace("\\", "▪") + ".html";

                var code = new StringBuilder();
                code.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                code.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
                code.AppendLine("<head>");
                code.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />");
                code.AppendLine("    <title>{0}</title>".FormatString(tab.Code));
                code.AppendLine("    <style type=\"text/css\">");
                code.AppendLine("        *");
                code.AppendLine("        {");
                code.AppendLine("            font-family:'微软雅黑';");
                code.AppendLine("        }");
                code.AppendLine("        body");
                code.AppendLine("        {");
                code.AppendLine("            font-size: 9pt;");
                code.AppendLine("            font-family:'lucida console';");
                code.AppendLine("        }");
                code.AppendLine("        .styledb");
                code.AppendLine("        {");
                code.AppendLine("            font-size: 14px;");
                code.AppendLine("        }");
                code.AppendLine("        .styletab");
                code.AppendLine("        {");
                code.AppendLine("            font-size: 14px;");
                code.AppendLine("            padding-top: 15px;");
                code.AppendLine("        }");
                code.AppendLine("        a");
                code.AppendLine("        {");
                code.AppendLine("            color: #015FB6;");
                code.AppendLine("        }");
                code.AppendLine("        a:link, a:visited, a:active");
                code.AppendLine("        {");
                code.AppendLine("            color: #015FB6;");
                code.AppendLine("            text-decoration: none;");
                code.AppendLine("        }");
                code.AppendLine("        a:hover");
                code.AppendLine("        {");
                code.AppendLine("            color: #E33E06;");
                code.AppendLine("        }");
                code.AppendLine("    </style>");
                code.AppendLine("</head>");
                code.AppendLine("<body>");
                code.AppendLine("    <div style=\"text-align: center\">");
                code.AppendLine("        <div>");
                code.AppendLine("            <table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" width=\"90%\">");
                code.AppendLine("                <tr>");
                code.AppendLine("                    <td bgcolor=\"#FBFBFB\">");
                code.AppendLine("                        <table cellspacing=\"0\" cellpadding=\"5\" border=\"1\" width=\"100%\" bordercolorlight=\"#D7D7E5\" bordercolordark=\"#D3D8E0\">");
                code.AppendLine("                        <caption>");
                code.AppendLine("        <div class=\"styletab\">{0}{1}</div>".FormatString(
                    tab.Code,
                    "<a href='../数据库表目录.html' style='float: right; margin-top: 6px;'>返回目录</a>"));
                code.AppendLine("                        </caption>");
                code.AppendLine("<tr bgcolor=\"#F0F0F0\"><td>序号</td><td>列名</td><td>数据类型</td><td>长度</td><td>主键</td><td>自增</td><td>允许空</td><td>列说明</td></tr>");

                int j = 1;
                foreach (var col in tab.Columns)
                {
                    code.AppendLine("<tr bgcolor=\"#F0F0F0\"><td>" + j + "</td><td>" + col.Code + "</td><td>" + col.DataType + "</td><td>" + (string.IsNullOrEmpty(col.Length) ? "&nbsp;" : col.Length) + "</td><td>" + (col.IsPrimaryKey ? "√" : "&nbsp;") + "</td><td>" + (col.Identity ? "√" : "&nbsp;") + "</td><td>" + (col.Mandatory ? "√" : "&nbsp;") + "</td><td>" + col.Name + (!string.IsNullOrEmpty(col.Description) ? "," + col.Description : "") + "</td></tr>");
                    j++;
                }
                code.AppendLine("                        </table>");
                code.AppendLine("                    </td>");
                code.AppendLine("                </tr>");
                code.AppendLine("            </table>");
                code.AppendLine("        </div>");
                code.AppendLine("    </div>");
                code.AppendLine("</body>");
                code.AppendLine("</html>");
                File.WriteAllText(tabPath, code.ToString(), Encoding.GetEncoding("gb2312"));
                j++;
            }
        }


       
    }
}

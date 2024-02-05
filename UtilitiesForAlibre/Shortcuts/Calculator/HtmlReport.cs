using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Bolsover.Shortcuts.Model;
using DevExpress.Utils.Svg;

namespace Bolsover.Shortcuts.Calculator
{
    public class HtmlReport
    {
       private readonly int _maxrows = 20;

        public string BuildReport(string profile)
        {
            var userShortcuts = RetrieveUserShortcuts(profile);
            var standardShortcuts = RetrieveStandardShortcuts(profile);
            string[] titles = {"Icon", "Hint", "Shortcut"};

            if (userShortcuts.Count > 0)
            {
                ShortcutsCalculator calculator = new();
                Dictionary<string, AlibreShortcut> standardShortcutsDict = calculator.ShortcutsDictionary(standardShortcuts);
                foreach (AlibreShortcut sc in userShortcuts)
                {
                    if (standardShortcutsDict.TryGetValue(sc.Profile + "." + sc.Command, out AlibreShortcut standardShortcut))
                    {
                        sc.ShortcutType = standardShortcut.KeyChar == sc.KeyChar ? ShortcutType.Default : ShortcutType.Override;
                    }
                    else
                    {
                        sc.ShortcutType = ShortcutType.Custom;
                    }
                }

                return BuildHtml(userShortcuts, titles, CalcTableCount(userShortcuts, _maxrows), false, profile);
            }

            return BuildHtml(standardShortcuts, titles, CalcTableCount(standardShortcuts, _maxrows), true, profile);
        }

        private string BuildHtml(List<AlibreShortcut> shortcuts, string[] titles, int subTables, bool isStandard, string profile)
        {
            StringBuilder sb = new();
            sb.Append(BuildHtmlHeader());
            sb.Append(BuildStyle());
            sb.Append(BuildBodyHeader(profile, isStandard));
            sb.Append(subTables > 0 ? BuildTableData(shortcuts, titles, subTables) : BuildSingleTable(shortcuts, titles));
            sb.Append(BuildBodyFooter());
            sb.Append(BuildHtmlFooter());
            return sb.ToString();
        }

        private string BuildStyle()
        {
            return @"<style>  table, th, td {  border: 1px solid black;  border-collapse: collapse;  }  th, td {  padding: 5px;  text-align: left;  }  </style>
                <style> table {float:left; margin-left: 5px; margin-right: 5px;} </style>";
        }

        private string BuildTableData(List<AlibreShortcut> shortcuts, string[] titles, int subTables)
        {
            StringBuilder sb = new();
            int processedRows = 0;
            int j = 0;
            for (int i = 0; i < subTables; i++)
            {
                sb.Append(BuildTableHeader());
                sb.Append(BuildTableTitles(titles));
                while (processedRows < _maxrows)
                {
                    var alibreShortcut = shortcuts[j];
                    sb.Append(BuildRow(alibreShortcut));
                    processedRows++;
                    j++;
                }

                processedRows = 0;
                sb.Append(BuildTableFooter());
            }

            return sb.ToString();
        }

        private string BuildSingleTable(List<AlibreShortcut> shortcuts, string[] titles)
        {
            StringBuilder sb = new();
            sb.Append(BuildTableHeader());
            sb.Append(BuildTableTitles(titles));
            for (int i = 0; i < shortcuts.Count; i++)
            {
                var alibreShortcut = shortcuts[i];
                sb.Append(BuildRow(alibreShortcut));
            }

            sb.Append(BuildTableFooter());
            return sb.ToString();
        }

        private string BuildRow(AlibreShortcut alibreShortcut)
        {
            StringBuilder sb = new();
            string color = alibreShortcut.ShortcutType switch
            {
                ShortcutType.Default => "height=\"25px\"",
                ShortcutType.Custom => " style=\"color:#0000ff;\"height=\"25px\"",
                ShortcutType.Override => " style=\"color:#ff0000;\"height=\"25px\"",
                _ => ""
            };
            sb.Append($"<tr {color}>");
            string imgSrc = "data:image/png;base64," + SvgToPng(alibreShortcut.SvgImage);
            sb.Append("<td> <img src=" + imgSrc);
            sb.Append($" alt=\"{alibreShortcut.Command}\" style=\"width:25px;height:25px;\"></img> </td>");
            sb.Append("<td>");
            sb.Append(alibreShortcut.Hint);
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append(alibreShortcut.KeyChar);
            sb.Append("</td>");
            sb.Append("</tr>");
            return sb.ToString();
        }

        /// <summary>
        /// Converts an SvgImage to a PNG format and returns it as a base64 string.
        /// </summary>
        /// <param name="svgImage">The SvgImage to be converted.</param>
        /// <returns>A base64 string representing the PNG image, or null if the input is null.</returns>
        private string SvgToPng(SvgImage svgImage)
        {
            if (svgImage == null) return null;
            var stream = new MemoryStream();
            var svgBitmap = SvgBitmap.Create(svgImage);
            var img = svgBitmap.Render(null, 0.8);
            img.Save(stream, ImageFormat.Png);
            var buffer = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(buffer, 0, (int) stream.Length);
            return Convert.ToBase64String(buffer);
        }

        private string BuildTableTitles(string[] titles)
        {
            StringBuilder sb = new();
            sb.Append("<tr>");

            foreach (var s in titles)
            {
                sb.Append("<th>");
                sb.Append(s);
                sb.Append("</th>");
            }

            sb.Append("</tr>");
            return sb.ToString();
        }

        /// <summary>
        /// The main table is split into multiple tables to fit the page.
        /// 
        /// </summary>
        /// <param name="shortcuts"></param>
        /// <returns></returns>
        private int CalcTableCount(List<AlibreShortcut> shortcuts, int maxRows)
        {
            return shortcuts.Count / maxRows;
        }

        private List<AlibreShortcut> RetrieveUserShortcuts(string profile)
        {
            ShortcutsCalculator calculator = new();
            return calculator.RetrieveUserShortcutsByProfile(profile);
        }

        private List<AlibreShortcut> RetrieveStandardShortcuts(string profile)
        {
            ShortcutsCalculator calculator = new();
            return calculator.RetrieveStandardShortcutsByProfile(profile);
        }

        private string BuildTableHeader()
        {
            StringBuilder sb = new();
            sb.Append("<table>");
            return sb.ToString();
        }

        private string BuildTableFooter()
        {
            StringBuilder sb = new();
            sb.Append("</table>");
            return sb.ToString();
        }

        private string BuildBodyHeader(string profile, bool isStandard)
        {
            StringBuilder sb = new();
            sb.Append("<body>");
            
            string texta =    $"<p><span style = \"color:black\">Black - Standard Shortcut " +
                              $"</span> <span style = \"color:red\">Red - Overridden Standard " +
                              $"</span><span style = \"color:blue\">Blue - Custom Shortcut " +
                              $"</span> </p><p><b>Profile: <span style = \"color:black\"> {profile}</span></b></p>";
            string textb =
                $"<p><b><span style = \"color:black\">No Custom Shortcuts found, showing Standard Shortcuts only. " +
                $"</span></b></p><p><b><span style = \"color:black\">To assign Custom Shortcuts use the System Options | All Workspaces | Keyboard Shortcuts dialog. " +
                $"</span></b></p><p><b>Profile: <span style = \"color:black\">{profile}</span></b></p>";
            sb.Append(isStandard ? textb : texta);
            return sb.ToString();
        }

        private string BuildBodyFooter()
        {
            StringBuilder sb = new();
            sb.Append("</body>");
            return sb.ToString();
        }

        private string BuildHtmlHeader()
        {
            StringBuilder sb = new();
            sb.Append("<html>");
            return sb.ToString();
        }

        private string BuildHtmlFooter()
        {
            StringBuilder sb = new();
            sb.Append("</html>");
            return sb.ToString();
        }
    }
}
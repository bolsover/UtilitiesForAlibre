using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using com.alibre.executive.locale;
using com.alibre.utils;
using NUnit.Framework;

namespace UnitTests
{
    public class ProfileTests
    {
        private readonly string filePath = "D:/Repository/Jetbrains/Bolsover/UtilitiesForAlibre/settings.pdf";
        private readonly string htmlFilePath = "D:/Repository/Jetbrains/Bolsover/UtilitiesForAlibre/settings.html";
        private readonly ConsoleIO io = new();
        private readonly StringBuilder sb = new();
        
        
        [Test]
        public void TestProfile()
        {
            string[] arguments = {"D:/Repository/Jetbrains/Bolsover/UtilitiesForAlibre/User.NET.profile_27"};
            
            LinearMap mapping;
            {
                FileStream fs = null;
                try
                {
                    if (arguments.Length != 1)
                        throw new Exception("usage: Profile <profile-file-name>");
                    
                    
                    fs = new FileStream(arguments[0], FileMode.Open);
                    var o = (Profile) ReadObjectFromFile(fs);
                    mapping = o.Mapping;
                    
                    for (var i = 0; i < mapping.Pairs.Length; i++)
                    {
                        var mappingPair = mapping.Pairs[i];
                        
                        var first = mappingPair.toWrappedObject().first;
                        var second = mappingPair.toWrappedObject().second;
                        
                        
                        var child = first.ToString();
                        
                        
                        if (second is Profile)
                        {
                            var p = (Profile) second;
                            DumpProfile(p, child);
                        }
                    }
                    
                    PrintToText(sb.ToString());
                    var html = AddHtmlHeaderFooter(ConvertCsvToHtmlTable(sb.ToString()));
                    //io.WriteLine(html);
                    PrintToHtml(html);
                }
                
                catch (Exception ex)
                {
                    io.WriteLine(ex.Message);
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
        }
        
        private string ConvertCsvToHtmlTable(string csvData)
        {
            var html = new StringBuilder("<table>");
            html.Append("<tr><th>Profile</th><th>Command</th><th>Shortcut</th></tr>\n");
            
            var rows = csvData.Split('\n');
            foreach (var row in rows)
            {
                html.Append("<tr>");
                var columns = row.Split(',');
                foreach (var column in columns)
                {
                    html.Append($"<td>{column}</td>");
                }
                
                html.Append("</tr>\n");
            }
            
            html.Append("</table>");
            
            return html.ToString();
        }
        
        private string AddHtmlHeaderFooter(string html)
        {
            var header =
                @"<html><head><style>  table, th, td {  border: 1px solid black;  border-collapse: collapse;  }  th, td {  padding: 5px;  text-align: left;  }  </style></head><body>";
            var footer = @"</body></html>";
            return header + html + footer;
        }
        
        public object ReadObjectFromFile(
            FileStream fileStream)
        {
            var formatter = new BinaryFormatter();
            formatter.Context = new StreamingContext(StreamingContextStates.All);
            var surrogateSelector = new SurrogateSelector();
            surrogateSelector.AddSurrogate(typeof(Profile), new StreamingContext(StreamingContextStates.All),
                new ProfileSerializationSurrogate());
            formatter.SurrogateSelector = surrogateSelector;
            
            
            var obj = formatter.Deserialize(fileStream);
            
            return obj;
        }
        
        private void DumpProfile(Profile profile, string parent)
        {
            var mapping = profile.Mapping;
            
            
            for (var i = 0; i < mapping.Pairs.Length; i++)
            {
                var mappingPair = mapping.Pairs[i];
                
                var first = mappingPair.toWrappedObject().first;
                var second = mappingPair.toWrappedObject().second;
                
                
                var child = parent + ", " + first;
                var kc = new KeysConverter();
                var keyChar = kc.ConvertToString(second);
                if (child.ToUpper().Contains("SHORTCUTS") && !second.ToString().ToUpper().Contains("PROFILE"))
                {
                    var toRemove = "SHORTCUTS,";
                    child = child.Remove(child.IndexOf(toRemove), toRemove.Length);
                    
                    toRemove = first.ToString();
                    var replace = LString.getLocalizedString(first.ToString(), LStringToken.ToolbarHint);
                    if (replace is null)
                    {
                        replace = first.ToString();
                    }
                    
                    replace = replace.Replace(",", " ");
                    child = child.Replace(toRemove, replace);
                    
                    
                    io.WriteLine(child + ", " + keyChar);
                    sb.Append(child + ", " + keyChar + "\n");
                }
                
                
                if (mappingPair.toWrappedObject().second is Profile)
                {
                    var p = (Profile) mappingPair.toWrappedObject().second;
                    DumpProfile(p, child);
                }
            }
        }
        
        private void PrintToText(string text)
        {
            try
            {
                var sw = new StreamWriter(filePath);
                sw.Write(text);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void PrintToHtml(string html)
        {
            try
            {
                var sw = new StreamWriter(htmlFilePath);
                sw.Write(html);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
using CSHTML5;
using DotNetForHtml5.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HelloWorld
{
    public partial class CheckBoxTestPage : Page
    {
        public CheckBoxTestPage()
        {
            this.InitializeComponent();

            /*
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var test = System.Diagnostics.Stopwatch.StartNew();

            dynamic smt = "123";
            var res = smt + "Test" + test.ToString();
            sw.Stop();

            var elapsed = sw.Elapsed.TotalMilliseconds;
            //WriteConsoleLog("First time - " + elapsed + " " + res);
            System.Diagnostics.Debug.WriteLine($"First time - {elapsed} {res}");
            */
        }

        internal static string EscapeStringForUseInJavaScript(string s)
        {
            // credits: http://stackoverflow.com/questions/1242118/how-to-escape-json-string

            if (s == null || s.Length == 0)
            {
                return "";
            }

            char c = '\0';
            int i;
            int len = s.Length;
            StringBuilder sb = new StringBuilder(len + 10);
            String t;

            for (i = 0; i < len; i += 1)
            {
                c = s[i];
                switch (c)
                {
                    case '\\':
                    case '"':
                        sb.Append('\\');
                        sb.Append(c);
                        break;
                    case '`':
                        sb.Append('\\');
                        sb.Append(c);
                        break;
                    case '/':
                        sb.Append('\\');
                        sb.Append(c);
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    default:
                        if (c < ' ')
                        {
                            t = "000" + String.Format("X", c);
                            sb.Append("\\u" + t.Substring(t.Length - 4));
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            return sb.ToString();
        }

        internal static string EscapeStringForUseInJavaScript2(string s)
        {
            // credits: http://stackoverflow.com/questions/1242118/how-to-escape-json-string

            //string converted = System.Text.Json.JsonSerializer.Serialize(s);
            //return converted;

            if (s == null || s.Length == 0)
            {
                return "";
            }

            char c = '\0';
            int i;
            int len = s.Length;
            StringBuilder sb = new StringBuilder(s, len + 10);
            String t;

            int insert = 0;
            for (i = 0; i < len; i += 1)
            {
                c = s[i];
                switch (c)
                {
                    case '\\':
                    case '"':
                    case '`':
                    case '/':
                        sb.Insert(insert, '\\');
                        insert++;
                        break;
                    case '\b':
                        sb[insert] = 'b';
                        sb.Insert(insert, '\\');
                        insert++;
                        break;
                    case '\t':
                        sb[insert] = 't';
                        sb.Insert(insert, '\\');
                        insert++;
                        break;
                    case '\n':
                        sb[insert] = 'n';
                        sb.Insert(insert, '\\');
                        insert++;
                        break;
                    case '\f':
                        sb[insert] = 'f';
                        sb.Insert(insert, '\\');
                        insert++;
                        break;
                    case '\r':
                        sb[insert] = 'r';
                        sb.Insert(insert, '\\');
                        insert++;
                        break;
                    default:
                        if (c < ' ')
                        {
                            sb.Insert(insert, "\\u");
                            insert += 2;
                            
                            t = "000" + String.Format("X", c);
                            t = t.Substring(t.Length - 4);
                            sb[insert] = t[0];
                            sb.Insert(insert + 1, t[1]);
                            sb.Insert(insert + 2, t[2]);
                            sb.Insert(insert + 3, t[3]);
                            insert += 3;
                        }
                        break;
                }

                insert++;
            }
            return sb.ToString();
        }

        internal static string EscapeStringForUseInJavaScript3(string s)
        {
            // credits: http://stackoverflow.com/questions/1242118/how-to-escape-json-string

            if (s == null || s.Length == 0)
            {
                return "";
            }

            s = s.Replace("\\", "\\\\");
            s = s.Replace("\"", "\\\"");

            s = s.Replace("`", "\\`");
            s = s.Replace("/", "\\/");
            s = s.Replace("\b", "\\b");
            s = s.Replace("\t", "\\t");
            s = s.Replace("\n", "\\n");
            s = s.Replace("\f", "\\f");
            s = s.Replace("\r", "\\r");

            return s;
        }

        private void WriteConsoleLog(string log)
        {
            if (INTERNAL_Simulator.IsRunningInTheSimulator_WorkAround)
                System.Diagnostics.Debug.WriteLine(log);
            else
                Console.WriteLine(log);
        }

        private void TestEscapeString()
        {
            Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            const int testCount = 100000;
            string toEscape = "document.body.appendChild(document.createElement(\"div\"))\t\r\n";
            //string toEscape = "document.body.appendChild(document.createElement('div'))";
            for (int i = 0; i < testCount; i++)
            {
                // 3426ms (100000 times)
                EscapeStringForUseInJavaScript(toEscape);

                //EscapeStringForUseInJavaScript2(toEscape);
                //EscapeStringForUseInJavaScript3(toEscape);
                //System.Web.HttpUtility.JavaScriptStringEncode(toEscape);
            }

            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} TestEscapeString - {sw.ElapsedMilliseconds}");
        }

        private void TestCombineString()
        {
            Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            const int testCount = 100000;
            string a = "(Called from HtmlDomManager.ExecuteJavaScriptWithResult)";
            string b = "Debug from HelloWorld";
            string c = "";
            for (int i = 0; i < testCount; i++)
                c = "Performance Test String " + a + b;
            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} SimplePlus - {sw.ElapsedMilliseconds}");

            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount; i++)
                c = string.Format("Performance Test String {0}{1}", a, b);
            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} StringFormat - {sw.ElapsedMilliseconds}");

            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount; i++)
                c = $"Performance Test String {a}{b}";
            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} DollarSign - {sw.ElapsedMilliseconds}");

            int num = 10;
            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount; i++)
                c = $"Performance Test String {num}";
            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} DollarSign(num) - {sw.ElapsedMilliseconds}");
            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount; i++)
                c = $"Performance Test String {num.ToString()}";
            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} DollarSign(num.ToString) - {sw.ElapsedMilliseconds}");
        }

        private void TestInteropStringManipulation(string javascript)
        {
            Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            int IndexOfNextUnmodifiedJSCallInList = 100;
            int referenceId = 100;

            int testCount = 10000;
            for (int i = 0; i < testCount; i++)
            {
                string errorCallBack = $"document.errorCallback(error, {IndexOfNextUnmodifiedJSCallInList.ToString()})";
                ++IndexOfNextUnmodifiedJSCallInList;

                // Surround the javascript code with some code that will store the
                // result into the "document.jsSimulatorObjectReferences" for later
                // use in subsequent calls to this method
                referenceId++;
                string a = $"try{{ document.jsSimulatorObjectReferences[\"{referenceId.ToString()}\"] = eval(\"{javascript}\"); }}catch (error) {{ {errorCallBack}; }}";
            }

            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} TestInteropStringManipulation - {sw.ElapsedMilliseconds}");
            // 180ms
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            return;
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} Test started.");

            TestEscapeString();

            //TestCombineString();

            //TestInteropStringManipulation("document.body.appendChild(document.createElement('div'))");

            return;

            Stopwatch sw;

            Interop.ExecuteJavaScript("var a= 0;");
            /*return;
            
            sw = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1; i++)
            {
                //INTERNAL_Simulator.JavaScriptExecutionHandler.ExecuteUnmarshalled("createDiv", null);
                //INTERNAL_Simulator.JavaScriptExecutionHandler.ExecuteCreateElement(10); 
            }
            
            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} ExecuteCreateElement - {sw.ElapsedMilliseconds}");

            return;*/

            const int testCount = 10000;
            // -- Sync
            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount; i++)
            {
                // 700ms
                //INTERNAL_Simulator.JavaScriptExecutionHandler.ExecuteJavaScript("try {document.jsSimulatorObjectReferences[\"1114\"] = eval(\"document.body.appendChild(document.createElement('div'))\");}catch (error) {    document.errorCallback(error, 1);}");

                // 1020ms => 900ms => 800ms =>750ms
                //CSHTML5.Internal.INTERNAL_HtmlDomManager.ExecuteJavaScriptWithResult("try {document.jsSimulatorObjectReferences[\"1114\"] = eval(\"document.body.appendChild(document.createElement('div'))\");}catch (error) {    document.errorCallback(error, 1);}");

                // 1036ms
                //CSHTML5.Internal.INTERNAL_HtmlDomManager.ExecuteJavaScriptWithResultWithCast("try {document.jsSimulatorObjectReferences[\"1114\"] = eval(\"document.body.appendChild(document.createElement('div'))\");}catch (error) {    document.errorCallback(error, 1);}");

                // 1850ms =>1520ms => 1050ms
                //Interop.ExecuteJavaScript2("document.body.appendChild(document.createElement('div'))");

                // 2360ms => 2100ms => 1850ms => 1350ms
                //Interop.ExecuteJavaScript("document.body.appendChild(document.createElement('div'))");

                // 328ms
                //INTERNAL_Simulator.JavaScriptExecutionHandler.ExecuteJavaScript("var a = 0;");

                // 336ms
                //INTERNAL_Simulator.JavaScriptExecutionHandler.ExecuteJavaScript("var document_body_appendChild_document_createElement_div_= 0;");

                // 350
                //INTERNAL_Simulator.JavaScriptExecutionHandler.ExecuteJavaScript("var document_body_appendChild_document_createElement_div_document_body_appendChild_document_createElement_div_document_body_appendChild_document_createElement_div_document_body_appendChild_document_createElement_div_= 0;");

                // 2260ms
                //Interop.ExecuteJavaScript("var document_body_appendChild_document_createElement_div_= 0;");

                // 1930ms
                //Interop.ExecuteJavaScript("var a=0");

            }
            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} Sync - {sw.ElapsedMilliseconds}");

            return;
            // Asynd with last sync
            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount - 1; i++)
            {
                Interop.ExecuteJavaScriptAsync("document.createElement('div')");
            }
            Interop.ExecuteJavaScript("document.createElement('div')");
            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} Async(last sync) - {sw.ElapsedMilliseconds}");

            // -- Async
            sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < testCount; i++)
            {
                Interop.ExecuteJavaScriptAsync("document.createElement('div')");
            }
            sw.Stop();
            WriteConsoleLog($"{DateTime.Now.ToString("HH:mm:ss.fff")} Async - {sw.ElapsedMilliseconds}");
        }
    }
}

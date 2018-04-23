using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports;
using System.Reflection;
using DevExpress.XtraReports.UI;

namespace RepGetScripts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1();

            report.CreateDocument();

            XREventsScriptManager esm = (XREventsScriptManager)typeof(XtraReport).InvokeMember("eventsScriptMgr", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance, null, report, null);
            object scriptManager = typeof(XREventsScriptManager).InvokeMember("scriptExecutor", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance, null, esm, null);
            
            object[] param = new object[] {new StringBuilder()};

            scriptManager.GetType().InvokeMember("GenerateSource", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, scriptManager, param);

            richTextBox1.Text = param[0].ToString();
            report.ShowPreview();
            this.Activate();
        }
    }
}
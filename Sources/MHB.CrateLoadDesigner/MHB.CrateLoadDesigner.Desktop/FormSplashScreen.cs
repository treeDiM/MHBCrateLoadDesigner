#region Using directives
using System;
using System.Windows.Forms;
using System.Reflection;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class FormSplashScreen : Form
    {
        public FormSplashScreen(Form parentForm)
        {
            InitializeComponent();
            // version
            lblVersion.Text = $"{AssemblyVersion}";
        }
        #region Public properties
        /// <summary>
        /// retrieves assembly version
        /// </summary>
        public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        /// <summary>
        ///  set / get time interval after which the splash screen will close
        /// </summary>
        public int TimerInterval
        {
            set { timerClose.Interval = value; }
            get { return timerClose.Interval; }
        }
        /// <summary>
        /// set / get transparency
        /// </summary>
        public bool Transparent { get; set; } = true;
        #endregion

        /// <summary>
        /// handles timer tick and closes splashscreen
        /// </summary>
        private void OnTimerTick(object sender, EventArgs e)
        {
            Close();
            ParentForm?.BringToFront();
        }
    }
}

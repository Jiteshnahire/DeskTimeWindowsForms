using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskTimeWindowsForms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // for active
            TimeSpan idleTime = GetSystemIdleTime();
            label2.Text = idleTime.ToString();
            // for inactive


        }
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        // Structure to hold the last input information
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        public static TimeSpan GetSystemIdleTime()
        {
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);

            if (!GetLastInputInfo(ref lastInputInfo))
                throw new Exception("Failed to retrieve the last input information.");

            uint lastInputTime = lastInputInfo.dwTime;
            uint currentTickCount = (uint)Environment.TickCount;
            uint idleTime = currentTickCount - lastInputTime;

            return TimeSpan.FromMilliseconds(idleTime);

        }

        }

    }
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OceanAirdrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonPCapDotNet_Click(object sender, EventArgs e)
        {
            string pcapFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "example.pcap");

            PcapAnalysis.ReadFile(pcapFile);
        }

        private void buttonTShark_Click(object sender, EventArgs e)
        {
            TSharkAnalysis tshark = new TSharkAnalysis(AppDomain.CurrentDomain.BaseDirectory, "example.pcap");

            string filter = "tcp.analysis.retransmission && ip.dst == 10.2.3.4";

            var filteredPackets = tshark.ProcessFilter(filter);

            int count = filteredPackets.Count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanAirdrop
{
    public class TSharkAnalysis
    {
        public string m_tsharkPath = @"C:\Program Files (x86)\Wireshark\tshark.exe";
        public string m_pcapFile = @"C:\Ade\TempCode\WireSharkAnalysis\WireSharkAnalysis\bin\Debug\ade3.pcapng";
        public string m_filter = "tcp.analysis.retransmission && ip.dst == 10.111.200.159";

        public string m_tsharkTemplate = "\"{0}\" -2 -r {1} -R  \"{2}\"";

        public string m_tsharkCmd = "";

        static StringBuilder m_tsharkOutput = new StringBuilder();

        public static Process m_process = null;

        public TSharkAnalysis(string path, string pcapFile)
        {
            m_tsharkPath = path;
            m_pcapFile = pcapFile;
        }

        public List<int> ProcessFilter(string filter)
        {
            // Stage 1: Setup the wireshark filter command
            m_tsharkCmd = string.Format(m_tsharkTemplate, m_tsharkPath, m_pcapFile, filter);

            // Stage 2: Clear the output
            m_tsharkOutput.Clear();

            // Stage 3: Run the command!
            using (m_process = new Process())
            {
                m_process.StartInfo.WorkingDirectory = @"C:\";
                m_process.StartInfo.FileName = Path.Combine(Environment.SystemDirectory, "cmd.exe");
                m_process.StartInfo.UseShellExecute = false;
                m_process.StartInfo.RedirectStandardInput = true;
                m_process.StartInfo.RedirectStandardOutput = true;
                m_process.StartInfo.RedirectStandardError = true;
                m_process.OutputDataReceived += OutputHandler;
                m_process.ErrorDataReceived += OutputHandler;
                m_process.Exited += new EventHandler(process_Exited);

                m_process.Start();
                m_process.BeginOutputReadLine();
                m_process.BeginErrorReadLine();

                // Send a directory command and an exit command to the shell
                m_process.StandardInput.WriteLine(m_tsharkCmd);
                m_process.StandardInput.WriteLine("exit");

                m_process.WaitForExit();
                m_process.Close();                
            }

            // Stage 4: Output the number of packets!
            var filteredPackets = GetFilteredPacket();

            return filteredPackets;
        }

        public List<int> GetFilteredPacket()
        {
            List<int> packetFilter = new List<int>();

            try
            {
                string[] delim = { Environment.NewLine, "\n" }; // "\n" added in case you manually appended a newline
                string[] lines = m_tsharkOutput.ToString().Split(delim, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line.Contains("Microsoft") == true || string.IsNullOrEmpty(line) == true || line.Contains("tshark") || line.Contains("exit"))
                        continue;

                    string[] lineSplit = line.Split(' ');
                    int packetNum= GetLineFirstNumber(lineSplit);

                    packetFilter.Add(packetNum);
                }
            }
            catch (Exception)
            {
            }

            return packetFilter;
        }

        private int GetLineFirstNumber(string[] lineSplit)
        {
            int result = -1;

            foreach (var item in lineSplit)
            {
                if (string.IsNullOrEmpty(item) == true)
                    continue;

                result = Convert.ToInt32(item);
                break;
            }

            return result;
        }

        private void process_Exited(object sender, EventArgs e)
        {
        }


        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            Console.WriteLine(outLine.Data);

            m_tsharkOutput.AppendLine(outLine.Data);
        }
    }
}

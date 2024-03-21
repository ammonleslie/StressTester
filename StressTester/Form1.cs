using LibreHardwareMonitor.Hardware;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace StressTester
{
    public class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }
        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
        }
        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }
    }

    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer m_Timer;

        public Form1()
        {
            InitializeComponent();

            ResetForm();

            m_Timer = new System.Windows.Forms.Timer();

            m_Timer.Interval = 4000;
            m_Timer.Tick += timer_Tick;
            //m_Timer.Start();
        }

        async void timer_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => RefreshProcesses());
        }

        private void RefreshProcesses()
        {
            Computer computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = false,
                IsMotherboardEnabled = false,
                IsControllerEnabled = false,
                IsNetworkEnabled = false,
                IsStorageEnabled = true
            };

            computer.Open();
            computer.Accept(new UpdateVisitor());

            List<string> data_list = [DateTime.Now.ToString()];

            foreach (IHardware hardware in computer.Hardware)
            {
                data_list.Add($"Hardware: {hardware.Name}");

                foreach (IHardware subhardware in hardware.SubHardware)
                {
                    if (subhardware.HardwareType == HardwareType.Cpu || subhardware.HardwareType == HardwareType.Storage)
                    {
                        data_list.Add($"\tSubhardware: {subhardware.Name}");

                        foreach (ISensor sensor in subhardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                data_list.Add($"\t\tSensor: {sensor.Name}, value: {sensor.Value}");
                            }
                        }
                    }
                }

                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        data_list.Add($"\tSensor: {sensor.Name}, value: {sensor.Value}");
                    }
                }
            }

            computer.Close();

            if (lbMeasurements.InvokeRequired)
                lbMeasurements.Invoke((MethodInvoker)delegate { lbMeasurements.DataSource = data_list; });
            else
                lbMeasurements.DataSource = data_list;
        }

        private void ResetForm()
        {
            lbMeasurements.Items.Clear();
            lbLog.Items.Clear();

            lbMeasurements.Items.Add("Live measurements will appear here!");
            lbLog.Items.Add("Test/Application logs will appear here!");
        }

        private void Log(string text)
        {
            lbLog.Items.Add($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} - {text}");
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            Log("Starting test...");

            // start cpu stress
            await Task.Run(() => CpuStress(10));

            // start storage stress
            await Task.Run(() => StorageStress(10));

            Log("Test has ended!");
        }
        
        private void CpuStress(double minutes)
        {
            DateTime end_time = DateTime.Now.AddMinutes(minutes);

            Parallel.For(0, 1 << 30, (i, l) =>
            {
                if (DateTime.Now > end_time)
                {
                    l.Stop();
                }
            });
        }

        private void StorageStress(double minutes)
        {
            string temp_file_path = "C:\\stress.out";
            if (!File.Exists(temp_file_path))
            {
                File.Create(temp_file_path);
            }

            var fi = new FileInfo(temp_file_path);

            const int blockSize = 1024 * 8;
            const int blocksPerMb = (1024 * 1024) / blockSize;
            byte[] data = new byte[blockSize];
            Random rng = new Random();
            using (FileStream stream1 = File.OpenWrite(temp_file_path))
            {
                // There 
                for (int i = 0; i < 1024 * 1 * blocksPerMb; i++)
                {
                    rng.NextBytes(data);
                    stream1.Write(data, 0, data.Length);
                }
            }

            var size = fi.Length * 1;

            using var stream = new FileStream(fi.FullName, FileMode.Open);
            var curRead = 0;
            var readBuffer = new byte[1024 * 1024];
            var j = 0;
            long totalRead = 0;

            var numReads = Math.Floor(size / (double)readBuffer.Length);
            var reportWait = Math.Floor(numReads / 100);

            while (totalRead < size)
            {
                curRead = stream.Read(readBuffer, 0, readBuffer.Length);

                if (curRead < readBuffer.Length)
                {
                    stream.Position = 0;
                }
                totalRead += curRead;

                j++;
            }
        }
    }
}

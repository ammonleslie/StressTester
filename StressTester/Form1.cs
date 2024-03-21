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
    }
}

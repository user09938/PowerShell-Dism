//https://stackoverflow.com/questions/74584885/how-can-i-programmatically-turn-off-or-on-windows-features/74590448
//
//https://stackoverflow.com/questions/8054282/how-can-you-programmatically-turn-off-or-on-windows-features
//Use DISM in Windows PowerShell: https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/use-dism-in-windows-powershell-s14?view=windows-11

using System.Diagnostics;
using System.Security.Cryptography;

namespace PowerShell_Dism
{
    public partial class Form1 : Form
    {
        private HelperPowerShell _helperPowerShell = new HelperPowerShell();
        private string _mountDir = Path.Combine(Path.GetTempPath(), "mnt");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set value
            comboBoxDismCommand.SelectedIndex = 0;

            //subscribe to events
            _helperPowerShell.PowerShellProgressUpdated += HelperPowerShell_PowerShellProgressUpdated;
        }

        private void HelperPowerShell_PowerShellProgressUpdated(object? sender, PowerShellProgressUpdatedEventArgs e)
        {
            //update ToolStripStatusLabel
            statusStrip1.BeginInvoke(new MethodInvoker(delegate
            {
                toolStripStatusLabel1.Text = $"Status: Processing... ({e.Progress}%)";
                statusStrip1.Refresh();
            }));
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //clear existing data
            richTextBoxOutput.Clear();

            if (!String.IsNullOrEmpty(comboBoxDismCommand.Text))
            {
                //set value
                toolStripStatusLabel1.Text = "Status: Processing...";

                Debug.WriteLine($"comboBoxDismCommand.Text: {comboBoxDismCommand.Text}");

                if (comboBoxDismCommand.Text == "Get-WindowsOptionalFeature -Online")
                    richTextBoxOutput.Text = _helperPowerShell.PowerShellDism(@"Get-WindowsOptionalFeature -Online | Sort-Object -Property $_.FeatureName  | Select-Object -Property FeatureName, State | ForEach-Object { $_.FeatureName + "": "" + $_.State }");
                else if (comboBoxDismCommand.Text == "Get-WindowsOptionalFeature -Online -FeatureName IIS-WebServer")
                    richTextBoxOutput.Text = _helperPowerShell.PowerShellDism(@"Get-WindowsOptionalFeature -Online -FeatureName IIS-WebServer | Select-Object -Property FeatureName, State | ForEach-Object { $_.FeatureName + "": "" + $_.State }");

                //all of code below works as well, but is redundant

                /*
                richTextBoxOutput.Text = _helperPowerShell.GetFeaturesAsString();

                foreach (FeatureInfo feature in _helperPowerShell.GetFeatures())
                {
                    richTextBoxOutput.AppendText($"{feature.FeatureName}: {feature.State}{Environment.NewLine}");
                }

                richTextBoxOutput.Text = _helperPowerShell.GetFeaturesUsingAddScriptAsString();

                
                foreach (FeatureInfo feature in _helperPowerShell.GetFeaturesUsingAddScript())
                {
                    richTextBoxOutput.AppendText($"{feature.FeatureName}: {feature.State}{Environment.NewLine}");
                }
                

                foreach (FeatureInfo feature in _helperPowerShell.GetFeaturesUsingAddScript())
                {
                    richTextBoxOutput.AppendText($"{feature.FeatureName}: {feature.State}{Environment.NewLine}");
                }

                */

                //set value
                toolStripStatusLabel1.Text = "Status: Complete";
            }
        }

        private async void btnWimMount_Click(object sender, EventArgs e)
        {
            //clear existing data
            richTextBoxOutput.Clear();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WIM File (*.wim)|*.wim";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //set value
                toolStripStatusLabel1.Text = "Status: Processing...";

                if (!Directory.Exists(_mountDir))
                    Directory.CreateDirectory(_mountDir);

                string script = $@"Mount-WindowsImage -ImagePath ""{ofd.FileName}"" -Index 1 -Path ""{_mountDir}"" -ReadOnly";

                richTextBoxOutput.Text = $"Command: {script}{Environment.NewLine}";

                //execute
                string result = await _helperPowerShell.PowerShellDismReportsProgress(script);

                if (!String.IsNullOrEmpty(result) && !result.Trim().EndsWith("Object"))
                    richTextBoxOutput.AppendText($"'{result}'"); //append
                else if (!String.IsNullOrEmpty(result) && result.Trim().EndsWith("Object"))
                    richTextBoxOutput.AppendText("Status: Complete"); //append

                //set value
                toolStripStatusLabel1.Text = "Status: Complete";
            }
        }

        private async void btnWimDismount_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_mountDir))
                return;

            //set value
            toolStripStatusLabel1.Text = "Status: Processing...";

            string script = $@"Dismount-WindowsImage -Path ""{_mountDir}"" -Discard";

            richTextBoxOutput.Text = $"Command: {script}"; richTextBoxOutput.Text = $"Command: {script}{Environment.NewLine}";

            //execute
            string result = await _helperPowerShell.PowerShellDismReportsProgress(script);

            if (!String.IsNullOrEmpty(result) && !result.Trim().EndsWith("Object"))
                richTextBoxOutput.AppendText($"'{result}'"); //append
            else if (!String.IsNullOrEmpty(result) && result.Trim().EndsWith("Object"))
                richTextBoxOutput.AppendText("Status: Complete"); //append

            //set value
            toolStripStatusLabel1.Text = "Status: Complete";
        }

        private async void btnWimRemount_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_mountDir))
                return;

            //set value
            toolStripStatusLabel1.Text = "Status: Processing...";

            string script = $@"Mount-WindowsImage -Path ""{_mountDir}"" -Remount";
            richTextBoxOutput.Text = $"Command: {script}{Environment.NewLine}";

            //execute
            string result = await _helperPowerShell.PowerShellDismReportsProgress(script);

            if (!String.IsNullOrEmpty(result) && !result.Trim().EndsWith("Object"))
                richTextBoxOutput.AppendText($"'{result}'"); //append
            else if (!String.IsNullOrEmpty(result) && result.Trim().EndsWith("Object"))
                richTextBoxOutput.AppendText("Status: Complete"); //append

            //set value
            toolStripStatusLabel1.Text = "Status: Complete";
        }
    }
}

//Download/install NuGet package: Microsoft.PowerShell.Sdk (v: 7.2.7)
//
//Use DISM in Windows PowerShell: https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/use-dism-in-windows-powershell-s14?view=windows-11


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.IO;
using System.Diagnostics;

namespace PowerShell_Dism
{
    public class HelperPowerShell
    {
        //event subscribers can subscribe to
        public event EventHandler<PowerShellProgressUpdatedEventArgs>? PowerShellProgressUpdated = null;

        public List<FeatureInfo> GetFeatures()
        {
            //create new instance
            List<FeatureInfo> features = new List<FeatureInfo>();

            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.RemoteSigned; //set execution policy
            iss.ImportPSModule(new[] { "Dism" }); //import module

            using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
            {
                //open
                runspace.Open();

                using (PowerShell ps = PowerShell.Create(runspace))
                {
                    // Get-WindowsOptionalFeature -Online
                    ps.AddCommand("Get-WindowsOptionalFeature").AddParameter("Online");

                    // Sort-Object -Property $_.FeatureName 
                    //ps.AddCommand("Sort-Object").AddParameter("Property", @"$_.FeatureName");
                    ps.AddCommand("Sort-Object").AddParameter("Property", @"FeatureName");

                    // Select-Object -Property FeatureName, State
                    List<string> props = new List<string>() { "FeatureName", "State" };
                    ps.AddCommand("Select-Object").AddParameter("Property", props);

                    // ForEach-Object { $_.FeatureName + "": "" + $_.State }
                    ps.AddCommand("ForEach-Object").AddParameter("Process", ScriptBlock.Create("$_.FeatureName + \": \" + $_.State"));

                    //execute
                    System.Collections.ObjectModel.Collection<PSObject> outputCollection = ps.Invoke();

                    foreach (PSObject outputItem in outputCollection)
                    {
                        //create reference
                        string? data = outputItem.BaseObject?.ToString();

                        if (!String.IsNullOrEmpty(data))
                        {
                            //create new instance
                            FeatureInfo featureInfo = new FeatureInfo();

                            //set value
                            featureInfo.FeatureName = data.Substring(0, data.IndexOf(":"));
                            featureInfo.State = data.Substring(data.IndexOf(":") + 2);

                            //add
                            features.Add(featureInfo);

                            Debug.WriteLine(data);
                        } 
                    }
                }
            }

            //sort
            //features.Sort();

            return features;
        }

        public string GetFeaturesAsString()
        {
            //create new instance
            StringBuilder sb = new StringBuilder();

            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.RemoteSigned; //set execution policy
            iss.ImportPSModule(new[] { "Dism" }); //import module

            using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
            {
                //open
                runspace.Open();

                using (PowerShell ps = PowerShell.Create(runspace))
                {
                    // Get-WindowsOptionalFeature -Online
                    ps.AddCommand("Get-WindowsOptionalFeature").AddParameter("Online");

                    // Sort-Object -Property $_.FeatureName
                    //ps.AddCommand("Sort-Object").AddParameter("Property", "$_.FeatureName");
                    ps.AddCommand("Sort-Object").AddParameter("Property", "FeatureName");

                    // Select-Object -Property FeatureName, State
                    List<string> props = new List<string>() { "FeatureName", "State" };
                    ps.AddCommand("Select-Object").AddParameter("Property", props);

                    // ForEach-Object { $_.FeatureName + "": "" + $_.State }
                    ps.AddCommand("ForEach-Object").AddParameter("Process", ScriptBlock.Create("$_.FeatureName + \": \" + $_.State"));

                    //execute
                    System.Collections.ObjectModel.Collection<PSObject> outputCollection = ps.Invoke();

                    foreach (PSObject outputItem in outputCollection)
                    {
                        sb.AppendLine(outputItem.BaseObject.ToString());
                        Debug.WriteLine(outputItem.BaseObject.ToString());
                    }
                }
            }

            return sb.ToString();
        }

        public List<FeatureInfo> GetFeaturesUsingAddScript()
        {
            List<FeatureInfo> features = new List<FeatureInfo>();

            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.RemoteSigned; //set execution policy
            iss.ImportPSModule(new[] { "Dism" }); //import module

            using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
            {
                //open
                runspace.Open();

                using (PowerShell ps = PowerShell.Create(runspace))
                {
                    string script = @"Get-WindowsOptionalFeature -Online | Sort-Object -Property $_.FeatureName | Select-Object -Property FeatureName, State | ForEach-Object { $_.FeatureName + "": "" + $_.State }";
                    Debug.WriteLine($"script: {script}");

                    ps.AddScript(script);

                    //execute
                    System.Collections.ObjectModel.Collection<PSObject> outputCollection = ps.Invoke();

                    foreach (PSObject outputItem in outputCollection)
                    {
                        //create reference
                        string? data = outputItem.BaseObject?.ToString();

                        if (!String.IsNullOrEmpty(data))
                        {
                            //create new instance
                            FeatureInfo featureInfo = new FeatureInfo();

                            //set value
                            featureInfo.FeatureName = data.Substring(0, data.IndexOf(":"));
                            featureInfo.State = data.Substring(data.IndexOf(":") + 2);

                            //add
                            features.Add(featureInfo);

                            Debug.WriteLine(data);
                        }
                    }
                }
            }

            return features;
        }

        public string GetFeaturesUsingAddScriptAsString()
        {
            StringBuilder sb = new StringBuilder();

            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.RemoteSigned; //set execution policy
            iss.ImportPSModule(new[] { "Dism" }); //import module

            using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
            {
                //open
                runspace.Open();

                using (PowerShell ps = PowerShell.Create(runspace))
                {
                    string script = @"Get-WindowsOptionalFeature -Online | Sort-Object -Property $_.FeatureName | Select-Object -Property FeatureName, State | ForEach-Object { $_.FeatureName + "": "" + $_.State }";
                    Debug.WriteLine($"script: {script}");
                    ps.AddScript(script);

                    //execute
                    System.Collections.ObjectModel.Collection<PSObject> outputCollection = ps.Invoke();

                    foreach (PSObject outputItem in outputCollection)
                    {
                        sb.AppendLine(outputItem.BaseObject.ToString());
                        Debug.WriteLine(outputItem.BaseObject.ToString());
                    }
                }
            }

            return sb.ToString();
        }

        public string PowerShellDism(string scriptText)
        {
            StringBuilder sb = new StringBuilder();

            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.RemoteSigned; //set execution policy
            iss.ImportPSModule(new[] { "Dism" }); //import module

            using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
            {
                //open
                runspace.Open();

                using (PowerShell ps = PowerShell.Create(runspace))
                {
                    Debug.WriteLine($"scriptText: {scriptText}");

                    ps.AddScript(scriptText);

                    //execute
                    System.Collections.ObjectModel.Collection<PSObject> outputCollection = ps.Invoke();

                    foreach (PSObject outputItem in outputCollection)
                    {
                        sb.AppendLine(outputItem.BaseObject.ToString());
                        Debug.WriteLine(outputItem.BaseObject.ToString());
                    }
                }
            }

            return sb.ToString();
        }

        public async Task<string> PowerShellDismReportsProgress(string scriptText)
        {
            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.RemoteSigned; //set execution policy
            iss.ImportPSModule(new[] { "Dism" }); //import module

            using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
            {
                //open
                runspace.Open();

                using (PowerShell ps = PowerShell.Create(runspace))
                {
                    //add script
                    ps.AddScript(scriptText);

                    //get progress
                    ps.Streams.Progress.DataAdded += (sender, e) =>
                    {
                        //create reference
                        PSDataCollection<ProgressRecord>? progressRecords = sender is not null ? (PSDataCollection<ProgressRecord>)sender : null;
                        System.Diagnostics.Debug.WriteLine($"Info: Progress is {progressRecords?[e.Index].PercentComplete} percent complete");

                        if (PowerShellProgressUpdated != null && progressRecords != null)
                            //raise event
                            PowerShellProgressUpdated(this, new PowerShellProgressUpdatedEventArgs(progressRecords[e.Index].PercentComplete));
                    };

                    //create new instance
                    PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

                    //execute
                    var result = await Task.Factory.FromAsync(ps.BeginInvoke<PSObject, PSObject>(null, outputCollection), pResult => ps.EndInvoke(pResult));

                    StringBuilder sb = new StringBuilder();
                    foreach (PSObject outputItem in outputCollection)
                    {
                        sb.AppendLine(outputItem.BaseObject.ToString());
                        Debug.WriteLine(outputItem.BaseObject.ToString());
                    }

                    return await Task.FromResult(sb.ToString());
                }
            }
        }
    }
}

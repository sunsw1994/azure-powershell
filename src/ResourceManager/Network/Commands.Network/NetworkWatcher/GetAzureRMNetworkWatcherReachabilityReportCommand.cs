// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using CNM = Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.Automation
{
    [Cmdlet(VerbsCommon.Get, "AzureRMNetworkWatcherReachabilityReport", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSAzureReachabilityReport))]
    public partial class GetAzureRMNetworkWatcherReachabilityReport : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The network watcher resource",
            ParameterSetName = "SetByResource")]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Alias("ResourceName", "Name")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }


        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of Internet service providers.",
            ValueFromPipelineByPropertyName = true)]
        public List<string> Providers { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Optional Azure regions to scope the query to.",
            ValueFromPipelineByPropertyName = true)]
        public List<string> AzureLocations { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The start time for the Azure reachability report.",
            ValueFromPipelineByPropertyName = true)]
        public DateTime StartTime { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The end time for the Azure reachability report.",
            ValueFromPipelineByPropertyName = true)]
        public DateTime EndTime { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the country.",
            ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the state.",
            ValueFromPipelineByPropertyName = true)]
        public string State { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the city.",
            ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        public override void Execute()
        {
            base.Execute();

            // ProviderLocation
            PSAzureReachabilityReportLocation vProviderLocation = null;

            if (this.Country != null)
            {
                if (vProviderLocation == null)
                {
                    vProviderLocation = new PSAzureReachabilityReportLocation();
                }
                vProviderLocation.Country = this.Country;
            }

            if (this.State != null)
            {
                if (vProviderLocation == null)
                {
                    vProviderLocation = new PSAzureReachabilityReportLocation();
                }
                vProviderLocation.State = this.State;
            }

            if (this.City != null)
            {
                if (vProviderLocation == null)
                {
                    vProviderLocation = new PSAzureReachabilityReportLocation();
                }
                vProviderLocation.City = this.City;
            }

            var vAzureReachabilityReportParameters = new AzureReachabilityReportParameters
            {
                Providers = this.Providers,
                AzureLocations = this.AzureLocations,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                ProviderLocation = NetworkResourceManagerProfile.Mapper.Map < MNM.AzureReachabilityReportLocation >(vProviderLocation),
            };

            if (ParameterSetName.Contains("SetByResource"))
            {
                ResourceGroupName = this.NetworkWatcher.ResourceGroupName;
                NetworkWatcherName = this.NetworkWatcher.Name;
            }
            var vNetworkWatcherResult = this.NetworkClient.NetworkManagementClient.NetworkWatchers.GetAzureReachabilityReport(ResourceGroupName, NetworkWatcherName, vAzureReachabilityReportParameters);
            var vNetworkWatcherModel = NetworkResourceManagerProfile.Mapper.Map<PSAzureReachabilityReport>(vNetworkWatcherResult);
            WriteObject(vNetworkWatcherModel);
        }
    }
}

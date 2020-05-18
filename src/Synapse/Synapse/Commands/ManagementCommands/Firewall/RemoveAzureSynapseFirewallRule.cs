﻿using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synaspe
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.FirewallRule, DefaultParameterSetName = DeleteByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureSynapseFirewallRule : SynapseCmdletBase
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";

        [Parameter(ParameterSetName = DeleteByNameParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = DeleteByNameParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = DeleteByNameParameterSet,Mandatory = true, HelpMessage = HelpMessages.FirewallRuleName)]
        [Parameter(ParameterSetName = DeleteByInputObjectParameterSet, Mandatory = true, HelpMessage = HelpMessages.FirewallRuleName)]
        [Alias(SynapseConstants.FirewallRuleName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = DeleteByInputObjectParameterSet, Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.RemovingFirewallRule, this.Name, this.WorkspaceName)))
            {
                SynapseAnalyticsClient.DeleteFirewallRule(ResourceGroupName, WorkspaceName, Name);
                if (PassThru)
                {
                    WriteObject(true);
                }
            }
        }
    }
}

using PlayFab.MultiplayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PFMultiplayerCmdlets
{
    [Cmdlet(VerbsCommon.New, "PFMultiplayerBuildAlias")]
    [OutputType(typeof(BuildAliasDetailsResponse))]
    public class NewPFMultiplayerBuildAlias : PFBaseCmdlet
    {
        [Parameter(Mandatory = true)]
        public string AliasName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public List<BuildSelectionCriterion> BuildSelectionCriteria { get; set; }

        protected override void ProcessRecord()
        {
            var resp = CallPlayFabApi(() => Instance.CreateBuildAliasAsync(new CreateBuildAliasRequest()
            {
                AliasName = AliasName,
                BuildSelectionCriteria = BuildSelectionCriteria
            }));

            WriteVerbose($"Created alias {resp.AliasName}");
            WriteObject(resp);
        }
    }
}

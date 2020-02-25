using PlayFab.MultiplayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PFMultiplayerCmdlets
{
    [Cmdlet(VerbsCommon.Set, "PFMultiplayerBuildAlias")]
    [OutputType(typeof(BuildAliasDetailsResponse))]
    public class SetPFMultiplayerBuildAlias : PFBaseCmdlet
    {
        [Parameter]
        public Guid? AliasId { get; set; }

        [Parameter]
        public string AliasName { get; set; }

        [Parameter]
        public List<BuildSelectionCriterion> BuildSelectionCriteria { get; set; }

        /// <summary>
        /// If used the other parameters are ignored. Allows an easy way to call GetPFMultiplayerBuild, modify the result, and pass it back to be updated.
        /// </summary>
        [Parameter]
        public BuildAliasDetailsResponse BuildAliasDetailsResponse { get; set; }

        protected override void ProcessRecord()
        {
            if (AliasId == null && BuildAliasDetailsResponse == null)
                throw new ArgumentException("Either 'AliasId' or 'BuildAliasDetailsResponse' should be specified.");
            
            // It is legal to set both the name and the BuildSelectionCriteria to null.

            UpdateBuildAliasRequest req;
            if (BuildAliasDetailsResponse != null)
                req = new UpdateBuildAliasRequest()
                {
                    AliasId = BuildAliasDetailsResponse.AliasId,
                    AliasName = BuildAliasDetailsResponse.AliasName,
                    BuildSelectionCriteria = BuildAliasDetailsResponse.BuildSelectionCriteria
                };
            else
                req = new UpdateBuildAliasRequest()
                {
                    AliasId = AliasId.Value.ToString(),
                    AliasName = AliasName,
                    BuildSelectionCriteria = BuildSelectionCriteria
                };

            var resp = CallPlayFabApi(() => Instance.UpdateBuildAliasAsync(req));

            WriteVerbose($"Updated alias {resp.AliasName} ({resp.AliasId})");
            WriteObject(resp);
        }
    }
}

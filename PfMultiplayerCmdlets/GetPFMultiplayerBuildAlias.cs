using PlayFab.MultiplayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PFMultiplayerCmdlets
{
    [Cmdlet(VerbsCommon.Get, "PFMultiplayerBuildAlias")]
    [OutputType(typeof(BuildAliasDetailsResponse))]
    public class GetPFMultiplayerBuildAlias : PFBaseCmdlet
    {
        [Parameter]
        public Guid? AliasId { get; set; }

        protected override void ProcessRecord()
        {
            List<BuildAliasDetailsResponse> result;
            if (AliasId.HasValue)
            {
                var resp = CallPlayFabApi(() => Instance.GetBuildAliasAsync(new GetBuildAliasRequest() { AliasId = AliasId.Value.ToString() }));
                result = new List<BuildAliasDetailsResponse> { resp };
            }
            else
            {
                var resp = CallPlayFabApi(() => Instance.ListBuildAliasesAsync(new MultiplayerEmptyRequest()));
                result = resp.BuildAliases ?? new List<BuildAliasDetailsResponse>();
            }

            WriteObject(result);
        }
    }
}

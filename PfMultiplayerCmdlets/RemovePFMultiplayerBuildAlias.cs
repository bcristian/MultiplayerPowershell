using PlayFab.MultiplayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PFMultiplayerCmdlets
{
    [Cmdlet(VerbsCommon.Remove, "PFMultiplayerBuildAlias")]
    public class RemovePFMultiplayerBuildAlias : PFBaseCmdlet
    {
        [Parameter(Mandatory = true)]
        public Guid? AliasId { get; set; }

        protected override void ProcessRecord()
        {
            CallPlayFabApi(() => Instance.DeleteBuildAliasAsync(new DeleteBuildAliasRequest() { AliasId = AliasId.Value.ToString() }));
            WriteVerbose($"Removed alias {AliasId.Value}");
        }
    }
}

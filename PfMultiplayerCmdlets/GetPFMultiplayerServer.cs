﻿namespace PFMultiplayerCmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PlayFab;
    using PlayFab.MultiplayerModels;

    [Cmdlet(VerbsCommon.Get, "PFMultiplayerServer")]
    [OutputType(typeof(MultiplayerServerSummary))]
    public class GetPFMultiplayerServer : PageableCmdlet
    {
        [Parameter]
        public string BuildName { get; set; }

        [Parameter]
        public Guid? BuildId { get; set; }

        [Parameter]
        public List<AzureRegion> Regions { get; set; }

        [Parameter]
        public SwitchParameter AllRegions { get; set; }

        protected override void ProcessRecord()
        {
            if (Regions?.Count > 0 && AllRegions)
            {
                ThrowTerminatingError(
                    new ErrorRecord(new ArgumentException("Exactly one of Regions, AllRegions should be specified."),
                        "InvalidArgument",
                        ErrorCategory.InvalidArgument, null));
            }

            if ((Regions == null || Regions.Count == 0) && !AllRegions)
            {
                ThrowTerminatingError(
                    new ErrorRecord(new ArgumentException("Exactly one of Regions, AllRegions should be specified."),
                        "InvalidArgument",
                        ErrorCategory.InvalidArgument, null));
            }

            string buildIdString = NewPFMultiplayerServer.GetBuildId(this, BuildName, BuildId);

            HashSet<AzureRegion> regionsList = new HashSet<AzureRegion>();
            if (AllRegions)
            {
                GetBuildResponse response = PlayFabMultiplayerAPI.GetBuildAsync(new GetBuildRequest() {BuildId = buildIdString}).Result.Result;
                response.RegionConfigurations.ForEach(x => regionsList.Add(x.Region.Value));
            }
            else
            {
                Regions.ForEach(x => regionsList.Add(x));
            }

            List<MultiplayerServerSummary> serverSummaries = new List<MultiplayerServerSummary>();
            foreach (AzureRegion region in regionsList)
            {
                serverSummaries.AddRange(GetMultiplayerServers(buildIdString, region));
            }
            
            WriteObject(serverSummaries);
        }

        private List<MultiplayerServerSummary> GetMultiplayerServers(string buildId, AzureRegion region)
        {
            List<MultiplayerServerSummary> summaries = new List<MultiplayerServerSummary>();
            ListMultiplayerServersResponse response = PlayFabMultiplayerAPI
                .ListMultiplayerServersAsync(new ListMultiplayerServersRequest() {PageSize = DefaultPageSize, Region = region, BuildId = buildId}).Result.Result;
            summaries.AddRange(response.MultiplayerServerSummaries ?? Enumerable.Empty<MultiplayerServerSummary>());
            if (All)
            {
                while (!string.IsNullOrEmpty(response.SkipToken))
                {
                    response = PlayFabMultiplayerAPI
                        .ListMultiplayerServersAsync(new ListMultiplayerServersRequest()
                        {
                            PageSize = DefaultPageSize,
                            SkipToken = response.SkipToken,
                            Region = region
                        }).Result.Result;
                    summaries.AddRange(response.MultiplayerServerSummaries ?? Enumerable.Empty<MultiplayerServerSummary>());
                }
            }

            return summaries;
        }
    }
}
﻿namespace PFMultiplayerCmdlets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PlayFab;
    using PlayFab.MultiplayerModels;

    [Cmdlet(VerbsCommon.Get, "PFMultiplayerCertificate")]
    [OutputType(typeof(List<CertificateSummary>))]
    public class GetPFMultiplayerCertificate : PageableCmdlet
    {
        protected override void ProcessRecord()
        {
            List<CertificateSummary> summaries = new List<CertificateSummary>();
            ListCertificateSummariesResponse response = PlayFabMultiplayerAPI
                .ListCertificateSummariesAsync(new ListCertificateSummariesRequest() { PageSize = DefaultPageSize }).Result.Result;
            summaries.AddRange(response.CertificateSummaries ?? Enumerable.Empty<CertificateSummary>());
            if (All)
            {
                while (!string.IsNullOrEmpty(response.SkipToken))
                {
                    response = PlayFabMultiplayerAPI
                        .ListCertificateSummariesAsync(new ListCertificateSummariesRequest() { PageSize = DefaultPageSize, SkipToken = response.SkipToken }).Result.Result;
                    summaries.AddRange(response.CertificateSummaries ?? Enumerable.Empty<CertificateSummary>());
                }
            }

            WriteObject(summaries);
        }
    }
}
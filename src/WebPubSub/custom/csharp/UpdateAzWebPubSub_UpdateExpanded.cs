// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Cmdlets
{
    using System.Management.Automation;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20;
    using Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime;

    public partial class UpdateAzWebPubSub_UpdateExpanded
    {
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<IErrorResponse> errorResponseTask, ref Task<bool> returnNow)
        {
            WriteInformation("Test", new string[] { "a" });
            var errorResponse = errorResponseTask.Result;
            WriteError(new ErrorRecord(new RestException<IErrorResponse>(responseMessage, errorResponseTask.Result), errorResponse.Code, ErrorCategory.InvalidOperation, new { SubscriptionId, ResourceGroupName, Name, ParametersBody }));
            returnNow = Task.FromResult(true);
        }
    }
}
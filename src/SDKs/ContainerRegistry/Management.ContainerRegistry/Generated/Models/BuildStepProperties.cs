// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.ContainerRegistry.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Base properties for any build step.
    /// </summary>
    public partial class BuildStepProperties
    {
        /// <summary>
        /// Initializes a new instance of the BuildStepProperties class.
        /// </summary>
        public BuildStepProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BuildStepProperties class.
        /// </summary>
        /// <param name="provisioningState">The provisioning state of the build
        /// step. Possible values include: 'Creating', 'Updating', 'Deleting',
        /// 'Succeeded', 'Failed', 'Canceled'</param>
        public BuildStepProperties(string provisioningState = default(string))
        {
            ProvisioningState = provisioningState;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the provisioning state of the build step. Possible values
        /// include: 'Creating', 'Updating', 'Deleting', 'Succeeded', 'Failed',
        /// 'Canceled'
        /// </summary>
        [JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState { get; private set; }

    }
}

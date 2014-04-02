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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Management.Network
{
    /// <summary>
    /// The Network Management API includes operations for managing the virtual
    /// networks for your subscription.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157182.aspx for
    /// more information)
    /// </summary>
    internal partial class NetworkOperations : IServiceOperations<NetworkManagementClient>, Microsoft.WindowsAzure.Management.Network.INetworkOperations
    {
        /// <summary>
        /// Initializes a new instance of the NetworkOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal NetworkOperations(NetworkManagementClient client)
        {
            this._client = client;
        }
        
        private NetworkManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.Network.NetworkManagementClient.
        /// </summary>
        public NetworkManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// The Begin Setting Network Configuration operation asynchronously
        /// configures the virtual network.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157181.aspx
        /// for more information)
        /// </summary>
        /// <param name='parameters'>
        /// Required. Parameters supplied to the Set Network Configuration
        /// operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard storage response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationResponse> BeginSettingConfigurationAsync(NetworkSetConfigurationParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (parameters.Configuration == null)
            {
                throw new ArgumentNullException("parameters.Configuration");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "BeginSettingConfigurationAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + this.Client.Credentials.SubscriptionId + "/services/networking/media";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = parameters.Configuration;
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    OperationResponse result = null;
                    result = new OperationResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Get Network Configuration operation retrieves the network
        /// configuration file for the given subscription.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157196.aspx
        /// for more information)
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get Network Configuration operation response.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.Network.Models.NetworkGetConfigurationResponse> GetConfigurationAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                Tracing.Enter(invocationId, this, "GetConfigurationAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + this.Client.Credentials.SubscriptionId + "/services/networking/media";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    NetworkGetConfigurationResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new NetworkGetConfigurationResponse();
                    result.Configuration = responseContent;
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The List Virtual network sites operation retrieves the virtual
        /// networks configured for the subscription.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157185.aspx
        /// for more information)
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response structure for the Network Operations List operation.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.Network.Models.NetworkListResponse> ListAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                Tracing.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + this.Client.Credentials.SubscriptionId + "/services/networking/virtualnetwork";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    NetworkListResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new NetworkListResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement virtualNetworkSitesSequenceElement = responseDoc.Element(XName.Get("VirtualNetworkSites", "http://schemas.microsoft.com/windowsazure"));
                    if (virtualNetworkSitesSequenceElement != null && virtualNetworkSitesSequenceElement.IsEmpty == false)
                    {
                        foreach (XElement virtualNetworkSitesElement in virtualNetworkSitesSequenceElement.Elements(XName.Get("VirtualNetworkSite", "http://schemas.microsoft.com/windowsazure")))
                        {
                            NetworkListResponse.VirtualNetworkSite virtualNetworkSiteInstance = new NetworkListResponse.VirtualNetworkSite();
                            result.VirtualNetworkSites.Add(virtualNetworkSiteInstance);
                            
                            XElement nameElement = virtualNetworkSitesElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                            if (nameElement != null && nameElement.IsEmpty == false)
                            {
                                string nameInstance = nameElement.Value;
                                virtualNetworkSiteInstance.Name = nameInstance;
                            }
                            
                            XElement labelElement = virtualNetworkSitesElement.Element(XName.Get("Label", "http://schemas.microsoft.com/windowsazure"));
                            if (labelElement != null && labelElement.IsEmpty == false)
                            {
                                string labelInstance = labelElement.Value;
                                virtualNetworkSiteInstance.Label = labelInstance;
                            }
                            
                            XElement idElement = virtualNetworkSitesElement.Element(XName.Get("Id", "http://schemas.microsoft.com/windowsazure"));
                            if (idElement != null && idElement.IsEmpty == false)
                            {
                                string idInstance = idElement.Value;
                                virtualNetworkSiteInstance.Id = idInstance;
                            }
                            
                            XElement affinityGroupElement = virtualNetworkSitesElement.Element(XName.Get("AffinityGroup", "http://schemas.microsoft.com/windowsazure"));
                            if (affinityGroupElement != null && affinityGroupElement.IsEmpty == false)
                            {
                                string affinityGroupInstance = affinityGroupElement.Value;
                                virtualNetworkSiteInstance.AffinityGroup = affinityGroupInstance;
                            }
                            
                            XElement stateElement = virtualNetworkSitesElement.Element(XName.Get("State", "http://schemas.microsoft.com/windowsazure"));
                            if (stateElement != null && stateElement.IsEmpty == false)
                            {
                                string stateInstance = stateElement.Value;
                                virtualNetworkSiteInstance.State = stateInstance;
                            }
                            
                            XElement addressSpaceElement = virtualNetworkSitesElement.Element(XName.Get("AddressSpace", "http://schemas.microsoft.com/windowsazure"));
                            if (addressSpaceElement != null && addressSpaceElement.IsEmpty == false)
                            {
                                NetworkListResponse.AddressSpace addressSpaceInstance = new NetworkListResponse.AddressSpace();
                                virtualNetworkSiteInstance.AddressSpace = addressSpaceInstance;
                                
                                XElement addressPrefixesSequenceElement = addressSpaceElement.Element(XName.Get("AddressPrefixes", "http://schemas.microsoft.com/windowsazure"));
                                if (addressPrefixesSequenceElement != null && addressPrefixesSequenceElement.IsEmpty == false)
                                {
                                    foreach (XElement addressPrefixesElement in addressPrefixesSequenceElement.Elements(XName.Get("AddressPrefix", "http://schemas.microsoft.com/windowsazure")))
                                    {
                                        addressSpaceInstance.AddressPrefixes.Add(addressPrefixesElement.Value);
                                    }
                                }
                            }
                            
                            XElement subnetsSequenceElement = virtualNetworkSitesElement.Element(XName.Get("Subnets", "http://schemas.microsoft.com/windowsazure"));
                            if (subnetsSequenceElement != null && subnetsSequenceElement.IsEmpty == false)
                            {
                                foreach (XElement subnetsElement in subnetsSequenceElement.Elements(XName.Get("Subnet", "http://schemas.microsoft.com/windowsazure")))
                                {
                                    NetworkListResponse.Subnet subnetInstance = new NetworkListResponse.Subnet();
                                    virtualNetworkSiteInstance.Subnets.Add(subnetInstance);
                                    
                                    XElement nameElement2 = subnetsElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                                    if (nameElement2 != null && nameElement2.IsEmpty == false)
                                    {
                                        string nameInstance2 = nameElement2.Value;
                                        subnetInstance.Name = nameInstance2;
                                    }
                                    
                                    XElement addressPrefixElement = subnetsElement.Element(XName.Get("AddressPrefix", "http://schemas.microsoft.com/windowsazure"));
                                    if (addressPrefixElement != null && addressPrefixElement.IsEmpty == false)
                                    {
                                        string addressPrefixInstance = addressPrefixElement.Value;
                                        subnetInstance.AddressPrefix = addressPrefixInstance;
                                    }
                                }
                            }
                            
                            XElement dnsElement = virtualNetworkSitesElement.Element(XName.Get("Dns", "http://schemas.microsoft.com/windowsazure"));
                            if (dnsElement != null && dnsElement.IsEmpty == false)
                            {
                                XElement dnsServersSequenceElement = dnsElement.Element(XName.Get("DnsServers", "http://schemas.microsoft.com/windowsazure"));
                                if (dnsServersSequenceElement != null && dnsServersSequenceElement.IsEmpty == false)
                                {
                                    foreach (XElement dnsServersElement in dnsServersSequenceElement.Elements(XName.Get("DnsServer", "http://schemas.microsoft.com/windowsazure")))
                                    {
                                        NetworkListResponse.DnsServer dnsServerInstance = new NetworkListResponse.DnsServer();
                                        virtualNetworkSiteInstance.DnsServers.Add(dnsServerInstance);
                                        
                                        XElement nameElement3 = dnsServersElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                                        if (nameElement3 != null && nameElement3.IsEmpty == false)
                                        {
                                            string nameInstance3 = nameElement3.Value;
                                            dnsServerInstance.Name = nameInstance3;
                                        }
                                        
                                        XElement addressElement = dnsServersElement.Element(XName.Get("Address", "http://schemas.microsoft.com/windowsazure"));
                                        if (addressElement != null && addressElement.IsEmpty == false)
                                        {
                                            string addressInstance = addressElement.Value;
                                            dnsServerInstance.Address = addressInstance;
                                        }
                                    }
                                }
                            }
                            
                            XElement gatewayElement = virtualNetworkSitesElement.Element(XName.Get("Gateway", "http://schemas.microsoft.com/windowsazure"));
                            if (gatewayElement != null && gatewayElement.IsEmpty == false)
                            {
                                NetworkListResponse.Gateway gatewayInstance = new NetworkListResponse.Gateway();
                                virtualNetworkSiteInstance.Gateway = gatewayInstance;
                                
                                XElement profileElement = gatewayElement.Element(XName.Get("Profile", "http://schemas.microsoft.com/windowsazure"));
                                if (profileElement != null && profileElement.IsEmpty == false)
                                {
                                    GatewayProfile profileInstance = ((GatewayProfile)Enum.Parse(typeof(GatewayProfile), profileElement.Value, true));
                                    gatewayInstance.Profile = profileInstance;
                                }
                                
                                XElement sitesSequenceElement = gatewayElement.Element(XName.Get("Sites", "http://schemas.microsoft.com/windowsazure"));
                                if (sitesSequenceElement != null && sitesSequenceElement.IsEmpty == false)
                                {
                                    foreach (XElement sitesElement in sitesSequenceElement.Elements(XName.Get("LocalNetworkSite", "http://schemas.microsoft.com/windowsazure")))
                                    {
                                        NetworkListResponse.LocalNetworkSite localNetworkSiteInstance = new NetworkListResponse.LocalNetworkSite();
                                        gatewayInstance.Sites.Add(localNetworkSiteInstance);
                                        
                                        XElement nameElement4 = sitesElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                                        if (nameElement4 != null && nameElement4.IsEmpty == false)
                                        {
                                            string nameInstance4 = nameElement4.Value;
                                            localNetworkSiteInstance.Name = nameInstance4;
                                        }
                                        
                                        XElement vpnGatewayAddressElement = sitesElement.Element(XName.Get("VpnGatewayAddress", "http://schemas.microsoft.com/windowsazure"));
                                        if (vpnGatewayAddressElement != null && vpnGatewayAddressElement.IsEmpty == false)
                                        {
                                            string vpnGatewayAddressInstance = vpnGatewayAddressElement.Value;
                                            localNetworkSiteInstance.VpnGatewayAddress = vpnGatewayAddressInstance;
                                        }
                                        
                                        XElement addressSpaceElement2 = sitesElement.Element(XName.Get("AddressSpace", "http://schemas.microsoft.com/windowsazure"));
                                        if (addressSpaceElement2 != null && addressSpaceElement2.IsEmpty == false)
                                        {
                                            NetworkListResponse.AddressSpace addressSpaceInstance2 = new NetworkListResponse.AddressSpace();
                                            localNetworkSiteInstance.AddressSpace = addressSpaceInstance2;
                                            
                                            XElement addressPrefixesSequenceElement2 = addressSpaceElement2.Element(XName.Get("AddressPrefixes", "http://schemas.microsoft.com/windowsazure"));
                                            if (addressPrefixesSequenceElement2 != null && addressPrefixesSequenceElement2.IsEmpty == false)
                                            {
                                                foreach (XElement addressPrefixesElement2 in addressPrefixesSequenceElement2.Elements(XName.Get("AddressPrefix", "http://schemas.microsoft.com/windowsazure")))
                                                {
                                                    addressSpaceInstance2.AddressPrefixes.Add(addressPrefixesElement2.Value);
                                                }
                                            }
                                        }
                                        
                                        XElement connectionsSequenceElement = sitesElement.Element(XName.Get("Connections", "http://schemas.microsoft.com/windowsazure"));
                                        if (connectionsSequenceElement != null && connectionsSequenceElement.IsEmpty == false)
                                        {
                                            foreach (XElement connectionsElement in connectionsSequenceElement.Elements(XName.Get("Connection", "http://schemas.microsoft.com/windowsazure")))
                                            {
                                                NetworkListResponse.Connection connectionInstance = new NetworkListResponse.Connection();
                                                localNetworkSiteInstance.Connections.Add(connectionInstance);
                                                
                                                XElement typeElement = connectionsElement.Element(XName.Get("Type", "http://schemas.microsoft.com/windowsazure"));
                                                if (typeElement != null && typeElement.IsEmpty == false)
                                                {
                                                    LocalNetworkConnectionType typeInstance = NetworkManagementClient.ParseLocalNetworkConnectionType(typeElement.Value);
                                                    connectionInstance.Type = typeInstance;
                                                }
                                            }
                                        }
                                    }
                                }
                                
                                XElement vPNClientAddressPoolElement = gatewayElement.Element(XName.Get("VPNClientAddressPool", "http://schemas.microsoft.com/windowsazure"));
                                if (vPNClientAddressPoolElement != null && vPNClientAddressPoolElement.IsEmpty == false)
                                {
                                    NetworkListResponse.VPNClientAddressPool vPNClientAddressPoolInstance = new NetworkListResponse.VPNClientAddressPool();
                                    gatewayInstance.VPNClientAddressPool = vPNClientAddressPoolInstance;
                                    
                                    XElement addressPrefixesSequenceElement3 = vPNClientAddressPoolElement.Element(XName.Get("AddressPrefixes", "http://schemas.microsoft.com/windowsazure"));
                                    if (addressPrefixesSequenceElement3 != null && addressPrefixesSequenceElement3.IsEmpty == false)
                                    {
                                        foreach (XElement addressPrefixesElement3 in addressPrefixesSequenceElement3.Elements(XName.Get("AddressPrefix", "http://schemas.microsoft.com/windowsazure")))
                                        {
                                            vPNClientAddressPoolInstance.AddressPrefixes.Add(addressPrefixesElement3.Value);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Set Network Configuration operation asynchronously configures
        /// the virtual network.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157181.aspx
        /// for more information)
        /// </summary>
        /// <param name='parameters'>
        /// Required. Parameters supplied to the Set Network Configuration
        /// operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself. If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request. If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationStatusResponse> SetConfigurationAsync(NetworkSetConfigurationParameters parameters, CancellationToken cancellationToken)
        {
            NetworkManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "SetConfigurationAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                OperationResponse response = await client.Networks.BeginSettingConfigurationAsync(parameters, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                OperationStatusResponse result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                int delayInSeconds = 30;
                while ((result.Status != OperationStatus.InProgress) == false)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                    result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                    delayInSeconds = 30;
                }
                
                if (shouldTrace)
                {
                    Tracing.Exit(invocationId, result);
                }
                
                if (result.Status != OperationStatus.Succeeded)
                {
                    if (result.Error != null)
                    {
                        CloudException ex = new CloudException(result.Error.Code + " : " + result.Error.Message);
                        ex.ErrorCode = result.Error.Code;
                        ex.ErrorMessage = result.Error.Message;
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    else
                    {
                        CloudException ex = new CloudException("");
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                }
                
                return result;
            }
            finally
            {
                if (client != null && shouldTrace)
                {
                    client.Dispose();
                }
            }
        }
    }
}

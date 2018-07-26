// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A server blob auditing policy.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ServerBlobAuditingPolicy : ProxyResource
    {
        /// <summary>
        /// Initializes a new instance of the ServerBlobAuditingPolicy class.
        /// </summary>
        public ServerBlobAuditingPolicy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ServerBlobAuditingPolicy class.
        /// </summary>
        /// <param name="state">Specifies the state of the policy. If state is
        /// Enabled, storageEndpoint and storageAccountAccessKey are required.
        /// Possible values include: 'Enabled', 'Disabled'</param>
        /// <param name="id">Resource ID.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="storageEndpoint">Specifies the blob storage endpoint
        /// (e.g. https://MyAccount.blob.core.windows.net). If state is
        /// Enabled, storageEndpoint is required.</param>
        /// <param name="storageAccountAccessKey">Specifies the identifier key
        /// of the auditing storage account. If state is Enabled,
        /// storageAccountAccessKey is required.</param>
        /// <param name="retentionDays">Specifies the number of days to keep in
        /// the audit logs.</param>
        /// <param name="auditActionsAndGroups">Specifies the Actions-Groups
        /// and Actions to audit.
        ///
        /// The recommended set of action groups to use is the following
        /// combination - this will audit all the queries and stored procedures
        /// executed against the database, as well as successful and failed
        /// logins:
        ///
        /// BATCH_COMPLETED_GROUP,
        /// SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP,
        /// FAILED_DATABASE_AUTHENTICATION_GROUP.
        ///
        /// This above combination is also the set that is configured by
        /// default when enabling auditing from the Azure portal.
        ///
        /// The supported action groups to audit are (note: choose only
        /// specific groups that cover your auditing needs. Using unnecessary
        /// groups could lead to very large quantities of audit records):
        ///
        /// APPLICATION_ROLE_CHANGE_PASSWORD_GROUP
        /// BACKUP_RESTORE_GROUP
        /// DATABASE_LOGOUT_GROUP
        /// DATABASE_OBJECT_CHANGE_GROUP
        /// DATABASE_OBJECT_OWNERSHIP_CHANGE_GROUP
        /// DATABASE_OBJECT_PERMISSION_CHANGE_GROUP
        /// DATABASE_OPERATION_GROUP
        /// DATABASE_PERMISSION_CHANGE_GROUP
        /// DATABASE_PRINCIPAL_CHANGE_GROUP
        /// DATABASE_PRINCIPAL_IMPERSONATION_GROUP
        /// DATABASE_ROLE_MEMBER_CHANGE_GROUP
        /// FAILED_DATABASE_AUTHENTICATION_GROUP
        /// SCHEMA_OBJECT_ACCESS_GROUP
        /// SCHEMA_OBJECT_CHANGE_GROUP
        /// SCHEMA_OBJECT_OWNERSHIP_CHANGE_GROUP
        /// SCHEMA_OBJECT_PERMISSION_CHANGE_GROUP
        /// SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP
        /// USER_CHANGE_PASSWORD_GROUP
        /// BATCH_STARTED_GROUP
        /// BATCH_COMPLETED_GROUP
        ///
        /// These are groups that cover all sql statements and stored
        /// procedures executed against the database, and should not be used in
        /// combination with other groups as this will result in duplicate
        /// audit logs.
        ///
        /// For more information, see [Database-Level Audit Action
        /// Groups](https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-action-groups).
        ///
        /// For Database auditing policy, specific Actions can also be
        /// specified (note that Actions cannot be specified for Server
        /// auditing policy). The supported actions to audit are:
        /// SELECT
        /// UPDATE
        /// INSERT
        /// DELETE
        /// EXECUTE
        /// RECEIVE
        /// REFERENCES
        ///
        /// The general form for defining an action to be audited is:
        /// &lt;action&gt; ON &lt;object&gt; BY &lt;principal&gt;
        ///
        /// Note that &lt;object&gt; in the above format can refer to an object
        /// like a table, view, or stored procedure, or an entire database or
        /// schema. For the latter cases, the forms DATABASE::&lt;db_name&gt;
        /// and SCHEMA::&lt;schema_name&gt; are used, respectively.
        ///
        /// For example:
        /// SELECT on dbo.myTable by public
        /// SELECT on DATABASE::myDatabase by public
        /// SELECT on SCHEMA::mySchema by public
        ///
        /// For more information, see [Database-Level Audit
        /// Actions](https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-actions)</param>
        /// <param name="storageAccountSubscriptionId">Specifies the blob
        /// storage subscription Id.</param>
        /// <param name="isStorageSecondaryKeyInUse">Specifies whether
        /// storageAccountAccessKey value is the storage's secondary
        /// key.</param>
        public ServerBlobAuditingPolicy(BlobAuditingPolicyState state, string id = default(string), string name = default(string), string type = default(string), string storageEndpoint = default(string), string storageAccountAccessKey = default(string), int? retentionDays = default(int?), IList<string> auditActionsAndGroups = default(IList<string>), System.Guid? storageAccountSubscriptionId = default(System.Guid?), bool? isStorageSecondaryKeyInUse = default(bool?))
            : base(id, name, type)
        {
            State = state;
            StorageEndpoint = storageEndpoint;
            StorageAccountAccessKey = storageAccountAccessKey;
            RetentionDays = retentionDays;
            AuditActionsAndGroups = auditActionsAndGroups;
            StorageAccountSubscriptionId = storageAccountSubscriptionId;
            IsStorageSecondaryKeyInUse = isStorageSecondaryKeyInUse;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets specifies the state of the policy. If state is
        /// Enabled, storageEndpoint and storageAccountAccessKey are required.
        /// Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.state")]
        public BlobAuditingPolicyState State { get; set; }

        /// <summary>
        /// Gets or sets specifies the blob storage endpoint (e.g.
        /// https://MyAccount.blob.core.windows.net). If state is Enabled,
        /// storageEndpoint is required.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageEndpoint")]
        public string StorageEndpoint { get; set; }

        /// <summary>
        /// Gets or sets specifies the identifier key of the auditing storage
        /// account. If state is Enabled, storageAccountAccessKey is required.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageAccountAccessKey")]
        public string StorageAccountAccessKey { get; set; }

        /// <summary>
        /// Gets or sets specifies the number of days to keep in the audit
        /// logs.
        /// </summary>
        [JsonProperty(PropertyName = "properties.retentionDays")]
        public int? RetentionDays { get; set; }

        /// <summary>
        /// Gets or sets specifies the Actions-Groups and Actions to audit.
        ///
        /// The recommended set of action groups to use is the following
        /// combination - this will audit all the queries and stored procedures
        /// executed against the database, as well as successful and failed
        /// logins:
        ///
        /// BATCH_COMPLETED_GROUP,
        /// SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP,
        /// FAILED_DATABASE_AUTHENTICATION_GROUP.
        ///
        /// This above combination is also the set that is configured by
        /// default when enabling auditing from the Azure portal.
        ///
        /// The supported action groups to audit are (note: choose only
        /// specific groups that cover your auditing needs. Using unnecessary
        /// groups could lead to very large quantities of audit records):
        ///
        /// APPLICATION_ROLE_CHANGE_PASSWORD_GROUP
        /// BACKUP_RESTORE_GROUP
        /// DATABASE_LOGOUT_GROUP
        /// DATABASE_OBJECT_CHANGE_GROUP
        /// DATABASE_OBJECT_OWNERSHIP_CHANGE_GROUP
        /// DATABASE_OBJECT_PERMISSION_CHANGE_GROUP
        /// DATABASE_OPERATION_GROUP
        /// DATABASE_PERMISSION_CHANGE_GROUP
        /// DATABASE_PRINCIPAL_CHANGE_GROUP
        /// DATABASE_PRINCIPAL_IMPERSONATION_GROUP
        /// DATABASE_ROLE_MEMBER_CHANGE_GROUP
        /// FAILED_DATABASE_AUTHENTICATION_GROUP
        /// SCHEMA_OBJECT_ACCESS_GROUP
        /// SCHEMA_OBJECT_CHANGE_GROUP
        /// SCHEMA_OBJECT_OWNERSHIP_CHANGE_GROUP
        /// SCHEMA_OBJECT_PERMISSION_CHANGE_GROUP
        /// SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP
        /// USER_CHANGE_PASSWORD_GROUP
        /// BATCH_STARTED_GROUP
        /// BATCH_COMPLETED_GROUP
        ///
        /// These are groups that cover all sql statements and stored
        /// procedures executed against the database, and should not be used in
        /// combination with other groups as this will result in duplicate
        /// audit logs.
        ///
        /// For more information, see [Database-Level Audit Action
        /// Groups](https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-action-groups).
        ///
        /// For Database auditing policy, specific Actions can also be
        /// specified (note that Actions cannot be specified for Server
        /// auditing policy). The supported actions to audit are:
        /// SELECT
        /// UPDATE
        /// INSERT
        /// DELETE
        /// EXECUTE
        /// RECEIVE
        /// REFERENCES
        ///
        /// The general form for defining an action to be audited is:
        /// &amp;lt;action&amp;gt; ON &amp;lt;object&amp;gt; BY
        /// &amp;lt;principal&amp;gt;
        ///
        /// Note that &amp;lt;object&amp;gt; in the above format can refer to
        /// an object like a table, view, or stored procedure, or an entire
        /// database or schema. For the latter cases, the forms
        /// DATABASE::&amp;lt;db_name&amp;gt; and
        /// SCHEMA::&amp;lt;schema_name&amp;gt; are used, respectively.
        ///
        /// For example:
        /// SELECT on dbo.myTable by public
        /// SELECT on DATABASE::myDatabase by public
        /// SELECT on SCHEMA::mySchema by public
        ///
        /// For more information, see [Database-Level Audit
        /// Actions](https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-actions)
        /// </summary>
        [JsonProperty(PropertyName = "properties.auditActionsAndGroups")]
        public IList<string> AuditActionsAndGroups { get; set; }

        /// <summary>
        /// Gets or sets specifies the blob storage subscription Id.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageAccountSubscriptionId")]
        public System.Guid? StorageAccountSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets specifies whether storageAccountAccessKey value is the
        /// storage's secondary key.
        /// </summary>
        [JsonProperty(PropertyName = "properties.isStorageSecondaryKeyInUse")]
        public bool? IsStorageSecondaryKeyInUse { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}
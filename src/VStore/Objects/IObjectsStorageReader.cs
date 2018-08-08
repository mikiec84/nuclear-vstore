﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using NuClear.VStore.DataContract;
using NuClear.VStore.Descriptors;
using NuClear.VStore.Descriptors.Objects;
using NuClear.VStore.Descriptors.Templates;

namespace NuClear.VStore.Objects
{
    public interface IObjectsStorageReader
    {
        Task<ContinuationContainer<IdentifyableObjectRecord<long>>> List(string continuationToken);
        Task<IReadOnlyCollection<ObjectMetadataRecord>> GetObjectMetadatas(IReadOnlyCollection<long> ids);
        Task<IVersionedTemplateDescriptor> GetTemplateDescriptor(long id, string versionId);
        Task<IReadOnlyCollection<ObjectVersionRecord>> GetObjectVersions(long id, string initialVersionId);
        Task<IReadOnlyCollection<ObjectVersionMetadataRecord>> GetObjectVersionsMetadata(long id, string initialVersionId);
        Task<IReadOnlyCollection<VersionedObjectDescriptor<string>>> GetObjectLatestVersions(long id);
        Task<ObjectDescriptor> GetObjectDescriptor(long id, string versionId, CancellationToken cancellationToken);
        Task<bool> IsObjectExists(long id);

        /// <summary>
        /// Get object's image element value
        /// </summary>
        /// <param name="id">Object identifier</param>
        /// <param name="versionId">Version identifier</param>
        /// <param name="templateCode">Element template code</param>
        /// <returns>Value of object's image element</returns>
        /// <exception cref="S3.ObjectNotFoundException">Object, specified version or element with specified template code is not found</exception>
        /// <exception cref="S3.ObjectElementInvalidTypeException">Specified object element is not an image</exception>
        Task<IImageElementValue> GetImageElementValue(long id, string versionId, int templateCode);
    }
}
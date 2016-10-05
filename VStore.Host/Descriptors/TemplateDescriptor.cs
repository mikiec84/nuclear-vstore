﻿using System;
using System.Collections.Generic;

namespace NuClear.VStore.Host.Descriptors
{
    public sealed class TemplateDescriptor : IEquatable<TemplateDescriptor>
    {
        public TemplateDescriptor()
        {
            ElementDescriptors = new List<IElementDescriptor>();
        }

        public Guid Id { get; set; }

        public string VersionId { get; set; }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        public IList<IElementDescriptor> ElementDescriptors { get; }

        public override bool Equals(object obj)
        {
            var other = obj as TemplateDescriptor;
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id && (VersionId?.Equals(other.VersionId, StringComparison.OrdinalIgnoreCase) ?? false);
        }

        public bool Equals(TemplateDescriptor other) => other.Equals(this);

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode() * 397) ^ (VersionId?.GetHashCode() ?? 0);
            }
        }
    }
}
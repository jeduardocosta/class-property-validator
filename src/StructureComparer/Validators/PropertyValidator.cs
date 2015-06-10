﻿using System.Collections.Generic;
using System.Reflection;
using StructureComparer.Extensions;

namespace StructureComparer.Validators
{
    internal interface IPropertyValidator
    {
        bool ValidateName(PropertyInfo baseProperty, PropertyInfo toCompareProperty);
        bool ValidateNameExistance(PropertyInfo baseProperty, IEnumerable<PropertyInfo> toCompareTypeProperties);
    }

    internal class PropertyValidator : IPropertyValidator
    {
        public bool ValidateName(PropertyInfo baseProperty, PropertyInfo toCompareProperty)
        {
            return baseProperty.Name == toCompareProperty.Name;
        }

        public bool ValidateNameExistance(PropertyInfo baseProperty, IEnumerable<PropertyInfo> toCompareTypeProperties)
        {
            var baseTypePropertyName = baseProperty.Name;
            var toCompareTypeProperty = toCompareTypeProperties.GetByName(baseTypePropertyName);
            return toCompareTypeProperty != null;
        }
    }
}
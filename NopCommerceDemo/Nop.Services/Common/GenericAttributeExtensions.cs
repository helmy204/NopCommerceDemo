﻿using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;

namespace Nop.Services.Common
{
    public static class GenericAttributeExtensions
    {
        //public static TPropType GetAttribute<TPropType>(this BaseEntity entity,
        //    string key, IGenericAttributeService genericAttributeService, int storeId = 0)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("entity");

        //    string keyGroup = entity.GetUnproxiedEntityType().Name;

        //    var props = genericAttributeService.GetAttributesForEntity(entity.Id, keyGroup);
        //    // little hack here (only for unit testing). we should write ecpet-return rules in unit tests for such cases
        //    if (props == null)
        //        return default(TPropType);
        //    props = props.Where(x => x.StoreId == storeId).ToList();
        //    if (props.Count == 0)
        //        return default(TPropType);

        //    var prop = props.FirstOrDefault(ga =>
        //        ga.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)); // should be culture invariant

        //    if (prop == null || string.IsNullOrEmpty(prop.Value))
        //        return default(TPropType);


        //}
    }
}

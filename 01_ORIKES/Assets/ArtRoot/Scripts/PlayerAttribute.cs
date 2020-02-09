//=====================================================
// - FileName:      PlayerAttribute.cs
// - Created:       02/01/2020 00:05:20
// - UserName:      Allen Zhang
// - Email:         allen.zhang@sencity.city
// - Description:   
// -  (C) Copyright 2019 - 2029, Allen Zhang,Inc.
// -  All Rights Reserved.
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AllenHelper
{
    public class PlayerAttribute : GameObjectAttributeBuilder {
        void Awake()
        {
            RegisterDefaultAttribute(AttributeField.speed.ToString(),1);
        }
    }
}
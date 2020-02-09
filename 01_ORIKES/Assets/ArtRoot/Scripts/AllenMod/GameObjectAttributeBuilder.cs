//=====================================================
// - Created:       2019/05/17 18:38:14
// - UserName:      Allen Zhang
// - Email:         allen.zhang@sencity.city
// - Description:   
// -  (C) Copyright 2019 - 2029, Allen Zhang,Inc.
// -  All Rights Reserved.
//======================================================
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace AllenHelper
{
    public class GameObjectAttributeBuilder : MonoBehaviour
    {
        public UnityAction<string> onAttributeChanged;
        public const string DEFAULTKEY = "default";
        /// <summary>
        /// 属性
        /// </summary>
        public readonly Dictionary<string, float> attribute_float = new Dictionary<string, float>();
        /// <summary>
        /// 注册初始值
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        public void RegisterDefaultAttribute(string field, float value)
        {
            AttributeModify(field, DEFAULTKEY, value);
        }
        /// <summary>
        /// 属性修改器
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="key">识别符</param>
        /// <param name="value">值</param>
        public void AttributeModify(string field, string key, float value)
        {
            string _key = MakeKey(field, key);

            AttributeModify(_key, value);
        }
        /// <summary>
        /// 属性修改器
        /// </summary>
        /// <param name="_key">字段名和识别符的组合，比如:"speed,rocket"</param>
        /// <param name="value">值</param>
        public void AttributeModify(string _key, float value)
        {
            
            _key = _key.ToLower();
            
            if (attribute_float.ContainsKey(_key)) //如果存在字段，修改值
            {
                if (attribute_float[_key] != value)
                    attribute_float[_key] = value;
            }
            else //如果字段不存在，新建并存入
                attribute_float.Add(_key, value);

            
            if(onAttributeChanged!=null)onAttributeChanged(_key);
            
        }
        public float GetFloatByAttribute(string field, string key)
        {
            string _key = MakeKey(field, key);
            if (!attribute_float.Keys.Contains(_key)) return 0;
           
            return attribute_float[_key];
            
        }
        public float GetFloatByAttribute(AttributeField field,string key)
        {
           return GetFloatByAttribute(field.ToString(),key);
        }
        /// <summary>
        /// 获取Float属性
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public float GetRealFloatByAttribute(string field, AttributeLogic logic = AttributeLogic.add)
        {
            field =field.ToLower();
            // if (GetFloatByAttribute(field,DEFAULTKEY)<=0) return 0;
            // float realAttribute = (mode == AttributeMode.add) ? 0 : realAttribute = attribute_float[MakeKey (field, DEFAULTKEY)];
            float realAttribute = attribute_float.ContainsKey(MakeKey(field, DEFAULTKEY))?attribute_float[MakeKey(field,DEFAULTKEY)]:0;
             
            foreach (var item in attribute_float)
            {
                string[] tepmKey = item.Key.Split(',');
                if (tepmKey[0] == field && !tepmKey[1].Contains(DEFAULTKEY))
                {
                    switch (logic)
                    {
                        case AttributeLogic.add:
                            realAttribute += item.Value;
                            break;
                        case AttributeLogic.mulit:
                            float tempValue = item.Value;
                            if (tempValue == 0) tempValue = 1;
                            realAttribute *= tempValue;
                            break;
                        case AttributeLogic.or:
                            if (item.Value > 0) realAttribute = 1;
                            break;
                        case AttributeLogic.and:
                            if (item.Value <= 0) realAttribute = 0;
                            break;
                    }
                }

            }
            return realAttribute;
        }
        public static string MakeKey(string field, string key)
        {
            field = field.ToLower();
            key = key.ToLower();
            return string.Format("{0},{1}", field, key);
        }
        public void RestoreAttribute(string field){
            field = field.ToLower();
            List<string> keys = new List<string>();
            foreach (var item in attribute_float)
            {
                string[] key = item.Key.Split(',');
                if(key[1]!=DEFAULTKEY&&key[0]==field){
                    keys.Add(item.Key);
                }
            }
            foreach (var item in keys)
                attribute_float[item]=0;
            
        }
    }
    public enum AttributeLogic
    {
        add,
        mulit,
        or,
        and
    }
    public enum AttributeField{
        speed
    }
}

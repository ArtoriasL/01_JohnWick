//=====================================================
// - FileName:      HelperInputSystem.cs
// - Created:       01/31/2020 21:25:36
// - UserName:      Allen Zhang
// - Email:         allen.zhang@sencity.city
// - Description:   
// -  (C) Copyright 2019 - 2029, Allen Zhang,Inc.
// -  All Rights Reserved.
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AllenHelper {
    public class HelperInputSystem : SingletonMonoBehaviour<HelperInputSystem> {
        public InputActionMap actionMap;
        public void SetActionMap (InputActionAsset actionAsset, string mapName) {

            actionMap = actionAsset.FindActionMap (mapName);
            actionMap.Enable ();
        }

        public void AddCallback (System.Action<InputAction.CallbackContext> action, int mode = 0) {
            var a = actionMap.FindAction (action.Method.Name.Replace ("On", ""));

            switch (mode) {
                case 0:
                    a.started += action;
                    break;
                case 1:
                    a.performed += action;
                    break;
                case 2:
                    a.canceled += action;
                    break;
            }

        }
    }
}
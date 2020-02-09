//=====================================================
// - FileName:      GameObjectActorController.cs
// - Created:       01/31/2020 17:19:31
// - UserName:      Allen Zhang
// - Email:         allen.zhang@sencity.city
// - Description:   
// -  (C) Copyright 2019 - 2029, Allen Zhang,Inc.
// -  All Rights Reserved.
//======================================================
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.InputSystem;
// using UnityEngine.Experimental.Input;

namespace AllenHelper {
    public class GameObjectActorController : MonoBehaviour {
        // HelperInputSystem inputs;
        public InputActionAsset inputs;

        public Transform cameraController;
        //Player
        public GameObject player;
        [HideInInspector] public PlayerAttribute attribute;
        [HideInInspector] public GameObjectAnimancer animancer;
        [HideInInspector] public vRagdoll ragdoll;

        private void Awake () {
            HelperInputSystem.Instance.SetActionMap (inputs, "Player");
            HelperInputSystem.Instance.AddCallback (OnTest, 1);

            attribute = player.GetComponent<PlayerAttribute> ();
            animancer = player.GetComponent<GameObjectAnimancer> ();
            ragdoll = player.GetComponent<vRagdoll> ();
            // Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnTest (InputAction.CallbackContext ctx) {
            animancer.StartPlayAnim (0);
            //    ragdoll.ActivateRagdoll();
        }
    }
}
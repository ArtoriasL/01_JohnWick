//=====================================================
// - FileName:      GameObjectActorController.cs
// - Created:       01/31/2020 17:19:31
// - UserName:      Allen Zhang
// - Email:         allen.zhang@sencity.city
// - Description:   
// -  (C) Copyright 2019 - 2029, Allen Zhang,Inc.
// -  All Rights Reserved.
//======================================================
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.InputSystem;

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
        [HideInInspector] public vThirdPersonController thirdController;

        private void Awake () {
            attribute = player.GetComponent<PlayerAttribute> ();
            animancer = player.GetComponent<GameObjectAnimancer> ();
            ragdoll = player.GetComponent<vRagdoll> ();
            thirdController = player.GetComponent<vThirdPersonController> ();
            InputSystemInit ();
        }
        public void InputSystemInit () {
            HelperInputSystem.Instance.SetActionMap (inputs, "Player");
            HelperInputSystem.Instance.AddCallback (OnConsole, 1);
            HelperInputSystem.Instance.AddCallback (OnHorizontal, 1);
            HelperInputSystem.Instance.AddCallback (OnVerticall, 1);
            HelperInputSystem.Instance.AddCallback (OnJump, 1);
            HelperInputSystem.Instance.AddCallback (OnRoll, 1);
            HelperInputSystem.Instance.AddCallback (OnCrouch, 1);
            HelperInputSystem.Instance.AddCallback (OnSprint, 1);
            HelperInputSystem.Instance.AddCallback (OnStrafe, 1);
            HelperInputSystem.Instance.AddCallback (OnRotateCameraX, 1);
            HelperInputSystem.Instance.AddCallback (OnRotateCameraY, 1);
        }
        public void OnConsole (InputAction.CallbackContext ctx) {
            // Debug.Log("test");
            thirdController.debugWindow = !thirdController.debugWindow;
        }
        public void OnHorizontal (InputAction.CallbackContext ctx) {
            // Debug.Log (ctx.ReadValueAsObject ());
        }
        public void OnVerticall (InputAction.CallbackContext ctx) {
            // Debug.Log (ctx.ReadValueAsObject ());
        }
        public void OnJump (InputAction.CallbackContext ctx) {

        }
        public void OnRoll (InputAction.CallbackContext ctx) {

        }
        public void OnCrouch (InputAction.CallbackContext ctx) {

        }
        public void OnSprint (InputAction.CallbackContext ctx) {

        }
        public void OnStrafe (InputAction.CallbackContext ctx) {

        }
        public void OnRotateCameraX (InputAction.CallbackContext ctx) {
            // Debug.Log (ctx.ReadValueAsObject ());
        }
        public void OnRotateCameraY (InputAction.CallbackContext ctx) {
            // Debug.Log (ctx.ReadValueAsObject ());
        }
    }
}
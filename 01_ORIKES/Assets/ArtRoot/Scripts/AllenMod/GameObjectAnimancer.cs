using System.Security.AccessControl;
//=====================================================
// - FileName:      GameobjectAnimancer.cs
// - Created:       12/25/2019 12:59:23
// - UserName:      Allen Zhang
// - Email:         allen.zhang@sencity.city
// - Description:   
// -  (C) Copyright 2019 - 2029, Allen Zhang,Inc.
// -  All Rights Reserved.
//======================================================
using System;
using System.Collections;
using System.Collections.Generic;
using Animancer;
using UnityEngine;
namespace AllenHelper {
    [RequireComponent (typeof (AnimancerComponent))]
    public class GameObjectAnimancer : MonoBehaviour {
        [SerializeField] AnimancerComponent _animancer;
        [SerializeField] AnimationClip[] _animClips;
        [SerializeField] AnimancerPlayOption _animOption;

        void Awake () {
            if (!_animancer) _animancer = GetComponent<AnimancerComponent> ();
        }
        IEnumerator Start () {

            yield return new WaitForSeconds (_animOption.defaultDelay);
            if (_animOption.defaultIndex > -1) {
                StartCoroutine (PlayAnim (_animOption.defaultIndex, 5f));
            }

        }
        IEnumerator PlayAnim (int index, float disable) {
            _animancer.Play (_animClips[index]);
            yield return new WaitForSeconds (disable);
            _animancer.enabled = false;
        }
        public void StartPlayAnim (int index, float disable = 3f) {
            StartCoroutine (PlayAnim (index, disable));
        }

        [Serializable]
        public class AnimancerPlayOption {
            public int defaultIndex = -1;
            public float defaultDelay;
            public bool isLoop;
        }
    }
}
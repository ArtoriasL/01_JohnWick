//=====================================================
// - FileName:      RandomAudioPlayer.cs
// - Created:       02/02/2020 21:50:17
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
    public class RandomAudioPlayer : MonoBehaviour {
        [SerializeField]AudioSource audioSource;
        [SerializeField]AudioClip[] clips;
        [SerializeField]bool playOnAwake=true;
        void Awake()
        {
            if(!audioSource)audioSource=GetComponent<AudioSource>();
            if(clips!=null)audioSource.clip=clips[Random.Range(0,clips.Length)];
            if(playOnAwake)audioSource.Play();
        }
    }
}
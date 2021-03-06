﻿/*
Copyright 2016 Frederic Babord

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

    
This is adapted from: http://wiki.unity3d.com/index.php?title=CreateScriptableObjectAsset to fit the intantory system

*/

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class InvantoryObject : ScriptableObject
{

	#if UNITY_EDITOR
    [MenuItem("Assets/Create/Invantory Object")]
    public static InvantoryObject CreateAsset()
    {
        InvantoryObject io = ScriptableObjectUtility.CreateAsset<InvantoryObject>();
        io.itemLogic.name = io.name;
        return io;
	}
	#endif

    public GameObject objectPrefab;
    public Sprite objectImage;
    public int quantity = 1;
    public InvantoryItemLogic itemLogic;
	public InventoryEquipLogic equipLogic;
    public string objectTooltip;
	public float rotationX;
	public float rotationY;
	public float rotationZ;

}
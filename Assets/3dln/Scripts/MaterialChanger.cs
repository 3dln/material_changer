//  A Simple Script to change the materials on a game object and all the nested children
//  Author: Ashkan Ashtiani
//  Github: https://github.com/3dln/material_changer

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{

    //  The material which we want to change to
    public Material rMaterial;

    //  List of all materials in SkinnedMeshRenderer components
    private List<Material[]> smrMaterials;

    void Start()
    {
        smrMaterials = new List<Material[]>();

        //Reading all the materials to reapply them later  
        ReadAllMaterials();
    }

    private void ReadAllMaterials()
    {
        //  First we read all the materials in skinnedmeshrenderer components
        SkinnedMeshRenderer[] skins = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer skin in skins)
        {
            if (skin.material != null)
            {
                smrMaterials.Add(skin.materials);
                Material[] _mats = new Material[skin.materials.Length];
                for (int i = 0; i < _mats.Length; i++)
                {
                    _mats[i] = rMaterial;
                }
                skin.materials = _mats;
            }
        }
    }
}

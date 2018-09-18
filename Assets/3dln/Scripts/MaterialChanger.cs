﻿//  A Simple Script to change the materials on a game object and all the nested children
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
    //  List of all materials in MeshRenderer components
    private List<Material[]> mrMaterials;
    //  To check if materials are swapped or not
    private bool hasDefaultMats = true;

    void Start()
    {
        smrMaterials = new List<Material[]>();
        mrMaterials = new List<Material[]>();
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
            }
        }

        // Then we read all the materials in MeshRenderer components and save them for later use
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            if (meshRenderer.material != null)
            {
                mrMaterials.Add(meshRenderer.materials);
            }
        }
    }

    private void ReplaceAllMaterials()
    {
        hasDefaultMats = false;
        SkinnedMeshRenderer[] skins = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer skin in skins)
        {
            if (skin.material != null)
            {
                Material[] _mats = new Material[skin.materials.Length];
                for (int i = 0; i < _mats.Length; i++)
                {
                    _mats[i] = rMaterial;
                }
                skin.materials = _mats;
            }
        }

        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            if (meshRenderer.material != null)
            {
                Material[] _mats = new Material[meshRenderer.materials.Length];
                for (int i = 0; i < _mats.Length; i++)
                {
                    _mats[i] = rMaterial;
                }
                meshRenderer.materials = _mats;
            }
        }
    }

    public void SwapAllMaterials()
    {
        if (hasDefaultMats)
            ReplaceAllMaterials();
    }
}

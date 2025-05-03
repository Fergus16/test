// Copyright (c) 2019-present, Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Developer Agreement, located
// here: https://auth.magicleap.com/terms/developer
using System.Collections.Generic;
using UnityEngine;

namespace MagicLeap.DesignToolkit.Samples
{
    /// <summary>
    /// Quickly bake a skinned mesh for direct interaction
    /// </summary>
    public class SkinnedMeshCollider : MonoBehaviour
    {
        public SkinnedMeshRenderer MeshRenderer;
        public MeshCollider Collider;

        public void Start()
        {
            UpdateCollider();
        }
    
        public void UpdateCollider() {
            Mesh colliderMesh = new Mesh();
            MeshRenderer.BakeMesh(colliderMesh);
            Collider.sharedMesh = null;
            Collider.sharedMesh = colliderMesh;
        }
    }   
}
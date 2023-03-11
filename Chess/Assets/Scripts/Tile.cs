using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Material baseMaterial, offsetMaterial;
    [SerializeField] private MeshRenderer tileRenderer;

    public void Init(bool isOffset)
    {
        tileRenderer.material = isOffset ? offsetMaterial : baseMaterial;
    }

    void OnMouseEnter()
    {

    }

    void OnMouseExit()
    {

    }
}
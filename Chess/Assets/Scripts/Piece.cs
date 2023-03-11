using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private Material whiteMaterial, blackMaterial;
    [SerializeField] private MeshRenderer pieceRenderer;

    public void Init(bool team)
    {
        pieceRenderer.material = team ? whiteMaterial : blackMaterial;
    }

    void OnMouseDown()
    {
        Debug.Log($"Piece {this.name} clicked");
    }

    void OnMouseEnter()
    {

    }

    void OnMouseExit()
    {

    }
}

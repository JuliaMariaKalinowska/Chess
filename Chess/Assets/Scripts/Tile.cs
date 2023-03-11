using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Material baseMaterial, offsetMaterial;
    [SerializeField] private MeshRenderer tileRenderer;

    public Piece occupant;
    public void Init(bool isOffset)
    {
        tileRenderer.material = isOffset ? offsetMaterial : baseMaterial;
        occupant = null;
    }

    void OnMouseDown()
    {
        //Debug.Log($"Tile {this.name}; occupant {occupant?.name}");
    }

    void OnMouseEnter()
    {
        //Debug.Log($"Tile {this.name}; occupant {occupant?.name}");
        if(occupant != null) occupant.transform.position += new Vector3(0, 0.3f, 0);

    }

    void OnMouseExit()
    {
        if (occupant != null) occupant.transform.position -= new Vector3(0, 0.3f, 0);
    }
}
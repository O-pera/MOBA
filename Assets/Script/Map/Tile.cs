using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour{
    private int _tileIndex = -1;
    public int TileIndex { get => _tileIndex; set => _tileIndex = value; }

    private bool _canMove = true;
    public bool CanMove { get => _canMove; }

    private Color _defaultColor = Color.gray;
    private MeshRenderer _renderer = null;

    private void Awake() {
        _renderer = GetComponent<MeshRenderer>();
        _defaultColor = _renderer.material.color;
    }

    public void Release() {
        _renderer.material.color = _defaultColor;
    }

    public void RaycastedByMouseAxisActor() {
        Color reactColor = Color.white;
        if(_canMove)
            reactColor = Color.green;
        else
            reactColor = Color.red;

        _renderer.material.color = reactColor;
    }
}
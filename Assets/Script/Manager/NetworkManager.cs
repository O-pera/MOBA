using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    [SerializeField] private bool _isOnline = false;
    public bool IsOnline { get => _isOnline; }
}

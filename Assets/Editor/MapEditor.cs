using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;
using Palmmedia.ReportGenerator.Core;

[CustomEditor(typeof(MapGenerator))]
public class MapEditor : Editor{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();      // 베이스 함수를 호출함으로써 인스펙터의 기본 구성들을 그린다.
        MapGenerator map = target as MapGenerator;

        if(GUILayout.Button("Generate Map")) { map.GenerateMap(); }
        if(GUILayout.Button("Set Visible"))  { map.SetVisible();  }
    }
}

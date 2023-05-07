using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;
using Palmmedia.ReportGenerator.Core;

[CustomEditor(typeof(MapGenerator))]
public class MapEditor : Editor{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();      // ���̽� �Լ��� ȣ�������ν� �ν������� �⺻ �������� �׸���.
        MapGenerator map = target as MapGenerator;

        if(GUILayout.Button("Generate Map")) { map.GenerateMap(); }
        if(GUILayout.Button("Set Visible"))  { map.SetVisible();  }
    }
}

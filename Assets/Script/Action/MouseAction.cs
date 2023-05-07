using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Insomnia {
    public class MouseAction : MonoBehaviour {
        [SerializeField] private GameObject _player = null;
        [SerializeField] private Tile _pointed = null;
        public Tile PointedTile { get => _pointed; }
        public void SetPointedTile(Tile tile) {
            if(tile == _pointed)
                return;

            if(_pointed != null)
                _pointed.Release();

            _pointed = tile;
            if(tile == null)
                return;
            tile.RaycastedByMouseAxisActor();
        }

        public void OnClick_MoveToPointedTile() {
            if(_pointed == null) {
                Debug.Log("���õ� Ÿ���� �����ϴ�!");
                return;
            }

            if(_pointed.CanMove == false) {
                Debug.Log("�ش� Ÿ�Ϸ� �̵��� �� �����ϴ�!");
                return;
            }

            //TODO: ���¹̳� 1 �Ҹ�, ��Ŷ ����Ͽ� �ֱ�
            //TODO: �ӽ÷� ���� ��. ���߿� ������ �ʿ� ����.

            Vector3 targetPosition = new Vector3(_pointed.transform.position.x, 0, _pointed.transform.position.z);

            _player.transform.position = new Vector3(targetPosition.x, _player.transform.position.y, targetPosition.z);

        }
    }
}
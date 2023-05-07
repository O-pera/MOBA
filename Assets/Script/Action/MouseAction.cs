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
                Debug.Log("선택된 타일이 없습니다!");
                return;
            }

            if(_pointed.CanMove == false) {
                Debug.Log("해당 타일로 이동할 수 없습니다!");
                return;
            }

            //TODO: 스태미너 1 소모, 패킷 대기목록에 넣기
            //TODO: 임시로 붙인 것. 나중에 수정할 필요 있음.

            Vector3 targetPosition = new Vector3(_pointed.transform.position.x, 0, _pointed.transform.position.z);

            _player.transform.position = new Vector3(targetPosition.x, _player.transform.position.y, targetPosition.z);

        }
    }
}
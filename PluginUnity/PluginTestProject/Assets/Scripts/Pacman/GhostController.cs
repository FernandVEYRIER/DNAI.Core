﻿using UnityEngine;

namespace Assets.Scripts.Pacman
{
    public class GhostController : MonoBehaviour
    {
        [SerializeField]
        private AstarTest _astar;

        [SerializeField]
        private float _distanceDelta = 0.1f;

        private GameObject _target;
        private DNAI.Astar2.Astar2.Position _targetPos = new DNAI.Astar2.Astar2.Position();
        private DNAI.Astar2.Astar2.Position _currPos = new DNAI.Astar2.Astar2.Position();

        private void Start()
        {
            _currPos.X = 1;
            _currPos.Y = 1;
            _targetPos.X = 4;
            _targetPos.Y = 1;
        }

        private void Update()
        {
            if (_target == null)
            {
                _target = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
                _currPos = TerrainManager.Instance.GetGridPosition(transform.position.x, transform.position.y).AsPosition();
                Debug.Log("Currentpos=" + _currPos.Display() + " Targetpos="+_targetPos.Display());
                var nodes = _astar.GetDestinationPath(_currPos, _targetPos);
                for (int i = 0; i < nodes.Count; i++)
                {
                    int node = nodes[i];
                    Debug.Log("Node["+i+"]"+_astar.GetNode(node).Display());
                }

                _targetPos = _astar.GetNode(nodes[1]);
                Debug.LogError("Targetpos=" + _targetPos.Display());
            }
            transform.position = Vector3.MoveTowards(transform.position,
                TerrainManager.Instance.GetWorldPosition((int)_targetPos.X, (int)_targetPos.Y),
                _distanceDelta);
        }
    }
}
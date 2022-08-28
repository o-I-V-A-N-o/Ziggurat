using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class ZigguratController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;

        [Tooltip("Задержка перед спавном")]
        [SerializeField, Range(0, 5)]
        private float spawnSpeed;

        [Tooltip("Цвет игрока")]
        [SerializeField,]
        private COLOR playerColor;
        

        void Start()
        {
            StartCoroutine(Creator());
        }

        private IEnumerator Creator()
        {
            while (true)
            {
                var unit = Instantiate(_playerPrefab, transform.position + Vector3.up * 12, transform.localRotation);
                Material unitColor = unit.GetComponentInChildren<SkinnedMeshRenderer>().material;
                switch (playerColor)
                {
                    case COLOR.Green:
                        unitColor.color = Color.green;
                        break;
                    case COLOR.Red:
                        unitColor.color = Color.red;
                        break;
                    case COLOR.Blue:
                        unitColor.color = Color.blue;
                        break;
                }

                yield return new WaitForSeconds(spawnSpeed);
            }
        }

        public enum COLOR
        {
            Green,
            Red,
            Blue
        }
    }
}

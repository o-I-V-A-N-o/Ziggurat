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
        private string playerColor;

        [SerializeField]
        private COLOR col;

        void Start()
        {
            StartCoroutine(Creator());
        }

        private IEnumerator Creator()
        {
            while (true)
            {
                var inst = Instantiate(_playerPrefab, transform.position + Vector3.up * 12, transform.localRotation);
                yield return new WaitForSeconds(spawnSpeed);
            }
        }

        public enum COLOR
        {
            Green = 0,
            Red = 1,
            Blue = 2
        }
    }
}

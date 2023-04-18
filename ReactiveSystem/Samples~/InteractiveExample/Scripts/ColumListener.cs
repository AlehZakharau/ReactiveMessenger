using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ReactiveSystem.Example.PowerTest.Scripts
{
    public class ColumListener : MonoBehaviour
    {
        public GameObject prefab;
        public int speed;

        private List<GameObject> cubes = new();
        private void Awake()
        {
            EventBus.Instance.Subscribe<MaxColumCubesSignal>(Initialize);
        }

        private void Activate(int amount)
        {
            for (int i = 0; i < cubes.Count; i++)
            {
                cubes[i].SetActive(i < amount);
            }
        }

        private void Initialize(MaxColumCubesSignal obj)
        {
            for (int i = 0; i < obj.MaxAmount; i++)
            {
                var cube = Instantiate(prefab, transform.position + new Vector3(0, i, 0), Quaternion.identity);
                cubes.Add(cube);
            }
        }

        private void Update()
        {
            if(Time.frameCount % speed != 0) return;
            Activate(Random.Range(0, cubes.Count));
        }
    }
}
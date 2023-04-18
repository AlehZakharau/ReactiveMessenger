using UnityEngine;
using Random = UnityEngine.Random;

namespace ReactiveSystem.Example.PowerTest.Scripts
{
    public class Controller : MonoBehaviour
    {
        public GameObject columPrefab;
        public int speed;
        private void Start()
        {
            EventBus.Instance.UnsubscribeAll();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Instantiate(columPrefab, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
            
            EventBus.Instance.Fire(new MaxColumCubesSignal(10));
        }


        private void Update()
        {
            if(Time.frameCount % speed != 0) return;
            EventBus.Instance.Fire(new CubeActionSignal(Random.ColorHSV()));
        }
    }
}
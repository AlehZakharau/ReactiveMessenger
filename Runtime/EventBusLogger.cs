using UnityEngine;

namespace ReactiveSystem
{
    public class EventBusLogger
    {
        public void FireLog<T>(T signal) 
        {
            Debug.Log($"Fire: <b><color=#FFFD55>{signal}</color></b>");
        }

        public void SubscribeLog<T>(T callback, int count)
        {
            Debug.Log($"Subscribe to <color=#FF925A>{typeof(T).GenericTypeArguments[0].Name}</color> " +
                      $" Count: <color=#74FAFF>{count}</color>");
        }

        public void UnSubscribeLog<T>(T callback, int count)
        {
            Debug.Log($"Subscribe to <color=#FF925A>{typeof(T).GenericTypeArguments[0].Name}</color> " +
                      $" Count: <color=#74FAFF>{count}</color>");
        }
    }
}
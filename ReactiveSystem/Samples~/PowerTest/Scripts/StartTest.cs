using System.Collections.Generic;
using UnityEngine;

namespace ReactiveSystem.Example.PowerTest.Scripts
{
    public class StartTest : MonoBehaviour
    {
        private bool isSimpleSignalTest;
        private bool isParamSignalTest;
        private bool isReferenceSignalTest;

        public int signalsPerSeconds;

        public void StartSimpleTest()
        {
            isSimpleSignalTest = !isSimpleSignalTest;
            Debug.Log("Start Simple Test");
        }
        public void StartParamTest()
        {
            isParamSignalTest = !isParamSignalTest;
            Debug.Log("Start Parameters Test");
        }
        public void StartReferenceTest()
        {
            isReferenceSignalTest = !isReferenceSignalTest;
            Debug.Log("Start Reference Test");
        }
        public void StartAllTest()
        {
            isSimpleSignalTest = true;
            isParamSignalTest = true;
            isReferenceSignalTest = true;
            Debug.Log("Start All Tests");
        }

        public void StopAllTest()
        {
            isSimpleSignalTest = false;
            isParamSignalTest = false;
            isReferenceSignalTest = false;
            Debug.Log("Stop All Tests");
        }

        private void SimpleSignalsTest()
        {
            for (int i = 0; i < signalsPerSeconds; i++)
            {
                EventBus.Instance.Fire(new PowerTestSignal());
            }
        }

        private List<string> testList = new();

        private void ParamSignalsTest()
        {
            for (int i = 0; i < signalsPerSeconds; i++)
            {
                EventBus.Instance.Fire(new PowerTestParamSignal(10, "test"));
            }
        }

        private void ReferenceSignalsTest()
        {
            for (int i = 0; i < signalsPerSeconds; i++)
            {
                EventBus.Instance.Fire(new PowerTestReferenceSignal(testList));
            }
        }


        private void Update()
        {
            if(isSimpleSignalTest)
                SimpleSignalsTest();
            if(isParamSignalTest)
                ParamSignalsTest();
            if(isReferenceSignalTest)
                ReferenceSignalsTest();
        }
    }
}
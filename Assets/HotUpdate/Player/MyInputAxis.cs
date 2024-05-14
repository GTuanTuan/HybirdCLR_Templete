using UnityEngine;

namespace Templete
{
    public class MyInputAxis
    {
        public KeyCode positiveKey;
        public KeyCode negativeKey;
        public float value = 0f;
        private float lastValue = 0f;
        public float gravity = 6f;
        public float dead = 0.001f;
        public float sensitivity = 3f; 

        private bool positive = false;
        public void Positive() { positive = true; }

        private bool negative = false;
        public void Negative() { negative = true; }

        private void Reset() { positive = false; negative = false; }

        public void Update()
        {
            bool pressed = false;
            if (Input.GetKey(positiveKey) || positive)
            {
                value += sensitivity * Time.deltaTime;
                pressed = true;
            }
            if (Input.GetKey(negativeKey) || negative)
            {
                value -= sensitivity * Time.deltaTime;
                pressed = true;
            }
            value =
                pressed ? value :
                value > 0 ? value - gravity * Time.deltaTime :
                value < 0 ? value + gravity * Time.deltaTime :
                value;
            lastValue = value =
                (Mathf.Abs(value) <= dead || lastValue * value < 0) ? 0 :
                (value > 1) ? 1 :
                (value < -1) ? -1 :
                value;
            Reset();
        }
    }
}


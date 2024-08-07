using UnityEngine;


namespace Game
{
    /// <summary>
    /// Connection between player/treasure and treasure
    /// </summary>
    public class TreasureConnection : MonoBehaviour
    {
        private Transform goalObj;
        private Transform connectedObj;
        private float goalDist;

        private float stiffness;
        private float oscillation;
        

        public void ConnectItems(Transform goalObj, Transform connectedObj, float initialDist, float stiffness, float oscillation)
        {
            this.goalObj = goalObj;
            this.connectedObj = connectedObj;
            goalDist = initialDist;

            this.stiffness = stiffness;
            this.oscillation = oscillation;


            Vector3 goalPos = goalObj.transform.position + goalDist * Vector3.up;
            connectedObj.transform.position = goalPos;
        }


        public void UpdateConnection()
        {

            //calculate Damped Oscillation

            Vector3 goalPos = goalObj.transform.position + Vector3.up * goalDist;

            Vector3 x0 = goalPos - connectedObj.transform.position;

            float t = Time.deltaTime;
            float m = 1f; //massa

            float k = 10f; //spring constant

            float b = 6f; // damping constant: b < sqrt(4km), oscillatio, b>=sqrt(4km) no oscillation

            float phaseShift = 0;

            float decayRate = b / (2 * m);
            float w0 = k / m;
            float wx = Mathf.Sqrt(w0 - Mathf.Pow(decayRate, 2));

            float change = Mathf.Exp(-b * t / (2 * m)) * Mathf.Cos(wx * t + phaseShift);

            float x = x0.x * change;
            float y = x0.y * change;

            
            connectedObj.transform.position = connectedObj.transform.position + (x0 - new Vector3(x, y, x0.z));

            
        }
    }
}


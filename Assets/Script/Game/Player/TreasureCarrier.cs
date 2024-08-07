using UnityEngine;

namespace Game
{
    /// <summary>
    /// simulates a stack of treasures, they are attached with springs to each other
    /// </summary>
    [RequireComponent(typeof(Player))]
    public class TreasureCarrier : MonoBehaviour
    {
        [SerializeField]
        private Transform treasureStackAnchor;
        [Range(0.1f,100f)]
        [SerializeField]
        private float springConstant = 10f; //kuinka jäykkä jousi on

        [Range(0.1f, 100f)]
        [SerializeField]
        private float dampingConstant = 6f; //kuinka paljon jousi oskilloi, damping constant: b < sqrt(4km) more oscillatio, b>=sqrt(4km) no oscillation

        private Player player;

        private void Start()
        {
            player = GetComponent<Player>();
        }

        private void Update()
        {
            UpdateTreasureStack();
        }

        private void UpdateTreasureStack()
        {
            for(int i = 0; i < player.Treasures.Count; i++)
            {
                Transform connectedObj = player.Treasures[i].transform;

                Transform goalObj = treasureStackAnchor;
                if(i > 0) 
                {
                    goalObj = player.Treasures[i - 1].transform;
                }

                UpdateConnection(goalObj, connectedObj, 1f, springConstant, dampingConstant, 1f, 0f);
            }
        }

        //k: spring constant, b: damping constant, m: mass
        private void UpdateConnection(Transform goalObj, Transform connectedObj, float goalDist, float k, float b, float m, float phaseShift)
        {
            //calculate Damped Oscillation

            Vector3 goalPos = goalObj.transform.position + Vector3.up * goalDist;

            Vector3 x0 = goalPos - connectedObj.transform.position;

            float t = Time.deltaTime;


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

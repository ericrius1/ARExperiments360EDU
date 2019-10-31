using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Eric.NeuralNetwork
{
    public class NNAxon : MonoBehaviour
    {

        LineRenderer lineRenderer;

        public int lineSegments = 33;

        public AnimationCurve widthCurve;

        public float curveStrength = 2;


        public Material m_material;
        void Awake()
        {

            lineRenderer = this.gameObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = .1f;
            lineRenderer.endWidth = .1f;
            lineRenderer.widthCurve = widthCurve;
            lineRenderer.positionCount = lineSegments;

            lineRenderer.material = m_material;
            lineRenderer.material.SetFloat("Time_Offset", Random.Range(5 , 33  ));
            //lineRenderer.material.SetColor("my_color", new Color(.1102f + Random.Range(0, 0.5f), .36f + Random.Range(0, .5f), .39f + Random.Range(0, .3f)));
            lineRenderer.material.SetColor("my_color", new Color(Random.Range(0.7f, 0.8f), Random.Range(0.0f, 0.2f),Random.Range(0.7f, 0.9f)));

            lineRenderer.useWorldSpace = false;

        }

        public void Grow(Vector3 startPosition, Vector3 endPosition)
        {

            Vector3 p0 = startPosition + Random.onUnitSphere * curveStrength;
            Vector3 p1 = startPosition;
            Vector3 p2 = endPosition;
            Vector3 p3 = endPosition + Random.onUnitSphere * curveStrength;
            List<Vector3> points = NNCatmullRomSpline.GetCatmullRomPositions(lineSegments, p0, p1, p2, p3);
            lineRenderer.SetPositions(points.ToArray());

        }



    }
}

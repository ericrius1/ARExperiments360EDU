using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Eric.NeuralNetwork
{
    public class NNSoma : MonoBehaviour
    {
        // Start is called before the first frame update

        MeshFilter m_MeshFilter;
        MeshRenderer m_MeshRenderer;

        public Mesh m_Mesh;

        public Material m_Material;


        public NNAxon axonPrefab;


        void Start()
        {
            m_MeshFilter = gameObject.AddComponent<MeshFilter>();
            m_MeshFilter.mesh = m_Mesh;

            m_MeshRenderer = gameObject.AddComponent<MeshRenderer>();
            m_MeshRenderer.material = m_Material;

        }

    }
}

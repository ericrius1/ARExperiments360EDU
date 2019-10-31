using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Eric.NeuralNetwork
{
    public class NNNeuralNetwork : MonoBehaviour
    {

        public NNSoma somaPrefab;
        public NNAxon axonPrefab;

        public int numNeurons = 5;
        public int numAxons = 22;

        List<NNSoma> somas;
        List<NNAxon> axons;

        // Axon key provides a pair of ints that refers to the start (originating) and end (terminating) index of its somas
        Dictionary<NNAxon, List<int>> axonConnectionMap;
        void Start()
        {


            SpawnSomas();
            CreateConnections();
        }

        void SpawnSomas()
        {
            somas = new List<NNSoma>();
            for(int i = 0; i < numNeurons; i++)
            {
                Vector3 position = Random.onUnitSphere * 5;
                NNSoma soma = Instantiate(somaPrefab, position, Quaternion.identity);
                soma.transform.parent = transform;
                somas.Add(soma);
               // Debug.Log("yaaaa");
            }
        }

        void CreateConnections()
        {
            axons = new List<NNAxon>();
            axonConnectionMap = new Dictionary<NNAxon, List<int>>();

            for(int i = 0; i < numAxons; i ++)
            {
                CreateConnection();
            }

       
        }

        void CreateConnection()
        {
            // select rwo random somas from list to create an axon connection
            int soma1Index = Random.Range(0, somas.Count);
            int soma2Index = Random.Range(0, somas.Count);
            while(soma2Index == soma1Index)
            {
                soma2Index = Random.Range(0, somas.Count);
            }

            NNAxon axon = Instantiate(axonPrefab, Vector3.zero, Quaternion.identity);
            axon.transform.parent = transform;
            axons.Add(axon);
            axonConnectionMap.Add(axon, new List<int>() {soma1Index, soma2Index });

            List<int> somaPair;
            axonConnectionMap.TryGetValue(axon, out somaPair);
            Vector3 startingPosition = somas[somaPair[0]].transform.position;
            Vector3 endingPosition = somas[somaPair[1]].transform.position;

            axon.Grow(startingPosition, endingPosition);



        }

    }
}
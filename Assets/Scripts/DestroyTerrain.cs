using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTerrain : MonoBehaviour
{
    [SerializeField]
    private Vector3 nextPos;
    [SerializeField]
    private GameObject[] _roadPrefab;

    private readonly Vector3 uberCostil = new Vector3(-3.67362f, 0f, 3.64247f);
    private readonly Vector3 uberCostil2 = new Vector3(5f, 0, 1f);

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.tag == "Road")
            GenerateNext();
    }

    void Start()
    {
        GenerateNext();
        GenerateNext();
        GenerateNext();
        GenerateNext();
        GenerateNext();
    }

    public void GenerateNext()
    {
        var flag = Random.Range(0, 2);
        var obsFlag = Random.Range(0, 4);

        var temp = Instantiate(_roadPrefab[obsFlag], nextPos, Quaternion.identity);
        if (flag == 1)
        {
            temp.transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
            temp.transform.position += uberCostil;
        }

        nextPos = temp.transform.GetChild(0).GetChild(8).position;
    }

}


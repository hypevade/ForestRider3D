using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField]
    private Vector3 nextPos;
    [SerializeField]
    private GameObject _roadPrefab;
    [SerializeField]
    private int _deleteTime;
    private float timer;
    [SerializeField]
    private float startPause = 5f;
    [SerializeField]
    private float frequency = 3f;

    private readonly Vector3 uberCostil = new Vector3(-3.67362f, 0f, 3.64247f);


    void Start()
    {
        timer = startPause;
        GenerateNext();
    }

    void FixedUpdate()
    {
        if (timer <= 0f)
        {
            timer = frequency;
            //GenerateNext();
        }
        timer -= Time.deltaTime;
    }

    public void GenerateNext()
    {
        var flag = Random.Range(0, 2);

        var temp = Instantiate(_roadPrefab, nextPos, Quaternion.identity);
        if (flag == 1)
        {
            temp.transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
            temp.transform.position += uberCostil;
        }
        else
            temp.transform.GetChild(0).localScale = new Vector3(1, 1, 1);
        nextPos = temp.transform.GetChild(0).GetChild(8).position;
        //StartCoroutine(Delete(temp));
    }

    //IEnumerator Delete(GameObject temp)
    //{
    //    yield return new WaitForSeconds(_deleteTime);
    //    Destroy(temp);
    //}
}

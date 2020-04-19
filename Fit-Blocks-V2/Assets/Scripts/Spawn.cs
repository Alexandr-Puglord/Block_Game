using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] Shape;
    // Start is called before the first frame update
    void Start()
    {
        NewBlock();
    }

    // Update is called once per frame
   public void NewBlock() //simply a randomization of asset line of code 
    {
        Instantiate(Shape[Random.Range(0, Shape.Length)], transform.position, Quaternion.identity);
    }
}

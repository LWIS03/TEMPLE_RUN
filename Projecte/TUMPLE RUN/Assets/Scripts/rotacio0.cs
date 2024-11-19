using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class rotacio0 : MonoBehaviour
{
    public GameObject cub;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = cub.transform.rotation;
    }
}

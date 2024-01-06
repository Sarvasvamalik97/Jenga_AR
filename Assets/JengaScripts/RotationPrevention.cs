using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPrevention : MonoBehaviour
{
    [SerializeField] private GameObject jengaPrefab;
    [SerializeField] private List<GameObject> jengaBlockList = new List<GameObject>();
    int jengaBlockCount = 0;

    public static RotationPrevention instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (jengaPrefab != null)
        {
            jengaBlockCount = jengaPrefab.transform.GetChild(0).transform.childCount;
        }
        for (int i = 0; i < jengaBlockCount - 1; i++)
        {
            jengaBlockList.Add(jengaPrefab.transform.GetChild(0).transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PreventOtherBlocksFromRotating(GameObject testBlock)
    {
        for (int i = 0; i < jengaBlockCount; i++)
        {
            if (testBlock.name != jengaBlockList[i].name)
            {
                jengaBlockList[i].GetComponent<Rigidbody>().freezeRotation = true;
            }
        }
    }

    public void RemoveConstraints()
    {
        for (int i = 0; i < jengaBlockCount; i++)
        {
            jengaBlockList[i].GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}

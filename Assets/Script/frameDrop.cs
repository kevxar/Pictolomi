using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameDrop : MonoBehaviour{
    public GameObject pictograma{
        get{
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    private void OnMouseUp()
    {
        if (!pictograma)
        {
            Drag.objectDragged.transform.SetParent(transform);
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

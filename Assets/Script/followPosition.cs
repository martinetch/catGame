using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPosition : MonoBehaviour
{
   //réference joueur
   public Transform targetTransform = null;

    // Update is called once per frame
    void Update()
    {
        if (this.targetTransform != null) {
            this.transform.position = new Vector3(this.targetTransform.position.x, this.targetTransform.position.y,  this.transform.position.z);
        }

    }
}

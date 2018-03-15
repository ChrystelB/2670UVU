using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put this script on an object with a collider set to isTrigger = true
public class UseZipline : MonoBehaviour {

    public Transform endPos;
    public GameObject player;

    public float time = 5;
    private float elapsedTime = 0;

    private bool isRunning = false;

    void OnTriggerEnter()
    {
        //prevents running multiple instances of coroutine per object.
        if(!isRunning)
        {
            StartCoroutine(Zipline());
        }
    }

    //lerps player from script's parent object to endPos variable
    IEnumerator Zipline()
    {
        isRunning = true;

        while (elapsedTime < time)
        {
            player.transform.position = Vector3.Lerp(transform.position, endPos.position, (elapsedTime / time));

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        isRunning = false;

        //resets elapsedTime to 0 so coroutine can run again
        elapsedTime = 0;

    }
}
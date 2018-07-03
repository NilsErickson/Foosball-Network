using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foosballPlayer : MonoBehaviour {

    public GameObject Character;
    public float Speed = 5f;
    public bool canControl;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Rotate(Vector3.right, 180, .1f));
        }

        if (canControl == true)
        {
            float h = Input.GetAxis("Horizontal") * Speed;

            Character.transform.Translate(h * Time.deltaTime, 0, 0);
        }
    }
    

    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }
}

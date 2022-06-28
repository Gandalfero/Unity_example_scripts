using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Checkpoint : MonoBehaviour
{
    Text checkpointText;

    private Vector3 checkpoint1;
    void Start()
    {
        checkpointText = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void TextDisabled()
    {
        checkpointText.enabled = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "PlayerCapsule")
        {
            checkpoint1 = gameObject.GetComponent<Transform>().transform.position;
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().checkpoint = checkpoint1;
            checkpointText.enabled = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Invoke("TextDisabled", 3);
            gameObject.SetActive(false);
        }
    }
}

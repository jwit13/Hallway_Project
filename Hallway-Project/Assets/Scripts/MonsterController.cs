using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System;

public class MonsterController : MonoBehaviour
{
    public Transform destination;
    NavMeshAgent navAgent;

    public GameObject player;
    Vector3 returnToStart;

    // Start is called before the first frame update
    void Start()
    {
        returnToStart = player.transform.position;
        navAgent = this.GetComponent<NavMeshAgent>();

        if (navAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            UIManager.instance.ShowScreen("Lose");
            AudioManager.instance.PlayBackground("Lose");
        }
    }

    private void SetDestination()
    {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navAgent.SetDestination(targetVector);
        }
    }
}

using UnityEngine;

public class RedLightGreenLightAI : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float decisionInterval = 2f; // Time interval for the AI to make decisions
    public float redLightDuration = 2f; // Time duration for red light

    private bool isRedLight = false;
    private float timer = 0f;

    enum AIState
    {
        Moving,
        Frozen
    }

    private AIState currentState = AIState.Moving;

    void Start()
    {
        // Start the decision-making process
        InvokeRepeating("MakeDecision", 0f, decisionInterval);
    }

    void Update()
    {
        if (currentState == AIState.Moving)
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        if (!isRedLight)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }

    void MakeDecision()
    {
        if (currentState == AIState.Moving)
        {
            // Switch to Frozen state during red light
            if (isRedLight)
            {
                currentState = AIState.Frozen;
                Invoke("ResumeMoving", redLightDuration);
            }
        }
    }

    void ResumeMoving()
    {
        currentState = AIState.Moving;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedLight"))
        {
            isRedLight = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RedLight"))
        {
            isRedLight = false;
        }
    }
}
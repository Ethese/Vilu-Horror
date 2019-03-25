using UnityEngine;
using UnityEngine.AI;

public class CarMovement3 : MonoBehaviour
{
    public NavMeshAgent agent;
    //Trsnforms
    public Transform[] puntos;
    public Transform puntoFinal;
    private Transform puntoInicio;

    // Start is called before the first frame update
    void Start()
    {
        puntoInicio = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Recorrido()
    {
        agent.SetDestination(new Vector3(puntoFinal.position.x, puntoFinal.position.y, puntoFinal.position.z));
    }
}

using UnityEngine;
using PathCreation;
using System.Collections;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    private float speed;
    public float startingPoint;
    [HideInInspector] public float distanceTravelled;

    void Start()
    {
        distanceTravelled = startingPoint;

        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    void Update()
    {
        speed = Player.Instance.GetSpeed();
        
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            SetPositionAlongPath();
        }
    }

    public void SetPositionAlongPath()
    {
        if (pathCreator != null)
        {
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}

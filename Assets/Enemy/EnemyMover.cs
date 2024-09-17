using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)]float speed = 1f;

    Enemy enemy;
 
    void OnEnable() 
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start() 
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Path").OrderBy(w => w.transform.position.z).OrderBy(w => w.transform.position.x).ToArray();

        foreach(GameObject waypoint in tiles)
            path.Add(waypoint.GetComponent<Waypoint>());
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            } 
        }
        
        FinishPath();
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
using UnityEngine;

public class SpawnScenery : MonoBehaviour
{
    [SerializeField][Header("gameobject used to spawn mountains")] private GameObject mountains;
    [SerializeField][Header("gameobject used to spawn trees")] private GameObject tree;
    [SerializeField][Header("Starting position of newly spawned mountains")] private GameObject mountainSpawnPos;
    [SerializeField][Header("Starting position of newly spawned trees")] private GameObject treeSpawnPos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("mountain"))
        {
            Instantiate(mountains,mountainSpawnPos.transform.position, Quaternion.identity);
            Destroy(other.transform.parent.gameObject,25f);
        }

        else if (other.tag.Equals("tree"))
        {
            Instantiate(tree, treeSpawnPos.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else if (other.tag.Equals("obstacle")||other.tag.Equals("pickup"))
        {
            Destroy(other.gameObject);
        }
    }
}

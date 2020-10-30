using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] Vector2 extent = Vector2.one;
    [SerializeField] bool randomX = true;
    [SerializeField] bool randomY = true;
    [Space]
    [SerializeField] GameObject toSpawn;
    [SerializeField] float spawnInterval = 1;
    [SerializeField] Transform spawnParent;
    [Space]
    [SerializeField] float startDelay;

    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(spawnInterval);
        yield return new WaitForSeconds(startDelay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    public virtual GameObject Spawn()
    {
        var spawn = Instantiate(toSpawn, spawnParent);
        spawn.transform.position = RandomPos();

        return spawn;
    }

    private Vector2 RandomPos()
    {
        return new Vector2() {
            x = transform.position.x + (randomX ? Random.Range(-extent.x, extent.x) * .5f : 0),
            y = transform.position.y + (randomY ? Random.Range(-extent.y, extent.y) * .5f : 0)
        };
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, extent);
    }
}

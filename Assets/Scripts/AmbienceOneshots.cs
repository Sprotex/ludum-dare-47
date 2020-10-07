using System.Collections;
using UnityEngine;

public class AmbienceOneshots : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string[] soundEvents;
    public Transform[] positions;
    public Vector2 randomTimeOffset;

    private IEnumerator PlayOnRandomLocation()
    {
        while(true)
        {
            var waitTime = Random.Range(randomTimeOffset.x, randomTimeOffset.y);
            yield return new WaitForSeconds(waitTime);
            var position = positions[Random.Range(0, positions.Length)];
            var soundEvent = soundEvents[Random.Range(0, soundEvents.Length)];
            var instance = FMODUnity.RuntimeManager.CreateInstance(soundEvent);
            instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(position));
            instance.start();
            instance.release();
        }
    }

    private void OnEnable() => StartCoroutine(PlayOnRandomLocation());
    private void OnDisable() => StopAllCoroutines();

}

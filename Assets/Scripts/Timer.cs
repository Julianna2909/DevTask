using System;
using System.Collections;
using UnityEngine;

public sealed class Timer : MonoBehaviour
{
    public void StartTimer(int seconds, Action onComplete, Action<int> onSecond)
    {
        StopTimer();
        StartCoroutine(RunTimer(seconds, onComplete, onSecond));
    }

    public void StopTimer() => StopAllCoroutines();

    private IEnumerator RunTimer(int seconds, Action onComplete, Action<int> onSecond)
    {
        var currentSecond = 0;
        var waitForOneSecond = new WaitForSeconds(1f);
        onSecond(currentSecond);

        while (currentSecond < seconds)
        {
            yield return waitForOneSecond;
            currentSecond++;
            onSecond(currentSecond);
        }
        
        onComplete();
    }
}

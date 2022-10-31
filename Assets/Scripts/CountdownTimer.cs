using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour {

    [SerializeField]
    private float countdownTime = 10f;
    [SerializeField]
    private bool isTimerRunning = false;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private UnityEvent OnCountdownStarted;
    [SerializeField]
    private UnityEvent OnCountdownFinished;

    private void Start() {
        if (isTimerRunning) {
            OnCountdownStarted?.Invoke();
        }
    }

    private void Update() {
        if (isTimerRunning) {
            if (countdownTime > 0) {
                countdownTime -= Time.deltaTime;
                DisplayTime(countdownTime);
            } else {
                OnCountdownFinished?.Invoke();
                countdownTime = 10;
                isTimerRunning = false;
            }
        }
    }

    private void DisplayTime(float timeToDisplay) {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("Countdown: {0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer() {
        isTimerRunning = true;
        OnCountdownStarted?.Invoke();
    }
}

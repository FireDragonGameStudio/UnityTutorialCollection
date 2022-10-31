using UnityEngine;
using UnityEngine.SceneManagement;

public class ProcessDeepLink : MonoBehaviour {

    // DeepLink can be tested on Android device via https://fdgs-deeplink-test.glitch.me/

    public static ProcessDeepLink Instance { get; private set; }

    public string DeepLinkURL = "[none]";

    [SerializeField]
    private bool testDeepLinkLoading;
    [SerializeField]
    private string sceneToLoad;

    public string FirstParameter { get; private set; }
    public string SecondParameter { get; set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;

            Application.deepLinkActivated += OnDeepLinkActivated;

            if (!string.IsNullOrEmpty(Application.absoluteURL)) {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                OnDeepLinkActivated(Application.absoluteURL);
                DeepLinkURL = Application.absoluteURL;
            }

            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (testDeepLinkLoading) {
            testDeepLinkLoading = !testDeepLinkLoading;
            OnDeepLinkActivated("testapp?parameter?anotherparam");
        }
    }

    private void OnDeepLinkActivated(string url) {
        // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
        DeepLinkURL = url;

        // e.g. unitydl://testapp?parameter?anotherparam
        // or from web unitydl://testdeeplink?ShadowPlayer666?124356890
        FirstParameter = url.Split('?')[1];
        SecondParameter = url.Split('?')[2];

        Debug.Log($"Deeplink parameter - 1: {FirstParameter}, 2: {SecondParameter}");

        if (!string.IsNullOrEmpty(FirstParameter) && !string.IsNullOrEmpty(SecondParameter)) {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void ManualDeepLinkLoading() {
        testDeepLinkLoading = true;
    }
}
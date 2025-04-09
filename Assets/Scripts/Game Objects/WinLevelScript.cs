using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevelScript : MonoBehaviour
{
    #region PROPERTIES
    [SerializeField] private GameObject[] slots;
    [SerializeField] private GameObject player;
    [SerializeField] private float waitTimeBeforeNextLevel;
    [SerializeField] private AudioClip winJingle;

    [Header("Switch worlds")]
    [SerializeField] private GameObject yinWorldManager;
    [SerializeField] private GameObject yangWorldManager;
    [SerializeField] private GameObject invertColourOverlay;

    [Header("Win screen animation")]
    [SerializeField] private float initialFlickerSpeed;
    [SerializeField] private float flickerSpeedIncrease;
    [SerializeField] private float minFlickerSpeed;
    [SerializeField] private float winAnimationRunTime;
    private bool isWinAnimationRunning = false;
    private float timer = 0f;
    private float timerRate;
    private bool playerHasWon = false;
    #endregion

    #region METHODS
    #region Win animation
    private void Start()
    {
        timerRate = initialFlickerSpeed;
    }

    private void Update()
    {
        // Run win animation
        if (isWinAnimationRunning)
        {
            // Run timer
            timer += Time.deltaTime;
            if (timer >= timerRate)
            {
                SwitchWorlds();
                // Reset timer and reduce rate
                timer = 0f;
                if (timerRate >= minFlickerSpeed) timerRate -= flickerSpeedIncrease;
            }
        }
    }

    /// <summary>
    /// Check if player has completed the level
    /// </summary>
    public void CheckWinState()
    {
        if (!playerHasWon)
        {
            // Check if all slots are full
            bool won = true;
            foreach (GameObject slot in slots)
            {
                if (!slot.GetComponent<SlotScript>().IsSlotFull())
                {
                    won = false;
                    break;
                }
            }
            playerHasWon = won;
            // Player has successfully completed the level
            if (playerHasWon)
            {
                // Deactivate player and start win animation
                player.SetActive(false);
                isWinAnimationRunning = true;
                Invoke(nameof(StopWinAnimation), winAnimationRunTime);
            }
        }
    }

    /// <summary>
    /// Stops win animation running and half the overlay
    /// </summary>
    private void StopWinAnimation()
    {
        if (isWinAnimationRunning)
        {
            isWinAnimationRunning = false;
            // Make sure both worlds and overlay are active
            yinWorldManager.SetActive(true);
            yangWorldManager.SetActive(true);
            invertColourOverlay.SetActive(true);
            invertColourOverlay.GetComponent<InvertOverlaySizeScript>().HalfWidth();
            AudioManagerScript.Instance.PlaySound(winJingle);
            Invoke(nameof(GoToNextLevel), waitTimeBeforeNextLevel);
        }
    }
    #endregion

    /// <summary>
    /// Load the next level
    /// </summary>
    private void GoToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneUtility.GetScenePathByBuildIndex(nextSceneIndex).Length > 0) SceneManager.LoadScene(nextSceneIndex);
    }

    /// <summary>
    /// Switch level between yin and yang worlds
    /// </summary>
    public void SwitchWorlds()
    {
        yinWorldManager.SetActive(!yinWorldManager.activeSelf);
        yangWorldManager.SetActive(!yangWorldManager.activeSelf);
        invertColourOverlay.SetActive(!invertColourOverlay.activeSelf);
    }
    #endregion
}

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;

    private void Update()
    {
        if (Input.GetKeyDown(StaticData.BACK_KEY) && _settingsPanel.activeInHierarchy)
        {
            ToggleSettingsPanel();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(StaticData.GAMEPLAY_SCENE_NAME, LoadSceneMode.Single);
    }

    public void ToggleSettingsPanel()
    {
        _settingsPanel.SetActive(!_settingsPanel.activeInHierarchy);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPoint : MonoBehaviour
{
    public int levelId;

    private void OnTriggerEnter2D(Collider2D other) {
        GameApp.MessageCenter.PostEvent(Defines.ShowLevelDescriptionEvent, levelId);
        Debug.Log("Level noktasına girdin.");
    }

    private void OnTriggerExit2D(Collider2D other) {
        GameApp.MessageCenter.PostEvent(Defines.HideLevelDescriptionEvent, levelId);
        Debug.Log("Level noktasından çıktın.");
    }
}

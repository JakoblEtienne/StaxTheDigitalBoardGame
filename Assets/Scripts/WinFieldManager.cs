using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WinFieldManager : MonoBehaviour
{
    public Button selectButton;

    public bool chanceForWinRed = false;
    public bool chanceForWinBlack = false;

    private GameplayManager gM;

    private void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
    }

    public void OnSelectButtonPressed()
    {
        if (!gM.spawnZweier)
        {
            if (transform.tag == "FieldWinRed")
            {
                GameObject lastBeatTokenRed = gM.beatTokensRed.Last();
                lastBeatTokenRed.transform.position = transform.position;
                gM.beatTokensRed.Remove(lastBeatTokenRed);
            }
            else if (transform.tag == "FieldWinBlack")
            {
                GameObject lastBeatTokenBlack = gM.beatTokensBlack.Last();
                lastBeatTokenBlack.transform.position = transform.position;
                gM.beatTokensBlack.Remove(lastBeatTokenBlack);
            }
            gM.DeactivateReturnTokenSelection();
        }
        else if (gM.spawnZweier)
        {
            if (transform.tag == "FieldWinRed")
            {
                GameObject lastBeatTokenRed = gM.beatTokensRed.Last();
                GameObject secondLastBeatTokenRed = gM.beatTokensRed[gM.beatTokensRed.Count - 2];

                lastBeatTokenRed.GetComponent<DragAndDrop>().canBeIgnored = true;
                lastBeatTokenRed.transform.position = new Vector3(0, -3, 0);
                secondLastBeatTokenRed.GetComponent<DragAndDrop>().canBeIgnored = true;
                secondLastBeatTokenRed.transform.position = new Vector3(0, -3, 0);

                gM.beatTokensRed.Remove(lastBeatTokenRed);
                gM.beatTokensRed.Remove(secondLastBeatTokenRed);

                GameObject ZweierRed = Instantiate(gM.ZweierRed, transform.position, Quaternion.identity, gM.TokensRedHolder.transform);

                gM.RefreshTokenLists();
            }
            else if (transform.tag == "FieldWinBlack")
            {
                GameObject lastBeatTokenBlack = gM.beatTokensBlack.Last();
                GameObject secondLastBeatTokenBlack = gM.beatTokensBlack[gM.beatTokensBlack.Count - 2];

                lastBeatTokenBlack.GetComponent<DragAndDrop>().canBeIgnored = true;
                lastBeatTokenBlack.transform.position = new Vector3(0, -3, 0);
                secondLastBeatTokenBlack.GetComponent<DragAndDrop>().canBeIgnored = true;
                secondLastBeatTokenBlack.transform.position = new Vector3(0, -3, 0);

                gM.beatTokensBlack.Remove(lastBeatTokenBlack);
                gM.beatTokensBlack.Remove(secondLastBeatTokenBlack);

                GameObject ZweierBlack = Instantiate(gM.ZweierBlack, transform.position, Quaternion.identity, gM.TokensBlackHolder.transform);

                gM.RefreshTokenLists();
            }

            gM.DeactivateReturnTokenSelection();
            gM.spawnZweier = false;
        }
        
    }
}

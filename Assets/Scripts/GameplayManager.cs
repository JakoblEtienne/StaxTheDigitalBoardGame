using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public List<GameObject> fields;
    public List<GameObject> winFieldsRed;
    public List<GameObject> winFieldsBlack;
    public List<GameObject> tokensRed;
    public List<GameObject> tokensBlack;
    public List<GameObject> beatTokenRedPositions;
    public List<GameObject> beatTokenBlackPositions;
    public List<GameObject> beatTokensRed;
    public List<GameObject> beatTokensBlack;

    public bool isAnyTokenRedSelected = false;
    public bool isAnyTokenBlackSelected = false;

    public bool isAnyTokenRedBeatable = false;
    public bool isAnyTokenBlackBeatable = false;

    public GameObject selectedTokenRed;
    public GameObject selectedTokenBlack;

    public int turnCounter = 0;
    public int curPlayer = 1;

    public List<GameObject> beatableTokensRed;
    public List<GameObject> beatableTokensBlack;

    private int lastTurnCounter = 0;

    public bool returnTokenSelectionIsActive = false;

    // Prefabs zum Spawnen
    public GameObject EinserRed;
    public GameObject EinserBlack;
    public GameObject ZweierRed;
    public GameObject ZweierBlack;

    public GameObject mainCamera;
    public GameObject TakeOrCapSelection;
    public Button capButton;
    public Button takeButton;
    public GameObject SelectionBlocker;
    public GameObject WinnerDisplay;
    public bool spawnZweier = false;

    public GameObject TokensRedHolder;
    public GameObject TokensBlackHolder;

    public GameObject rPos1, rPos2, rPos3, rPos4, rPos5, rPos6, rPos7, rPos8, rPos9, rPos10, rPos11, rPos12, rPos13, rPos14, rPos15, rPos16;
    public GameObject bPos1, bPos2, bPos3, bPos4, bPos5, bPos6, bPos7, bPos8, bPos9, bPos10, bPos11, bPos12, bPos13, bPos14, bPos15, bPos16;

    void Start()
    {
        fields = new List<GameObject>();
        winFieldsRed = new List<GameObject>();
        winFieldsBlack = new List<GameObject>();
        tokensRed = new List<GameObject>();
        tokensBlack = new List<GameObject>();
        beatTokenRedPositions = new List<GameObject>();
        beatTokenBlackPositions = new List<GameObject>();
        beatTokensRed = new List<GameObject>();
        beatTokensBlack = new List<GameObject>();

        beatTokenRedPositions.Add(rPos1); beatTokenRedPositions.Add(rPos2); beatTokenRedPositions.Add(rPos3); beatTokenRedPositions.Add(rPos4); beatTokenRedPositions.Add(rPos5);
        beatTokenRedPositions.Add(rPos6); beatTokenRedPositions.Add(rPos7); beatTokenRedPositions.Add(rPos8); beatTokenRedPositions.Add(rPos9); beatTokenRedPositions.Add(rPos10);
        beatTokenRedPositions.Add(rPos11); beatTokenRedPositions.Add(rPos12); beatTokenRedPositions.Add(rPos13); beatTokenRedPositions.Add(rPos14); beatTokenRedPositions.Add(rPos15);
        beatTokenRedPositions.Add(rPos16);

        beatTokenBlackPositions.Add(bPos1); beatTokenBlackPositions.Add(bPos2); beatTokenBlackPositions.Add(bPos3); beatTokenBlackPositions.Add(bPos4); beatTokenBlackPositions.Add(bPos5);
        beatTokenBlackPositions.Add(bPos6); beatTokenBlackPositions.Add(bPos7); beatTokenBlackPositions.Add(bPos8); beatTokenBlackPositions.Add(bPos9); beatTokenBlackPositions.Add(bPos10);
        beatTokenBlackPositions.Add(bPos11); beatTokenBlackPositions.Add(bPos12); beatTokenBlackPositions.Add(bPos13); beatTokenBlackPositions.Add(bPos14); beatTokenBlackPositions.Add(bPos15);
        beatTokenBlackPositions.Add(bPos16);

        fields.AddRange(GameObject.FindGameObjectsWithTag("Field"));
        fields.AddRange(GameObject.FindGameObjectsWithTag("FieldWinRed"));
        fields.AddRange(GameObject.FindGameObjectsWithTag("FieldWinBlack"));
        winFieldsRed.AddRange(GameObject.FindGameObjectsWithTag("FieldWinRed"));
        winFieldsBlack.AddRange(GameObject.FindGameObjectsWithTag("FieldWinBlack"));

        tokensRed.AddRange(GameObject.FindGameObjectsWithTag("TokenRed"));

        tokensBlack.AddRange(GameObject.FindGameObjectsWithTag("TokenBlack"));

        beatableTokensRed = new List<GameObject>();
        beatableTokensBlack = new List<GameObject>();        
    }

    void Update()
    {
        CheckIfAnyTokenSelected();
    }

    private void CheckIfAnyTokenSelected()
    {
        foreach (GameObject token in tokensRed)
        {
            if (token.TryGetComponent(out DragAndDrop dragAndDrop) && dragAndDrop.isSelected)
            {
                selectedTokenRed = token;
                isAnyTokenRedSelected = true;
            }
            else if (token.TryGetComponent(out DragAndDropZweier dragAndDropZ) && dragAndDropZ.isSelected)
            {
                selectedTokenRed = token;
                isAnyTokenRedSelected = true;
            }
            else if (token.TryGetComponent(out DragAndDropDreier dragAndDropD) && dragAndDropD.isSelected)
            {
                selectedTokenRed = token;
                isAnyTokenRedSelected = true;
            }                
        }
        foreach (GameObject token in tokensBlack)
        {
            if (token.TryGetComponent(out DragAndDrop dragAndDrop) && dragAndDrop.isSelected)
            {
                selectedTokenBlack = token;
                isAnyTokenBlackSelected = true;
            }
            else if (token.TryGetComponent(out DragAndDropZweier dragAndDropZ) && dragAndDropZ.isSelected)
            {
                selectedTokenBlack = token;
                isAnyTokenBlackSelected = true;
            }
            else if (token.TryGetComponent(out DragAndDropDreier dragAndDropD) && dragAndDropD.isSelected)
            {
                selectedTokenBlack = token;
                isAnyTokenBlackSelected = true;
            }
        }
    }

    public void CheckIfAnyTokenBeatable()
    {
        foreach (GameObject token in tokensRed)
        {
            if (token.TryGetComponent(out DragAndDrop dragAndDrop) && dragAndDrop.isBeatable)
            {
                HelpFunctionBeatableTokenRedToken(token);
            }
            else if (token.TryGetComponent(out DragAndDropZweier dragAndDropZ) && dragAndDropZ.isBeatable)
            {
                HelpFunctionBeatableTokenRedToken(token);
            }
            else if (token.TryGetComponent(out DragAndDropDreier dragAndDropD) && dragAndDropD.isBeatable)
            {
                HelpFunctionBeatableTokenRedToken(token);
            }
        }
        foreach (GameObject token in tokensBlack)
        {
            if (token.TryGetComponent(out DragAndDrop dragAndDrop) && dragAndDrop.isBeatable)
            {
                HelpFunctionBeatableTokenBlackToken(token);
            }
            else if (token.TryGetComponent(out DragAndDropZweier dragAndDropZ) && dragAndDropZ.isBeatable)
            {
                HelpFunctionBeatableTokenBlackToken(token);
            }
            else if (token.TryGetComponent(out DragAndDropDreier dragAndDropD) && dragAndDropD.isBeatable)
            {
                HelpFunctionBeatableTokenBlackToken(token);
            }
        }
    }

    public void SetNotAnyTokenSelected()
    {
        foreach (GameObject token in tokensRed)
        {
            HelpFunctionTokenNotSelected(token);
        }
        foreach (GameObject token in tokensBlack)
        {
            HelpFunctionTokenNotSelected(token);
        }

        isAnyTokenRedSelected = false;
        isAnyTokenBlackSelected = false;
        selectedTokenRed = null;
        selectedTokenBlack = null;
    }

    public void SetNotAnyTokenBeatable()
    {
        foreach (GameObject token in tokensRed)
        {
            HelpFunctionTokenNotBeatable(token);
        }
        foreach (GameObject token in tokensBlack)
        {
            HelpFunctionTokenNotBeatable(token);
        }

        isAnyTokenRedBeatable = false;
        isAnyTokenBlackBeatable = false;
        beatableTokensRed.Clear();
        beatableTokensBlack.Clear();
    }

    public void SetAllFieldsNotPlacable()
    {
        foreach (GameObject field in fields)
        {
            field.GetComponent<PlacementManager>().SetIsNotPlacable();
        }
    }

    public void RefreshTokenLists()
    {
        foreach(GameObject token in tokensRed)
        {
            if((token.TryGetComponent(out DragAndDropZweier dragAndDropZ) && dragAndDropZ.canBeIgnored) || (token.TryGetComponent(out DragAndDropDreier dragAndDropD) && dragAndDropD.canBeIgnored) 
                || (token.TryGetComponent(out DragAndDrop dragAndDrop) && dragAndDrop.canBeIgnored))
            {
                token.transform.tag = "Untagged";
            }
        }
        foreach (GameObject token in tokensBlack)
        {
            if ((token.TryGetComponent(out DragAndDropZweier dragAndDropZ) && dragAndDropZ.canBeIgnored) || (token.TryGetComponent(out DragAndDropDreier dragAndDropD) && dragAndDropD.canBeIgnored) 
                || (token.TryGetComponent(out DragAndDrop dragAndDrop) && dragAndDrop.canBeIgnored))
            {
                token.transform.tag = "Untagged";
            }
        }
        tokensRed.Clear();
        tokensBlack.Clear();
        tokensRed.AddRange(GameObject.FindGameObjectsWithTag("TokenRed"));
        tokensBlack.AddRange(GameObject.FindGameObjectsWithTag("TokenBlack"));
    }

    public void ActivateTakeOrCapSelectionOnPos(Vector3 pos)
    {
        SelectionBlocker.SetActive(true);
        TakeOrCapSelection.SetActive(true);
        TakeOrCapSelection.transform.position = new Vector3(pos.x, TakeOrCapSelection.transform.position.y, pos.z);
    }

    public void ActivateTakeOrCapSelectionOnPosRotated(Vector3 pos)
    {
        SelectionBlocker.SetActive(true);
        TakeOrCapSelection.SetActive(true);
        TakeOrCapSelection.transform.position = new Vector3(pos.x, TakeOrCapSelection.transform.position.y, pos.z);
        TakeOrCapSelection.transform.Rotate(Vector3.up, 180);
    }

    public void DeactivateTakeOrCapSelection()
    {
        TakeOrCapSelection.transform.rotation = Quaternion.identity;

        SelectionBlocker.SetActive(false);
        TakeOrCapSelection.SetActive(false);
    }

    public void ActivateReturnTokenSelectionOnPos(Vector3 pos, bool spawnZweier)
    {
        returnTokenSelectionIsActive = true;
        this.spawnZweier = spawnZweier;
        foreach (GameObject winField in winFieldsRed)
        {
            if(!winField.GetComponent<PlacementManager>().hasTokenRed && !winField.GetComponent<PlacementManager>().hasTokenBlack)
            {
                winField.GetComponent<WinFieldManager>().selectButton.gameObject.SetActive(true);
            }
        }
        SelectionBlocker.SetActive(true);
    }

    public void ActivateReturnTokenSelectionOnPosRotated(Vector3 pos, bool spawnZweier)
    {
        returnTokenSelectionIsActive = true;
        this.spawnZweier = spawnZweier;
        foreach (GameObject winField in winFieldsBlack)
        {
            if (!winField.GetComponent<PlacementManager>().hasTokenRed && !winField.GetComponent<PlacementManager>().hasTokenBlack)
            {
                winField.GetComponent<WinFieldManager>().selectButton.gameObject.SetActive(true);
            }
        }
        SelectionBlocker.SetActive(true);
    }

    public void DeactivateReturnTokenSelection()
    {
        SelectionBlocker.SetActive(false);

        foreach(GameObject winField in winFieldsRed)
        {
            winField.GetComponent<WinFieldManager>().selectButton.gameObject.SetActive(false);
        }
        foreach (GameObject winField in winFieldsBlack)
        {
            winField.GetComponent<WinFieldManager>().selectButton.gameObject.SetActive(false);
        }
        returnTokenSelectionIsActive = false;
    }

    public bool IsAnyWinFieldRedFreeAndEnoughTokens(int amountOfTokens)
    {
        if(beatTokensRed.Count >= amountOfTokens)
        {
            foreach(GameObject winField in winFieldsRed)
            {
                if (!winField.GetComponent<PlacementManager>().hasTokenRed && !winField.GetComponent<PlacementManager>().hasTokenBlack)
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }

    public bool IsAnyWinFieldBlackFreeAndEnoughTokens(int amountOfTokens)
    {
        if(beatTokensBlack.Count >= amountOfTokens)
        {
            foreach (GameObject winField in winFieldsBlack)
            {
                if (!winField.GetComponent<PlacementManager>().hasTokenRed && !winField.GetComponent<PlacementManager>().hasTokenBlack)
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }

    public async void ChangePlayerAsync()
    {
        CheckForWin();

        if (returnTokenSelectionIsActive)
        {
            await new WaitUntil(() => returnTokenSelectionIsActive == false);
        }

        if (curPlayer == 1)
        {
            mainCamera.transform.Rotate(new Vector3(0, 0, 180));
            curPlayer = 2;
        }
        else if (curPlayer == 2)
        {
            mainCamera.transform.Rotate(new Vector3(0, 0, -180));
            curPlayer = 1;
        }
        
    }

    private void CheckForWin()
    {
        foreach(GameObject winFieldRed in winFieldsRed)
        {
            if (winFieldRed.GetComponent<PlacementManager>().hasTokenBlack)
            {
                winFieldRed.GetComponent<WinFieldManager>().chanceForWinBlack = true;
            }
            else
            {
                winFieldRed.GetComponent<WinFieldManager>().chanceForWinBlack = false;
            }
        }
        foreach (GameObject winFieldBlack in winFieldsBlack)
        {
            if (winFieldBlack.GetComponent<PlacementManager>().hasTokenRed)
            {
                winFieldBlack.GetComponent<WinFieldManager>().chanceForWinRed = true;
            }
            else
            {
                winFieldBlack.GetComponent<WinFieldManager>().chanceForWinRed = false;
            }
        }
        if(lastTurnCounter == turnCounter - 1)
        {
            foreach (GameObject winFieldRed in winFieldsRed)
            {
                if (winFieldRed.GetComponent<PlacementManager>().hasTokenBlack && winFieldRed.GetComponent<WinFieldManager>().chanceForWinBlack == true)
                {
                    SelectionBlocker.SetActive(true);
                    WinnerDisplay.GetComponent<WinnerDisplay>().winnerText.text = "Player Blue Wins!";
                    WinnerDisplay.SetActive(true);
                }
            }
            foreach (GameObject winFieldBlack in winFieldsBlack)
            {
                if (winFieldBlack.GetComponent<PlacementManager>().hasTokenRed && winFieldBlack.GetComponent<WinFieldManager>().chanceForWinRed == true)
                {
                    SelectionBlocker.SetActive(true);
                    WinnerDisplay.GetComponent<WinnerDisplay>().winnerText.text = "Player Red Wins!";
                    WinnerDisplay.SetActive(true);
                }
            }
        }

        lastTurnCounter = turnCounter;
    }

    private void HelpFunctionTokenNotBeatable(GameObject token)
    {
        if (token.TryGetComponent(out DragAndDrop dragAndDrop))
        {
            dragAndDrop.isBeatable = false;
        }
        else if (token.TryGetComponent(out DragAndDropZweier dragAndDropZ))
        {
            dragAndDropZ.isBeatable = false;
        }
        else if (token.TryGetComponent(out DragAndDropDreier dragAndDropD))
        {
            dragAndDropD.isBeatable = false;
        }
    }

    private void HelpFunctionTokenNotSelected(GameObject token)
    {
        if (token.TryGetComponent(out DragAndDrop dragAndDrop))
        {
            dragAndDrop.isSelected = false;
        }
        else if (token.TryGetComponent(out DragAndDropZweier dragAndDropZ))
        {
            dragAndDropZ.isSelected = false;
        }
        else if (token.TryGetComponent(out DragAndDropDreier dragAndDropD))
        {
            dragAndDropD.isSelected = false;
        }
    }

    private void HelpFunctionBeatableTokenRedToken(GameObject token)
    {
        if (!beatableTokensRed.Contains(token))
        {
            beatableTokensRed.Add(token);
        }
        isAnyTokenRedBeatable = true;
    }

    private void HelpFunctionBeatableTokenBlackToken(GameObject token)
    {
        if (!beatableTokensBlack.Contains(token))
        {
            beatableTokensBlack.Add(token);
        }
        isAnyTokenBlackBeatable = true;
    }
}

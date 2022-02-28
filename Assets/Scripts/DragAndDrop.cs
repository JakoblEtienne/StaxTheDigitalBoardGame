using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    public LayerMask fieldMask;

    public bool isSelected = false;
    public bool isBeatable = false;

    public bool canBeIgnored = false;

    public Transform L1, L2, L3, L4, L5, L6, L7, L8;
    public Transform R1, R2, R3, R4, R5, R6, R7, R8;
    public Transform V1;
    public Transform H1;

    public GameObject curField;
    private GameplayManager gM;

    private void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
    }

    private void MoveValidator()
    {
        foreach(GameObject field in gM.fields)
        {
            field.GetComponent<PlacementManager>().SetIsNotPlacable();
        }

        List<RaycastHit> hitsL = new List<RaycastHit>();
        List<RaycastHit> hitsR = new List<RaycastHit>();
        List<RaycastHit> hitsVH = new List<RaycastHit>();

        RaycastHit hitL1; if (Physics.Raycast(new Ray(L1.position, -L1.up), out hitL1, fieldMask)){ hitsL.Add(hitL1); }
        RaycastHit hitL2; if (Physics.Raycast(new Ray(L2.position, -L2.up), out hitL2, fieldMask)){ hitsL.Add(hitL2); }
        RaycastHit hitL3; if (Physics.Raycast(new Ray(L3.position, -L3.up), out hitL3, fieldMask)){ hitsL.Add(hitL3); }
        RaycastHit hitL4; if (Physics.Raycast(new Ray(L4.position, -L4.up), out hitL4, fieldMask)){ hitsL.Add(hitL4); }
        RaycastHit hitL5; if (Physics.Raycast(new Ray(L5.position, -L5.up), out hitL5, fieldMask)){ hitsL.Add(hitL5); }
        RaycastHit hitL6; if (Physics.Raycast(new Ray(L6.position, -L6.up), out hitL6, fieldMask)){ hitsL.Add(hitL6); }
        RaycastHit hitL7; if (Physics.Raycast(new Ray(L7.position, -L7.up), out hitL7, fieldMask)){ hitsL.Add(hitL7); }
        RaycastHit hitL8; if (Physics.Raycast(new Ray(L8.position, -L8.up), out hitL8, fieldMask)){ hitsL.Add(hitL8); }
        RaycastHit hitR1; if (Physics.Raycast(new Ray(R1.position, -R1.up), out hitR1, fieldMask)){ hitsR.Add(hitR1); }
        RaycastHit hitR2; if (Physics.Raycast(new Ray(R2.position, -R2.up), out hitR2, fieldMask)){ hitsR.Add(hitR2); }
        RaycastHit hitR3; if (Physics.Raycast(new Ray(R3.position, -R3.up), out hitR3, fieldMask)){ hitsR.Add(hitR3); }
        RaycastHit hitR4; if (Physics.Raycast(new Ray(R4.position, -R4.up), out hitR4, fieldMask)){ hitsR.Add(hitR4); }
        RaycastHit hitR5; if (Physics.Raycast(new Ray(R5.position, -R5.up), out hitR5, fieldMask)){ hitsR.Add(hitR5); }
        RaycastHit hitR6; if (Physics.Raycast(new Ray(R6.position, -R6.up), out hitR6, fieldMask)){ hitsR.Add(hitR6); }
        RaycastHit hitR7; if (Physics.Raycast(new Ray(R7.position, -R7.up), out hitR7, fieldMask)){ hitsR.Add(hitR7); }
        RaycastHit hitR8; if (Physics.Raycast(new Ray(R8.position, -R8.up), out hitR8, fieldMask)){ hitsR.Add(hitR8); }
        RaycastHit hitV1; if (Physics.Raycast(new Ray(V1.position, -V1.up), out hitV1, fieldMask)){ hitsVH.Add(hitV1); }
        RaycastHit hitH1; if (Physics.Raycast(new Ray(H1.position, -H1.up), out hitH1, fieldMask)){ hitsVH.Add(hitH1); }

        //Check Left Side
        foreach (RaycastHit hit in hitsL)
        {
            if (hit.collider.tag == "TokenRed" || hit.collider.tag == "TokenBlack")
            {
                break;
            }
            else if (hit.collider.tag == "Field" || hit.collider.tag == "FieldWinRed" || hit.collider.tag == "FieldWinBlack")
            {
                MoveValidatorLeftRight(hit);
            }
        }
        //Check Right Side
        foreach (RaycastHit hit in hitsR)
        {
            if (hit.collider.tag == "TokenRed" || hit.collider.tag == "TokenBlack")
            {
                break;
            }
            else if (hit.collider.tag == "Field" || hit.collider.tag == "FieldWinRed" || hit.collider.tag == "FieldWinBlack")
            {
                MoveValidatorLeftRight(hit);
            }
        }
        //Check Front and Back
        foreach (RaycastHit hit in hitsVH)
        {
            if (transform.tag == "TokenRed")
            {
                if (hit.collider.tag == "TokenBlack")
                {
                    MoveValidatorFrontBack(hit);
                }
            }
            else if (transform.tag == "TokenBlack")
            {
                if (hit.collider.tag == "TokenRed")
                {
                    MoveValidatorFrontBack(hit);
                }
            }
        }

    }

    private void MoveValidatorLeftRight(RaycastHit hit)
    {
        PlacementManager curFieldPM = hit.transform.gameObject.GetComponent<PlacementManager>();
        if (transform.tag == "TokenRed" || transform.tag == "TokenBlack")
        {
            curFieldPM.SetIsPlacable();
        }
    }

    private void MoveValidatorFrontBack(RaycastHit hit)
    {
        if (hit.transform.gameObject.TryGetComponent(out DragAndDrop dragAndDrop))
        {
            dragAndDrop.isBeatable = true;
            dragAndDrop.curField.GetComponent<PlacementManager>().SetIsBeatable();
        }
        else if (hit.transform.gameObject.TryGetComponent(out DragAndDropZweier dragAndDropZ))
        {
            dragAndDropZ.isBeatable = true;
            dragAndDropZ.curField.GetComponent<PlacementManager>().SetIsBeatable();
        }
        else if (hit.transform.gameObject.TryGetComponent(out DragAndDropDreier dragAndDropD))
        {
            dragAndDropD.isBeatable = true;
            dragAndDropD.curField.GetComponent<PlacementManager>().SetIsBeatable();
        }
        gM.CheckIfAnyTokenBeatable();

    }

    private void OnMouseDown()
    {
        // Fürs Übernehmen oder Schlagen bei Einsern
        if(isBeatable && gM.isAnyTokenRedSelected && gM.selectedTokenRed.TryGetComponent(out DragAndDrop dragAndDrop))
        {
            gM.ActivateTakeOrCapSelectionOnPos(transform.position);
            gM.capButton.onClick.AddListener(CaptureTokenBlack);
            gM.takeButton.onClick.AddListener(TakeOverTokenBlack);
            return;
        }
        else if (isBeatable && gM.isAnyTokenBlackSelected && gM.selectedTokenBlack.TryGetComponent(out DragAndDrop dragAndDrop2))
        {
            gM.ActivateTakeOrCapSelectionOnPosRotated(transform.position);
            gM.capButton.onClick.AddListener(CaptureTokenRed);
            gM.takeButton.onClick.AddListener(TakeOverTokenRed);
            return;
        }

        // Fürs Schlagen bei Zweiern u. Dreiern
        if (isBeatable)
        {
            Vector3 curPos = transform.position;
            if (gM.isAnyTokenRedSelected)
            {
                gM.beatTokensBlack.Add(gameObject);
                transform.position = gM.beatTokenBlackPositions[gM.beatTokensBlack.Count - 1].transform.position;
                gM.selectedTokenRed.transform.position = curPos;

                if(gM.selectedTokenRed.TryGetComponent(out DragAndDropDreier dragAndDropD) && gM.IsAnyWinFieldRedFreeAndEnoughTokens(2))
                {
                    gM.ActivateReturnTokenSelectionOnPos(curPos, true);
                }
                else if (gM.IsAnyWinFieldRedFreeAndEnoughTokens(1))
                {
                    gM.ActivateReturnTokenSelectionOnPos(curPos, false);
                }
            }
            else if (gM.isAnyTokenBlackSelected)
            {
                gM.beatTokensRed.Add(gameObject);
                transform.position = gM.beatTokenRedPositions[gM.beatTokensRed.Count - 1].transform.position;
                gM.selectedTokenBlack.transform.position = curPos;

                if (gM.selectedTokenBlack.TryGetComponent(out DragAndDropDreier dragAndDropD) && gM.IsAnyWinFieldBlackFreeAndEnoughTokens(2))
                {
                    gM.ActivateReturnTokenSelectionOnPosRotated(curPos, true);
                }
                else if (gM.IsAnyWinFieldBlackFreeAndEnoughTokens(1))
                {
                    gM.ActivateReturnTokenSelectionOnPosRotated(curPos, false);
                }
            }
            gM.SetNotAnyTokenBeatable();
            gM.SetNotAnyTokenSelected();
            gM.SetAllFieldsNotPlacable();
            gM.turnCounter++;
            gM.ChangePlayerAsync();
            return;
        }
        // Fürs Auswählen
        if(transform.tag == "TokenRed" && gM.curPlayer == 1)
        {
            gM.SetNotAnyTokenSelected();
            isSelected = true;

            MoveValidator(); 
        }
        else if(transform.tag == "TokenBlack" && gM.curPlayer == 2)
        {
            gM.SetNotAnyTokenSelected();
            isSelected = true;

            MoveValidator();
        }
                    
    }

    private void CaptureTokenBlack()
    {
        Vector3 curPos = transform.position;

        gM.beatTokensBlack.Add(gameObject);
        transform.position = gM.beatTokenBlackPositions[gM.beatTokensBlack.Count - 1].transform.position;
        gM.selectedTokenRed.transform.position = curPos;

        if (gM.IsAnyWinFieldRedFreeAndEnoughTokens(1))
        {
            gM.ActivateReturnTokenSelectionOnPos(curPos, false);
        }

        gM.SetNotAnyTokenBeatable();
        gM.SetNotAnyTokenSelected();
        gM.SetAllFieldsNotPlacable();

        gM.capButton.onClick.RemoveListener(CaptureTokenBlack);
        gM.takeButton.onClick.RemoveListener(TakeOverTokenBlack);
        gM.DeactivateTakeOrCapSelection();
        gM.turnCounter++;
        gM.ChangePlayerAsync();
    }

    private void TakeOverTokenBlack()
    {
        Vector3 curPos = transform.position;

        canBeIgnored = true;
        gameObject.transform.position = new Vector3(0, -3, 0);
        gM.selectedTokenRed.GetComponent<DragAndDrop>().canBeIgnored = true;
        gM.selectedTokenRed.transform.position = new Vector3(0, -3, 0);

        GameObject Zweier = Instantiate(gM.ZweierRed, curPos, Quaternion.identity, gM.TokensRedHolder.transform);

        gM.SetNotAnyTokenBeatable();
        gM.SetNotAnyTokenSelected();
        gM.SetAllFieldsNotPlacable();
        gM.RefreshTokenLists();

        gM.capButton.onClick.RemoveListener(CaptureTokenBlack);
        gM.takeButton.onClick.RemoveListener(TakeOverTokenBlack);
        gM.DeactivateTakeOrCapSelection();
        gM.turnCounter++;
        gM.ChangePlayerAsync();
    }

    private void CaptureTokenRed()
    {
        Vector3 curPos = transform.position;

        gM.beatTokensRed.Add(gameObject);
        transform.position = gM.beatTokenRedPositions[gM.beatTokensRed.Count - 1].transform.position;
        gM.selectedTokenBlack.transform.position = curPos;

        if (gM.IsAnyWinFieldBlackFreeAndEnoughTokens(1))
        {
            gM.ActivateReturnTokenSelectionOnPosRotated(curPos, false);
        }

        gM.SetNotAnyTokenBeatable();
        gM.SetNotAnyTokenSelected();
        gM.SetAllFieldsNotPlacable();

        gM.capButton.onClick.RemoveListener(CaptureTokenRed);
        gM.takeButton.onClick.RemoveListener(TakeOverTokenRed);
        gM.DeactivateTakeOrCapSelection();
        gM.turnCounter++;
        gM.ChangePlayerAsync();
    }

    private void TakeOverTokenRed()
    {
        Vector3 curPos = transform.position;

        canBeIgnored = true;
        gameObject.transform.position = new Vector3(0, -3, 0);
        gM.selectedTokenBlack.GetComponent<DragAndDrop>().canBeIgnored = true;
        gM.selectedTokenBlack.transform.position = new Vector3(0, -3, 0);

        GameObject Zweier = Instantiate(gM.ZweierBlack, curPos, Quaternion.identity, gM.TokensBlackHolder.transform);

        gM.SetNotAnyTokenBeatable();
        gM.SetNotAnyTokenSelected();
        gM.SetAllFieldsNotPlacable();
        gM.RefreshTokenLists();

        gM.capButton.onClick.RemoveListener(CaptureTokenRed);
        gM.takeButton.onClick.RemoveListener(TakeOverTokenRed);
        gM.DeactivateTakeOrCapSelection();
        gM.turnCounter++;
        gM.ChangePlayerAsync();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.transform.name + " collision with " + other.transform.name);
        if (other.tag == "Field" || other.tag == "FieldWinRed" || other.tag == "FieldWinBlack")
        {
            curField = other.transform.gameObject;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragAndDropZweier : MonoBehaviour
{
    public LayerMask fieldMask;

    public Transform LO1, LO2, LO3, LO4, LO5, LO6, LO7, LO8;
    public Transform LU1, LU2, LU3, LU4, LU5, LU6, LU7, LU8;
    public Transform RO1, RO2, RO3, RO4, RO5, RO6, RO7, RO8;
    public Transform RU1, RU2, RU3, RU4, RU5, RU6, RU7, RU8;

    public bool isSelected = false;
    public bool isBeatable = false;

    public bool canBeIgnored = false;

    public GameObject curField;
    private GameplayManager gM;

    private void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
    }

    private void MoveValidator()
    {
        foreach (GameObject field in gM.fields)
        {
            field.GetComponent<PlacementManager>().SetIsNotPlacable();
        }

        List<RaycastHit> hitsLO = new List<RaycastHit>();
        List<RaycastHit> hitsLU = new List<RaycastHit>();
        List<RaycastHit> hitsRO = new List<RaycastHit>();
        List<RaycastHit> hitsRU = new List<RaycastHit>();


        RaycastHit hitLO1; if (Physics.Raycast(new Ray(LO1.position, -LO1.up), out hitLO1, fieldMask)) { hitsLO.Add(hitLO1); }
        RaycastHit hitLO2; if (Physics.Raycast(new Ray(LO2.position, -LO2.up), out hitLO2, fieldMask)) { hitsLO.Add(hitLO2); }
        RaycastHit hitLO3; if (Physics.Raycast(new Ray(LO3.position, -LO3.up), out hitLO3, fieldMask)) { hitsLO.Add(hitLO3); }
        RaycastHit hitLO4; if (Physics.Raycast(new Ray(LO4.position, -LO4.up), out hitLO4, fieldMask)) { hitsLO.Add(hitLO4); }
        RaycastHit hitLO5; if (Physics.Raycast(new Ray(LO5.position, -LO5.up), out hitLO5, fieldMask)) { hitsLO.Add(hitLO5); }
        RaycastHit hitLO6; if (Physics.Raycast(new Ray(LO6.position, -LO6.up), out hitLO6, fieldMask)) { hitsLO.Add(hitLO6); }
        RaycastHit hitLO7; if (Physics.Raycast(new Ray(LO7.position, -LO7.up), out hitLO7, fieldMask)) { hitsLO.Add(hitLO7); }
        RaycastHit hitLO8; if (Physics.Raycast(new Ray(LO8.position, -LO8.up), out hitLO8, fieldMask)) { hitsLO.Add(hitLO8); }

        RaycastHit hitLU1; if (Physics.Raycast(new Ray(LU1.position, -LU1.up), out hitLU1, fieldMask)) { hitsLU.Add(hitLU1); }
        RaycastHit hitLU2; if (Physics.Raycast(new Ray(LU2.position, -LU2.up), out hitLU2, fieldMask)) { hitsLU.Add(hitLU2); }
        RaycastHit hitLU3; if (Physics.Raycast(new Ray(LU3.position, -LU3.up), out hitLU3, fieldMask)) { hitsLU.Add(hitLU3); }
        RaycastHit hitLU4; if (Physics.Raycast(new Ray(LU4.position, -LU4.up), out hitLU4, fieldMask)) { hitsLU.Add(hitLU4); }
        RaycastHit hitLU5; if (Physics.Raycast(new Ray(LU5.position, -LU5.up), out hitLU5, fieldMask)) { hitsLU.Add(hitLU5); }
        RaycastHit hitLU6; if (Physics.Raycast(new Ray(LU6.position, -LU6.up), out hitLU6, fieldMask)) { hitsLU.Add(hitLU6); }
        RaycastHit hitLU7; if (Physics.Raycast(new Ray(LU7.position, -LU7.up), out hitLU7, fieldMask)) { hitsLU.Add(hitLU7); }
        RaycastHit hitLU8; if (Physics.Raycast(new Ray(LU8.position, -LU8.up), out hitLU8, fieldMask)) { hitsLU.Add(hitLU8); }

        RaycastHit hitRO1; if (Physics.Raycast(new Ray(RO1.position, -RO1.up), out hitRO1, fieldMask)) { hitsRO.Add(hitRO1); }
        RaycastHit hitRO2; if (Physics.Raycast(new Ray(RO2.position, -RO2.up), out hitRO2, fieldMask)) { hitsRO.Add(hitRO2); }
        RaycastHit hitRO3; if (Physics.Raycast(new Ray(RO3.position, -RO3.up), out hitRO3, fieldMask)) { hitsRO.Add(hitRO3); }
        RaycastHit hitRO4; if (Physics.Raycast(new Ray(RO4.position, -RO4.up), out hitRO4, fieldMask)) { hitsRO.Add(hitRO4); }
        RaycastHit hitRO5; if (Physics.Raycast(new Ray(RO5.position, -RO5.up), out hitRO5, fieldMask)) { hitsRO.Add(hitRO5); }
        RaycastHit hitRO6; if (Physics.Raycast(new Ray(RO6.position, -RO6.up), out hitRO6, fieldMask)) { hitsRO.Add(hitRO6); }
        RaycastHit hitRO7; if (Physics.Raycast(new Ray(RO7.position, -RO7.up), out hitRO7, fieldMask)) { hitsRO.Add(hitRO7); }
        RaycastHit hitRO8; if (Physics.Raycast(new Ray(RO8.position, -RO8.up), out hitRO8, fieldMask)) { hitsRO.Add(hitRO8); }

        RaycastHit hitRU1; if (Physics.Raycast(new Ray(RU1.position, -RU1.up), out hitRU1, fieldMask)) { hitsRU.Add(hitRU1); }
        RaycastHit hitRU2; if (Physics.Raycast(new Ray(RU2.position, -RU2.up), out hitRU2, fieldMask)) { hitsRU.Add(hitRU2); }
        RaycastHit hitRU3; if (Physics.Raycast(new Ray(RU3.position, -RU3.up), out hitRU3, fieldMask)) { hitsRU.Add(hitRU3); }
        RaycastHit hitRU4; if (Physics.Raycast(new Ray(RU4.position, -RU4.up), out hitRU4, fieldMask)) { hitsRU.Add(hitRU4); }
        RaycastHit hitRU5; if (Physics.Raycast(new Ray(RU5.position, -RU5.up), out hitRU5, fieldMask)) { hitsRU.Add(hitRU5); }
        RaycastHit hitRU6; if (Physics.Raycast(new Ray(RU6.position, -RU6.up), out hitRU6, fieldMask)) { hitsRU.Add(hitRU6); }
        RaycastHit hitRU7; if (Physics.Raycast(new Ray(RU7.position, -RU7.up), out hitRU7, fieldMask)) { hitsRU.Add(hitRU7); }
        RaycastHit hitRU8; if (Physics.Raycast(new Ray(RU8.position, -RU8.up), out hitRU8, fieldMask)) { hitsRU.Add(hitRU8); }


        //Check Left Oben Side
        foreach (RaycastHit hit in hitsLO)
        {
            if (hit.collider.tag == "TokenRed" || hit.collider.tag == "TokenBlack")
            {
                HelpFunctionMoveValidatorBeatable(hit);
                break;
            }
            else if (hit.collider.tag == "Field" || hit.collider.tag == "FieldWinRed" || hit.collider.tag == "FieldWinBlack")
            {
                HelpFunctionMoveValidatorPlacable(hit);
            }
        }

        //Check Left Unten Side
        foreach (RaycastHit hit in hitsLU)
        {
            if (hit.collider.tag == "TokenRed" || hit.collider.tag == "TokenBlack")
            {
                HelpFunctionMoveValidatorBeatable(hit);
                break;
            }
            else if (hit.collider.tag == "Field" || hit.collider.tag == "FieldWinRed" || hit.collider.tag == "FieldWinBlack")
            {
                HelpFunctionMoveValidatorPlacable(hit);
            }
        }

        //Check Right Oben Side
        foreach (RaycastHit hit in hitsRO)
        {
            if (hit.collider.tag == "TokenRed" || hit.collider.tag == "TokenBlack")
            {
                HelpFunctionMoveValidatorBeatable(hit);
                break;
            }
            else if (hit.collider.tag == "Field" || hit.collider.tag == "FieldWinRed" || hit.collider.tag == "FieldWinBlack")
            {
                HelpFunctionMoveValidatorPlacable(hit);
            }
        }

        //Check Right Unten Side
        foreach (RaycastHit hit in hitsRU)
        {
            if (hit.collider.tag == "TokenRed" || hit.collider.tag == "TokenBlack")
            {
                HelpFunctionMoveValidatorBeatable(hit);
                break;
            }
            else if (hit.collider.tag == "Field" || hit.collider.tag == "FieldWinRed" || hit.collider.tag == "FieldWinBlack")
            {
                HelpFunctionMoveValidatorPlacable(hit);
            }
        }
    }

    private void HelpFunctionMoveValidatorBeatable(RaycastHit hit)
    {
        if (transform.tag == "TokenRed" && hit.collider.tag == "TokenBlack")
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
        else if (transform.tag == "TokenBlack" && hit.collider.tag == "TokenRed")
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
    }

    private void HelpFunctionMoveValidatorPlacable(RaycastHit hit)
    {
        PlacementManager curFieldPM = hit.transform.gameObject.GetComponent<PlacementManager>();
        if (transform.tag == "TokenRed" || transform.tag == "TokenBlack")
        {
            curFieldPM.SetIsPlacable();
        }
    }

    private void OnMouseDown()
    {
        // Fürs Schlagen
        if (isBeatable)
        {
            Vector3 curPos = transform.position;
            if (gM.isAnyTokenRedSelected)
            {
                //Zwei neue Einser werden im Ablagebereich erzeugt
                GameObject EinserBlack1 = Instantiate(gM.EinserBlack, gM.beatTokenBlackPositions.Last().transform.position, Quaternion.identity,gM.TokensBlackHolder.transform);
                gM.beatTokensBlack.Add(EinserBlack1);
                EinserBlack1.transform.position = gM.beatTokenBlackPositions[gM.beatTokensBlack.Count - 1].transform.position;
                GameObject EinserBlack2 = Instantiate(gM.EinserBlack, gM.beatTokenBlackPositions.Last().transform.position, Quaternion.identity, gM.TokensBlackHolder.transform);
                gM.beatTokensBlack.Add(EinserBlack2);
                EinserBlack2.transform.position = gM.beatTokenBlackPositions[gM.beatTokensBlack.Count - 1].transform.position;

                //Dieser Zweier wird unter das Spielfeld verschoben und zum Ignorieren freigegeben
                gameObject.transform.position = new Vector3(0, -3, 0);
                canBeIgnored = true;

                gM.selectedTokenRed.transform.position = curPos;

                if (gM.selectedTokenRed.TryGetComponent(out DragAndDropDreier dragAndDropD) && gM.IsAnyWinFieldRedFreeAndEnoughTokens(2))
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
                //Zwei neue Einser werden im Ablagebereich erzeugt
                GameObject EinserRed1 = Instantiate(gM.EinserRed, gM.beatTokenRedPositions.Last().transform.position, Quaternion.identity, gM.TokensRedHolder.transform);
                gM.beatTokensRed.Add(EinserRed1);
                EinserRed1.transform.position = gM.beatTokenRedPositions[gM.beatTokensRed.Count - 1].transform.position;
                GameObject EinserRed2 = Instantiate(gM.EinserRed, gM.beatTokenRedPositions.Last().transform.position, Quaternion.identity, gM.TokensRedHolder.transform);
                gM.beatTokensRed.Add(EinserRed2);
                EinserRed2.transform.position = gM.beatTokenRedPositions[gM.beatTokensRed.Count - 1].transform.position;

                //Dieser Zweier wird unter das Spielfeld verschoben und zum Ignorieren freigegeben
                gameObject.transform.position = new Vector3(0, -3, 0);
                canBeIgnored = true;

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
            gM.RefreshTokenLists();
            gM.turnCounter++;
            gM.ChangePlayerAsync();
            return;
        }

        //Fürs Auswählen
        if (transform.tag == "TokenRed" && gM.curPlayer == 1)
        {
            gM.SetNotAnyTokenSelected();
            isSelected = true;

            MoveValidator();
        }
        else if (transform.tag == "TokenBlack" && gM.curPlayer == 2)
        {
            gM.SetNotAnyTokenSelected();
            isSelected = true;

            MoveValidator();
        }
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

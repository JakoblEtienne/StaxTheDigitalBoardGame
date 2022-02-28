using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragAndDropDreier : MonoBehaviour
{
    public LayerMask fieldMask;

    public Transform IVL, IVO, IVR, IHL, IHU, IHR;
    public Transform AL, AVL, AVR, AR, AHR, AHL;

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

        List<RaycastHit> hitsI = new List<RaycastHit>();
        List<RaycastHit> hitsA = new List<RaycastHit>();

        RaycastHit hitIVL; if (Physics.Raycast(new Ray(IVL.position, -IVL.up), out hitIVL, fieldMask)) { hitsI.Add(hitIVL); }
        RaycastHit hitIVO; if (Physics.Raycast(new Ray(IVO.position, -IVO.up), out hitIVO, fieldMask)) { hitsI.Add(hitIVO); }
        RaycastHit hitIVR; if (Physics.Raycast(new Ray(IVR.position, -IVR.up), out hitIVR, fieldMask)) { hitsI.Add(hitIVR); }
        RaycastHit hitIHL; if (Physics.Raycast(new Ray(IHL.position, -IHL.up), out hitIHL, fieldMask)) { hitsI.Add(hitIHL); }
        RaycastHit hitIHU; if (Physics.Raycast(new Ray(IHU.position, -IHU.up), out hitIHU, fieldMask)) { hitsI.Add(hitIHU); }
        RaycastHit hitIHR; if (Physics.Raycast(new Ray(IHR.position, -IHR.up), out hitIHR, fieldMask)) { hitsI.Add(hitIHR); }

        RaycastHit hitAL; if (Physics.Raycast(new Ray(AL.position, -AL.up), out hitAL, fieldMask)) { hitsA.Add(hitAL); }
        RaycastHit hitAVL; if (Physics.Raycast(new Ray(AVL.position, -AVL.up), out hitAVL, fieldMask)) { hitsA.Add(hitAVL); }
        RaycastHit hitAVR; if (Physics.Raycast(new Ray(AVR.position, -AVR.up), out hitAVR, fieldMask)) { hitsA.Add(hitAVR); }
        RaycastHit hitAR; if (Physics.Raycast(new Ray(AR.position, -AR.up), out hitAR, fieldMask)) { hitsA.Add(hitAR); }
        RaycastHit hitAHR; if (Physics.Raycast(new Ray(AHR.position, -AHR.up), out hitAHR, fieldMask)) { hitsA.Add(hitAHR); }
        RaycastHit hitAHL; if (Physics.Raycast(new Ray(AHL.position, -AHL.up), out hitAHL, fieldMask)) { hitsA.Add(hitAHL); }



        //Check Innerer Ring
        foreach (RaycastHit hit in hitsI)
        {
            if (hit.collider.tag == "Field" || hit.collider.tag == "FieldWinRed" || hit.collider.tag == "FieldWinBlack")
            {
                HelpFunctionMoveValidatorPlacable(hit);
            }
        }

        //Check Äußerer Ring
        foreach (RaycastHit hit in hitsA)
        {
            if (hit.collider.tag == "TokenRed" || hit.collider.tag == "TokenBlack")
            {
                HelpFunctionMoveValidatorBeatable(hit);
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
        if (isBeatable)
        {
            Vector3 curPos = transform.position;
            if (gM.isAnyTokenRedSelected)
            {
                //Drei neue Einser werden im Ablagebereich erzeugt
                GameObject EinserBlack1 = Instantiate(gM.EinserBlack, gM.beatTokenBlackPositions.Last().transform.position, Quaternion.identity, gM.TokensBlackHolder.transform);
                gM.beatTokensBlack.Add(EinserBlack1);
                EinserBlack1.transform.position = gM.beatTokenBlackPositions[gM.beatTokensBlack.Count - 1].transform.position;
                GameObject EinserBlack2 = Instantiate(gM.EinserBlack, gM.beatTokenBlackPositions.Last().transform.position, Quaternion.identity, gM.TokensBlackHolder.transform);
                gM.beatTokensBlack.Add(EinserBlack2);
                EinserBlack2.transform.position = gM.beatTokenBlackPositions[gM.beatTokensBlack.Count - 1].transform.position;
                GameObject EinserBlack3 = Instantiate(gM.EinserBlack, gM.beatTokenBlackPositions.Last().transform.position, Quaternion.identity, gM.TokensBlackHolder.transform);
                gM.beatTokensBlack.Add(EinserBlack3);
                EinserBlack3.transform.position = gM.beatTokenBlackPositions[gM.beatTokensBlack.Count - 1].transform.position;

                //Dieser Dreier wird unter das Spielfeld verschoben und zum Ignorieren freigegeben
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
                //Drei neue Einser werden im Ablagebereich erzeugt
                GameObject EinserRed1 = Instantiate(gM.EinserRed, gM.beatTokenRedPositions.Last().transform.position, Quaternion.identity, gM.TokensRedHolder.transform);
                gM.beatTokensRed.Add(EinserRed1);
                EinserRed1.transform.position = gM.beatTokenRedPositions[gM.beatTokensRed.Count - 1].transform.position;
                GameObject EinserRed2 = Instantiate(gM.EinserRed, gM.beatTokenRedPositions.Last().transform.position, Quaternion.identity, gM.TokensRedHolder.transform);
                gM.beatTokensRed.Add(EinserRed2);
                EinserRed2.transform.position = gM.beatTokenRedPositions[gM.beatTokensRed.Count - 1].transform.position;
                GameObject EinserRed3 = Instantiate(gM.EinserRed, gM.beatTokenRedPositions.Last().transform.position, Quaternion.identity, gM.TokensRedHolder.transform);
                gM.beatTokensRed.Add(EinserRed3);
                EinserRed3.transform.position = gM.beatTokenRedPositions[gM.beatTokensRed.Count - 1].transform.position;

                //Dieser Dreier wird unter das Spielfeld verschoben und zum Ignorieren freigegeben
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

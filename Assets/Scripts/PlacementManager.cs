using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public bool isPlacable = false;
    public bool hasTokenRed = false;
    public bool hasTokenBlack = false;

    public Material isPlacableMat;
    public Material isNotPlacableMat;
    public Material isBeatableMat;

    private GameObject rand;

    private GameplayManager gM;
    private ChatManager cM;

    private void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
        cM = GameObject.FindGameObjectWithTag("ChatManager").GetComponent<ChatManager>();
        rand = transform.GetChild(0).gameObject;
    }

    private void OnMouseDown()
    {
        if (isPlacable && gM.isAnyTokenRedSelected)
        {
            gM.selectedTokenRed.transform.position = transform.position + new Vector3(0, 0.1f, 0);
            gM.SetNotAnyTokenSelected();
            gM.SetNotAnyTokenBeatable();
            cM.SendMessageToChat("To " +  gameObject.name, Message.MessageType.playerMessage);
            gM.turnCounter++;
            gM.ChangePlayerAsync();
        }
        else if (isPlacable && gM.isAnyTokenBlackSelected)
        {
            gM.selectedTokenBlack.transform.position = transform.position + new Vector3(0, 0.1f, 0);
            gM.SetNotAnyTokenSelected();
            gM.SetNotAnyTokenBeatable();
            cM.SendMessageToChat("To " + gameObject.name, Message.MessageType.playerMessage);
            gM.turnCounter++;
            gM.ChangePlayerAsync();
        }
        gM.SetAllFieldsNotPlacable();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "TokenRed")
        {
            hasTokenRed = false;
            cM.SendMessageToChat("From " + gameObject.name, Message.MessageType.playerMessage);
        }
        else if (other.transform.tag == "TokenBlack")
        {
            hasTokenBlack = false;
            cM.SendMessageToChat("From " + gameObject.name, Message.MessageType.playerMessage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "TokenRed" || other.transform.tag == "TokenBlack")
        {
            if (other.gameObject.TryGetComponent(out DragAndDrop dragAndDrop))
            {
                dragAndDrop.isSelected = false;
            }
            else if (other.gameObject.TryGetComponent(out DragAndDropZweier dragAndDropZ))
            {
                dragAndDropZ.isSelected = false;
            }
            else if (other.gameObject.TryGetComponent(out DragAndDropDreier dragAndDropD))
            {
                dragAndDropD.isSelected = false;
            }
        }
        if (other.transform.tag == "TokenRed")
        {
            hasTokenRed = true;
        }
        else if (other.transform.tag == "TokenBlack")
        {
            hasTokenBlack = true;
        }
    }

    public void SetIsPlacable()
    {
        isPlacable = true;
        rand.GetComponent<MeshRenderer>().material = isPlacableMat;
    }

    public void SetIsNotPlacable()
    {
        isPlacable = false;
        rand.GetComponent<MeshRenderer>().material = isNotPlacableMat;
    }

    public void SetIsBeatable()
    {
        rand.GetComponent<MeshRenderer>().material = isBeatableMat;
    }
}

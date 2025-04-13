using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitButton : Interactable
{
    public CapacityPuzzleSource CPS;

    override protected void Interact()
    {
        CPS.Transmit();
    }

}

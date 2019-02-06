using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public interface InventarioItem
{ 
    string Nombre { get; }
    Sprite Imagen { get; }
    void Recogido();

}

public class InventarioEventArgs : EventArgs{
public InventarioEventArgs(InventarioItem item)
    {
        Item = item;
    }
    public InventarioItem Item;
}

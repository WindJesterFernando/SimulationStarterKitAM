using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MapObject : MonoBehaviour
{
    public abstract int GetMapObjectType();

    private void OnMouseDown()
    {
        TileEditorLogic.tileEditorLogic.GetComponent<TileEditorLogic>().MapTilePressed(this.gameObject);
    }

}

public class MapSprite : MapObject
{
    public override int GetMapObjectType()
    {
        return MapObjectTypeID.Sprite;
    }
}

public class MapTile : MapObject
{
    public override int GetMapObjectType()
    {
        return MapObjectTypeID.Tile;
    }
}

public class EditorButton : MonoBehaviour
{
    int mapObjectType, textureID;
    public void SetMapObjectTypeAndTextureID(int MapObjectType, int TextureID)
    {
        mapObjectType = MapObjectType;
        textureID = TextureID;
    }
    private void OnMouseDown()
    {
        TileEditorLogic.tileEditorLogic.GetComponent<TileEditorLogic>().EditorButtonPressed(mapObjectType, textureID);
    }

}


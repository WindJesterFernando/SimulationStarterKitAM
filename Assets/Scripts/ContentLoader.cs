using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

static public class ContentLoader
{
    static Dictionary<string, Texture2D> loadedTextures;
    static Dictionary<string, Sprite> loadedSprites;

    const string MainTileMapAssetName = "tileSet_64x64.png";
    const int MainTileMapAssetPixelSize = 64;

    const string FighterSpritesAssetName = "Perks_Fighter_Spritesheet.png";
    const string BlackMageSpritesAssetName = "Perks_Wizard_Spritesheet.png";
    const string WhiteMageSpritesAssetName = "Perks_WhiteMage_Spritesheet.png";
    const string RogueSpritesAssetName = "Perks_Thief_Spritesheet.png";
    const string MonkSpritesAssetName = "Perks_Monk_Spritesheet.png";
    const string RedMageSpritesAssetName = "Perks_RedMage_Spritesheet.png";
    const int SpriteAssetPixelSize = 320;

    static public void Init()
    {
        loadedTextures = new Dictionary<string, Texture2D>();
        loadedSprites = new Dictionary<string, Sprite>();
    }
    static public Sprite GetTexturedSprite(int id)
    {
        string file = "";

        int texPosX = 0, texPosY = 0, texSizeX = 0, texSizeY = 0;

        if (id >= TextureSpriteID.MapTilesStart && id <= TextureSpriteID.MapTilesEnd)
        {
            file = Application.dataPath + "/Graphics/" + MainTileMapAssetName;
            texSizeX = MainTileMapAssetPixelSize;
            texSizeY = MainTileMapAssetPixelSize;
        }
        else if (id >= TextureSpriteID.CharacterSpritesStart && id <= TextureSpriteID.CharacterSpritesEnd)
        {
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }

        #region Map Tiles

        if (id == TextureSpriteID.Grass)
        {
            texPosX = 0 * MainTileMapAssetPixelSize;
            texPosY = 0 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.Water)
        {
            texPosX = 8 * MainTileMapAssetPixelSize;
            texPosY = 2 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.Desert)
        {
            texPosX = 0 * MainTileMapAssetPixelSize;
            texPosY = 0 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.Rocks)
        {
            texPosX = 1 * MainTileMapAssetPixelSize;
            texPosY = 2 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.Tent)
        {
            texPosX = 3 * MainTileMapAssetPixelSize;
            texPosY = 4 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.House)
        {
            texPosX = 5 * MainTileMapAssetPixelSize;
            texPosY = 6 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.WindmillBase)
        {
            texPosX = 2 * MainTileMapAssetPixelSize;
            texPosY = 6 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.WindmillTop)
        {
            texPosX = 7 * MainTileMapAssetPixelSize;
            texPosY = 8 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.FarmFieldPlowed)
        {
            texPosX = 4 * MainTileMapAssetPixelSize;
            texPosY = 9 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.FarmFieldGrowing)
        {
            texPosX = 4 * MainTileMapAssetPixelSize;
            texPosY = 5 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.FarmFieldHarvest)
        {
            texPosX = 6 * MainTileMapAssetPixelSize;
            texPosY = 2 * MainTileMapAssetPixelSize;
        }
        else if (id == TextureSpriteID.FarmFieldHarvest)
        {
            texPosX = 6 * MainTileMapAssetPixelSize;
            texPosY = 2 * MainTileMapAssetPixelSize;
        }

        #endregion

        #region Sprite Tiles

        else if (id == TextureSpriteID.Fighter1)
        {
            file = Application.dataPath + "/Graphics/" + FighterSpritesAssetName;
            texPosX = 0 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.Fighter2)
        {
            file = Application.dataPath + "/Graphics/" + FighterSpritesAssetName;
            texPosX = 1 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.Fighter3)
        {
            file = Application.dataPath + "/Graphics/" + FighterSpritesAssetName;
            texPosX = 2 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.Fighter4)
        {
            file = Application.dataPath + "/Graphics/" + FighterSpritesAssetName;
            texPosX = 3 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.BlackMage1)
        {
            file = Application.dataPath + "/Graphics/" + BlackMageSpritesAssetName;
            texPosX = 0 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.BlackMage2)
        {
            file = Application.dataPath + "/Graphics/" + BlackMageSpritesAssetName;
            texPosX = 1 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.BlackMage3)
        {
            file = Application.dataPath + "/Graphics/" + BlackMageSpritesAssetName;
            texPosX = 2 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.BlackMage4)
        {
            file = Application.dataPath + "/Graphics/" + BlackMageSpritesAssetName;
            texPosX = 3 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }

        else if (id == TextureSpriteID.WhiteMage1)
        {
            file = Application.dataPath + "/Graphics/" + WhiteMageSpritesAssetName;
            texPosX = 0 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.WhiteMage2)
        {
            file = Application.dataPath + "/Graphics/" + WhiteMageSpritesAssetName;
            texPosX = 1 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.WhiteMage3)
        {
            file = Application.dataPath + "/Graphics/" + WhiteMageSpritesAssetName;
            texPosX = 2 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.WhiteMage4)
        {
            file = Application.dataPath + "/Graphics/" + WhiteMageSpritesAssetName;
            texPosX = 3 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }

        else if (id == TextureSpriteID.Monk1)
        {
            file = Application.dataPath + "/Graphics/" + MonkSpritesAssetName;
            texPosX = 0 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.Monk2)
        {
            file = Application.dataPath + "/Graphics/" + MonkSpritesAssetName;
            texPosX = 1 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.Monk3)
        {
            file = Application.dataPath + "/Graphics/" + MonkSpritesAssetName;
            texPosX = 2 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.Monk4)
        {
            file = Application.dataPath + "/Graphics/" + MonkSpritesAssetName;
            texPosX = 3 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }

        else if (id == TextureSpriteID.Rogue1)
        {
            file = Application.dataPath + "/Graphics/" + MonkSpritesAssetName;
            texPosX = 0 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.Rogue2)
        {
            file = Application.dataPath + "/Graphics/" + MonkSpritesAssetName;
            texPosX = 1 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.Rogue3)
        {
            file = Application.dataPath + "/Graphics/" + MonkSpritesAssetName;
            texPosX = 2 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.Rogue4)
        {
            file = Application.dataPath + "/Graphics/" + MonkSpritesAssetName;
            texPosX = 3 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.RedMage1)
        {
            file = Application.dataPath + "/Graphics/" + RedMageSpritesAssetName;
            texPosX = 0 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.RedMage2)
        {
            file = Application.dataPath + "/Graphics/" + RedMageSpritesAssetName;
            texPosX = 1 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.RedMage3)
        {
            file = Application.dataPath + "/Graphics/" + RedMageSpritesAssetName;
            texPosX = 2 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }
        else if (id == TextureSpriteID.RedMage4)
        {
            file = Application.dataPath + "/Graphics/" + RedMageSpritesAssetName;
            texPosX = 3 * SpriteAssetPixelSize;
            texPosY = 0 * SpriteAssetPixelSize;
            texSizeX = SpriteAssetPixelSize;
            texSizeY = SpriteAssetPixelSize;
        }

        #endregion

        else if (id == TextureSpriteID.SpriteEraser)
        {
            file = Application.dataPath + "/Graphics/" + MainTileMapAssetName;
            texSizeX = MainTileMapAssetPixelSize;
            texSizeY = MainTileMapAssetPixelSize;
            
            texPosX = 6 * MainTileMapAssetPixelSize;
            texPosY = 2 * MainTileMapAssetPixelSize;
        }

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(file))
        {
            if (loadedTextures.ContainsKey(file))
            {
                tex = loadedTextures[file];
            }
            else
            {
                fileData = File.ReadAllBytes(file);
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData);//this will auto resize the image dimentions based on image actual dimentions

                loadedTextures.Add(file, tex);
            }
        }
        else
        {
            Debug.Log("Unable to find file: " + file);
        }

        if (tex != null)
        {
            //int texPosX = 0, texPosY = 0, texMaxPosX = tex.width, texMaxPosY = tex.height;
            string spriteKeyName = file + "-" + texPosX + " " + texPosY + " " + " " + texSizeX + " " + texSizeY;

            if (loadedSprites.ContainsKey(spriteKeyName))
            {
                return loadedSprites[spriteKeyName];
            }

            Sprite newSprite = Sprite.Create(tex, new Rect(texPosX, texPosY, texSizeX, texSizeY), new Vector2(0.5f, 0.5f), 100f);
            loadedSprites.Add(spriteKeyName, newSprite);
            return newSprite;
        }
        else
        {
            Debug.Log("Unable to create sprite " + file);
        }
        return null;
    }
    static private GameObject GetNewMapObject()
    {
        GameObject go = new GameObject("MapObject");
        go.AddComponent<SpriteRenderer>();
        return go;
    }
    static public GameObject GetNewMapTileGameObject(int textureSpriteID)
    {
        GameObject go = GetNewMapObject();
        go.name = "MapTile";
        go.AddComponent<MapTile>();
        go.GetComponent<SpriteRenderer>().sprite = GetTexturedSprite(textureSpriteID);
        go.gameObject.AddComponent<BoxCollider2D>();
        return go;
    }
    static public GameObject GetNewMapSpriteGameObject(int textureSpriteID)
    {
        GameObject go = GetNewMapObject();
        go.name = "MapSprite";
        go.AddComponent<MapSprite>();
        go.GetComponent<SpriteRenderer>().sprite = GetTexturedSprite(textureSpriteID);
        go.GetComponent<SpriteRenderer>().sortingOrder = 1;
        return go;
    }

}



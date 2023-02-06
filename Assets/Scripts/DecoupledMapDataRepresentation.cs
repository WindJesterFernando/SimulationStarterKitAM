using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

public class MapData
{
    static public MapData instance;


    public int[,] mapTiles;
    public LinkedList<MapSpriteDataRepresentation> mapSprites;

    public int numTilesX = 20;
    public int numTilesY = 9;

    int selectedEditorButtonTextureID;
    int selectedEditorButtonMapObjectType;

    public void Init()
    {
        CreateMapTiles();
        mapSprites = new LinkedList<MapSpriteDataRepresentation>();

        mapSprites.AddLast(new MapSpriteDataRepresentation(TextureSpriteID.Fighter1, 6, 4));
        mapSprites.AddLast(new MapSpriteDataRepresentation(TextureSpriteID.BlackMage1, 3, 2));
        mapSprites.AddLast(new MapSpriteDataRepresentation(TextureSpriteID.BlackMage1, 2, 3));
    }
    private void CreateMapTiles()
    {
        mapTiles = new int[numTilesX, numTilesY];
        for (int i = 0; i < numTilesX; i++)
        {
            for (int j = 0; j < numTilesY; j++)
            {
                mapTiles[i, j] = TextureSpriteID.Grass;
            }
        }
    }
    public void ProcessEditorButtonPressed(int mapObjectType, int textureID)
    {
        selectedEditorButtonMapObjectType = mapObjectType;
        selectedEditorButtonTextureID = textureID;
    }
    public void ProcessMapTilePressed(int x, int y)
    {
        if (selectedEditorButtonMapObjectType == MapObjectTypeID.Tile)
            mapTiles[x, y] = selectedEditorButtonTextureID;
        else if (selectedEditorButtonMapObjectType == MapObjectTypeID.Sprite)
        {
            if (selectedEditorButtonTextureID != TextureSpriteID.SpriteEraser)
            {
                MapSpriteDataRepresentation removeMe = null;
                foreach (MapSpriteDataRepresentation s in mapSprites)
                {
                    if (s.x == x && s.y == y)
                    {
                        removeMe = s;
                        break;
                    }
                }
                if (removeMe != null)
                    mapSprites.Remove(removeMe);

                mapSprites.AddLast(new MapSpriteDataRepresentation(selectedEditorButtonTextureID, x, y));

            }
            else if (selectedEditorButtonTextureID == TextureSpriteID.SpriteEraser)
            {
                MapSpriteDataRepresentation removeMe = null;
                foreach (MapSpriteDataRepresentation s in mapSprites)
                {
                    if (s.x == x && s.y == y)
                    {
                        removeMe = s;
                        break;
                    }
                }
                if (removeMe != null)
                    mapSprites.Remove(removeMe);
            }

        }
    }
    public void ProcessResize(int x, int y)
    {
        Debug.Log("Processing Resize: " + x + "," + y);
        numTilesX = x;
        numTilesY = y;

        LinkedList<MapSpriteDataRepresentation> removeMes = new LinkedList<MapSpriteDataRepresentation>();

        foreach (MapSpriteDataRepresentation s in mapSprites)
        {
            if (s.x > x || s.y > y)
                removeMes.AddLast(s);
        }

        foreach (MapSpriteDataRepresentation s in removeMes)
            mapSprites.Remove(s);

        CreateMapTiles();
    }
    public void ProcessSaveMap(string name)
    {
        Debug.Log("Process SaveMap: " + name);
    }
    public void ProcessLoadMap(string name)
    {
        Debug.Log("Process LoadMap: " + name);
    }



    public MapData MakeShallowCopyOfMapData()
    {
        MapData copy = new MapData();

        copy.mapTiles = new int[numTilesX, numTilesY];

        for (int i = 0; i < numTilesX; i++)
        {
            for (int j = 0; j < numTilesY; j++)
            {
                copy.mapTiles[i, j] = mapTiles[i, j];
            }
        }

        copy.mapSprites = new LinkedList<MapSpriteDataRepresentation>();
        foreach (MapSpriteDataRepresentation s in mapSprites)
        {
            copy.mapSprites.AddLast(s);
        }

        copy.numTilesX = numTilesX;
        copy.numTilesY = numTilesY;

        copy.selectedEditorButtonTextureID = selectedEditorButtonTextureID;
        copy.selectedEditorButtonMapObjectType = selectedEditorButtonMapObjectType;

        return copy;
    }

    public MapData MakeDeepCopyOfMapData()
    {
        MapData copy = new MapData();

        copy.mapTiles = new int[numTilesX, numTilesY];

        for (int i = 0; i < numTilesX; i++)
        {
            for (int j = 0; j < numTilesY; j++)
            {
                copy.mapTiles[i, j] = mapTiles[i, j];
            }
        }

        copy.mapSprites = new LinkedList<MapSpriteDataRepresentation>();
        foreach (MapSpriteDataRepresentation s in mapSprites)
        {
            MapSpriteDataRepresentation c = new MapSpriteDataRepresentation(s.id, s.x, s.y);
            copy.mapSprites.AddLast(c);
        }

        copy.numTilesX = numTilesX;
        copy.numTilesY = numTilesY;

        copy.selectedEditorButtonTextureID = selectedEditorButtonTextureID;
        copy.selectedEditorButtonMapObjectType = selectedEditorButtonMapObjectType;

        return copy;
    }


    public void ProcessGameOfLifeIteration()
    {
        // MapData copy = MakeDeepCopyOfMapData();


        int[,] nextMapTiles = new int[numTilesX, numTilesY];

        for (int i = 0; i < numTilesX; i++)
        {
            for (int j = 0; j < numTilesY; j++)
            {
                int count = CountNumberOfNeighbours(i, j);

                bool isAlive = (mapTiles[i, j] == TextureSpriteID.Water);

                if (isAlive)
                {
                    if (count == 3 || count == 2)
                        nextMapTiles[i, j] = TextureSpriteID.Water;
                    else
                        nextMapTiles[i, j] = TextureSpriteID.Grass;
                }
                else
                {
                    if (count == 3)
                        nextMapTiles[i, j] = TextureSpriteID.Water;
                    else
                        nextMapTiles[i, j] = TextureSpriteID.Grass;
                }
            }
        }

        mapTiles = nextMapTiles;

    }

    private int CountNumberOfNeighbours(int x, int y)
    {
        int count = 0;

        if (x - 1 > 0)
        {
            if (mapTiles[x - 1, y] == TextureSpriteID.Water)
                count++;
        }

        if (x + 1 < numTilesX - 1)
        {
            if (mapTiles[x + 1, y] == TextureSpriteID.Water)
                count++;
        }
        if (y - 1 > 0)
        {
            if (mapTiles[x, y - 1] == TextureSpriteID.Water)
                count++;
        }
        if (y + 1 < numTilesY - 1)
        {
            if (mapTiles[x, y + 1] == TextureSpriteID.Water)
                count++;
        }


        if (x + 1 < numTilesX - 1 && y + 1 < numTilesY - 1)
        {
            if (mapTiles[x + 1, y + 1] == TextureSpriteID.Water)
                count++;
        }
        if (x - 1 > 0 && y + 1 < numTilesY - 1)
        {
            if (mapTiles[x - 1, y + 1] == TextureSpriteID.Water)
                count++;
        }
        if (x - 1 > 0 && y - 1 > 0)
        {
            if (mapTiles[x - 1, y - 1] == TextureSpriteID.Water)
                count++;
        }

        if (x + 1 < numTilesX - 1 && y - 1 > 0)
        {
            if (mapTiles[x + 1, y - 1] == TextureSpriteID.Water)
                count++;
        }

        return count;
    }

    public bool DoesPathExist(TileLocation start, TileLocation end)
    {
        //we need to 

        LinkedList<TileLocation> possibleMoveLocations = new LinkedList<TileLocation>();
        LinkedList<TileLocation> previouslyChecked = new LinkedList<TileLocation>();

        possibleMoveLocations.AddLast(start);

        while (possibleMoveLocations.Count > 0)
        {
            //Debug.Log("Searching, possible move locations == " + possibleMoveLocations.Count);
            TileLocation tileBeingProcessed = possibleMoveLocations.First.Value;
            possibleMoveLocations.RemoveFirst();
            previouslyChecked.AddLast(tileBeingProcessed);
            
            foreach (TileLocation tl in GetNeighbours(tileBeingProcessed.x, tileBeingProcessed.y))
            {
                if (tl.x == end.x && tl.y == end.y)
                {
                    Debug.Log("Path has been found!!!!");
                    return true;
                }

                if (ListHasTileLocation(tl, previouslyChecked) || (ListHasTileLocation(tl, possibleMoveLocations)))
                    ;//Do nothing, we already have processed or queued the tile location for processing
                else
                    possibleMoveLocations.AddLast(tl);
            }
        }

        Debug.Log("Path Not Found!!!");

        return false;
    }

    private LinkedList<TileLocation> GetNeighbours(int x, int y)
    {
        LinkedList<TileLocation> neighbours = new LinkedList<TileLocation>();

        if (x - 1 > 0)
        {
            if (mapTiles[x - 1, y] != TextureSpriteID.Water)
                neighbours.AddLast(new TileLocation(x - 1, y));
        }

        if (x + 1 < numTilesX - 1)
        {
            if (mapTiles[x + 1, y] != TextureSpriteID.Water)
                neighbours.AddLast(new TileLocation(x + 1, y));
        }
        if (y - 1 > 0)
        {
            if (mapTiles[x, y - 1] != TextureSpriteID.Water)
                neighbours.AddLast(new TileLocation(x, y - 1));
        }
        if (y + 1 < numTilesY - 1)
        {
            if (mapTiles[x, y + 1] != TextureSpriteID.Water)
                neighbours.AddLast(new TileLocation(x, y + 1));
        }


        if (x + 1 < numTilesX - 1 && y + 1 < numTilesY - 1)
        {
            if (mapTiles[x + 1, y + 1] != TextureSpriteID.Water)
                neighbours.AddLast(new TileLocation(x + 1, y + 1));
        }
        if (x - 1 > 0 && y + 1 < numTilesY - 1)
        {
            if (mapTiles[x - 1, y + 1] != TextureSpriteID.Water)
                neighbours.AddLast(new TileLocation(x - 1, y + 1));
        }
        if (x - 1 > 0 && y - 1 > 0)
        {
            if (mapTiles[x - 1, y - 1] != TextureSpriteID.Water)
                neighbours.AddLast(new TileLocation(x - 1, y - 1));
        }

        if (x + 1 < numTilesX - 1 && y - 1 > 0)
        {
            if (mapTiles[x + 1, y - 1] != TextureSpriteID.Water)
                neighbours.AddLast(new TileLocation(x + 1, y - 1));
        }

        return neighbours;
    }
    private bool ListHasTileLocation(TileLocation tl, LinkedList<TileLocation> list)
    {
        foreach (TileLocation i in list)
        {
            if (tl.x == i.x && tl.y == i.y)
                return true;
        }

        return false;
    }

    // private void ProcessTileLocation(TileLocation tileToProcess, TileLocation end)
    // {
    //     foreach (TileLocation tl in GetNeighbours(tileToProcess.x, tileToProcess.y))
    //     {
    //         if (tl.x == end.x && tl.y == end.y)
    //             return true;

    //         if (ListHasTileLocation(tl, previouslyChecked) || (ListHasTileLocation(tl, possibleMoveLocations)))
    //             ;//Do nothing, we already have processed or queued the tile location for processing
    //         else
    //             possibleMoveLocations.AddLast(tl);
    //     }
    // }

    public void SerializeToJSON()
    {
        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(this);
        Debug.Log(jsonData);

        StreamWriter sw = new StreamWriter(Application.dataPath + Path.DirectorySeparatorChar + "serializedBigDadData.txt");
        sw.WriteLine(jsonData);
        sw.Close();

        
        
        // Debug.Log(md.mapTiles[3,3]);
        
        //string jsonString = Json(this);
    }

    public void DeserializeFromJSON()
    {

        string jsonData;

        StreamReader sr = new StreamReader(Application.dataPath + Path.DirectorySeparatorChar + "serializedBigDadData.txt");
        jsonData = sr.ReadToEnd();
        sr.Close();
        MapData md = JsonConvert.DeserializeObject<MapData>(jsonData);

        instance = md;

        //string jsonData = {"mapTiles":[[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0]],"mapSprites":[{"id":1101,"x":6,"y":4},{"id":1201,"x":3,"y":2},{"id":1201,"x":2,"y":3}],"numTilesX":20,"numTilesY":9};
        
        //Newtonsoft.Json.JsonSerializ
        //
    }
//using Newtonsoft.Json.Converters;
}

public class MapSpriteDataRepresentation
{
    public int id;
    public int x, y;

    public MapSpriteDataRepresentation(int ID, int X, int Y)
    {
        id = ID;
        x = X;
        y = Y;
    }

}


public static class MapObjectTypeID
{
    public const int Tile = 1;
    public const int Sprite = 2;
}


public class TileLocation
{
    public int x, y;

    public TileLocation(int X, int Y)
    {
        x = X;
        y = Y;
    }

}



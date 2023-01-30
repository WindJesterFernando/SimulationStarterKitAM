using System.Collections;
using System.Collections.Generic;

public static class TextureSpriteID
{

    public const int SpriteEraser = -1;

    public const int MapTilesStart = 0;
    public const int MapTilesEnd = 1000;

    public const int CharacterSpritesStart = 1000;
    public const int CharacterSpritesEnd = 2000;


    public const int Grass = 0;
    public const int Water = 1;
    public const int Desert = 2;
    public const int Rocks = 3;

    public const int Tent = 101;
    public const int House = 102;
    public const int WindmillBase = 103;
    public const int WindmillTop = 104;

    public const int FarmFieldPlowed = 201;
    public const int FarmFieldGrowing = 202;
    public const int FarmFieldHarvest = 203;


    public const int Fighter1 = 1101;
    public const int Fighter2 = 1102;
    public const int Fighter3 = 1103;
    public const int Fighter4 = 1104;

    public const int BlackMage1 = 1201;
    public const int BlackMage2 = 1202;
    public const int BlackMage3 = 1203;
    public const int BlackMage4 = 1204;

    public const int WhiteMage1 = 1301;
    public const int WhiteMage2 = 1302;
    public const int WhiteMage3 = 1303;
    public const int WhiteMage4 = 1304;

    public const int Rogue1 = 1401;
    public const int Rogue2 = 1402;
    public const int Rogue3 = 1403;
    public const int Rogue4 = 1404;

    public const int Monk1 = 1501;
    public const int Monk2 = 1502;
    public const int Monk3 = 1503;
    public const int Monk4 = 1504;

    public const int RedMage1 = 1601;
    public const int RedMage2 = 1602;
    public const int RedMage3 = 1603;
    public const int RedMage4 = 1604;

    static public List<int> AllSprites;

    static public List<int> AllTiles;

    static public void Init()
    {
        AllTiles = new List<int>
        {
            Grass,
            Water,
            Desert,
            Rocks,

            Tent,
            House,
            WindmillBase,
            WindmillTop,

            FarmFieldPlowed,
            FarmFieldGrowing,
            FarmFieldHarvest
        };

        AllSprites = new List<int>
        {
            SpriteEraser,
            Fighter1,
            Fighter2,
            Fighter3,
            Fighter4,
            BlackMage1,
            BlackMage2,
            BlackMage3,
            BlackMage4,
            WhiteMage1,
            WhiteMage2,
            WhiteMage3,
            WhiteMage4,
            Rogue1,
            Rogue2,
            Rogue3,
            Rogue4,
            Monk1,
            Monk2,
            Monk3,
            Monk4,
            RedMage1,
            RedMage2,
            RedMage3,
            RedMage4,
        };

    }

}



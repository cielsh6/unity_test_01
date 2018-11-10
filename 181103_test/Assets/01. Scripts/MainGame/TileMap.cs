using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{

    [SerializeField] GameObject _tileObjectPrefabs; // SerializeField : 변수 프라이빗이처리. 단 에디터에서는 사용 가능. 다른 소스코드에서는 바꿀수 없게 함


    // Unity Methods
    void Start ()
    {

        //Create();
                
    }
	
	void Update ()
    {
        
	}

    MapTile[,] _mapTileArray;


    public void Create()
    {
        // 맵 타일 출력 테스트
        Sprite[] spriteList = Resources.LoadAll<Sprite>("MapSprite");


        // 모든 맵 리스트 출력
        int width = 32;
        int height = 32;

        _mapTileArray = new MapTile[height, width];

        //1층 (바닥)
        for (int y=0; y<height; y++)
        {

            for(int x=0; x<width; x++)
            {
                GameObject tileObject = GameObject.Instantiate(_tileObjectPrefabs);
                tileObject.transform.SetParent(transform);
                tileObject.transform.localScale = Vector3.one;
                tileObject.transform.localPosition = Vector3.zero;

                int spriteIndex = 23;
                if (spriteIndex < spriteList.Length)
                {                    
                    MapTile mapTile = tileObject.GetComponent<MapTile>();
                    mapTile.Init(spriteList[spriteIndex], x, y);
                    _mapTileArray[y, x] = mapTile;
                }

            }

        }

        //2층 (아이템같은것들)
        for (int y = 0; y < height; y++)
        {

            for (int x = 0; x < width; x++)
            {

                int createValue = Random.Range(0, 100);
                if (createValue < 30)
                {

                    GameObject tileObject = GameObject.Instantiate(_tileObjectPrefabs);
                    tileObject.transform.SetParent(transform);
                    tileObject.transform.localScale = Vector3.one;
                    tileObject.transform.localPosition = Vector3.zero;

                    int spriteIndex = 126;
                    if (spriteIndex < spriteList.Length)
                    {
                        MapTile mapTile = tileObject.GetComponent<MapTile>();
                        mapTile.Init(spriteList[spriteIndex], x, y);
                        
                    }

                }

            }

        }

    }

    MapTile GetMapTile(int tileX, int tileY)
    {
        return _mapTileArray[tileY, tileX];
    }

    public void SetCharacter(int tileX, int tileY, Player character)
    {
        MapTile mapTile = GetMapTile(tileX, tileY);
        character.transform.position = mapTile.transform.position;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;
using FactoryStarter.Core.Positions;
using FactoryStarter.Unity;
using UnityEngine;
using UnityEngine.Serialization;

public class GameComponent : MonoBehaviour, ILevelEventHandler, IDtoRepository {

    public GameObject CellPrefab;

    public GameObject[] ConstructionPrefabs;

    public GameObject[] ItemPrefabs;

    private GameObject _cellContainer;
    private GameObject _constructionContainer;

    private Game _gameCore;
    
    void Start() {
        _cellContainer = new GameObject($"{nameof(_cellContainer)}");
        _constructionContainer = new GameObject($"{nameof(_constructionContainer)}");
        
        _gameCore = new FactoryStarter.Core.Game(this);
        _gameCore.SetLevelEventHandler(this);
        
        _gameCore.Editor.ChangeLevelSize(2, 2);
        _gameCore.Editor.ChangeLevelSize(10, 10);
        
        _gameCore.Editor.BuildConstruction(0, new Position2(3, 3));
        _gameCore.Editor.BuildConstruction(1, new Position2(5, 5));
        
        _gameCore.Editor.AddItemBunch(1, new ItemBunchDto(1, 6));
        _gameCore.Editor.AddItemBunch(1, new ItemBunchDto(1, 5));
        _gameCore.Editor.AddItemBunch(1, new ItemBunchDto(3, 2));
        
        _gameCore.Editor.RemoveItemBunch(1, new ItemBunchDto(1, 1));
        _gameCore.Editor.RemoveItemBunch(1, new ItemBunchDto(3, 1));
        
    }

    public void OnSizeChanged(int width, int height) {
        foreach (Transform child in _cellContainer.transform) 
            Destroy(child.gameObject);

        foreach (Transform child in _constructionContainer.transform)
            Destroy(child.gameObject);

        for (int i = 0; i < width; i++)
        for (int j = 0; j < height; j++) {
            var position = new Vector3(i, 0, j);
            var cell = Instantiate(CellPrefab, position, Quaternion.identity);
            cell.transform.SetParent(_cellContainer.transform);
        }
    }

    public void OnConstructionBuilt(int typeId, int id, Position2 center) {
        var (x, z) = (center.X, center.Y);
        var position = new Vector3(x, 0, z);
        var constructionObject = Instantiate(GetConstructionPrefab(typeId),
                    position, Quaternion.identity,
                    _constructionContainer.transform);
        
        _gameCore.SetConstructionEventHandler(id,constructionObject.GetComponent<ConstructionComponent>());
    }

    public void Save(LevelDto dto) {
        throw new NotImplementedException();
    }

    public ConstructionTypeDto GetConstructionType(int id) {
        var types = ConstructionPrefabs
            .Select(x => x.GetComponent<ConstructionComponent>().TypeDto);
        return types.First(x => x.Id == id);
    }

    public GameObject GetConstructionPrefab(int id) {
        return ConstructionPrefabs.First(x => x.GetComponent<ConstructionComponent>().Id == id);
    }
    public GameObject GetItemPrefab(int id) {
        return ItemPrefabs.First(x => x.GetComponent<ItemComponent>().Id == id);
    }
    public ItemTypeDto GetItemType(int id) {
        var types = ItemPrefabs
            .Select(x => x.GetComponent<ItemComponent>().TypeDto);
        return types.First(x => x.Id == id);
    }

    public LevelDto GetLevel(int id) {
        throw new NotImplementedException();
    }
}
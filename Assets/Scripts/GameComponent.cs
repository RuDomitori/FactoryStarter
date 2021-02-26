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
    // Start is called before the first frame update
    void Start() {
        var game = new FactoryStarter.Core.Game(this);
        game.SetLevelEventHandler(this);
        game.Editor.ChangeLevelSize(10, 10);
        game.Editor.BuildConstruction(0, new Position2(3, 3));
        game.Editor.BuildConstruction(1, new Position2(5, 5));
    }

    public void OnSizeChanged(int width, int height) {
        for (int i = 0; i < width; i++)
        for (int j = 0; j < height; j++) {
            var position = new Vector3(i, 0, j);
            var cellClone = Instantiate(CellPrefab, position, Quaternion.identity);
        }
    }

    public void OnConstructionBuilt(int typeId, int id, Position2 center) {
        var (x, z) = (center.X, center.Y);
        var position = new Vector3(x, 0, z);
        Instantiate(ConstructionPrefabs[typeId], position, Quaternion.identity);
    }

    public void Save(LevelDto dto) {
        throw new NotImplementedException();
    }

    public ConstructionTypeDto GetConstructionType(int id) {
        var types = ConstructionPrefabs
            .Select(x => x.GetComponent<ConstructionComponent>().dto);
        return types.First(x => x.Id == id);
    }

    public ItemTypeDto GetItemType(int id) {
        var types = ItemPrefabs
            .Select(x => x.GetComponent<ItemComponent>().Dto);
        return types.First(x => x.Id == id);
    }

    public LevelDto GetLevel(int id) {
        throw new NotImplementedException();
    }
}
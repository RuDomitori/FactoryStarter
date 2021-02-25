using System;
using System.Collections;
using System.Collections.Generic;
using FactoryStarter.Core.Levels;
using FactoryStarter.Core.Positions;
using FactoryStarter.Unity;
using UnityEngine;
using UnityEngine.Serialization;

public class Game : MonoBehaviour, ILevelEventHandler {

    public GameObject CellPrefab;

    public DtoRepository DtoRepository;

    public GameObject[] ConstructionPrefabs;
    // Start is called before the first frame update
    void Start() {
        var game = new FactoryStarter.Core.Game(DtoRepository);
        game.SetLevelEventHandler(this);
        game.Editor.ChangeLevelSize(10, 10);
        game.Editor.BuildConstruction(0, new Position2(3, 3));
        game.Editor.BuildConstruction(1, new Position2(7, 7));
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
}
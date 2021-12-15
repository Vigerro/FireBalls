using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _towerSize = 50;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Block _block;

    private List<Block> _blocks = new List<Block>();

    public List<Block> Build()
    {
        Transform currentBlock = _spawnPoint;

        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = CreateBlock(currentBlock);
            _blocks.Add(newBlock);
            currentBlock = newBlock.transform;
            Renderer renderer = currentBlock.GetComponent<Renderer>();
            if (i % 2 == 0)
            {
                renderer.material.color = Color.yellow;
            }
            else
            {
                renderer.material.color = Color.blue;
            }
        }

        return _blocks;
    }
    private Block CreateBlock(Transform currentBlock)
    {
        return Instantiate(_block, GetSpawnPosition(currentBlock), Quaternion.identity, _spawnPoint);
    }

    private Vector3 GetSpawnPosition(Transform currentBlock)
    {
        return new Vector3(
            currentBlock.transform.position.x,
            currentBlock.transform.position.y + _block.transform.localScale.y,
            currentBlock.transform.position.z );
    }

}

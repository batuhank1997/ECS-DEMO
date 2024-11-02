using UnityEngine;

namespace Game.Scripts
{
    public class VoxelMap : MonoBehaviour 
    {
        [SerializeField] private float _size = 2f;
        [SerializeField] private int _voxelResolution = 8;
        [SerializeField] private int _chunkResolution = 2;
        
        [SerializeField] private GameObject _voxelPrefab;
        
        private VoxelGrid[] _chunks;
        
        private float _chunkSize;
        private float _halfSize;
        private float _voxelSize;
        
        private void Awake()
        {
            _halfSize = _size * 0.5f;
            _chunkSize = _size / _chunkResolution;
            _voxelSize = _chunkSize / _voxelResolution;
            
            _chunks = new VoxelGrid[_chunkResolution * _chunkResolution * _chunkResolution];
            
            CreateChunks();
        }

        private void CreateChunks()
        {
            for (int i = 0, y = 0; y < _chunkResolution; y++)
            {
                for (var z = 0; z < _chunkResolution; z++)
                {
                    for (var x = 0; x < _chunkResolution; x++, i++)
                    {
                        if (x == 0 || x == _chunkResolution - 1 || y == 0 || y == _chunkResolution - 1 || z == 0 || z == _chunkResolution - 1)
                        {
                            CreateChunk(i, x, y, z);
                        }
                    }
                }
            }
        }

        private void CreateChunk(int i, int x, int y, int z)
        {
            var chunk = Instantiate(new GameObject("Chunk " + i), transform);
            chunk.transform.localPosition = new Vector3(x * _chunkSize - _halfSize, y * _chunkSize - _halfSize, z * _chunkSize - _halfSize);

            _chunks[i] = InitializeVoxelGrid();
        }

        private VoxelGrid InitializeVoxelGrid()
        {
            var gridData = new GridData(_voxelResolution, _size);
            var grid = new VoxelGrid(_voxelPrefab, gridData);
            // grid.CreateGrid(_voxelResolution);
            
            return grid;
        }
    }
}
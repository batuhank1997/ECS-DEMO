using UnityEngine;

namespace Game.Scripts
{
    public class VoxelMap : MonoBehaviour {

        [SerializeField] private float _size = 2f;
        [SerializeField] private int _voxelResolution = 8;
        [SerializeField] private int _chunkResolution = 2;
        
        [SerializeField] private GameObject _voxelPrefab;
        
        private void Awake()
        {
            InitializeVoxelGrid();
        }

        private void InitializeVoxelGrid()
        {
            var gridData = new GridData(_voxelResolution, _size);
            var grid = new VoxelGrid(_voxelPrefab, gridData);
            grid.CreateMap(_voxelResolution);
        }
    }
}
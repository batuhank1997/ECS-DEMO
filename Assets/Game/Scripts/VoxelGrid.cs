using UnityEngine;

namespace Game.Scripts
{
    public class VoxelGrid
    {
        private readonly GameObject _voxelPrefab;
        private bool[] _voxels;
        
        public VoxelGrid(GameObject voxelPrefab, GridData gridData)
        {
            _voxelPrefab = voxelPrefab;
            _voxels = new bool[gridData.Resolution * gridData.Resolution * gridData.Resolution];
        }

        public void CreateGrid(int resolution)
        {
            var parentObj = Object.Instantiate(new GameObject("VoxelGrid"));

            for (int i = 0, y = 0; y < resolution; y++)
            {
                for (var z = 0; z < resolution; z++)
                {
                    for (var x = 0; x < resolution; x++, i++)
                    {
                        if (x == 0 || x == resolution - 1 || y == 0 || y == resolution - 1 || z == 0 || z == resolution - 1)
                        {
                            _voxels[i] = true;
                            CreateVoxel(x, y, z, parentObj.transform);
                        }
                    }
                }
            }
        }

        private void CreateVoxel(int x, int y, int z, Transform parent)
        {
            var voxelObject = Object.Instantiate(_voxelPrefab, parent);
            voxelObject.transform.localPosition = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);
            voxelObject.transform.localScale = Vector3.one * 0.95f;
        }
    }
}

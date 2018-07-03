using System;
using Mogre;

namespace Game
{
    class GameItems 
    {
        Radian angle;
        Vector3 direction;
        float radius;

        SceneManager mSceneMgr;
        Entity gemEntity;
        SceneNode gemNode;

        public GameItems(SceneManager mSceneMgr)
        {
            this.mSceneMgr = mSceneMgr;
            Load();
        }

            private void Load()
        {
            gemEntity = mSceneMgr.CreateEntity("gem.Mesh");
            gemNode = mSceneMgr.CreateSceneNode();
            gemNode.AttachObject(gemEntity);
            mSceneMgr.RootSceneNode.AddChild(gemNode);
        }

        public void Dispose()
        {
            gemNode.Parent.RemoveChild(gemNode);
            gemNode.DetachAllObjects();
            gemNode.Dispose();
            gemEntity.Dispose();
        }
    }
}

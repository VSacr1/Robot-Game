using System;
using System.Collections.Generic;
using Mogre;
using PhysicsEng;

namespace Game
{
    class Environment
    {
        Light light;

        public Light Light
        {
            get { return light; }
        }

        SceneManager mSceneMgr;
        RenderWindow mWindow;

        Ground ground;

        Boundary border;

        Cube cube;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mSceneMgr">A reference to the scene manager</param>
        /// <param name="mWindow",>A reference to the mWindow</param>
        public Environment(SceneManager mSceneMgr, RenderWindow mWindow)
        {
            this.mSceneMgr = mSceneMgr;
            this.mWindow = mWindow;

            Load();
        }

        private void Load()
        {
            SetLight();

            SetSky();
            SetFog();
            ground = new Ground(mSceneMgr); 
            Physics.AddBoundary(ground.Plane);

            cube = new Cube(mSceneMgr);

            border = new Boundary(mSceneMgr);
            Physics.AddBoundary(border.Plane1);
            Physics.AddBoundary(border.Plane2);
            Physics.AddBoundary(border.Plane3);
            Physics.AddBoundary(border.Plane4);

            SetShadow(); 

        }

        /// <summary>
        /// This method dispose of any object instanciated in this class
        /// </summary>
        public void Dispose()
        {
            ground.Dispose(); 
        }

        public void SetLight()
        {
            mSceneMgr.AmbientLight = new ColourValue(0.3f, 0.3f, 0.3f);
           
            light = mSceneMgr.CreateLight();

            light.DiffuseColour = ColourValue.White;
            light.Position = new Vector3(0, 100, 0);

            ///light.Type = Light.LightTypes.LT_DIRECTIONAL; ///Set light to directional light
            ///light.Type = Light.LightTypes.LT_SPOTLIGHT; ///Set  the light to be a spot light
            ///light.SetSpotLightRange(Mogre.Math.PI / 6, Mogre.Math.PI / 4, 0.001f); ///Set the spot light parametes
            ///light.Direction = Vector3.NEGATIVE_UNIT_Y; ///set the light direction. 

            light.Type = Light.LightTypes.LT_POINT;

            float range = 1000;
            float constantAttenuation = 0;
            float linearAttenuation = 0;
            float quadraticAttenuation = 0.0001f;

            light.SetAttenuation(range, constantAttenuation,
                linearAttenuation, quadraticAttenuation);
        }

        private void SetSky()
        {

            /// mSceneMgr.SetSkyDome(true, "Sky", 1f, 10, 500, true);

            //Plane sky = new Plane(Vector3.NEGATIVE_UNIT_Y, -50);
            //mSceneMgr.SetSkyPlane(true, sky, "Sky", 10, 5, true, 0.5f, 100, 100,
            //     ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME);

            mSceneMgr.SetSkyBox(true, "SkyBox", 10f, true);
        }

        private void SetFog()
        {
            ColourValue fadeColour = new ColourValue(0.9f, 0.9f, 0.9f);
            mWindow.GetViewport(0).BackgroundColour = fadeColour;

            mSceneMgr.SetFog(FogMode.FOG_LINEAR, fadeColour, 0, 10000, 10000);
            mSceneMgr.SetFog(FogMode.FOG_EXP, fadeColour, 0.005f);
            mSceneMgr.SetFog(FogMode.FOG_EXP2, fadeColour, 0.005f);

        }

        private void SetShadow()
        {

            ///mSceneMgr.ShadowTechnique = ShadowTechnique.SHADOWTYPE_STENCIL_MODULATIVE;
            mSceneMgr.ShadowTechnique = ShadowTechnique.SHADOWTYPE_STENCIL_ADDITIVE;

        }

    }
}

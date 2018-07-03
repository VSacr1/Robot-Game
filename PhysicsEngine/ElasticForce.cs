﻿using Mogre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEng
{
    public class ElasticForce:Force
    {
		//*************** DO NOT TOUCH THIS SECTION, THE METHOD TO IMPLEMENT IS AT THE BOTTOM *********************
        // --------------------- Fields ---------------------
		private float k;				//ks
        private float d;				//kd
        private float restLength;		//r
        
        private PhysObj anchorPoint;	//Object 2
        private PhysObj freeEnd;		//Object 1
		
		// --------------------- Attributes ---------------------
        public ElasticForce(PhysObj anchorPoint, PhysObj freeEnd, float restLength = 1.0f, float elastiConstant = 0.1f, float dampingConstant = 0.01f, string id = "ELASTIC") 
        { 
            type = id;
            this.anchorPoint = anchorPoint;
            this.freeEnd = freeEnd;
            this.k = elastiConstant;
            this.d = dampingConstant;
            this.restLength = restLength;
        }

        public PhysObj AnchorPoint
        {
            get { return anchorPoint; }
            set { anchorPoint = value; }
        }

        public PhysObj FreeEnd
        {
            get { return freeEnd; }
            set { freeEnd = value; }
        }

        public float ElasticConstant
        {
            get { return k; }
            set { k = value; }
        }

        public float DampingConstant
        {
            get { return d; }
            set { d = value; }
        }

        public float RestLength
        {
            get { return restLength; }
            set { restLength = value; }
        }
        //**********************************************************************************************************
		
		// ------------------------------- Compute Method ---------------------------------
        public override void compute(Vector3 Position = new Vector3())
        {
            Vector3 direction = (anchorPoint.Position - freeEnd.Position); 	//Dx/||Dx||
            float extension = direction.Normalise();                        // Dx
                                                                            // ***---> YOUR IMPLEMENTATION HERE! <---***
            force = - ( ElasticConstant * (direction - restLength) + DampingConstant * ((anchorPoint.Velocity - freeEnd.Velocity).DotProduct(direction))/extension) * (direction/extension);
        }
    }
}

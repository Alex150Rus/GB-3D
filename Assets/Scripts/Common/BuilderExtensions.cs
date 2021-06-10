using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SpaceJailRunner.Common
{
    public static partial class  BuilderExtensions
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }
        
        public static GameObject SetPhysicsMaterial(this GameObject gameObject, string name)
        {
            gameObject.GetComponent<Collider>().material = 
                Resources.Load<PhysicMaterial>($"Materials/physics/{name}");
            return gameObject;
        }
        
        public static GameObject SetScale(this GameObject gameObject, float x, float y, float z)
        {
            gameObject.transform.localScale = new Vector3(x, y, z);
            return gameObject;
        }
        
        public static GameObject SetColor(this GameObject gameObject, Color color)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = color;
            return gameObject;
        }
        
        public static GameObject SetTriggerMode(this GameObject gameObject, bool isTrigger)
        {
            gameObject.GetComponent<Collider>().isTrigger = isTrigger;
            return gameObject;
        }
        
        public static GameObject AddRigidbody(this GameObject gameObject, float mass, float drag, float angularDrag, 
            bool useGravity)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            component.drag = drag;
            component.angularDrag = angularDrag;
            component.useGravity = useGravity;
            return gameObject;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}
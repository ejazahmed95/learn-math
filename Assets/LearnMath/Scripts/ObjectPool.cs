using System.Collections.Generic;
using UnityEngine;

namespace LearnMath {
    public class ObjectPool<T>: MonoBehaviour where T: MonoBehaviour {
        [SerializeField] protected T objectPrefab;

        private List<T> _freeObjectPool = new();

        public virtual T GetNewObject() {
            if (_freeObjectPool.Count > 0) {
                var obj = _freeObjectPool[0];
                _freeObjectPool.RemoveAt(0);
                obj.gameObject.SetActive(true);
                return obj;
            }
            T newObj = Instantiate(objectPrefab, gameObject.transform);
            return newObj;
        }

        public virtual void RemoveObject(T obj) {
            obj.gameObject.SetActive(false);
            _freeObjectPool.Add(obj);
        }
    }
}
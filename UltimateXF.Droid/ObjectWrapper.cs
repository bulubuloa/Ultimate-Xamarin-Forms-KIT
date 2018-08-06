using System;
namespace UltimateXF.Droid
{
    public class ObjectWrapper<T> : Java.Lang.Object
    {
        private T _value;

        public ObjectWrapper(T managedValue)
        {
            _value = managedValue;
        }

        public T Value { get { return _value; } }
    }
}
using UnityEngine;

namespace AEngine
{
    public class ParamsData
    {
        public static ParamsData None => null;

        public static ParamsData Set(params object[] args)
        {
            ParamsData data = new ParamsData();
            data.args = args;

            return data;
        }

        //==================================================
        // Fields
        //==================================================

        private object[] args;

        //==================================================
        // Properties
        //==================================================

        public int Length => args != null ? args.Length : 0;

        //==================================================
        // Methods
        //==================================================

        public T Get<T>(int index)
        {
            return (T)args[index];
        }
    }
}
using System;
using System.Collections.Generic;

namespace ETCold
{
    public class ListComponent<T> : IDisposable
    {

        private bool isDispose;

        public static ListComponent<T> Create()
        {
            var listT = new ListComponent<T>();
            listT.isDispose = false;
            return listT;
        }

        public List<T> List { get; } = new List<T>();


        public void Dispose()
        {
            if (isDispose)
            {
                return;
            }
            isDispose = true;
            List.Clear();
        }
    }

}
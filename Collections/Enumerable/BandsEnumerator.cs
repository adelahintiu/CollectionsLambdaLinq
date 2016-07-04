using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections.Enumerable
{
    public class BandsEnumerator : IEnumerator<Band>
    {
        public Band Current { get { return currentBand; } }
        object IEnumerator.Current
        {
            get { return Current; }
        }

        private Band[] collection;
        private int currentIndex;
        private Band currentBand;

        public BandsEnumerator(Band[] bandsArray)
        {
            collection = bandsArray;
            //until "MoveNext" is called first time, the enumerator is positioned before the first element
            Reset();
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            currentIndex--;

            if (currentIndex < 0)
            {
                return false;
            }

            currentBand = collection[currentIndex];
            return true;
        }

       
        public void Reset()
        {
            currentIndex = collection.Length;
            currentBand = null;
        }
    }
}

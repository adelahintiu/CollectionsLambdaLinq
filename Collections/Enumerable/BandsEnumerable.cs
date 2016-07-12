﻿using System.Collections;
using System.Collections.Generic;

namespace Collections.Enumerable
{
    public class BandsEnumerable : IEnumerable<Band>
    {
        private Band[] bands;

        public Band this [int i] {

            get
            {
                return bands[i];
            }

            set
            {
                bands[i] = value;
            }
        }

        public BandsEnumerable(Band[] bandsArray)
        {
            bands = new Band[bandsArray.Length];

            for (int i = 0; i < bandsArray.Length; i++)
            {
                bands[i] = bandsArray[i];
            }
        }

        public IEnumerator<Band> GetEnumerator()
        {
            return new BandsEnumerator(bands);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}

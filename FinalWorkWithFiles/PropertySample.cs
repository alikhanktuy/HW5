using System;
namespace FinalWorkWithFiles
{
    public class PropertySample
    {
        int prop;
        public PropertySample()
        {
            prop = 0;
        }

        public int MyProp
        {
            get { return prop; }
            set { if (value > 1)  prop = value; }
        }

    }
}

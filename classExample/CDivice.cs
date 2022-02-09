using System;

namespace classExample
{
    class CDivide
    {
        COutput cn = new COutput();

        readonly decimal _a = 0;
        readonly decimal _b = 0;

        public CDivide(int a, int b)
        {
            _a = Convert.ToDecimal(a);
            _b = Convert.ToDecimal(b);
        }
        public void Result()
        {
            if (_b.Equals(0)) { return; }

            cn.DrawLine();
            cn.Write("Seuraavaksi " + _a.ToString() + " jaettuna " + _b.ToString());
            cn.Result(Math.Round(_a / _b, 4));
        }
    }
}

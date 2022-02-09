namespace classExample
{
    class CMultiply
    {
        COutput cn = new COutput();

        readonly int _a = 0;
        readonly int _b = 0;

        public CMultiply(int a, int b)
        {
            _a = a;
            _b = b;
        }
        public void Result()
        {
            cn.DrawLine();
            cn.Write("Seuraavaksi " + _a.ToString() + " kertaa " + _b.ToString());
            cn.Result(_a * _b);
        }
    }
}

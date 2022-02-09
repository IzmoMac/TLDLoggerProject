namespace classExample
{
    class CCalculate
    {
        readonly int _a = 0;
        readonly int _b = 0;

        public CCalculate(int a, int b)
        {
            _a = a;
            _b = b;
        }
        public void Result()
        {
            if (_b.Equals(0))
            {
                new COutput().Error("Pyyntö ohitettu, nollalla ei voi jakaa");
                return;
            }

            new CMultiply(_a, _b).Result();
            new CDivide(_a, _b).Result();
        }
    }
}

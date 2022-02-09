using System;

namespace classExample
{
    public class COutput
    {
        private string cLine = new string('-', 15);
        private const string cMsg = "Result: ";

        public void Write()
        {
            Empty();
        }
        public void Write(string s)
        {
            WriteLine(s);
        }
        public void Result(int i)
        {
            WriteLine(cMsg + i.ToString());
        }
        public void Result(decimal d)
        {
            WriteLine(cMsg + d.ToString());
        }
        //public void Result(string s)
        //{
        //    WriteLine(cMsg + s);
        //}
        public void Error(string s)
        {
            DrawLine();
            WriteLine(s);
        }
        public void DrawLine()
        {
            Empty();
            WriteLine(cLine);
            Empty();
        }
        private void Empty()
        {
            WriteLine(string.Empty);
        }
        private void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
        public int ReadInteger()
        {
            Int32.TryParse(Console.ReadLine(), out int a);
            return a;
        }
    }
}

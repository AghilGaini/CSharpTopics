using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    [Flags]
    public enum FunctionType
    {
        Square = 1,
        Cube = 2,
        All = Square | Cube
    }

    public class MulticastDelegateClass
    {
        #region properties
        private FunctionType _functionType { get; set; }
        private int _value { get; set; }
        private delegate int myDelegate();
        private myDelegate _delegate;
        #endregion

        #region Methods
        public MulticastDelegateClass(FunctionType type, int value)
        {
            _functionType = type;
            _value = value;

            if (_functionType == FunctionType.Square)
                _delegate += Square;
            else if (_functionType == FunctionType.Cube)
                _delegate += Cube;
            else
            {
                _delegate += Square;
                _delegate += Cube;
            }
        }

        private int Square()
        {
            return _value * _value;
        }

        private int Cube()
        {
            return _value * _value * _value;
        }

        public string ReturnDelegateResultAsString()
        {
            var invokeResults = _delegate.GetInvocationList().Select(r => (int)r.DynamicInvoke());
            string result = "ReturnDelegateResultAsString : ";
            foreach (var item in invokeResults)
            {
                result += $"/{item}/";
            }

            return result;
        }

        public string ReturnDelegateResultAsInt()
        {
            var invokeResult = _delegate.GetInvocationList().Select(r => (int)r.DynamicInvoke());
            int result = 0;
            foreach (var item in invokeResult)
            {
                result += item;
            }

            return $"ReturnDelegateResultAsInt : {result}";
        }

        #endregion
    }

    public class CombineDelegateClass
    {
        #region Properties
        private int _value { get; set; }
        private delegate void MyDelegate();
        private MyDelegate _delegate { get; set; }
        #endregion

        #region Methods
        public CombineDelegateClass(int value)
        {
            _value = value;
            MyDelegate squareDelegate = new MyDelegate(Square);
            MyDelegate cubeDelegate = new MyDelegate(Cube);
            MyDelegate lambdaDelegate = () => Console.WriteLine($"This is from lambda delegate.value is {_value}");

            _delegate = squareDelegate + cubeDelegate + lambdaDelegate;
        }

        private void Square()
        {
            Console.WriteLine($"Square is : {_value * _value}");
        }

        private void Cube()
        {
            Console.WriteLine($"Cube is : {_value * _value * _value}");
        }

        public void CallCombinedDelegates()
        {
            _delegate.Invoke();
        }

        #endregion
    }
}

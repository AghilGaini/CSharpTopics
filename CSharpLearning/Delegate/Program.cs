using Delegate;

var testMulticastDelegate = new MulticastDelegateClass(FunctionType.Cube, 2);
var testCombinedDelegate = new CombineDelegateClass(2);
var testGenericDelegate = new GenericDelegate(2);

Console.WriteLine(testMulticastDelegate.ReturnDelegateResultAsString());
Console.WriteLine(testMulticastDelegate.ReturnDelegateResultAsInt());
testCombinedDelegate.CallCombinedDelegates();
testGenericDelegate.CallGenericDelegate();

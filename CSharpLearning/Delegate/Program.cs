using Delegate;

var testMulticastDelegate = new MulticastDelegateClass(FunctionType.Cube, 2);
var testCombinedDelegate = new CombineDelegateClass(2);

Console.WriteLine(testMulticastDelegate.ReturnDelegateResultAsString());
Console.WriteLine(testMulticastDelegate.ReturnDelegateResultAsInt());
testCombinedDelegate.CallCombinedDelegates();

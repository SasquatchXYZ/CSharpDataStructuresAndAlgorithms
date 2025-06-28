using SortingAlgorithms;

int[] testArray = [-11, 12, -42, 0, 1, 90, 68, 6, -9];
var testSort = new SelectionSort();
testSort.Sort(testArray);
Console.WriteLine(string.Join(" | ", testArray));

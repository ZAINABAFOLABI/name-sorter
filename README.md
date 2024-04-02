Name Sorter Algorithm
This is a console application with .NET 7.0 version that is used for sorting a list of names in a text file by their last name.
This project can be run via the visual studio IDE with ctr + f5 and it will sort, print and write the output in a sorted-names-list.txt file.
Alternatively, it can be run from the command line and pass a file of unsorted names as an argument which will result in a list of sorted names by their lastname, printed on the screen and saved in a sorted-names-list.txt file.
This project Name Sorter consists of three solutions which are: NameSorter.Consoleapp, NameSorter.Core and the NameSorter.Tests.
The NameSorter.Consoleapp is the entry point to run the app, the NameSorter.Core comprises the models, the interfaces and the logic of the solution while the NameSorter.Tests contains the test file for unit testing.
A build pipeline has been setup using Github Actions that will build each time a push is made to the master branch.

[Day 17 Spinlock](http://adventofcode.com/2017/day/17)


Today's Instructions: 

>This spinlock's algorithm is simple but efficient, quickly consuming everything in its path. It starts with a circular buffer 
containing only the value 0, which it marks as the current position. It then steps forward through the circular buffer some number
of steps (your puzzle input) before inserting the first new value, 1, after the value it stopped on. The inserted value becomes the
current position. Then, it steps forward from there the same number of steps, and wherever it stops, inserts after it the second new
value, 2, and uses that as the new current position again.

```
//This is what the output at each increment of the index should produce  
//{0} currentIndex = 0; count = 1;  
//{0, (1)} currentIndex = 1; count = 2;  
//{0, (2), 1} currentIndex = 1; count = 3;  
//{0  2 (3) 1} currentIndex = 2; count = 4;  
//{0  2 (4) 3  1} currentIndex = 2; count = 5;  
//{0 (5) 2  4  3  1} currentIndex = 1; count = 6;  
```

The challenge of this Day is that you have to be able to keep track of iterations that go over the ends of the bounds of the array 
multiple times in a row. This one was definitely a step in the difficult direction. 

After a number of different attempts at designing the algorithm here I eventually solved it using the following: 

```
 static int SpinLockCycle(List<int> spinLock)
{
    int numberAfter2017 = 0;//  the number being returned after 2018 cycles. This number occupies the index after the index of the number 2017

    int currentIndex = 0; //the updated value storing the index of the last integer inserted into the list

    for (int numberToInsert = 1; numberToInsert < 2018; numberToInsert++)
    {
        int stepsForward = 304; // provided by the instructions + 1 to account for being zero indexed

        while (stepsForward > 0) // a way to keep track of how many steps I can continue to take while updating my current index
        {
            stepsForward--;

            if (spinLock.Count - currentIndex > 1) // if within the bounds of my list
            {
                currentIndex++;
            }
            else // if past the bounds of the size of the list, we simply reset the current index to 0 and continue
            {
                currentIndex = 0;
            }
        }

        spinLock.Insert(currentIndex, numberToInsert); //inserts the current number between 0 and 2018 into the current index, bumping back any other integers

    }

    numberAfter2017 = spinLock[spinLock.IndexOf(2017) + 1]; //assigns the number in the index after the index of 2017 (i.e. the number requested) 

    return numberAfter2017;
}
```


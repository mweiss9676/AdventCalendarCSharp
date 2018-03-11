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

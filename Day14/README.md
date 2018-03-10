# [Day 14 - Disk Defragmentation](http://adventofcode.com/2017/day/14)

>Suddenly, a scheduled job activates the system's disk defragmenter. Were the situation different, you might sit and watch it for a while,
but today, you just don't have that kind of time. It's soaking up valuable system resources that are needed elsewhere,
and so the only option is to help it finish its task as soon as possible.

Here we are going to be re-using our code from Day 10 to create knot hashes of our disk in question, a 128 by 128 grid of *free* and *used* 
spaces. 

Our input will be: stpzcrnm

Our job is to append to this input a dash followed by the numbers 0 through 127 (128 numbers using zero-indexing)
which we accomplish with a simple for loop with one oddity

```
static void NumberTheInputs(string inputToAddend)
{
    List<string> inputs = new List<string>();

    string inputCopy = inputToAddend;

    for (int i = 0; i < 128; i++)
    {
        inputToAddend = inputCopy;
        inputToAddend += "-" + i.ToString();
        inputs.Add(inputToAddend);
    }...
```
Notice that I had to make a copy of the input string because it needed to be refreshed each time I iterated the loop. Took this out
originally during a refactor but needed to put it back in. 

>The output of a knot hash is traditionally represented by 32 hexadecimal digits; each of these digits correspond to 4 bits,
for a total of 4 * 32 = 128 bits. To convert to bits, turn each hexadecimal digit to its equivalent binary value,
high-bit first: 0 becomes 0000, 1 becomes 0001, e becomes 1110, f becomes 1111, and so on; a hash that begins with a0c2017...
in hexadecimal would begin with 10100000110000100000000101110000... in binary.

The result of this is a grid of 0's and 1's (or any other hex chars you'd like to make a binary representation out of)

Our task is to count the number of "used" spaces (1's in our case)

An extremely nice Redditor in the Advent of Code community going by the username u/janiczek created the following image to 
help clarify these somewhat confusing instructions: 

![u/janiczek image](../images/day14-knot-hash.png)


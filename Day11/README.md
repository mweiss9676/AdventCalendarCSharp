# Day 11 Hex Ed

## Part 1

For this challenge we are to track down a "missing robot child" lost in a hexagonal grid. 
The challenge here is finding the shortest path along a grid that is hexagonal. 

![hex-grid](../images/hex-grid.png)

I needed to first parse our input (a section of which looks like this: se,ne,se,se,s,se,ne,ne,se...
into an array of just the directions. In other words I had to:

```string[] array = input.Split(',').ToArray();
```
Using [this](https://www.redblobgames.com/grids/hexagons/) information about Hex Grids and how to measure distance in them I prepared
three variables to keep track of the distance travelled along the x, y, and z axes

I used a foreach statement to iterate through the resulting list and a switch statement to increment the proper axis based on the input: 

``` foreach (string str in array)
            {
                switch (str)
                {
                    case "nw":
                        x++;
                        y--;
                        furthest(x, y, z);
                        break;
                    case "n":
                        x++;
                        z--;
                        furthest(x, y, z);
                        break;
                    case "ne":
                        y++;
                        z--;
                        furthest(x, y, z);
                        break;
                    case "sw":
                        y--;
                        z++;
                        furthest(x, y, z);
                        break;
                    case "s":
                        x--;
                        z++;
                        furthest(x, y, z);
                        break;
                    case "se":
                        x--;
                        y++;
                        furthest(x, y, z);
                        break;
                    default:
                        Console.WriteLine("something went wrong");
                        break;
                }
            }
            x = Math.Abs(x);
            y = Math.Abs(y);
            z = Math.Abs(z);
```

Also I discovered this little nugget that I need to commit to memory so I don't have to look it up every time (but isn't that always the way with code, I guess just knowing it exists is a help a lot of the time)

```
//a clever way to return the max integer value between more than 2 values
            int result = new[] { x, y, z }.Max();
```
After performing some Math.Abs on these numbers I was able to determine the fewest number of "steps" required to reach the little guy was: 

### Answer: 675

## Part 2

For Part 2 we had to determine the furthest the little robot ever got from his starting position.

This just ended up being a simple matter of having a class-wide variable that was checked against and updated every time it was the new biggest number. I didn't end up making this into a second file because the pieces were already there to solve it in the one class 

### Answer: 1424

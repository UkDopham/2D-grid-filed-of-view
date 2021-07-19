# 2D-grid-filed-of-view
Field of view algorithm in a 2d grid.

10/07/2021


## Bresenham's line Algorithm 

One of the simpliest algorithm, Bresenham's line algorithm is a line drawing algorithm that determinesa straight line between two points. It is commonly used to draw line primitives in a image. </br> \
Here it's used to simulate the field of view. We'll draw a line between all points in range from the starting point, if there is at least one element inside this path between the starting point and the ending point then the point is not visible from the starting point.

### Equation of the line :
`y = mx + b` 
</br> <i> - Coordinates of the point A (xa;yb) and the point B (xb;yb) </i>
</br> <i> - <b>m</b> = (yb - ya) / (xb - xa) </i> the slope
</br> <i> - <b>b</b> y-intercept

# MagmaMc.GDI
User Friendly Way To Render Shapes To The Users Screen

## Basic Usage

### Box
```c#
Box.Render(
	new Pen(Color.White), 
	new Point(300, 200), // Start X, Y (X, Y)
	new Point(300, 200), // End X, Y (Width, Hight)
	true // Fill Box
	);
```
#### Screen
```c#
Box.Render(
	TernaryRaster.SRCCOPY, 
	new Rectangle(300, 200, 100, 100), // Start X, Y,  Width, Height - Source
	new Rectangle(600, 400, 100, 100), // End X, Y,  Width, Height - Destination
	);
```

### Line
```c#
Line line = new Line(new Pen(Color.White));

line.Render(
	new Point(300, 200), // Start X, Y
	new Point(300, 200), // End X, Y
	);
```
### Line Static
```c#
Line.Render(
	new Pen(Color.White), 
	new Point(300, 200), // Start X, Y
	new Point(300, 200), // End X, Y
	);
```

### Image
```c#
Graphic.Render(
	(Bitmap)System.Drawing.Image.FromFile("image.png"), // Image To Render
	new Point(100, 500) // X, Y Position
	);
```
Can Also Support Icon And GIF

### Icon
```c#
Graphic.Render(
	(Bitmap)System.Drawing.Icon.FromFile("image.ico"), // Image To Render
	new Point(100, 500) // X, Y Position
	);
```
### GIF
```c#
Graphic.Render(
	new GIF("image.gif"), // Image To Render
	new Point(100, 500) // X, Y Position
	);
```
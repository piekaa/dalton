public class Circle  
{
	public int x;
	public int y;
	public int r;
	public bool background = true;

	public Circle (int x, int y, int r)
	{
		this.x = x;
		this.y = y;
		this.r = r;
	}

	public Circle ()
	{
	}

	public bool IsColliding(Circle c)
	{
		if ((x - c.x) * (x - c.x) + (y - c.y) * (y - c.y) <= (r + c.r) * (r + c.r))
			return true;
		return false;
	}


	public override string ToString ()
	{
		return string.Format ("[Circle: x={0}, y={1}, r={2}]", x, y, r);
	}
	

}

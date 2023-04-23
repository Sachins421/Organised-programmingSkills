class point
{
    public int x;
    public int y;

    public point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void move(int x, int y)
    {
        this.y = y;
        this.x = x;
    }

    public void move(point location)
    {
        if (location == null)
        {
            throw new ArgumentNullException("location");
        }

        move(location.x, location.y);
       // this.x = location.x;
        //this.y = location.y;
    }
}
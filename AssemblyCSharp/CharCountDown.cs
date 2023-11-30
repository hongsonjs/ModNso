public class CharCountDown
{
	private long maxTime;

	private int w;

	public bool WantDestroy;

	public string tile = string.Empty;

	private long timesv;

	private int timeper;

	private int per;

	public CharCountDown(long time, string tile)
	{
		this.tile = tile;
		maxTime = time;
		w = 60;
		timeper = (int)(maxTime - mSystem.currentTimeMillis());
	}

	public void paint(mGraphics g, int x, int y)
	{
		int num = 0;
		long num2 = maxTime - mSystem.currentTimeMillis();
		num = (int)(60 - num2 * w / timeper);
		g.drawRegion(GameCanvas.imghealth[1], 0, 9, 62, 9, 0, x, y, 0);
		g.drawRegion(GameCanvas.imghealth[0], 0, 7, num, 7, 0, x, y + 1, 0);
		mFont.tahoma_7.drawString(g, tile, x + w / 2 + 1, y - 10 + 1 - 3, 2);
		mFont.tahoma_7_white.drawString(g, tile, x + w / 2, y - 10 - 3, 2);
		mFont.tahoma_7b_white.drawString(g, per + "%", x + w / 2, y, 2);
	}

	public void update()
	{
		long num = maxTime - mSystem.currentTimeMillis();
		per = (int)(100 - num * 100 / timeper);
		if (maxTime - mSystem.currentTimeMillis() <= 0)
		{
			WantDestroy = true;
		}
	}

	public static string converSecon2minutes(int time)
	{
		int num = time % 60;
		int num2 = time / 60 % 60;
		if (num2 <= 0)
		{
			return num + string.Empty;
		}
		return num2 + ":" + num;
	}
}

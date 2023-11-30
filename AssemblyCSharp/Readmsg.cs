using System;

public class Readmsg
{
	public const sbyte SUB2_LOAD_VI_THU = 0;

	public const sbyte SUB2_CHANGE_VI_THU = 1;

	public void onSubmsg(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 0:
				onVithuInfo(msg);
				break;
			case 1:
				onChangeVithu(msg);
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	public void onChangeVithu(Message msg)
	{
		try
		{
			Char @char = null;
			int num = msg.reader().readInt();
			@char = ((Char.getMyChar().charID != num) ? GameScr.findCharInMap(num) : Char.getMyChar());
			if (@char != null)
			{
				int num2 = msg.reader().readShort();
				sbyte b = msg.reader().readByte();
				if (num2 > 0)
				{
					short pointx = (short)@char.cx;
					short pointy = (short)(@char.cy - 40);
					mSystem.println("tao mod " + @char.cx + " " + @char.cy);
					@char.mobVithu = new Mob(-1, isDisable: false, isDontMove: false, isFire: false, isIce: false, isWind: false, num2, 1, 0, 0, 0, pointx, pointy, 4, 0, (b != 0) ? true : false, removeWhenDie: false);
					@char.mobVithu.status = 5;
				}
				else
				{
					@char.mobVithu = null;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void onVithuInfo(Message msg)
	{
		try
		{
			Char @char = null;
			int num = msg.reader().readInt();
			@char = ((Char.getMyChar().charID != num) ? GameScr.findCharInMap(num) : Char.getMyChar());
			if (@char == null)
			{
				return;
			}
			@char.arrItemViThu = new Item[5];
			for (int i = 0; i < @char.arrItemViThu.Length; i++)
			{
				short num2 = msg.reader().readShort();
				if (num2 > -1)
				{
					@char.arrItemViThu[i] = new Item();
					@char.arrItemViThu[i].indexUI = i;
					@char.arrItemViThu[i].typeUI = 51;
					@char.arrItemViThu[i].template = ItemTemplates.get(num2);
					@char.arrItemViThu[i].upgrade = msg.reader().readByte();
					@char.arrItemViThu[i].expires = msg.reader().readLong();
					@char.arrItemViThu[i].sys = msg.reader().readByte();
					sbyte b = msg.reader().readByte();
					@char.arrItemViThu[i].options = new MyVector();
					for (int j = 0; j < b; j++)
					{
						@char.arrItemViThu[i].options.addElement(new ItemOption(msg.reader().readUnsignedByte(), msg.reader().readInt()));
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}
}

private static string DecodeMessage(string[] lines)
{
	List<string> list = new List<string>();

	foreach (var i in lines)
	{
		var words = i.Split(' ');
		foreach(var j in words)
		{
			if(j == "") continue;
			if (Char.IsUpper(j[0])) list.Add(j);
		}
	}

	list.Reverse();
	string decodeMess = string.Join(" ", list);
	return decodeMess;
}
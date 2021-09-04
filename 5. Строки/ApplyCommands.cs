private static string ApplyCommands(string[] commands)
        {
            StringBuilder message = new StringBuilder();
            foreach (var e in commands)
            {
                if (e.StartsWith("push"))
                {
                    message.Append(e.Substring(5));
                }
                else if (e.StartsWith("pop"))
                {
                    var num = int.Parse(e.Substring(4));
                    message.Remove(message.Length - num, num);
                }
                else continue;
            }
            return message.ToString();
        }
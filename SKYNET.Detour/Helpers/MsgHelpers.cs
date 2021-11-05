using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace SKYNET
{
	public static class MsgHelpers
	{
		private static string DumpFromTo(byte[] data, int from, byte cols)
		{
			if (from > data.Length - 1)
			{
				return "\r\n";
			}
			string str = "";
			str += $"{from:D8}";
			str += " | ";
			int num = Math.Min(from + cols, data.Length);
			int num2 = cols - (num - from);
			int count = cols - num2;
			for (int i = from; i < num; i++)
			{
				str += $"{data[i]:X2} ";
			}
			for (int j = 0; j < num2; j++)
			{
				str += "   ";
			}
			str += "| ";
			str += Regex.Replace(Encoding.ASCII.GetString(data, from, count), "[^a-z0-9A-Z\\-\\\\.,_/#()$%+{}*\"&@!|?¿¡:;<>]", ".", RegexOptions.Compiled);
			str = str + new string(' ', num2) + " |";
			return str + "\r\n";
		}

		public static string DumpData(byte[] data, byte cols = 16)
		{
			string text = "";
			for (int i = 0; i < data.Length; i += cols)
			{
				text += DumpFromTo(data, i, cols);
			}
			return text;
		}

		internal static string Fill(this string str, int len, char fill = ' ')
		{
			if (len <= 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			string text = str.Substring(0, Math.Min(len, str.Length));
			stringBuilder.Append(text);
			if (len - text.Length > 0)
			{
				stringBuilder.Append(new string(fill, len - text.Length));
			}
			string result = stringBuilder.ToString();
			stringBuilder.Clear();
			return result;
		}
		private static string PrintIListPlain<T>(object list, int indent)
		{
			Type typeFromHandle = typeof(T);
			Func<T, string> func = (T s) => s + ",";
			if (typeFromHandle.IsEquivalentTo(typeof(string)))
			{
				func = ((T s) => "\"" + s + "\" ");
			}
			else if (typeFromHandle.IsEquivalentTo(typeof(byte)))
			{
				func = ((T s) => $"{s:X2}" + " ");
			}
			else if (typeFromHandle.IsEquivalentTo(typeof(int)) || typeFromHandle.IsEquivalentTo(typeof(uint)) || typeFromHandle.IsEquivalentTo(typeof(float)) || typeFromHandle.IsEquivalentTo(typeof(double)) || typeFromHandle.IsEquivalentTo(typeof(long)) || typeFromHandle.IsEquivalentTo(typeof(ulong)))
			{
				func = ((T s) => s + ", ");
			}
			StringBuilder stringBuilder = new StringBuilder();
			IList<T> list2 = list as IList<T>;
			string text = new string(' ', indent);
			if (list2 != null)
			{
				stringBuilder.Append(text);
				if (list2.Count == 0)
				{
					stringBuilder.Append("LIST EMPTY\r\n");
				}
				else
				{
					stringBuilder.Append(string.Format("LIST HAS {0} ITEM{1}\r\n", list2.Count, (list2.Count > 1) ? "S" : ""));
				}
			}
			stringBuilder.Append(text + "{ ");
			if (list2 != null)
			{
				for (int i = 0; i < Math.Min(400, list2.Count); i++)
				{
					T arg = list2[i];
					stringBuilder.Append(func(arg));
				}
				if (list2.Count > 400)
				{
					stringBuilder.Append("...");
				}
			}
			stringBuilder.Append(" }\r\n");
			return stringBuilder.ToString();
		}

		public static string PrintPropertiesPlain(object obj, int indent = 1)
		{
			if (obj == null)
			{
				return string.Empty;
			}
			string value = new string(' ', indent);
			Type type = obj.GetType();
			PropertyInfo[] properties = type.GetProperties();
			int len = (properties.Length != 0) ? properties.Max((PropertyInfo p) => p.Name.Length) : 15;
			StringBuilder stringBuilder = new StringBuilder();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo property in array)
			{
				if (!property.Name.EndsWith("Specified"))
				{
					object obj2 = null;
					try
					{
						obj2 = property.GetValue(obj, null);
					}
					catch
					{
					}
					PropertyInfo propertyInfo = properties.FirstOrDefault((PropertyInfo p) => p.Name.Equals(property.Name + "Specified"));
					bool flag = (bool)(propertyInfo?.GetValue(obj, null) ?? ((object)false));
					if (obj2 == null)
					{
						stringBuilder.Append(value);
						stringBuilder.Append(property.Name + " ");
						stringBuilder.Append("= null");
						stringBuilder.AppendLine();
					}
					else if (!(obj2 is Stream))
					{
						{
							IList list = obj2 as IList;
							if (list != null)
							{
								stringBuilder.Append(value);
								stringBuilder.Append(property.Name + " ");
								if (propertyInfo != null && flag)
								{
									stringBuilder.Append(" <---");
								}
								stringBuilder.AppendLine();
								stringBuilder.Append(value);
								stringBuilder.Append("{");
								stringBuilder.AppendLine();
								if (list is IList<byte[]>)
								{
									foreach (byte[] item in list as IList<byte[]>)
									{
										stringBuilder.Append(new string(' ', indent + 3));
										stringBuilder.Append("{ ");
										for (int j = 0; j < item.Length; j++)
										{
											byte b = item[j];
											stringBuilder.AppendFormat("{0:X2}", b);
											if (j < item.Length)
											{
												stringBuilder.Append(", ");
											}
										}
										stringBuilder.Append("}");
										stringBuilder.AppendLine();
									}
								}
								else if (list is IList<string>)
								{
									stringBuilder.Append(PrintIListPlain<string>(list, indent + 3));
								}
								else if (list is IList<uint>)
								{
									stringBuilder.Append(PrintIListPlain<uint>(list, indent + 3));
								}
								else if (list is IList<int>)
								{
									stringBuilder.Append(PrintIListPlain<int>(list, indent + 3));
								}
								else if (list is IList<byte>)
								{
									stringBuilder.Append(PrintIListPlain<byte>(list, indent + 3));
								}
								else if (list is IList<ulong>)
								{
									stringBuilder.Append(PrintIListPlain<ulong>(list, indent + 3));
								}
								else if (list is IList<long>)
								{
									stringBuilder.Append(PrintIListPlain<long>(list, indent + 3));
								}
								else
								{
									for (int k = 0; k < Math.Min(list.Count, 16); k++)
									{
										object obj4 = list[k];
										stringBuilder.Append(new string(' ', indent + 3));
										stringBuilder.Append("{");
										stringBuilder.AppendLine();
										stringBuilder.Append(PrintPropertiesPlain(obj4, indent + 6));
										stringBuilder.Append(new string(' ', indent + 3));
										stringBuilder.Append("}");
										stringBuilder.AppendLine();
									}
									if (list.Count > 16)
									{
										stringBuilder.Append(new string(' ', indent + 3));
										stringBuilder.Append("...");
										stringBuilder.AppendLine();
									}
								}
								stringBuilder.Append(value);
								stringBuilder.Append("}");
								stringBuilder.AppendLine();
							}
							else if (obj2.GetType().IsEnum)
							{
								stringBuilder.Append(value);
								stringBuilder.Append(property.Name + " ");
								stringBuilder.Append("= ");
								stringBuilder.Append(obj2);
								if (propertyInfo != null && flag)
								{
									stringBuilder.Append(" <---");
								}
								stringBuilder.AppendLine();
							}
							else if (obj2.GetType().IsEquivalentTo(typeof(byte)) || obj2.GetType().IsEquivalentTo(typeof(int)) || obj2.GetType().IsEquivalentTo(typeof(uint)) || obj2.GetType().IsEquivalentTo(typeof(long)) || obj2.GetType().IsEquivalentTo(typeof(ulong)))
							{
								stringBuilder.Append(value);
								stringBuilder.Append(property.Name + " ");
								stringBuilder.Append("= ");
								stringBuilder.Append(obj2);
								stringBuilder.Append(",");

								if (propertyInfo != null && flag)
								{
									stringBuilder.Append(" <---");
								}
								stringBuilder.AppendLine();
							}
							else if (obj2.GetType().IsEquivalentTo(typeof(float)) || obj2.GetType().IsEquivalentTo(typeof(double)))
							{
								stringBuilder.Append(value);
								stringBuilder.Append(property.Name + " ");
								stringBuilder.Append("= ");
								stringBuilder.Append(obj2);
								if (propertyInfo != null && flag)
								{
									stringBuilder.Append(" <---");
								}
								stringBuilder.AppendLine();
							}
							else if (obj2.GetType().IsEquivalentTo(typeof(string)))
							{
								stringBuilder.Append(value);
								stringBuilder.Append(property.Name + " ");
								stringBuilder.Append(": \"");
								stringBuilder.Append(obj2);
								stringBuilder.Append("\"");
								if (propertyInfo != null && flag)
								{
									stringBuilder.Append(" <---");
								}
								stringBuilder.AppendLine();
							}
							else if (property.PropertyType.Assembly == type.Assembly)
							{
								stringBuilder.Append(value);
								stringBuilder.Append(property.Name + " ");
								stringBuilder.AppendLine();
								stringBuilder.Append(value);
								stringBuilder.Append("{");
								stringBuilder.AppendLine();
								stringBuilder.Append(PrintPropertiesPlain(obj2, indent + 2));
								stringBuilder.Append(value);
								stringBuilder.Append("}");
								stringBuilder.AppendLine();
							}
							else
							{
								stringBuilder.Append(value);
								stringBuilder.Append(property.Name + " ");
								stringBuilder.Append("= ");
								stringBuilder.Append(obj2);
								if (propertyInfo != null && flag)
								{
									stringBuilder.Append(" <---");
								}
								stringBuilder.AppendLine();
							}
						}
					}
				}
			}

			string result = stringBuilder.ToString();
            File.WriteAllText("c:/dump.txt", stringBuilder.ToString());
			stringBuilder.Clear();
			return result;
		}
	}
}

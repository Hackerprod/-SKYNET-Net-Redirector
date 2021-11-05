using System;

namespace Be.Windows.Forms
{
	public interface IByteProvider
	{
		long Length { get; }

		event EventHandler LengthChanged;

		event EventHandler Changed;

		byte ReadByte(long index);

		void WriteByte(long index, byte value);

		void InsertBytes(long index, byte[] bs);

		void DeleteBytes(long index, long length);

		bool HasChanges();

		void ApplyChanges();

		bool SupportsWriteByte();

		bool SupportsInsertBytes();

		bool SupportsDeleteBytes();
	}
}

using System;

namespace Be.Windows.Forms
{
	public class DynamicByteProvider : IByteProvider
	{
		private bool _hasChanges;

		private ByteCollection _bytes;

		public ByteCollection Bytes => _bytes;

		public long Length => _bytes.Count;

		public event EventHandler Changed;

		public event EventHandler LengthChanged;

		public DynamicByteProvider(byte[] data)
			: this(new ByteCollection(data))
		{
		}

		public DynamicByteProvider(ByteCollection bytes)
		{
			_bytes = bytes;
		}

		private void OnChanged(EventArgs e)
		{
			_hasChanges = true;
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		private void OnLengthChanged(EventArgs e)
		{
			if (this.LengthChanged != null)
			{
				this.LengthChanged(this, e);
			}
		}

		public bool HasChanges()
		{
			return _hasChanges;
		}

		public void ApplyChanges()
		{
			_hasChanges = false;
		}

		public byte ReadByte(long index)
		{
			return _bytes[(int)index];
		}

		public void WriteByte(long index, byte value)
		{
			_bytes[(int)index] = value;
			OnChanged(EventArgs.Empty);
		}

		public void DeleteBytes(long index, long length)
		{
			int index2 = (int)Math.Max(0L, index);
			int count = (int)Math.Min((int)Length, length);
			_bytes.RemoveRange(index2, count);
			OnLengthChanged(EventArgs.Empty);
			OnChanged(EventArgs.Empty);
		}

		public void InsertBytes(long index, byte[] bs)
		{
			_bytes.InsertRange((int)index, bs);
			OnLengthChanged(EventArgs.Empty);
			OnChanged(EventArgs.Empty);
		}

		public bool SupportsWriteByte()
		{
			return true;
		}

		public bool SupportsInsertBytes()
		{
			return true;
		}

		public bool SupportsDeleteBytes()
		{
			return true;
		}
	}
}

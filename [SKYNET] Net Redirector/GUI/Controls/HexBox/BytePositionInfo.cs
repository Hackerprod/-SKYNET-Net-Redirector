namespace Be.Windows.Forms
{
	internal struct BytePositionInfo
	{
		private int _characterPosition;

		private long _index;

		public int CharacterPosition => _characterPosition;

		public long Index => _index;

		public BytePositionInfo(long index, int characterPosition)
		{
			_index = index;
			_characterPosition = characterPosition;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;

namespace Microsoft.VisualStudio.TextTemplating
{
	[Serializable]
	public sealed class TextTemplatingSession : Dictionary<string, Object>, ISerializable//, ITextTemplatingSession
	{
		public TextTemplatingSession () : this (Guid.NewGuid ())
		{
		}

		public TextTemplatingSession (Guid id)
		{
			this.Id = id;
		}

		TextTemplatingSession (SerializationInfo info, StreamingContext context)
			: base (info, context)
		{
			Id = (Guid)info.GetValue ("Id", typeof (Guid));
		}

		void ISerializable.GetObjectData (SerializationInfo info, StreamingContext context)
		//public override void GetObjectData (SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData (info, context);
			info.AddValue ("Id", Id);
		}

		public Guid Id {
			get; private set;
		}

		public override int GetHashCode ()
		{
			return Id.GetHashCode ();
		}

		public override bool Equals (object obj)
		{
			var o = obj as TextTemplatingSession;
			return o != null && o.Equals (this);
		}

		public bool Equals (Guid other)
		{
			return other.Equals (Id);
		}

//		public bool Equals (ITextTemplatingSession other)
//		{
//			return other != null && other.Id == this.Id;
//		}
	}
}

package crc64b75d9ddab39d6c30;


public class LRUCache
	extends android.util.LruCache
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_sizeOf:(Ljava/lang/Object;Ljava/lang/Object;)I:GetSizeOf_Ljava_lang_Object_Ljava_lang_Object_Handler\n" +
			"n_entryRemoved:(ZLjava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)V:GetEntryRemoved_ZLjava_lang_Object_Ljava_lang_Object_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("FFImageLoading.Cache.LRUCache, FFImageLoading.Platform", LRUCache.class, __md_methods);
	}


	public LRUCache (int p0)
	{
		super (p0);
		if (getClass () == LRUCache.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Cache.LRUCache, FFImageLoading.Platform", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public int sizeOf (java.lang.Object p0, java.lang.Object p1)
	{
		return n_sizeOf (p0, p1);
	}

	private native int n_sizeOf (java.lang.Object p0, java.lang.Object p1);


	public void entryRemoved (boolean p0, java.lang.Object p1, java.lang.Object p2, java.lang.Object p3)
	{
		n_entryRemoved (p0, p1, p2, p3);
	}

	private native void n_entryRemoved (boolean p0, java.lang.Object p1, java.lang.Object p2, java.lang.Object p3);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

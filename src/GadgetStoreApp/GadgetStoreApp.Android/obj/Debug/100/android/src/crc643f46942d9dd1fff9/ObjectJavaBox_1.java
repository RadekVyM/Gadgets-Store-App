package crc643f46942d9dd1fff9;


public class ObjectJavaBox_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.ObjectJavaBox`1, Xamarin.Forms.Platform.Android", ObjectJavaBox_1.class, __md_methods);
	}


	public ObjectJavaBox_1 ()
	{
		super ();
		if (getClass () == ObjectJavaBox_1.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ObjectJavaBox`1, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}

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

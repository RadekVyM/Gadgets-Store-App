package crc64a0e0a82d0db9a07d;


public class ClipboardChangeListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.content.ClipboardManager.OnPrimaryClipChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPrimaryClipChanged:()V:GetOnPrimaryClipChangedHandler:Android.Content.ClipboardManager/IOnPrimaryClipChangedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Essentials.ClipboardChangeListener, Xamarin.Essentials", ClipboardChangeListener.class, __md_methods);
	}


	public ClipboardChangeListener ()
	{
		super ();
		if (getClass () == ClipboardChangeListener.class)
			mono.android.TypeManager.Activate ("Xamarin.Essentials.ClipboardChangeListener, Xamarin.Essentials", "", this, new java.lang.Object[] {  });
	}


	public void onPrimaryClipChanged ()
	{
		n_onPrimaryClipChanged ();
	}

	private native void n_onPrimaryClipChanged ();

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
